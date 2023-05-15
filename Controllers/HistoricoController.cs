using Microsoft.AspNetCore.Mvc;
using processo_estágio.BancoDeDados.Entrada;
using processo_estágio.BancoDeDados.Mercadorias;
using processo_estágio.BancoDeDados.Saida;
using processo_estágio.Models;
using System.Data;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace processo_estágio.Controllers
{
    public class HistoricoController : Controller
    {
        public IActionResult Index()
        {

            GetDataModel model = new GetDataModel();

            model.MercadoriasModel = DatabaseMercadorias.ObterDados();

            return View(model);
        }

        // CHAMA UM MÉTODO DO BANCO DE DADOS DA ENTRADA PARA OBTER OS DADOS DE UM DETERMINADA MERCADORIA
        public ActionResult ObterDadosEntrada(string mercadoria)
        {

            DataTable DadosEntrada = DatabaseEntrada.ObterDadosHistorico(mercadoria);

         
            GetDataModel.MercadoriasEntradaHistorico = DadosEntrada;

            return RedirectToAction("Index");

        }

        // CHAMA UM MÉTODO DO BANCO DE DADOS DA SAIDA PARA OBTER OS DADOS DE UM DETERMINADA MERCADORIA
        public ActionResult ObterDadosSaidaSegundo(string mercadoria)
        {

            DataTable DadosSaida = DatabaseSaida.ObterDadosHistorico(mercadoria);
         
            GetDataModel.MercadoriasSaidaHistorico = DadosSaida;

            return RedirectToAction("Index");

        }

        //CHAMA A VIEW DE CONFIRMAÇÃO DE EXCLUSÃO DA ENTRADA, PASSANDO O ID
        public ActionResult HistoricoConfirmarExc(string id)
        {

            GetDataModel.idDeletarHistorico = id;
            return View();
        }

        // CHAMA MÉTODO PARA EXCLUSÃO DE REGISTRO DE UM ITEM DO BANCO DE DADOS DA ENTRADA
        public ActionResult ExcHistoricoEnt()
        {
            DatabaseEntrada.DeletarHistoricoEntrada(GetDataModel.idDeletarHistorico);

            GetDataModel.MercadoriasEntradaHistorico = null;
            GetDataModel.MercadoriasSaidaHistorico = null;

            return RedirectToAction("Index");
        }

        //CHAMA A VIEW DE CONFIRMAÇÃO DE EXCLUSÃO DA SAIDA, PASSANDO O ID
        public ActionResult ConfirmarExcSaida(string id)
        {
            GetDataModel.idDeletarHistorico = id;
            return View();
        }

        // CHAMA MÉTODO PARA EXCLUSÃO DE REGISTRO DE UM ITEM DO BANCO DE DADOS DA SAIDA
        public ActionResult HistoricoSaidaExc()
        {
            DatabaseSaida.DeletarHistoricoSaida(GetDataModel.idDeletarHistorico);

            GetDataModel.MercadoriasEntradaHistorico = null;
            GetDataModel.MercadoriasSaidaHistorico = null;
            return RedirectToAction("Index");
        }

        // CHAMA O FORMULÁRIO DE EDIÇÃO DA ENTRADA
        public ActionResult AttHistoricoEntrada(int id)
        {

            GetDataModel.idAtualizarHistorico = id;

           GetDataModel.DadosHistoricoEntAtt = DatabaseEntrada.ObterDadosParaAtualizar(id);

            return View();
        }

        // ATUALIZA O REGISTRO DE ENTRADA
        public ActionResult AtualizarHistoricoEnt(int quantidade, int dia, int mes, int ano, string hora, string local)
        {

            DatabaseEntrada.AtualizarHistoricoEnt(GetDataModel.idAtualizarHistorico,quantidade,dia,mes,ano,hora,local);
            GetDataModel.MercadoriasEntradaHistorico = null;
            GetDataModel.MercadoriasSaidaHistorico = null;

            return RedirectToAction("Index");
        }

        // CHAMA O FORMULÁRIO DE EDIÇÃO DA SAIDA
        public ActionResult AttHistoricoSaida(int id)
        {
            GetDataModel.idAtualizarHistorico = id;

            GetDataModel.DadosHistoricoSaidaAtt = DatabaseSaida.ObterDadosParaAtualizar(id);

            return View();
        }

        // ATUALIZA O REGISTRO DE SAIDA
        public ActionResult AtualizarHistoricoSaida(int quantidade, int dia, int mes, int ano, string hora, string local)
        {
            DatabaseSaida.AtualizarHistoricoSaida(GetDataModel.idAtualizarHistorico, quantidade, dia, mes, ano, hora, local);
            GetDataModel.MercadoriasEntradaHistorico = null;
            GetDataModel.MercadoriasSaidaHistorico = null;

            return RedirectToAction("Index");
        }

        // MÉTODO QUE GERA O PDF
        public ActionResult Pdf()
        {

            Document doc = new Document(PageSize.A4);
            doc.SetMargins(20,20,30,30);
            doc.AddCreationDate();
            string caminho = AppDomain.CurrentDomain.BaseDirectory + @"\pdf\" + "relatorio.pdf";
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));

            doc.Open();

            Paragraph titulo = new Paragraph();
            titulo.Font = new Font(Font.FontFamily.COURIER, 30);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.Add("Relatório das Ações\n\n\n\n");
            doc.Add(titulo);

            Paragraph subtitulo1 = new Paragraph();
            subtitulo1.Font = new Font(Font.FontFamily.COURIER, 20);
			subtitulo1.Alignment = Element.ALIGN_CENTER;
			subtitulo1.Add("Mercadorias Entrada\n\n\n\n");
            doc.Add(subtitulo1);

            Paragraph paragrafoMercEnt = new Paragraph();
            paragrafoMercEnt.Font = new Font(Font.FontFamily.COURIER, 20);

            DataTable dadosEntrada = DatabaseEntrada.ObterDadosRelatorioEntrada();

            PdfPTable table = new PdfPTable(7);
            table.AddCell("N° Registro");
            table.AddCell("Mês de entrada");
            table.AddCell("Mercadoria");
            table.AddCell("Quantidade");
            table.AddCell("Hora");
            table.AddCell("Dia");
            table.AddCell("Ano");
            string mesEntrada = "";

            foreach (DataRow row in dadosEntrada.Rows)
            {
                mesEntrada = row["MES_ENT"].ToString();
                switch(mesEntrada)
                {
                    case "1" :
                        mesEntrada = "Janeiro";
                        break;
                    case "2" :
                        mesEntrada = "Fevereiro";
                        break;
                    case "3" :
                        mesEntrada = "Março";
                        break;
                    case "4" :
                        mesEntrada = "Abril";
                        break;
                    case "5" :
                        mesEntrada = "Maio";
                        break;
                    case "6" :
                        mesEntrada = "Junho";
                        break;
                    case "7" :
                        mesEntrada = "Julho";
                        break;
                    case "8" :
                        mesEntrada = "Agosto";
                        break;
                    case "9" :
                        mesEntrada = "Setembro";
                        break;
                    case "10" :
                        mesEntrada = "Outubro";
                        break;
                    case "11" :
                        mesEntrada = "Novembro";
                        break;
                    case "12" :
                        mesEntrada = "Dezembro";
                        break;
                }
                table.AddCell(row["ID_ENT"].ToString());
                table.AddCell(mesEntrada);
                table.AddCell(row["MERCADORIA_ENT"].ToString());
                table.AddCell(row["QUANTIDADE_ENT"].ToString());
                table.AddCell(row["HORA_ENT"].ToString() + " hrs");
                table.AddCell(row["DIA_ENT"].ToString());
                table.AddCell(row["ANO_ENT"].ToString());

			}

            doc.Add(table);

            Paragraph separador = new Paragraph();
            separador.Alignment = Element.ALIGN_CENTER;
            separador.Add("------------------------------------------------\n\n\n\n");
            doc.Add(separador);

			Paragraph subtitulo2 = new Paragraph();
			subtitulo2.Font = new Font(Font.FontFamily.COURIER, 20);
			subtitulo2.Alignment = Element.ALIGN_CENTER;
			subtitulo2.Add("Mercadorias Saída\n\n\n\n");
			doc.Add(subtitulo2);

			DataTable dadosSaida = DatabaseSaida.ObterDadosRelatorioSaida();

            PdfPTable table2 = new PdfPTable(7);
            table2.AddCell("N° Registro");
            table2.AddCell("Mês de saída");
            table2.AddCell("Mercadoria");
            table2.AddCell("Quantidade");
            table2.AddCell("Hora");
            table2.AddCell("Dia");
            table2.AddCell("Ano");
            string mesSaida = "";

            foreach (DataRow row in dadosSaida.Rows)
            {
                mesSaida = row["MES_SAIDA"].ToString();
                switch(mesSaida)
                {
                    case "1" :
                        mesSaida = "Janeiro";
                        break;
                    case "2" :
						mesSaida = "Fevereiro";
                        break;
                    case "3" :
						mesSaida = "Março";
                        break;
                    case "4" :
						mesSaida = "Abril";
                        break;
                    case "5" :
						mesSaida = "Maio";
                        break;
                    case "6" :
						mesSaida = "Junho";
                        break;
                    case "7" :
						mesSaida = "Julho";
                        break;
                    case "8" :
						mesSaida = "Agosto";
                        break;
                    case "9" :
                        mesSaida = "Setembro";
                        break;
                    case "10" :
                        mesSaida = "Outubro";
                        break;
                    case "11" :
						mesSaida = "Novembro";
                        break;
                    case "12" :
						mesSaida = "Dezembro";
                        break;
                }
                table2.AddCell(row["ID_SAIDA"].ToString());
                table2.AddCell(mesSaida);
                table2.AddCell(row["MERCADORIA_SAIDA"].ToString());
                table2.AddCell(row["QUANTIDADE_SAIDA"].ToString());
                table2.AddCell(row["HORA_SAIDA"].ToString() + " hrs");
                table2.AddCell(row["DIA_SAIDA"].ToString());
                table2.AddCell(row["ANO_SAIDA"].ToString());
			}

            doc.Add(table2);

			doc.Add(separador);

			doc.Close();
			byte[] bytes = System.IO.File.ReadAllBytes(caminho);
			return File(bytes, "application/pdf", "relatorio.pdf");
		}
    }
}
