using Site_MVC_FinTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site_MVC_FinTech.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            var produto = Repositorio.ListarProdutos();

            return View(produto);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Cadastrar(Produto pd)
        {
            bool enviamensagem = Repositorio.InserirProduto(pd);

            if (enviamensagem)
                ViewBag.Mensagem = "Cadastrado com sucesso";

            return View();
        }

        [Authorize]
        public ActionResult Listar()
        {
            var produto = Repositorio.ListarProdutos();

            return View(produto);
        }

        [Authorize]
        public ActionResult ExcluirProduto(int id)
        {
            Repositorio.ExcluirProduto(id);

            return RedirectToAction("Listar");
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditarProduto(int id)
        {
            var produto = Repositorio.ListarProduto(id);

            return View("Cadastrar", produto);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditarProduto(Produto pd)
        {
            Repositorio.AlterarProduto(pd);

            return RedirectToAction("Listar");
        }
    }
}