// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using AsMinhasReviews.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using AsMinhasReviews.Models;

namespace AsMinhasReviews.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        /// <summary>
        /// Classe que representa o acesso à base de dados do sistema
        /// </summary>
        private readonly ApplicationDbContext _context;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        /// <summary>
        /// Atributo responsável pela recolha e envio de dados
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        /// Link para o qual o utilizador vai ser redirecionado depois de fazer o login
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// Estrutura do objeto que transporta os dados relativos à interface
        /// </summary>
        public class InputModel
        {
            /// <summary>
            /// Nome do utilizador
            /// </summary>
            [Required]
            [Display(Name = "Nome de utilizador")]
            public string UserName { get; set; }

            /// <summary>
            /// Email do utilizador
            /// </summary>
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            /// <summary>
            /// Palavra-passe do utilizador
            /// </summary>
            [Required]
            [StringLength(32, ErrorMessage = "A {0} deve ter entre {2} e {1} caractéres.", MinimumLength = 8)]
            [DataType(DataType.Password)]
            [Display(Name = "Palavra-passe")]
            public string Password { get; set; }

            /// <summary>
            /// Confirmação da palavra-passe do utilizador
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirmar palavra-passe")]
            [Compare("Password", ErrorMessage = "A palavra-passe não corresponde à palavra-passe de confirmação.")]
            public string ConfirmPassword { get; set; }

            /// <summary>
            /// Dados do utilizador que ficará associado à autenticação
            /// </summary>
            public Utilizadores Utilizador { get; set; }
        }

        /// <summary>
        /// Reage a um pedido feito em HTTP GET
        /// </summary>
        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        /// <summary>
        /// Reage a um pedido feito em HTTP POST
        /// </summary>
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = CreateUser();
                await _userStore.SetUserNameAsync(user, Input.UserName, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                user.EmailConfirmed = true;
                user.LockoutEnabled = true;
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    //Envio de mensagem a confirmar a criação da conta
                    _logger.LogInformation("Novo utilizador criado.");
                    //Associar o utilizador à role 'Utilizador'
                    await _userManager.AddToRoleAsync(user, "Utilizador");
                    //Guardar os dados do novo utilizador
                    Input.Utilizador.UserID = user.Id;
                    Input.Utilizador.Nome = Input.UserName; 
                    try
                    {
                        _context.Add(Input.Utilizador);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception)
                    {
                        //Se ocorrer algum erro, apagar o utilizador já criado
                        await _userManager.DeleteAsync(user);
                        //Mensagem de erro a ser enviada ao utilizador
                        ModelState.AddModelError("", "Ocorreu um erro com a criação do Utilizador");
                        //Devolver o controlo da app ao utilizador
                        return Page();
                    }
                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirme o seu email.",
                        $"Por favor confirme o seu email <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicando aqui.</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            //Se aqui chegámos, algo correu mal, mostra então o formulário de novo
            return Page();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}
