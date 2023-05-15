using Microsoft.AspNetCore.Mvc;
using processo_estágio.BancoDeDados.Entrada;
using processo_estágio.BancoDeDados.Mercadorias;
using processo_estágio.Models;
using System.Data;
using System.Diagnostics;

namespace processo_estágio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            GetDataModel model = new GetDataModel();

            model.MercadoriasModel = DatabaseMercadorias.ObterDados();

            GetDataModel.MercadoriasEntradaHistorico = null;
            GetDataModel.MercadoriasSaidaHistorico = null;

            return View(model);
        }

        public ActionResult Deletar(string id)
        {

            GetDataModel.idDeletarMercadoria = id;

            return RedirectToAction("ConfirmarExclusao");
        }
        public ActionResult ConfirmarExclusao()
        {
            return View();
        }
        public ActionResult Exclusao()
        {
            DatabaseMercadorias.DeletarDados(GetDataModel.idDeletarMercadoria);

            return RedirectToAction("Index");
        }
        public IActionResult FormAtualizar(int id)
        {
            GetDataModel.idAtualizarMercadoria = id;

            GetDataModel.MercadoriasAtualizacao = DatabaseMercadorias.ObterDadosParaAtualizacao(id);

            return View();
        }

        [HttpPost]
        public ActionResult AtualizarDados(string nome, string fabricante, string tipo)
        {

            DatabaseMercadorias.AtualizarDados(GetDataModel.idAtualizarMercadoria, nome, fabricante, tipo);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}