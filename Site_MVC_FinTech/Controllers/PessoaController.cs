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
        public ActionResult IndexPessoa()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CadastrarPessoa()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarPessoa(Pessoa p)
        {
            Repositorio.InserirPessoa(p);

            return RedirectToAction("ListarPessoa");
        }

        public ActionResult ListarPessoa()
        {
            var pessoa = Repositorio.ListarPessoas();

            return View(pessoa);
        }

        public ActionResult ExcluirPessoa(int id)
        {
            Repositorio.ExcluirPessoa(id);

            return RedirectToAction("ListarPessoa");
        }

        [HttpGet]
        public ActionResult EditarPessoa(int id)
        {
            var pessoa = Repositorio.ListarPessoa(id);

            return View("CadastrarPessoa", pessoa);
        }

        [HttpPost]
        public ActionResult EditarPessoa(Pessoa p)
        {
            Repositorio.AlterarPessoa(p);

            return RedirectToAction("ListarPessoa");
        }

        [HttpGet]
        public ViewContext Login(string usuario, string senha)
        {
            Pessoa user = Repositorio.FindById(usuario, senha);
            if(user.IDPessoa != null)
            {
                TempData["mensagem"] = "Usuario logado com sucesso!";
                return Redirect("\arearestrita");
            }
            else
            {
                TempData["mensagem"] = "Usuario não encontrado!";
            }

            
        }
    }
}