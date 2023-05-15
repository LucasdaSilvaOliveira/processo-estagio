using System.Data.SQLite;
using System.Data;
using processo_estágio.Models;

namespace processo_estágio.BancoDeDados.Entrada
{
    public class DatabaseEntrada
    {
        public static SQLiteConnection ConexaoBanco()
        {
            SQLiteConnection conexao = new SQLiteConnection("Data Source=D:\\Program Files\\SQLiteStudio\\DB_Mstar");
            conexao.Open();
            return conexao;
        }

        // PEGANDO DADOS PARA SOLICITAÇÃO DO HISTÓRICO DE ENTRADA DA MERCADORIA SELECIONADA
        public static DataTable ObterDadosHistorico(string mercadoria)
        {
            DataTable dt = new DataTable();

            try
            {
                using (var cmd = ConexaoBanco().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM tb_entrada WHERE MERCADORIA_ENT = '" + mercadoria + "'";

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

        // CADASTRAR ENTRADA DE UM DETERMINADO PRODUTO
        public static void InserirDados(string quantidade, string dia, string mes, string ano, string hora, string local, string mercadoria)
        {
            using (var cmd = ConexaoBanco().CreateCommand())
            {
                cmd.CommandText = "INSERT INTO tb_entrada(QUANTIDADE_ENT, DIA_ENT, MES_ENT, ANO_ENT, HORA_ENT, LOCAL_ENT, MERCADORIA_ENT) VALUES(@quantidade,@dia,@mes,@ano,@hora,@local,@mercadoria)";
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

        // PEGANDO DADOS DA ENTRADA DE MERCADORIAS PARA COLOCAR NO PDF GERADO PARA O RELATÓRIO(AQUI ESTÁ ORDERNADO POR MÊS)
        public static DataTable ObterDadosRelatorioEntrada()
        {
			DataTable dt = new DataTable();

			try
			{
				using (var cmd = ConexaoBanco().CreateCommand())
				{
					cmd.CommandText = "SELECT * FROM tb_entrada ORDER BY MES_ENT ASC";

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

        // EXCLUSÃO DO REGISTRO DE ENTRADA
        public static void DeletarHistoricoEntrada(string id)
        {
			using (var cmd = ConexaoBanco().CreateCommand())
			{
				cmd.CommandText = "DELETE FROM tb_entrada WHERE ID_ENT = " + Convert.ToInt32(id);
				ConexaoBanco().Close();
				cmd.ExecuteNonQuery();
			}
		}

        //PEGANDO DADOS PARA COLOCAR NOS VALORES DOS CAMPOS DE FORMULÁRIO DE EDIÇÃO DE ENTRADA
		public static DataTable ObterDadosParaAtualizar(int id)
		{
			DataTable dt = new DataTable();

			try
			{
				using (var cmd = ConexaoBanco().CreateCommand())
				{
					cmd.CommandText = "SELECT QUANTIDADE_ENT, DIA_ENT, MES_ENT, ANO_ENT, HORA_ENT, LOCAL_ENT FROM tb_entrada WHERE ID_ENT = " + id;

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

        // ATUALIZANDO REGISTRO DE ENTRADA
        public static void AtualizarHistoricoEnt(int id, int quantidade, int dia, int mes, int ano, string hora, string local)
        {
            using (var cmd = ConexaoBanco().CreateCommand())
            {
                cmd.CommandText = "UPDATE tb_entrada SET QUANTIDADE_ENT = " + quantidade + ", DIA_ENT = " + dia + ", MES_ENT = " + mes + ", ANO_ENT = "+ano+", HORA_ENT = '"+hora+"', LOCAL_ENT = '"+local+"' WHERE ID_ENT = " + Int32.Parse(id.ToString());
                ConexaoBanco().Close();
                cmd.ExecuteNonQuery();
            }
        }

        public static void AtualizarNomeMercadoria(string nome, string nomeAntigo)
        {

            var cmd = ConexaoBanco().CreateCommand();
            cmd.CommandText = "UPDATE tb_entrada SET MERCADORIA_ENT = '" + nome + "' WHERE MERCADORIA_ENT = '" + nomeAntigo + "'";
            ConexaoBanco().Close();
            cmd.ExecuteNonQuery();

        }
    }
}
