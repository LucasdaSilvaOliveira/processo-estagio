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

        // PEGANDO DADOS PARA SOLICITAÇÃO DO HISTÓRICO DE SAIDA DA MERCADORIA SELECIONADA
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

        // CADASTRAR SAIDA DE UM DETERMINADO PRODUTO
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

        // PEGANDO DADOS DA SAIDA DE MERCADORIAS PARA COLOCAR NO PDF GERADO PARA O RELATÓRIO(AQUI ESTÁ ORDERNADO POR MÊS)
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

        // EXCLUSÃO DO REGISTRO DE SAIDA
        public static void DeletarHistoricoSaida(string id)
        {
            using (var cmd = ConexaoBanco().CreateCommand())
            {
                cmd.CommandText = "DELETE FROM tb_saida WHERE ID_SAIDA = " + Convert.ToInt32(id);
                ConexaoBanco().Close();
                cmd.ExecuteNonQuery();
            }
        }

        //PEGANDO DADOS PARA COLOCAR NOS VALORES DOS CAMPOS DE FORMULÁRIO DE EDIÇÃO DE SAIDA
        public static DataTable ObterDadosParaAtualizar(int id)
        {
            DataTable dt = new DataTable();

            try
            {
                using (var cmd = ConexaoBanco().CreateCommand())
                {
                    cmd.CommandText = "SELECT QUANTIDADE_SAIDA, DIA_SAIDA, MES_SAIDA, ANO_SAIDA, HORA_SAIDA, LOCAL_SAIDA FROM tb_saida WHERE ID_SAIDA = " + id;

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

        // ATUALIZANDO REGISTRO DE SAIDA
        public static void AtualizarHistoricoSaida(int id, int quantidade, int dia, int mes, int ano, string hora, string local)
		{
			using (var cmd = ConexaoBanco().CreateCommand())
			{
				cmd.CommandText = "UPDATE tb_saida SET QUANTIDADE_SAIDA = " + quantidade + ", DIA_SAIDA = " + dia + ", MES_SAIDA = " + mes + ", ANO_SAIDA = " + ano + ", HORA_SAIDA = '" + hora + "', LOCAL_SAIDA = '" + local + "' WHERE ID_SAIDA = " + Int32.Parse(id.ToString());
				ConexaoBanco().Close();
				cmd.ExecuteNonQuery();
			}
		}

        // NOME DA MERCADORIA NO REGISTRO TAMBÉM MUDAR QUANDO EU ALTERAR O NOME DA MERCADORIA
        public static void AtualizarNomeMercadoria(string nome, string nomeAntigo)
        {

            var cmd = ConexaoBanco().CreateCommand();
            cmd.CommandText = "UPDATE tb_saida SET MERCADORIA_SAIDA = '" + nome + "' WHERE MERCADORIA_SAIDA = '" + nomeAntigo + "'";
            ConexaoBanco().Close();
            cmd.ExecuteNonQuery();

        }
    }
}
