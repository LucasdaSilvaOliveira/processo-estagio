using Microsoft.AspNetCore.Mvc;
using processo_estágio.BancoDeDados.Entrada;
using processo_estágio.BancoDeDados.Mercadorias;
using processo_estágio.BancoDeDados.QuantidadeTotal;
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
                DatabaseQuantidadeTotal.InserirDados(nome);
            }

            return RedirectToAction("Index");
        }

        // ACTION CHAMANDO MÉTODO DO BANCO DE DADOS DA ENTRADA PARA INSERIR DADOS NA TABELA
        public ActionResult Entrar(string quantidade, string dia, string mes, string ano, string hora, string local, string mercadoria)
        {

            DataTable QntdAtual = DatabaseQuantidadeTotal.ObterQuantidadeAtual(mercadoria);

            int valorAtual = Convert.ToInt32(QntdAtual.Rows[0].ItemArray[0]);

            int novoValor = valorAtual + int.Parse(quantidade);

            if (quantidade != null && dia != null && mes != null && ano != null && hora != null && local != null && mercadoria != null)
            {
                DatabaseEntrada.InserirDados(quantidade, dia, mes, ano, hora, local, mercadoria);
                DatabaseQuantidadeTotal.AtualizarQuantidade(novoValor, mercadoria);
            }


            return RedirectToAction("Index");
        }

        // ACTION CHAMANDO MÉTODO DO BANCO DE DADOS DA SAIDA PARA INSERIR DADOS NA TABELA
        public ActionResult Sair(string quantidade, string dia, string mes, string ano, string hora, string local, string mercadoria)
        {

            DataTable dados = DatabaseQuantidadeTotal.ObterQuantidadeAtual(mercadoria);

            int quantidadeTotal = Convert.ToInt32(dados.Rows[0].ItemArray[0]);

            int novoValor = quantidadeTotal - int.Parse(quantidade);

            if (Convert.ToInt32(quantidade) <= quantidadeTotal && Convert.ToInt32(quantidade) >= 0)
            {
                if (quantidade != null && dia != null && mes != null && ano != null && hora != null && local != null && mercadoria != null)
                {
                    DatabaseSaida.InserirDados(quantidade, dia, mes, ano, hora, local, mercadoria);
                    DatabaseQuantidadeTotal.AtualizarQuantidade(novoValor,mercadoria);
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
