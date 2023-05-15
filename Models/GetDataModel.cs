using processo_estágio.BancoDeDados.Mercadorias;
using System.Data;

namespace processo_estágio.Models
{
    public class GetDataModel
    {
        public DataTable MercadoriasModel { get; set; }
        public static DataTable MercadoriasEntradaHistorico { get; set; }
        public static DataTable MercadoriasSaidaHistorico { get; set; }
        public static string idDeletarMercadoria { get; set; }
        public static int idAtualizarMercadoria { get; set; }
        public static DataTable MercadoriasAtualizacao { get; set; }
        public static string idDeletarHistorico { get; set; }
        public static int idAtualizarHistorico { get; set; }
        public static DataTable DadosHistoricoEntAtt { get; set; }
        public static DataTable DadosHistoricoSaidaAtt { get; set; }
    }
}
