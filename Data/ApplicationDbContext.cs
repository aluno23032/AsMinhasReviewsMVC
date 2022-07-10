using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AsMinhasReviews.Models;

namespace AsMinhasReviews.Data
{
    /// <summary>
    /// Classe com os dados particulares do utilizador registado
    /// </summary>
    public class ApplicationUser : IdentityUser { }

    /// <summary>
    /// Classe que funciona como a base de dados do nosso projeto
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Este método é executado imediatamente antes da criação do Modelo.
        /// É utilizado para adicionar as últimas instruções à criação do modelo
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Importa todo o comportamento do método, quando é definido na SuperClasse
            base.OnModelCreating(modelBuilder);
            // Criar os perfís de utilizador da aplicação
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "a", Name = "Administrador", NormalizedName = "ADMINISTRADOR" },
                new IdentityRole { Id = "u", Name = "Utilizador", NormalizedName = "UTILIZADOR" }
            );
            // Adicionar registos que serão adicionados às tabelas da BD
            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "1",
                    UserName = "admin123",
                    NormalizedUserName = "ADMIN123",
                    Email = "admin123@gmail.com",
                    NormalizedEmail = "ADMIN123@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "admin123"),
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser
                {
                    Id = "2",
                    UserName = "josesilva",
                    NormalizedUserName = "JOSESILVA",
                    Email = "josesilva12@gmail.com",
                    NormalizedEmail = "JOSESILVA12@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "josesilva123"),
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser
                {
                    Id = "3",
                    UserName = "joaotiago",
                    NormalizedUserName = "JOAOTIAGO",
                    Email = "joaotiago71@gmail.com",
                    NormalizedEmail = "JOAOTIAGO71@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "joaotiago123"),
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser
                {
                    Id = "4",
                    UserName = "ricardosantos",
                    NormalizedUserName = "RICARDOSANTOS",
                    Email = "ricardosantos55@gmail.com",
                    NormalizedEmail = "RICARDOSANTOS55@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "ricardosantos123"),
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser
                {
                    Id = "5",
                    UserName = "utilizador123",
                    NormalizedUserName = "UTILIZADOR123",
                    Email = "utilizador123@gmail.com",
                    NormalizedEmail = "UTILIZADOR123@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "utilizador123"),
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "a",
                    UserId = "1"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "u",
                    UserId = "2"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "u",
                    UserId = "3"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "u",
                    UserId = "4"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "u",
                    UserId = "5"
                }
            );

            modelBuilder.Entity<Utilizadores>().HasData(
                new Utilizadores()
                {
                    Id = 1,
                    Nome = "admin123",
                    DataNascimento = new DateTime(2012, 12, 25),
                    UserID = "1"
                },
                new Utilizadores()
                {
                    Id = 2,
                    Nome = "josesilva",
                    DataNascimento = new DateTime(2012, 12, 25),
                    UserID = "2"
                },
                new Utilizadores()
                {
                    Id = 3,
                    Nome = "joaotiago",
                    DataNascimento = new DateTime(2004, 10, 12),
                    UserID = "3"
                },
                new Utilizadores()
                {
                    Id = 4,
                    Nome = "ricardosantos",
                    DataNascimento = new DateTime(2007, 1, 9),
                    UserID = "4"
                },
                new Utilizadores()
                {
                    Id = 5,
                    Nome = "utilizador123",
                    DataNascimento = new DateTime(2006, 5, 12),
                    UserID = "5"
                }
               );

            modelBuilder.Entity<Jogos>().HasData(
               new Jogos
               {
                   Id = 1,
                   Nome = "The Witcher 3: Wild Hunt",
                   NomeFormatado = "thewitcher3wildhunt",
                   Capa = "TheWitcher3WildHunt.jpg",
                   Plataformas = "PC, PlayStation4, XboxOne, Nintendo Switch",
                   Rating = 10,
                   DataLancamento = new DateTime(2015, 4, 18),
                   Descricao = "Geralt de Rivia, membro de uma casta em vias de extinção de caçadores de monstros, embarca em uma jornada épica por um mundo devastado pela guerra " +
                   "em The Witcher 3: Wild Hunt - uma aventura que levará você ao inevitável confronto com um inimigo mais sinistro do que a espécie humana jamais enfrentou até hoje. " +
                   "Áspero e impiedoso, o mundo onde se desenrola sua jornada é gigantesco, com um ecossistema complexo e uma não linearidade repleta de significado.",
               },
               new Jogos
               {
                   Id = 2,
                   Nome = "Rocket League",
                   NomeFormatado = "rocketleague",
                   Capa = "rocketleague.png",
                   Plataformas = "PC, PlayStation4, XboxOne, MacOS, Linux, Nintendo Switch",
                   Rating = 9,
                   DataLancamento = new DateTime(2015, 7, 5),
                   Descricao = "Compita neste híbrido radical de futebol estilo arcade e destruição automotiva! Personalize seu carro, entre em campo e compita em um dos jogos esportivos" +
                   " mais aclamados pela crítica de todos os tempos! Baixe e prepare o seu chute!",
               },
               new Jogos
               {
                   Id = 3,
                   Nome = "Uncharted 3: Drake's Deception",
                   NomeFormatado = "uncharted3drake'sdeception",
                   Capa = "Uncharted3.jpg",
                   Plataformas = "PlayStation",
                   Rating = (10m + 10m + 9m) / 3,
                   DataLancamento = new DateTime(2011, 11, 1),
                   Descricao = "Nathan Drake parte numa missão em busca da famosa Atlantis of the Sands na PlayStation 3.Nathan Drake pode agora defrontar os seus inimigos de mais formas do que dantes: " +
                   "combate mano-a - mano com vários adversários, ataques de proximidade com base no contexto e novas opções de acção sub-reptícia.o.",
               },
               new Jogos
               {
                   Id = 4,
                   Nome = "God Of War",
                   NomeFormatado = "godofwar",
                   Capa = "GodofWar2018.jpg",
                   Plataformas = "PC, PlayStation, XboxOne",
                   Rating = (10m + 10m + 9m)/3,
                   DataLancamento = new DateTime(2018, 4, 20),
                   Descricao = "Baseada em distintas mitologias, a história segue Kratos, um guerreiro espartano que foi levado a matar sua família por seu antigo mestre, o deus da guerra Ares. Isso desencadeia " +
                   "uma série de eventos que levam à guerras com os panteões mitológicos.",
               },
               new Jogos
               {
                   Id = 5,
                   Nome = "Call of Duty: Modern Warfare",
                   NomeFormatado = "callofdutymodernwarfare",
                   Capa = "CallofDutyModernWarfare.jpg",
                   Plataformas = "PC, PlayStation",
                   Rating = (8m + 8m + 9m) / 3,
                   DataLancamento = new DateTime(2019, 10, 25),
                   Descricao = "Prepare-se para entrar em ação, Modern Warfare está de volta!As apostas nunca foram tão altas,agora que os jogadores assumem o papel de operadores letais de alto nível em uma saga que vai " +
                   "afetar o equilíbrio global de poder.Desenvolvido pelo estúdio que começou tudo,Infinity Ward oferece uma releitura épica da icônica série Modern Warfare a partir do zero.",
               },
               new Jogos
               {
                   Id = 6,
                   Nome = "Undertale",
                   NomeFormatado = "undertale",
                   Capa = "Undertale.jpg",
                   Plataformas = "PC, PlayStation4, XboxOne, Nintendo Switch, Vita",
                   Rating = (10m + 10m + 9m) / 3,
                   DataLancamento = new DateTime(2015, 7, 15),
                   Descricao = "Entre no submundo e explore um mundo hilário e emocionante cheio de monstros perigosos. Namore com um esqueleto, dance com um robô, cozinhe com uma mulher-peixe... ou destrua todos onde eles estiverem." +
                   " O futuro é seu para determinar!",
               },
               new Jogos
               {
                   Id = 7,
                   Nome = "Mad Max",
                   NomeFormatado = "madmax",
                   Capa = "MadMax.jpg",
                   Plataformas = "PC, PlayStation4, XboxOne",
                   Rating = (8m + 7m + 8m) / 3,
                   DataLancamento = new DateTime(2015, 7, 1),
                   Descricao = "Mad Max coloca os jogadores no papel de um guerreiro solitário que deve embarcar numa jornada para recuperar o seu intercetor roubado de uma gangue mortal de saqueadores.",
               },
               new Jogos
               {
                   Id = 8,
                   Nome = "Tom Clancy's Rainbow Six Siege",
                   NomeFormatado = "tomclancy'srainbowsixsiege",
                   Capa = "R6.png",
                   Plataformas = "PlayStation4, PlayStation5, PC, Stadia, XboxOne, Xbox Series X",
                   Rating = (8m + 7m + 8m) / 3,
                   DataLancamento = new DateTime(2015, 12, 1),
                   Descricao = "Tom Clancy's Rainbow Six Siege é inspirado em organizações antiterroristas do mundo real e insere os jogadores no meio de combates letais de curta distância. Pela primeira vez em" +
                   " um jogo de Tom Clancy's Rainbow Six, os jogadores podem escolher entre uma variedade de agentes antiterroristas exclusivos e se envolver em cercos tangíveis, um novo estilo de ataque no qual os " +
                   "inimigos têm os meios para transformar seus ambientes em fortalezas modernas enquanto Rainbow Six equipes lideram o ataque para romper a posição do inimigo.",
               },
               new Jogos
               {
                   Id = 9,
                   Nome = "Infamous 2",
                   NomeFormatado = "infamous2",
                   Capa = "Inf2.jpg",
                   Plataformas = "PlayStation3 ",
                   Rating = (10m + 9m + 9m) / 3,
                   DataLancamento = new DateTime(2011, 6, 7),
                   Descricao = "Culpado pela destruição de Empire City e assombrado pelos fantasmas de seu passado, o herói relutante Cole MacGrath faz uma jornada dramática para a histórica cidade sulista de New Marais " +
                   "em um esforço para descobrir todo o seu potencial superpoderoso - e enfrentar uma civilização. terminando o confronto com um inimigo sombrio e aterrorizante de seu próprio futuro. Dotado de extraordinárias " +
                   "habilidades divinas, Cole sozinho tem o poder de salvar a humanidade, mas a questão é: ele escolherá fazê-lo?",
               },
               new Jogos
               {
                   Id = 10,
                   Nome = "Grand Theft Auto V",
                   NomeFormatado = "grandtheftautov",
                   Capa = "GTAV.jpg",
                   Plataformas = "PlayStation3, PlayStation4, PlayStation5, PC, Stadia, XboxOne, Xbox Series X",
                   Rating = (10m + 10m + 9m) / 3,
                   DataLancamento = new DateTime(2014, 11, 18),
                   Descricao = "O jogo se passa no estado ficcional de San Andreas, com a história da campanha um jogador seguindo três criminosos e seus esforços para realizarem assaltos sob a pressão de uma agência governamental." +
                   " O mundo aberto permite que os jogadores naveguem livremente pelas áreas rurais e urbanas de San Andreas.",
               },
               new Jogos
               {
                   Id = 11,
                   Nome = "Grand Theft Auto IV",
                   NomeFormatado = "grandtheftautoiv",
                   Capa = "GTAIV.jpg",
                   Plataformas = "PC, PlayStation3, XboxOne",
                   Rating = (10m + 10m + 9m) / 3,
                   DataLancamento = new DateTime(2008, 4, 29),
                   Descricao = "O que significa o sonho americano hoje? Para Niko Belic, recém-saído do barco da Europa. É a esperança de que ele possa escapar de seu passado. Para seu primo, Roman, é a visão de que juntos eles podem " +
                     "encontrar fortuna em Liberty City, porta de entrada para a terra das oportunidades. À medida que se endividam e são arrastados para um submundo do crime por uma série de vigaristas, ladrões e sociopatas, eles descobrem " +
                     "que a realidade é muito diferente do sonho em uma cidade que adora dinheiro e status, e é o paraíso para quem os tem. um pesadelo vivo para aqueles que não o fazem.",
               },
               new Jogos
               {
                   Id = 12,
                   Nome = "The Witcher 2: Assassins of Kings",
                   NomeFormatado = "thewitcher2assassinsofkings",
                   Capa = "Witcher2.jpg",
                   Plataformas = "PC, PlayStation3, Xbox360",
                   Rating = 10,
                   DataLancamento = new DateTime(2011, 5, 17),
                   Descricao = "The Witcher 2 é a sequência do jogo de RPG de fantasia o do desenvolvedor CD Projekt",
               },
               new Jogos
               {
                   Id = 13,
                   Nome = "Cyberpunk 2077",
                   NomeFormatado = "cyberpunk2077",
                   Capa = "2077.jpg",
                   Plataformas = "PlayStation5, PlayStation4, PC, XboxOne, Xbox Series X",
                   Rating = (7m + 9m + 9m) / 3,
                   DataLancamento = new DateTime(2020, 12, 10),
                   Descricao = "Cyberpunk 2077 é uma história de ação e aventura de mundo aberto ambientada em Night City, uma megalópole obcecada por poder, glamour e modificação corporal. Assuma o papel de V, um fora-da-lei mercenário que " +
                   "busca um implante único que é a chave para a imortalidade. Você pode personalizar o cyberware, o conjunto de habilidades e o estilo de jogo do seu personagem e explorar uma vasta cidade onde as escolhas que você faz moldam a" +
                   " história e o mundo ao seu redor. Torne-se um cyberpunk, um mercenário urbano equipado com aprimoramentos cibernéticos e construa sua lenda nas ruas de Night City. Aceite o trabalho mais arriscado de sua vida e vá atrás de um " +
                   "implante protótipo que é a chave para a imortalidade.",

               },
               new Jogos
               {
                   Id = 14,
                   Nome = "The Sims 4",
                   NomeFormatado = "thesims4",
                   Capa = "Sims4.jpg",
                   Plataformas = "PC, PlayStation, XboxOne",
                   Rating = (7m + 7m + 8m) / 3,
                   DataLancamento = new DateTime(2017, 11, 17),
                   Descricao = "The Sims 4 é o jogo de simulação de vida altamente antecipado que permite que você jogue com a vida como nunca antes. Crie novos Sims com inteligência e emoção. Experimente todas as novas ferramentas criativas intuitivas e " +
                   "divertidas para esculpir seus Sims e construir casas únicas. Controle a mente, o corpo e o coração dos seus Sims e dê vida às suas histórias.",
               },
               new Jogos
               {
                   Id = 15,
                   Nome = "Borderlands 2",
                   NomeFormatado = "borderlands2",
                   Capa = "Bd2.jpg",
                   Plataformas = "PC, PlayStation3, Xbox360, XboxOne, Vita",
                   Rating = 9,
                   DataLancamento = new DateTime(2012, 7, 17),
                   Descricao = "Borderlands 2 é a sequência do aclamado título da Gearbox lançado em 2009. Desta vez, os jogadores poderão desbravar o mundo de Pandora com muito mais respostas, pois os acontecimentos das missões e do próprio enredo estão diretamente " +
                   "ligados àquele universo, criando um contexto muito maior e mais coeso..",
               }
            ); ;

            modelBuilder.Entity<Reviews>().HasData(
                 new Reviews
                {
                 Id = 1,
                 DataCriacao = new DateTime(2022, 7, 5),
                 Conteudo = "O modelo atual de títulos de RPG e mundos abertos, The Witcher: Wild Hunt é um jogo para as idades; um mundo rico e envolvente cheio de decisões significativas e uma sensação de fantasia inteligente e épica. Inigualável.",
                 Rating = 10,
                 CriadorFK = 2,
                 JogoFK = 1
               },
               new Reviews
               {
                   Id = 2,
                   DataCriacao = new DateTime(2022, 6, 26),
                   Conteudo = "Rocket League transforma um conceito incrível e simples num jogo bem executado.",
                   Rating = 9,
                   CriadorFK = 2,
                   JogoFK = 2
               },
               new Reviews
               {
                     Id = 3,
                    DataCriacao = new DateTime(2022, 7, 6),
                    Conteudo = "É mais do que apenas a melhor entrada de uma série excelente - resume a razão pela qual muitos de nós jogamos jogos. E essa é a sua maior conquista.",
                    Rating = 10,
                    CriadorFK = 2,
                    JogoFK = 3
               },
               new Reviews
               {
                   Id = 4,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "O retorno do furioso guerreiro espartano foi bem feito. God of War já é um grande candidato a jogo do ano e não se pode perder.",
                   Rating = 10,
                   CriadorFK = 2,
                   JogoFK = 4
               },
               new Reviews
               {
                    Id = 5,
                    DataCriacao = new DateTime(2022, 7, 6),
                    Conteudo = "Call of Duty: Modern Warfare tem uma campanha excelente,e o multiplayer vai te deixar ansioso para jogar só mais um jogo de novo, e de novo.",
                    Rating = 8,
                    CriadorFK = 2,
                    JogoFK = 5
               },
               new Reviews
               {
                   Id = 6,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "Undertale é uma ótima experiência para quem procura algo fresco e cheio de conteúdo alternativo que dará vontade de jogar mais que uma vez.",
                   Rating = 9,
                   CriadorFK = 2,
                   JogoFK = 6
               },
               new Reviews
               {
                   Id = 7,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "A Avanlanche Studios conseguiu criar um mapa vasto com cenários lindíssimos que deliciam os fãs de Mad Max, mas depois esqueceu-se do resto.",
                   Rating = 7,
                   CriadorFK = 2,
                   JogoFK = 7
               },
               new Reviews
               {
                   Id = 8,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "Rainbow Six Siege transformou-se num jogo de tiros altamente competitivo e estratégico com uma variedade impressionante de operadores.",
                   Rating = 8,
                   CriadorFK = 2,
                   JogoFK = 8
               },
               new Reviews
               {
                   Id = 9,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "Se inFAMOUS já o era então a sequela consegue ser ainda mais um produto altamente recomendável para todos os que procuram diversão nesta indústria." +
                   " Simples e descomprometido mas com profundidade e estrutura para brilhar, inFAMOUS 2 é uma daquelas sequelas que faz muito mais de bem do que de mal. Mesmo dentro de " +
                   "um género popular é algo relativamente único e só é pena que alguns pontos se mostrem ligeiramente inferiores não permitindo um épico.",
                   Rating = 10,
                   CriadorFK = 2,
                   JogoFK = 9
                              },
               new Reviews
               {
                   Id = 10,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "Grand Theft Auto 5 não é perfeito, mas está tão avançado e é tão impressionante que facilmente é confundível com um jogo desenvolvido de raiz para a nova geração.",
                   Rating = 9,
                   CriadorFK = 2,
                   JogoFK = 10
               },
               new Reviews
               {
                   Id = 11,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "Grand Theft Auto IV é o primeiro verdadeiro jogo de nova geração a chegar à PlayStation 3, e vale bem o dinheiro pedido.",
                   Rating = 9,
                   CriadorFK = 2,
                   JogoFK = 11
               },
               new Reviews
               {
                   Id = 12,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "The Witcher 2 proporciona uma das experiências mais ricas que tive com um RPG nos últimos tempos, principalmente em termos de caracterização e storytelling.",
                   Rating = 10,
                   CriadorFK = 2,
                   JogoFK = 12
               },
               new Reviews
               {
                   Id = 13,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "É mais que um jogo, é uma cultura tornada videojogável, mas com falhas que o impedem de atingir um estatuto de obra-prima.",
                   Rating = 9,
                   CriadorFK = 2,
                   JogoFK = 13
               },
               new Reviews
               {
                   Id = 14,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "Recomendar The Sims 4 não é muito fácil, principalmente para os veteranos nestas andanças. Se é a primeira vez que colocam as mãos na série, vão ficar de certeza encantados, onde tudo é novidade e as surpresas estão em toda a parte.",
                   Rating = 7,
                   CriadorFK = 2,
                   JogoFK = 14
               },
               new Reviews
               {
                   Id = 15,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "Não há dúvidas que a Gearbox soube ouvir os fãs na criação desta merecida sequela. Borderlands 2 é gigante, intenso e viciante.",
                   Rating = 9,
                   CriadorFK = 2,
                   JogoFK = 15
               },
               new Reviews
               {
                     Id = 16,
                     DataCriacao = new DateTime(2022, 7, 5),
                     Conteudo = "Esta obra não só está brilhantemente caracterizada, como é uma lupa para o interior de Geralt, é mais do que uma filha adoptiva para ele, é o seu destino, desde que a conheceu, até aos tempos que passaram em Kaer Morhen.",
                     Rating = 10,
                     CriadorFK = 3,
                     JogoFK = 1
               },
               new Reviews
               {
                    Id = 17,
                    DataCriacao = new DateTime(2022, 6, 26),
                    Conteudo = "Rocket League tem tanto de louco como de prazeroso, depois de toda a minha relutância em aceder à insistência de amigos para experimentá-lo, não pensava encontrar aquele que até agora, é o melhor jogo de desporto do ano.",
                    Rating = 9,
                    CriadorFK = 3,
                    JogoFK = 2
               },

               new Reviews
               {
                   Id = 18,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "Com Uncharted 3: Drake's Deception a Naughty Dog volta a entregar uma aventura que toca nos padrões de qualidade alcançados em Uncharted 2, ultrapassando-os até em determinados momentos. Porém e para uma terceira fase de evolução esperava-se uma maior longevidade e até uma reinterpretação da estrutura do jogo",
                   Rating = 9,
                   CriadorFK = 3,
                   JogoFK = 3
               },
               new Reviews
               {
                   Id = 19,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "Uma viagem épica entre pai e filho pela mitologia nórdica que renova a identidade de God of War sem desrespeitar as suas origens.",
                   Rating = 10,
                   CriadorFK = 3,
                   JogoFK = 4
               },
               new Reviews
               {
                   Id = 20,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "Campanha, multiplayer e modo cooperativo formam um bloco coeso.Um regresso ao rumo cinzento,dramático e intenso das missões especiais.",
                   Rating = 8,
                   CriadorFK = 3,
                   JogoFK = 5
               },
               new Reviews
               {
                   Id = 21,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "A compreensão inteligente de Undertale sobre a mentalidade RPG e a escrita fantástica tornam uma experiência inesquecível única para os jogos",
                   Rating = 10,
                   CriadorFK = 3,
                   JogoFK = 6
               },
               new Reviews
               {
                   Id = 22,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "Mad Max acaba por ser deixado à merecê do deserto graças ao enorme sucesso de Metal Gear Solid V: The Phantom Pain, um desfecho infeliz para um jogo bem melhor que muitos outros de mundo aberto atualmente no mercado.",
                   Rating = 8,
                   CriadorFK = 3,
                   JogoFK = 7
               },
               new Reviews
               {
                   Id = 23,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "Não é fácil julgar um título tão elitista e particular como Rainbow Six Siege, um shooter que exige muita dedicação, coordenação e vontade por parte do jogador, num título que vive quase exclusivamente do multijogador.",
                   Rating = 7,
                   CriadorFK = 3,
                   JogoFK = 8
               },
               new Reviews
               {
                   Id = 24,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "Este é um jogo de ação em terceira pessoa sólido com uma história incrível, ótimos personagens, jogabilidade excelente.",
                   Rating = 9,
                   CriadorFK = 3,
                   JogoFK = 9
               },
               new Reviews
               {
                   Id = 25,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "Grand Theft Auto V não é apenas um jogo absurdamente agradável, mas também uma sátira inteligente e afiada da América contemporânea.",
                   Rating = 10,
                   CriadorFK = 3,
                   JogoFK = 10
               },
               new Reviews
               {
                   Id = 26,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "Tudo no GTA IV funciona em harmonia. A história não seria nada sem a cidade; a cidade ganha realismo com o motor da física; a física complementa a IA aprimorada; " +
                   "a IA não faria sentido sem o novo sistema de cobertura.E assim por diante",
                   Rating = 10,
                   CriadorFK = 3,
                   JogoFK = 11
               },
               new Reviews
               {
                   Id = 27,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "The Witcher 2 é um jogo ambicioso que não é apenas superficialmente “adulto”, mas genuinamente maduro.",
                   Rating = 10,
                   CriadorFK = 3,
                   JogoFK = 12
               },
               new Reviews
               {
                   Id = 28,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "Cyberpunk 2077 é um dos mais perturbadores e estonteantes RPGs da história, onde cada decisão tem impacto no nosso percurso. A CD Projekt RED atira-nos para o centro de uma cidade repleta de encantos repugnantes, onde cada personagem merece a nossa atenção, numa experiência imersiva e bastante recompensadora.",
                   Rating = 9,
                   CriadorFK = 3,
                   JogoFK = 13
               },
               new Reviews
               {
                   Id = 29,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "O jogo está destinado ao sucesso, mas para isso será preciso investimento nos previsíveis DLC que chegarão nos próximos tempos.",
                   Rating = 7,
                   CriadorFK = 3,
                   JogoFK = 14
               },
               new Reviews
               {
                   Id = 30,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "Borderlands 2 preserva as melhores partes da franquia ao mesmo tempo em que faz inúmeras e necessárias melhorias em áreas como narrativa e design de habilidades de classe.",
                   Rating = 9,
                   CriadorFK = 3,
                   JogoFK = 15
               },
               new Reviews
               {
                   Id = 31,
                   DataCriacao = new DateTime(2022, 7, 5),
                   Conteudo = "Jogos de interpretação de papéis não são melhores do que isso: The Witcher 3 é o melhor exemplo de um RPG.",
                   Rating = 10,
                   CriadorFK = 4,
                   JogoFK = 1
               },
               new Reviews
               {
                   Id = 32,
                   DataCriacao = new DateTime(2022, 6, 26),
                   Conteudo = "Rocket League é um jogo em constante mudança. Com uma ideia inovadora e uma nova jogabilidade, é um dos melhores jogos multijogadores.",
                   Rating = 9,
                   CriadorFK = 4,
                   JogoFK = 2
               },

               new Reviews
               {
                   Id = 33,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "Tenho apenas uma palavra para Uncharted 3 … fantástico. É um autêntico filme de aventura ao mais belo estilo de Indiana Jones em que, a todo o momento temos a sensação de estarmos bem dentro do filme. ",
                   Rating = 10,
                   CriadorFK = 4,
                   JogoFK = 3
               },
               new Reviews
               {
                   Id = 34,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "No geral esta é uma aventura que superou as expectativas. God of War é a experiência que reúne aquilo que se faz de melhor na indústria dos videojogos e apresenta-nos todos os factores com uma jogada de mestre.",
                   Rating = 9,
                   CriadorFK = 4,
                   JogoFK = 4
               },
               new Reviews
               {
                   Id = 35,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "Com Modern Warfare, a Infinity Ward carregou no botão de reset de uma das sub-séries mais importantes da história de Call of Duty, com o remake de um clássico que dá alguns dos saltos mais significantes a nível visual e de jogabilidade que a série já teve.",
                   Rating = 9,
                   CriadorFK = 4,
                   JogoFK = 5
               },
               new Reviews
               {
                   Id = 36,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "É uma experiência emocionalmente forte e uma grande estreia de Toby Fox. Todos os olhos estarão virados neste produtor para os próximos anos.",
                   Rating = 10,
                   CriadorFK = 4,
                   JogoFK = 6
               },
               new Reviews
               {
                   Id = 37,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "O jogo proporciona momentos de diversão e consegue ser bem fiel ao material presente nos longas-metragens. Mesmo com as atividades repetitivas, os sistemas de combate e a história de vingança conseguem prender o jogador por horas.",
                   Rating = 8,
                   CriadorFK = 4,
                   JogoFK = 7
               },
               new Reviews
               {
                   Id = 38,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "Em conclusão, esta entrada tem muitas semelhanças com outros FPS realistas contemporâneos, tais como a natureza das suas missões ou a ideia geral do jogo. Por outro lado, o título também consegue ser revolucionário, acrescentando elementos como a destruição ambiental ou personagens identificáveis por nomes e capacidades únicas.",
                   Rating = 8,
                   CriadorFK = 4,
                   JogoFK = 8
               },
               new Reviews
               {
                   Id = 39,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "InFamous 2 veio para fazer história, a começar pela excelente dobragem e os seus menus totalmente em português. Os gráficos melhoraram, e a possibilidade de criar missões aumenta a vida útil do jogo e agrada aqueles jogadores mais insaciáveis.",
                   Rating = 9,
                   CriadorFK = 4,
                   JogoFK = 9
               },
               new Reviews
               {
                   Id = 40,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "GTA 5 chega para assumir o importante posto de um dos melhores jogos da geração. Com historia de qualidade, jogabilidade afiada e divertida, gráficos impressionantes e opções variadas de diversão, como armas, carros e avioes , o jogo é praticamente incomparável nos quesitos conteúdo e qualidade.",
                   Rating = 10,
                   CriadorFK = 4,
                   JogoFK = 10
               },
               new Reviews
               {
                   Id = 41,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "GTA IV é um jogo com uma historia convincente e não linear, um jogo com um grande protagonista que você não pode deixar de gostar.",
                   Rating = 10,
                   CriadorFK = 4,
                   JogoFK = 11
               },
               new Reviews
               {
                   Id = 42,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "Se você ainda não jogou este brilhante RPG, dedique suas próximas trinta horas de jogo ao Witcher 2.Você não vai se arrepender.",
                   Rating = 10,
                   CriadorFK = 4,
                   JogoFK = 12
               },
               new Reviews
               {
                   Id = 43,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "Cyberpunk 2077, vale a pena ser jogado pelo seu enredo, pela sua trilha sonora e pelas reflexões que, mesmo sem querer, acaba levantando.",
                   Rating = 7,
                   CriadorFK = 4,
                   JogoFK = 13
               },
               new Reviews
               {
                   Id = 44,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "The Sims é um fenómeno ímpar de sucesso a nível mundial, com mais de 175 milhões de unidades vendidas até à data e mesmo assim continua a aumentar o seu portfólio multi plataforma com ofertas que inspiram a criatividade e alcançam uma das maiores audiências de videojogos.",
                   Rating = 8,
                   CriadorFK = 4,
                   JogoFK = 14
               },
               new Reviews
               {
                   Id = 45,
                   DataCriacao = new DateTime(2022, 7, 6),
                   Conteudo = "Borderlands 2 foi um dos grandes lançamentos do seu ano. O título combina jogabilidade online com a ação de um jogo de tiro em primeira pessoa e elementos de RPG.",
                   Rating = 9,
                   CriadorFK = 4,
                   JogoFK = 15
               }
            );
        }

        //Definir as tabelas
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Utilizadores> Utilizadores { get; set; }
        public DbSet<Jogos> Jogos { get; set; }
    }
}