using System.Data;
using System.Data.SQLite;

namespace processo_estágio.BancoDeDados.Mercadorias
{
    public class DatabaseMercadorias
    {
        public static SQLiteConnection ConexaoBanco()
        {
            SQLiteConnection conexao = new SQLiteConnection("Data Source=D:\\Program Files\\SQLiteStudio\\DB_Mstar");
            conexao.Open();
            return conexao;
        }

        // PEGANDO DADOS PARA: TABELAS DE PRODUTOS E DropDownList DOS CAMPOS NECESSÁRIOS
        public static DataTable ObterDados()
        {
            DataTable dt = new DataTable();

            try
            {
                using (var cmd = ConexaoBanco().CreateCommand())
                {
                    cmd.CommandText = "SELECT ID_MERC, NOME, FABRICANTE, TIPO FROM tb_mercadorias";

                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd.CommandText, ConexaoBanco());
                    da.Fill(dt);
                    ConexaoBanco().Close();
                    return dt;
                }
            } catch (Exception)
            {
                throw;
            }
        }

        // PEGANDO DADOS PARA PREENCHER OS CAMPOS DE FORMULÁRIO DE EDIÇÃO
        public static DataTable ObterDadosParaAtualizacao(int id)
        {
            DataTable dt = new DataTable();

            try
            {
                using (var cmd = ConexaoBanco().CreateCommand())
                {
                    cmd.CommandText = "SELECT NOME, FABRICANTE, TIPO FROM tb_mercadorias WHERE ID_MERC =" + Int32.Parse(id.ToString());

                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd.CommandText, ConexaoBanco());
                    da.Fill(dt);
                    ConexaoBanco().Close();
                    return dt;
                }
            } catch (Exception)
            {
                throw;
            }
        }

        // ATUALIZAÇÃO DOS DADOS DA MERCADORIA
        public static void AtualizarDados(int id, string nome, string fabricante, string tipo)
        {
                using (var cmd = ConexaoBanco().CreateCommand())
                {
                    cmd.CommandText = "UPDATE tb_mercadorias SET NOME = '" + nome + "', FABRICANTE = '" + fabricante + "', TIPO = '" + tipo + "' WHERE ID_MERC = " + Int32.Parse(id.ToString());
                    ConexaoBanco().Close();
                    cmd.ExecuteNonQuery();
                }
        }

        // INSERINDO DADOS
        public static void InserirDados(string nome, string fabricante, string tipo, string descricao)
        {
            using(var cmd = ConexaoBanco().CreateCommand())
            {
                cmd.CommandText = "INSERT INTO tb_mercadorias(NOME, FABRICANTE, TIPO, DESCRICAO) VALUES(@nome,@fabricante,@tipo,@descricao)";
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@fabricante", fabricante);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@descricao", descricao);
                ConexaoBanco().Close();
                cmd.ExecuteNonQuery();
            }
        }

        // DELETANDO DADOS
        public static void DeletarDados(string? id)
        {
            using (var cmd = ConexaoBanco().CreateCommand())
            {
                cmd.CommandText = "DELETE FROM tb_mercadorias WHERE ID_MERC = " + Convert.ToInt32(id);
                ConexaoBanco().Close();
                cmd.ExecuteNonQuery();
            }
        }
        
    }
}
