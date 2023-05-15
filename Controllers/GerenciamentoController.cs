using Microsoft.AspNetCore.Mvc;
using processo_estágio.BancoDeDados.Entrada;
using processo_estágio.BancoDeDados.Mercadorias;
using processo_estágio.BancoDeDados.Saida;
using processo_estágio.Models;
using System.Data;

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

        // ACTION CHAMANDO MÉTODO DO BANCO DE DADOS DA MERCADORIA PARA INSERIR DADOS NA TABELA
        public ActionResult Adicionar(string nome, string fabricante, string tipo, string descricao)
        {

            if (nome != null && fabricante != null && tipo != null && descricao != null)
            {
                DatabaseMercadorias.InserirDados(nome, fabricante, tipo, descricao);

            }

            return RedirectToAction("Index");
        }

        // ACTION CHAMANDO MÉTODO DO BANCO DE DADOS DA ENTRADA PARA INSERIR DADOS NA TABELA
        public ActionResult Entrar(string quantidade, string dia, string mes, string ano, string hora, string local, string mercadoria)
        {

            if (quantidade != null && dia != null && mes != null && ano != null && hora != null && local != null && mercadoria != null)
            {
                DatabaseEntrada.InserirDados(quantidade, dia, mes, ano, hora, local, mercadoria);
            }


            return RedirectToAction("Index");
        }

        // ACTION CHAMANDO MÉTODO DO BANCO DE DADOS DA SAIDA PARA INSERIR DADOS NA TABELA
        public ActionResult Sair(string quantidade, string dia, string mes, string ano, string hora, string local, string mercadoria)
        {

            DataTable dados = DatabaseEntrada.ObterQuantidadeEnt(mercadoria);

            int quantidadeTotal = 0;

            if (dados.Rows.Count != 0 || dados != null)
            {
                for (int i = 0; i < dados.Rows.Count; i++)
                {
                    quantidadeTotal += Convert.ToInt32(dados.Rows[i].ItemArray[0]);
                }
            }

            if (Convert.ToInt32(quantidade) < quantidadeTotal)
            {

                if (quantidade != null && dia != null && mes != null && ano != null && hora != null && local != null && mercadoria != null)
                {
                    DatabaseSaida.InserirDados(quantidade, dia, mes, ano, hora, local, mercadoria);
                }

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Informe");
            }
        }

        public ActionResult Informe()
        {
            return View();
        }
    }
}
