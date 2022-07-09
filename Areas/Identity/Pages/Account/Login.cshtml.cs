// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.ComponentModel.DataAnnotations;
using AsMinhasReviews.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AsMinhasReviews.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<ApplicationUser> signInManager, ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
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
        /// Mensagem de erro a ser mostrada ao utilizador
        /// </summary>
        [TempData]
        public string ErrorMessage { get; set; }

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
            /// Palavra-passe do utilizador
            /// </summary>
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Palavra-passe")]
            public string Password { get; set; }

            /// <summary>
            /// Indica se o utilizador quer que o seu nome de utilizador seja guardado para logins futuros
            /// </summary>
            [Display(Name = "Lembrar-me?")]
            public bool RememberMe { get; set; }
        }

        /// <summary>
        /// Reage a um pedido feito em HTTP GET
        /// </summary>
        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }
            returnUrl ??= Url.Content("~/");
            // Limpar os cookies externos existentes para garantir um processo de login limpo
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
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
                var result = await _signInManager.PasswordSignInAsync(Input.UserName, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    //Envio de mensagem a confirmar o login do utilizador
                    _logger.LogInformation("Login feito com sucesso.");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("Conta do utilizador bloqeuada");
                    return RedirectToPage("./Lockout");
                }
                //Se ocorrer algum erro...
                else
                {
                    //Mensagem de erro a ser enviada ao utilizador
                    ModelState.AddModelError(string.Empty, "Tentativa de login inválida.");
                    //Devolver o controlo da app ao utilizador
                    return Page();
                }
            }

            //Se aqui chegámos, algo correu mal, mostra então o formulário de novo
            return Page();
        }
    }
}
