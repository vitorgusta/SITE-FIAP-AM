using Site_MVC_FinTech.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site_MVC_FinTech.Controllers
{
    public class NoticiaController : Controller
    {
        //[AllowAnonymous]
        // GET: Noticia
        public ActionResult Index()
        {
            var noticia = Repositorio.ListarNoticias();

            return View(noticia);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Cadastrar(Noticia n, HttpPostedFileBase ImageFile)
        {
            using (var ms = new MemoryStream())
            {
                ImageFile.InputStream.CopyTo(ms);
                n.Image = ms.ToArray();
            }

            if (ModelState.IsValid)
            {
                Repositorio.InserirNoticia(n);
            }

            return RedirectToAction("Listar");
        }

        [Authorize]
        public ActionResult Listar()
        {
            var noticia = Repositorio.ListarNoticias();

            return View(noticia);
        }

        [Authorize]
        public ActionResult ExcluirNoticia(int id)
        {
            Repositorio.ExcluirNoticia(id);

            return RedirectToAction("Listar");
        }

        [Authorize]
        public ActionResult EditarNoticia(int id)
        {
            var noticia = Repositorio.ListarNoticia(id);

            return View("Cadastrar", noticia);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditarNoticia(Noticia n)
        {
            Repositorio.AlterarNoticia(n);

            return RedirectToAction("Listar");
        }
    }
}