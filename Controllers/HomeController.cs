using Microsoft.AspNetCore.Mvc;
using processo_estágio.BancoDeDados.Entrada;
using processo_estágio.BancoDeDados.Mercadorias;
using processo_estágio.BancoDeDados.Saida;
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

        // CHAMA A VIEW DE CONFIRMAÇÃO DE EXCLUSÃO DE MERCADORIA
        public ActionResult Deletar(string id)
        {

            GetDataModel.idDeletarMercadoria = id;

            return RedirectToAction("ConfirmarExclusao");
        }

        // VIEW CONFIRMAR EXCLUSÃO
        public ActionResult ConfirmarExclusao()
        {
            return View();
        }

        // CHAMA MÉTODO DE EXCLUSÃO DE DADOS
        public ActionResult Exclusao()
        {
            DatabaseMercadorias.DeletarDados(GetDataModel.idDeletarMercadoria);

            return RedirectToAction("Index");
        }

        // CHAMA VIEW DO FORMULÁRIO DE EDIÇÃO DE MERCADORIAS
        public IActionResult FormAtualizar(int id)
        {
            GetDataModel.idAtualizarMercadoria = id;

            GetDataModel.MercadoriasAtualizacao = DatabaseMercadorias.ObterDadosParaAtualizacao(id);

            return View();
        }

        // ATUALIZA OS DADOS DA MERCADORIA SELECIONADA
        [HttpPost]
        public ActionResult AtualizarDadosHome(string nome, string fabricante, string tipo, string nomeAntigo)
        {

            DatabaseMercadorias.AtualizarDados(GetDataModel.idAtualizarMercadoria, nome, fabricante, tipo);

            DatabaseEntrada.AtualizarNomeMercadoria(nome, nomeAntigo);

            DatabaseSaida.AtualizarNomeMercadoria(nome, nomeAntigo);

            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}