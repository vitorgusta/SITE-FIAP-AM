﻿using Site_MVC_FinTech.Models;
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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Cadastrar(Noticia n, HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null)
            {
                using (var ms = new MemoryStream())
                {
                    ImageFile.InputStream.CopyTo(ms);
                    n.Image = $"data:image/gif;base64,{Convert.ToBase64String(ms.ToArray())}";
                }
            }

            if (n.IDNoticia > 0)
            {
                Repositorio.AlterarNoticia(n);
            }
            else
            {
                n.DataMateria = DateTime.Now;
                Repositorio.InserirNoticia(n);
            }

            return RedirectToAction("Listar");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Listar()
        {
            var noticia = Repositorio.ListarNoticias();

            return View(noticia);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ExcluirNoticia(int id)
        {
            Repositorio.ExcluirNoticia(id);

            return RedirectToAction("Listar");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ExcluirFotoNoticia(int id)
        {
           Noticia not =  Repositorio.ListarNoticia(id);

            not.Image = null;

            Repositorio.AlterarNoticia(not);

            return View("Cadastrar", not);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditarNoticia(int id)
        {
            var noticia = Repositorio.ListarNoticia(id);

            return View("Cadastrar", noticia);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditarNoticia(Noticia n, HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null)
            {
                using (var ms = new MemoryStream())
                {
                    ImageFile.InputStream.CopyTo(ms);
                    n.Image = $"data:image/gif;base64,{Convert.ToBase64String(ms.ToArray())}";
                }
            }

            Repositorio.AlterarNoticia(n);

            return RedirectToAction("Listar");
        }
    }
}