using Site_MVC_FinTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            Repositorio.InserirPessoa(p);

            return RedirectToAction("Listar");
        }

        public ActionResult Listar()
        {
            var pessoa = Repositorio.ListarPessoas();

            return View(pessoa);
        }

        public ActionResult ExcluirPessoa(int id)
        {
            Repositorio.ExcluirPessoa(id);

            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult EditarPessoa(int id)
        {
            var pessoa = Repositorio.ListarPessoa(id);

            return View("Cadastrar", pessoa);
        }

        [HttpPost]
        public ActionResult EditarPessoa(Pessoa p)
        {
            Repositorio.AlterarPessoa(p);

            return RedirectToAction("ListarPessoa");
        }

        [HttpGet]
<<<<<<< HEAD
        public ViewContext Login(string usuario, string senha)
        {
            Pessoa user = Repositorio.FindById(usuario, senha);
            if(user.IDPessoa != null)
            {
                TempData["mensagem"] = "Usuario logado com sucesso!";
                return Redirect("\arearestrita");
=======
        public ActionResult Login(string usuario, string senha)
        {
            Pessoa user = Repositorio.FindById(usuario, senha);
            if (user.IDPessoa > 0)
            {
                TempData["mensagem"] = "Usuario logado com sucesso!";

                return RedirectToAction("/AreaRestrita/Index");
>>>>>>> teste
            }
            else
            {
                TempData["mensagem"] = "Usuario não encontrado!";
            }

<<<<<<< HEAD
            
=======
            return View();
>>>>>>> teste
        }
    }
}