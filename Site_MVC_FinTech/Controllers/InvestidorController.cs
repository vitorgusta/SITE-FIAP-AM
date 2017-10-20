using Site_MVC_FinTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site_MVC_FinTech.Controllers
{
    public class InvestidorController : Controller
    {
        // GET: Investidor
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Cadastrar(Pacote pct)
        {
            bool sucesso = Repositorio.InserirPacote(pct);

            if (sucesso)
                ViewBag.Mensagem = "Cliente cadastrado com sucesso";
            else
                ViewBag.Mensagem = "ERRO: Pacote já cadastrado";

            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Listar()
        {
            var pacote = Repositorio.ListarPacote();

            return View(pacote);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ExcluirPacote(int id)
        {
            Repositorio.ExcluirPacote(id);

            return RedirectToAction("Listar");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult EditarPacote(int id)
        {
            var pacote = Repositorio.ListarPacote(id);

            return View("Cadastrar", pacote);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditarPacote(Pacote pct)
        {
            Repositorio.AlterarPacote(pct);

            return RedirectToAction("Listar");
        }

        [Authorize(Roles = "Admin, Investidor")]
        public ActionResult AreaRestrita()
        {
            return View();
        }
    }
}