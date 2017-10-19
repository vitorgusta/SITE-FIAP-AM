using Site_MVC_FinTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Site_MVC_FinTech.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Pessoa p)
        {
            bool sucesso = Repositorio.InserirPessoa(p);

            if (sucesso)
                ViewBag.Mensagem = "Cliente cadastrado com sucesso";
            else
                ViewBag.Mensagem = "ERRO: Cliente (CPF), já cadastrado";

            return View();
        }

        [Authorize]
        public ActionResult Listar()
        {
            var pessoa = Repositorio.ListarPessoas();

            return View(pessoa);
        }

        [Authorize]
        public ActionResult ExcluirPessoa(int id)
        {
            Repositorio.ExcluirPessoa(id);

            return RedirectToAction("Listar");
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditarPessoa(int id)
        {
            var pessoa = Repositorio.ListarPessoa(id);

            return View("Cadastrar", pessoa);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditarPessoa(Pessoa p)
        {
            Repositorio.AlterarPessoa(p);

            return RedirectToAction("Listar");
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Pessoa model, string returnUrl)
        {
            var user = Repositorio.FindById(model.Usuario, model.Senha);
            
            if (user != null && user.Sta_Adm)
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                                          user.Usuario,
                                          DateTime.Now,
                                          DateTime.Now.AddMinutes(30),
                                          false,
                                          "User",
                                          FormsAuthentication.FormsCookiePath);

                string encTicket = FormsAuthentication.Encrypt(ticket);

                //cria o cookie
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
                FormsAuthentication.SetAuthCookie(user.Usuario, false);

                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("AreaRestrita", "Pessoa");
                }
            }

            this.ModelState.AddModelError("Usuario", "Login ou senha incorretos");
            return View(model);
        }

        [Authorize]
        public ActionResult AreaRestrita()
        {
            return View();
        }

        //PESQUISA

        [Authorize]
        [HttpGet]
        public ActionResult Pesquisar()
        {
            var pessoa = Repositorio.PesquisarPessoa();

            if (pessoa == null || ((List<Pessoa>)pessoa).Count == 0)
                ViewBag.Mensagem = "Nenhum cliente cadastrado";

            return View(pessoa);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Pesquisar(string texto, string combo)
        {
            var pessoa = Repositorio.PesquisarPessoa(texto, combo);

            if (pessoa == null || ((List<Pessoa>)pessoa).Count == 0)
                ViewBag.Mensagem = "Nenhum cliente encontrado";

            return View(pessoa);
        }

        // SAIR LOG-OUT

        [Authorize]
        public ActionResult Sair()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        
    }
}