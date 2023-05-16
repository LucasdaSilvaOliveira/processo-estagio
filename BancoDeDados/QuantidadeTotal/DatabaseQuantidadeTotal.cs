using System.Data;
using System.Data.SQLite;

namespace processo_estágio.BancoDeDados.QuantidadeTotal
{
    public class DatabaseQuantidadeTotal
    {
        public static SQLiteConnection ConexaoBanco()
        {
            SQLiteConnection conexao = new SQLiteConnection("Data Source=D:\\Program Files\\SQLiteStudio\\DB_Mstar");
            conexao.Open();
            return conexao;
        }

        public static void InserirDados(string nome)
        {
            using (var cmd = ConexaoBanco().CreateCommand())
            {
                cmd.CommandText = "INSERT INTO tb_quantidadeTotal(QUANTIDADE_TOTAL, MERCADORIA_QT) VALUES (0,'"+nome+"')";
                ConexaoBanco().Close();
                cmd.ExecuteNonQuery();
            }
        } 

        public static void DeletarDados(string? nome)
        {
            using (var cmd = ConexaoBanco().CreateCommand())
            {
                cmd.CommandText = "DELETE FROM tb_quantidadeTotal WHERE MERCADORIA_QT = '"+nome+"'";
                ConexaoBanco().Close();
                cmd.ExecuteNonQuery();
            }
        }

        public static DataTable ObterQuantidadeAtual(string? nome)
        {
            DataTable dt = new DataTable();

            try
            {
                using (var cmd = ConexaoBanco().CreateCommand())
                {
                    cmd.CommandText = "SELECT QUANTIDADE_TOTAL FROM tb_quantidadeTotal WHERE MERCADORIA_QT = '"+nome+"'";

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

        public static void AtualizarQuantidade(int valorNovo, string? nome)
        {
            using (var cmd = ConexaoBanco().CreateCommand())
            {
                cmd.CommandText = "UPDATE tb_quantidadeTotal SET QUANTIDADE_TOTAL = "+valorNovo+" WHERE MERCADORIA_QT ='"+nome+"'";
                ConexaoBanco().Close();
                cmd.ExecuteNonQuery();
            }
        }
        public static void AtualizarNome(string nomeNovo,string nomeAntigo)
        {
            using (var cmd = ConexaoBanco().CreateCommand())
            {
                cmd.CommandText = "UPDATE tb_quantidadeTotal SET MERCADORIA_QT = '"+nomeNovo+"' WHERE MERCADORIA_QT ='"+nomeAntigo+"'";
                ConexaoBanco().Close();
                cmd.ExecuteNonQuery();
            }
        }

        public static DataTable ObterDados()
        {
			DataTable dt = new DataTable();

			try
			{
				using (var cmd = ConexaoBanco().CreateCommand())
				{
					cmd.CommandText = "SELECT * FROM tb_quantidadeTotal";

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
    }
}
