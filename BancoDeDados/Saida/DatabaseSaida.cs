using System.Data;
using System.Data.SQLite;

namespace processo_estágio.BancoDeDados.Saida
{
    public class DatabaseSaida
    {
        public static SQLiteConnection ConexaoBanco()
        {
            SQLiteConnection conexao = new SQLiteConnection("Data Source=D:\\Program Files\\SQLiteStudio\\DB_Mstar");
            conexao.Open();
            return conexao;
        }

        public static DataTable ObterDadosHistorico(string mercadoria)
        {
            DataTable dt = new DataTable();

            try
            {
                using (var cmd = ConexaoBanco().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM tb_saida WHERE MERCADORIA_SAIDA = '" + mercadoria + "'";

                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd.CommandText, ConexaoBanco());
                    da.Fill(dt);
                    ConexaoBanco().Close();
                    return dt;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void InserirDados(string quantidade, string dia,string mes,string ano, string hora, string local, string mercadoria)
        {
            using (var cmd = ConexaoBanco().CreateCommand())
            {
                cmd.CommandText = "INSERT INTO tb_saida(QUANTIDADE_SAIDA, DIA_SAIDA,MES_SAIDA,ANO_SAIDA, HORA_SAIDA, LOCAL_SAIDA, MERCADORIA_SAIDA) VALUES(@quantidade,@dia,@mes,@ano,@hora,@local,@mercadoria)";
                cmd.Parameters.AddWithValue("@quantidade", Convert.ToInt32(quantidade));
                cmd.Parameters.AddWithValue("@dia", dia);
                cmd.Parameters.AddWithValue("@mes", mes);
                cmd.Parameters.AddWithValue("@ano", ano);
                cmd.Parameters.AddWithValue("@hora", hora);
                cmd.Parameters.AddWithValue("@local", local);
                cmd.Parameters.AddWithValue("@mercadoria", mercadoria);
                ConexaoBanco().Close();
                cmd.ExecuteNonQuery();
            }
        }

		public static DataTable ObterDadosRelatorioSaida()
		{
			DataTable dt = new DataTable();

			try
			{
				using (var cmd = ConexaoBanco().CreateCommand())
				{
					cmd.CommandText = "SELECT * FROM tb_saida ORDER BY MES_SAIDA ASC";

					SQLiteDataAdapter da = new SQLiteDataAdapter(cmd.CommandText, ConexaoBanco());
					da.Fill(dt);
					ConexaoBanco().Close();
					return dt;
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

        public static void DeletarHistoricoSaida(string id)
        {
            using (var cmd = ConexaoBanco().CreateCommand())
            {
                cmd.CommandText = "DELETE FROM tb_saida WHERE ID_SAIDA = " + Convert.ToInt32(id);
                ConexaoBanco().Close();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
