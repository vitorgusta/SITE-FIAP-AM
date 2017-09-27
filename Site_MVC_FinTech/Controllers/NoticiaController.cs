using Site_MVC_FinTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site_MVC_FinTech.Controllers
{
    public class NoticiaController : Controller
    {
        // GET: Noticia
        public ActionResult IndexListarNoticia()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CadastrarNoticia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarNoticia(Noticia n)
        {
            Repositorio.Instance().InserirNoticia(n);

            return RedirectToAction("IndexListarNoticia");
        }

        public ActionResult ListarNoticia()
        {
            var pessoa = Repositorio.Instance().ListarNoticias();

            return View(pessoa);
        }

        public ActionResult Excluir(int id)
        {
            Repositorio.Instance().ExcluirPessoa(id);

            return RedirectToAction("IndexListarNoticia");
        }

        public ActionResult Editar(int id)
        {
            var pessoa = Repositorio.Instance().ListarPessoa(id);

            return View("CadastrarNoticia", pessoa);
        }

        [HttpPost]
        public ActionResult Editar(Pessoa p)
        {
            Repositorio.Instance().AlterarPessoa(p);

            return RedirectToAction("IndexListarNoticia");
        }
    }
}