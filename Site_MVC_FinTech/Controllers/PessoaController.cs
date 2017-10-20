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

        [Authorize(Roles = "Admin")]
        public ActionResult Listar()
        {
            var pessoa = Repositorio.ListarPessoas();

            return View(pessoa);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ExcluirPessoa(int id)
        {
            Repositorio.ExcluirPessoa(id);

            return RedirectToAction("Listar");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult EditarPessoa(int id)
        {
            var pessoa = Repositorio.ListarPessoa(id);

            return View("Cadastrar", pessoa);
        }

        [Authorize(Roles = "Admin")]
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
            if (returnUrl != null &&
                Request.IsAuthenticated &&
              FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData == "Investidor")
            {
                ViewBag.Mensagem = "Você Não tem permissão para acessar";
            }
            else
            {
                ViewBag.ReturnUrl = returnUrl;
            }
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Pessoa model, string returnUrl)
        {
            var user = Repositorio.FindById(model.Usuario, model.Senha);

            if (user != null)
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                                          user.Usuario,
                                          DateTime.Now,
                                          DateTime.Now.AddMinutes(30),
                                          false,
                                          user.Sta_Adm ? "Admin" : "Investidor",
                                          FormsAuthentication.FormsCookiePath);

                string encTicket = FormsAuthentication.Encrypt(ticket);

                //cria o cookie
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else if (user.Sta_Adm)
                    return RedirectToAction("AreaRestrita", "Pessoa");
                else
                    return RedirectToAction("AreaRestrita", "Investidor");
            }

            this.ModelState.AddModelError("Usuario", "Login ou senha incorretos");

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AreaRestrita()
        {
            return View();
        }

        //PESQUISA

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Pesquisar()
        {
            var pessoa = Repositorio.PesquisarPessoa();

            if (pessoa == null || ((List<Pessoa>)pessoa).Count == 0)
                ViewBag.Mensagem = "Nenhum cliente cadastrado";

            return View(pessoa);
        }

        [Authorize(Roles = "Admin")]
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
            return RedirectToAction("Index", "Produto");
        }

    }
}