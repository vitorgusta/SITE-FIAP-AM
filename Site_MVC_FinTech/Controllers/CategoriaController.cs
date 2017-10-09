using Site_MVC_FinTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site_MVC_FinTech.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            var categoria = Repositorio.ListarCategorias();
            return View(categoria);
        }

        [HttpGet]
        public ActionResult CadastrarCategoria()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarCategoria(Categoria n)
        {
            Repositorio.InserirCategoria(n);

            return RedirectToAction("Listar");
        }

        //[Authorize]
        public ActionResult ListarCategoria()
        {
            var categoria = Repositorio.ListarCategorias();

            return View(categoria);
        }

        public ActionResult ExcluirCategoria(int id)
        {
            Repositorio.ExcluirCategorioa(id);

            return RedirectToAction("Listar");
        }

        public ActionResult EditarNoticia(int id)
        {
            var noticia = Repositorio.ListarNoticia(id);

            return View("Cadastrar", noticia);
        }

        [HttpPost]
        public ActionResult EditarCategoria(Categoria n)
        {
            Repositorio.AlterarCategoria(n);

            return RedirectToAction("Listar");
        }
    }

}