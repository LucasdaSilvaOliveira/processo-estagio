using Microsoft.AspNetCore.Mvc;
using processo_estágio.BancoDeDados.Entrada;
using processo_estágio.BancoDeDados.Mercadorias;
using processo_estágio.BancoDeDados.Saida;
using processo_estágio.Models;

namespace processo_estágio.Controllers
{
    public class GerenciamentoController : Controller
    {
        public IActionResult Index()
        {

            GetDataModel.MercadoriasEntradaHistorico = null;
            GetDataModel.MercadoriasSaidaHistorico = null;

            return View();
        }

        public IActionResult Entrada()
        {

            GetDataModel model = new GetDataModel();

            model.MercadoriasModel = DatabaseMercadorias.ObterDados();

            return View(model);
        }
        public IActionResult Saida()
        {
            GetDataModel model = new GetDataModel();

            model.MercadoriasModel = DatabaseMercadorias.ObterDados();

            return View(model);
        }

        public ActionResult Adicionar(string nome, string fabricante, string tipo, string descricao)
        {

            if(nome != null && fabricante != null && tipo != null && descricao != null)
            {
                DatabaseMercadorias.InserirDados(nome, fabricante, tipo, descricao);
               
            }

            return RedirectToAction("Index");
        }

        public ActionResult Entrar(string quantidade, string dia, string mes, string ano, string hora, string local, string mercadoria)
        {

            if(quantidade != null && dia != null && mes != null && ano != null && hora != null && local != null && mercadoria != null)
            {
                DatabaseEntrada.InserirDados(quantidade, dia, mes , ano, hora, local, mercadoria);
            }
            

            return RedirectToAction("Index");
        }
        public ActionResult Sair(string quantidade, string dia,string mes, string ano, string hora, string local, string mercadoria)
        {

            if(quantidade != null && dia != null && mes != null && ano != null && hora != null && local != null && mercadoria != null)
            {
                DatabaseSaida.InserirDados(quantidade, dia, mes, ano, hora, local, mercadoria);
               

            }
            return RedirectToAction("Index");

        }
    }
}
