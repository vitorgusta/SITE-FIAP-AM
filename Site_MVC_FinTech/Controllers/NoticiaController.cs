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
        public ActionResult IndexNoticia()
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
            Repositorio.InserirNoticia(n);

            return RedirectToAction("ListarNoticia");
        }

        public ActionResult ListarNoticia()
        {
            var noticia = Repositorio.ListarNoticias();

            return View(noticia);
        }

        public ActionResult ExcluirNoticia(int id)
        {
            Repositorio.ExcluirNoticia(id);

            return RedirectToAction("ListarNoticia");
        }

        public ActionResult EditarNoticia(int id)
        {
            var noticia = Repositorio.ListarNoticia(id);

            return View("CadastrarNoticia", noticia);
        }

        [HttpPost]
        public ActionResult EditarNoticia(Noticia n)
        {
            Repositorio.AlterarNoticia(n);

            return RedirectToAction("ListarNoticia");
        }
    }
}