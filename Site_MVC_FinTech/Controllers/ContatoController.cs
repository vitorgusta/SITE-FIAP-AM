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
            c.DataMensagem = DateTime.Now;
            bool enviamensagem = Repositorio.InserirContato(c);

            if (enviamensagem)
                ViewBag.Mensagem = "Mensagem enviada com sucesso. Aguarde e entraremos em contato";

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Listar()
        {
            var conntato = Repositorio.ListarContatos();

            return View(conntato);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ExcluirContato(int id)
        {
            Repositorio.ExcluirContato(id);

            return RedirectToAction("Listar");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditarContato(int id)
        {
            var contato = Repositorio.ListarContato(id);

            return View("Cadastrar", contato);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditarContato(Contato c)
        {
            Repositorio.AlterarContato(c);

            return RedirectToAction("Listar");
        }

        //PESQUISA

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Pesquisar()
        {
            var contato = Repositorio.PesquisarContato();

            if (contato == null || ((List<Contato>)contato).Count == 0)
                ViewBag.Mensagem = "Nenhum contato cadastrado";

            return View(contato);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Pesquisar(string texto, string combo)
        {
            var contato = Repositorio.PesquisarContato(texto, combo);

            if (contato == null || ((List<Contato>)contato).Count == 0)
                ViewBag.Mensagem = "Nenhum contato encontrado";

            return View(contato);
        }
    }
}