using Site_MVC_FinTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Site_MVC_FinTech.Controllers
{
    public class InvestidorController : DefaultController
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
                ViewBag.Mensagem = "Pacote cadastrado com sucesso";
            else
                ViewBag.Mensagem = "ERRO: Pacote já cadastrado";

            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Listar()
        {
            var pacote = Repositorio.ListarPacotes();

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
        [HttpGet]
        public ActionResult ConfirmaDados(int id)
        {
            Investidor invest = new Investidor();
            invest.pacote = Repositorio.ListarPacote(id);
            invest.pessoa = Repositorio.ListarPessoa(UserId);


            var investidores = Repositorio.Listarinvestidores();


            int qtdPct = 0;

            foreach (var inv in investidores.Where(iv => iv.pacote.IDPacote == invest.pacote.IDPacote))
            {
                qtdPct += inv.Quantidade;
            }

            invest.pacote.QtdDisponivel = invest.pacote.QtdTotal - qtdPct;

            return View(invest);
        }

        [Authorize(Roles = "Admin, Investidor")]
        [HttpPost]
        public ActionResult ConfirmaDados(Investidor model)
        {
            model.pessoa = Repositorio.ListarPessoa(UserId);
            model.pacote = Repositorio.ListarPacote(model.pacote.IDPacote);

            var investidores = Repositorio.Listarinvestidores();


            int qtdPct = 0;

            foreach (var inv in investidores.Where(iv => iv.pacote.IDPacote == model.pacote.IDPacote))
            {
                qtdPct += inv.Quantidade;
            }

            if ((model.pacote.QtdTotal - qtdPct) - model.Quantidade >= 0)
            {

                bool enviamensagem = Repositorio.InseriInvestidor(model);

                if (enviamensagem)
                    ViewBag.Mensagem = "Obrigado!";
                else
                    ViewBag.Mensagem = "Ops! Algo deu errado, tente novamente mais tarde.";
            }
            else
            {
                ViewBag.Mensagem = "Ops! Número de pacotes não disponível.";
            }

            return RedirectToAction("AreaRestrita", new { id = model.pacote.IDPacote });
        }

        //PESQUISA

        [Authorize(Roles = "Admin, Investidor")]
        [HttpGet]
        public ActionResult AreaRestrita(int? id)
        {
            if (id != null)
            {
                Investidor invest = new Investidor();
                invest.pacote = Repositorio.ListarPacote((int)id);
                invest.pessoa = Repositorio.ListarPessoa(UserId);

                var investidor = Repositorio.FiltrarPacote(UserId);

                if (investidor == null || ((List<Investidor>)investidor).Count == 0)
                    ViewBag.Mensagem = "Nenhum cliente cadastrado";

                return View(investidor);
            }
            else
            {
                ViewBag.Mensagem = "Nenhum Investimento lançado";
                return View();
            }
            
        }

        [Authorize(Roles = "Admin, Investidor")]
        [HttpPost]
        public ActionResult AreaRestrita(string texto, string combo)
        {
            var investidor = Repositorio.FiltrarPacote(texto, combo, UserId);

            if (investidor == null || ((List<Investidor>)investidor).Count == 0)
                ViewBag.Mensagem = "Nenhum cliente encontrado";

            return View(investidor);
        }
    }
}