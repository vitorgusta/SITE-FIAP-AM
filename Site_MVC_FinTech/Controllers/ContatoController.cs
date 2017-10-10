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
            bool enviamensagem = Repositorio.InserirContato(c);

            if (enviamensagem)
                ViewBag.Mensagem = "Mensagem enviada com sucesso. Aguarde e entraremos em contato";

            return View();
        }

        [Authorize]
        public ActionResult Listar()
        {
            var conntato = Repositorio.ListarContatos();

            return View(conntato);
        }

        [Authorize]
        public ActionResult ExcluirContato(int id)
        {
            Repositorio.ExcluirContato(id);

            return RedirectToAction("Listar");
        }

        [Authorize]
        public ActionResult EditarContato(int id)
        {
            var contato = Repositorio.ListarContato(id);

            return View("Cadastrar", contato);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditarContato(Contato c)
        {
            Repositorio.AlterarContato(c);

            return RedirectToAction("Listar");
        }
    }
}