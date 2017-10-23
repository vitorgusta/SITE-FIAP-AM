using Site_MVC_FinTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site_MVC_FinTech.Controllers
{
    public class ProdutoController : DefaultController
    {
        // GET: Produto
        public ActionResult Index()
        {
            var produto = Repositorio.ListarProdutos();
            var pacotes = Repositorio.ListarPacotes();
            var investidores = Repositorio.Listarinvestidores();

            foreach (var pacote in pacotes)
            {
                int qtdPct = 0;

                foreach (var inv in investidores.Where(iv => iv.pacote.IDPacote == pacote.IDPacote))
                {
                    qtdPct += inv.Quantidade;
                }
                
                pacote.QtdDisponivel = pacote.QtdTotal - qtdPct;
            }

            ViewBag.Pacotes = pacotes;

            return View(produto);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Cadastrar(Produto pd)
        {
            bool enviamensagem = Repositorio.InserirProduto(pd);

            if (enviamensagem)
                ViewBag.Mensagem = "Cadastrado com sucesso";

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Listar()
        {
            var produto = Repositorio.ListarProdutos();

            return View(produto);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ExcluirProduto(int id)
        {
            Repositorio.ExcluirProduto(id);

            return RedirectToAction("Listar");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult EditarProduto(int id)
        {
            var produto = Repositorio.ListarProduto(id);

            return View("Cadastrar", produto);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditarProduto(Produto pd)
        {
            Repositorio.AlterarProduto(pd);

            return RedirectToAction("Listar");
        }
    }
}