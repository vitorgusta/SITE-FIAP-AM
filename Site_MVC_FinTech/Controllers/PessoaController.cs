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
            Repositorio.Instance().InserirPessoa(p);

            return RedirectToAction("ListarPessoa");
        }

        public ActionResult ListarPessoa()
        {
            var pessoa = Repositorio.Instance().ListarPessoas();

            return View(pessoa);
        }

        public ActionResult ExcluirPessoa(int id)
        {
            Repositorio.Instance().ExcluirPessoa(id);

            return RedirectToAction("ListarPessoa");
        }

        public ActionResult EditarPessoa(int id)
        {
            var pessoa = Repositorio.Instance().ListarPessoa(id);

            return View("CadastrarPessoa", pessoa);
        }

        [HttpPost]
        public ActionResult EditarPessoa(Pessoa p)
        {
            Repositorio.Instance().AlterarPessoa(p);

            return RedirectToAction("ListarPessoa");
        }
    }
}