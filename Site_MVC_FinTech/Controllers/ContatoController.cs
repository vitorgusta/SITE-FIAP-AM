using Site_MVC_FinTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site_MVC_FinTech.Controllers
{
    public class ContatoController : Controller
    {
        // GET: Contato
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
        public ActionResult Cadastrar(Contato c)
        {
            Repositorio.InserirContato(c);

            return RedirectToAction("Listar");
        }

        public ActionResult Listar()
        {
            var conntato = Repositorio.ListarContatos();

            return View(conntato);
        }

        public ActionResult ExcluirContato(int id)
        {
            Repositorio.ExcluirContato(id);

            return RedirectToAction("Listar");
        }

        public ActionResult EditarContato(int id)
        {
            var contato = Repositorio.ListarContato(id);

            return View("Cadastrar", contato);
        }

        [HttpPost]
        public ActionResult EditarContato(Contato c)
        {
            Repositorio.AlterarContato(c);

            return RedirectToAction("Listar");
        }
    }
}