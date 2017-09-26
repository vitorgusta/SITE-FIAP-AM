using Site_MVC_FinTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site_MVC_FinTech.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
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
        public ActionResult Cadastrar(Cliente c)
        {
            Repositorio.Instance().InserirClinete(c);

            return RedirectToAction("Listar");
        }

        public ActionResult Listar()
        {
            var cliente = Repositorio.Instance().ListarClientes();

            return View(cliente);
        }

        public ActionResult Excluir(int id)
        {
            Repositorio.Instance().ExcluirCliente(id);

            return RedirectToAction("Listar");
        }

        public ActionResult Editar(int id)
        {
            var cliente = Repositorio.Instance().ListarCliente(id);

            return View("Cadastrar", cliente);
        }

        [HttpPost]
        public ActionResult Editar(Cliente c)
        {
            Repositorio.Instance().AlterarCliente(c);

            return RedirectToAction("Listar");
        }
    }
}