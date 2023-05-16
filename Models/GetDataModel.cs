using processo_estágio.BancoDeDados.Mercadorias;
using System.Data;

namespace processo_estágio.Models
{
    public class GetDataModel
    {
        // USADO NOS DropDownList, TABELAS DE PRODUTOS
        public DataTable? MercadoriasModel { get; set; }

        // USADO NA TABELA DE HISTÓRICO DE ENTRADA PARA VISUALIZAR OS REGISTROS DE UMA MERCADORIA ESPECÍFICA
        public static DataTable? MercadoriasEntradaHistorico { get; set; }

        // USADO NA TABELA DE HISTÓRICO DE ENTRADA PARA VISUALIZAR OS REGISTROS DE UMA MERCADORIA ESPECÍFICA
        public static DataTable? MercadoriasSaidaHistorico { get; set; }

        // ID SETADO PARA DELETAR MERCADORIA
        public static string? idDeletarMercadoria { get; set; }

        // ID SETADO PARA ATUALIZAR MERCADORIA
        public static int idAtualizarMercadoria { get; set; }

        // MODELO USADO PARA PASSAR OS DADOS QUE SERÃO ATUALIZADOS PARA O CAMPO DE FORMULARIO DE EDIÇÃO DA MERCADORIA
        public static DataTable? MercadoriasAtualizacao { get; set; }

        // ID SETADO PARA DELETAR HISTÓRICO
        public static string? idDeletarHistorico { get; set; }

        //ID SETADO PARA ATUALIZAR HISTÓRICO
        public static int idAtualizarHistorico { get; set; }

        // MODELO USADO PARA PASSAR OS DADOS QUE SERÃO ATUALIZADOS PARA O CAMPO DE FORMULARIO DE EDIÇÃO DE ENTRADA
        public static DataTable? DadosHistoricoEntAtt { get; set; }

        // MODELO USADO PARA PASSAR OS DADOS QUE SERÃO ATUALIZADOS PARA O CAMPO DE FORMULARIO DE EDIÇÃO DE SAIDA
        public static DataTable? DadosHistoricoSaidaAtt { get; set; }

        public static string? nomeQuantidadeTotal { get; set; }
        public static string? nomeMercadoriaEntDeletada { get;set; }
        public static string? qntMercadoriaSaidaDeletada { get; set; }
		public static string? nomeMercadoriaSaidaDeletada { get; set; }
	}
}
