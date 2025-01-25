//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using MySql.Data.MySqlClient;
//using System.Windows.Forms;

//namespace portasTestes.Repository
//{
//    public class HistoricoRepository
//    {
//        private readonly string _connectionString;

//        public HistoricoRepository(string connectionString)
//        {
//            _connectionString = connectionString;
//        }

//        public void CriarTabela()
//        {
//            try
//            {
//                var conexao = new MySqlConnection(_connectionString);
//                conexao.Open();
//                var comando = new MySqlCommand(@"
//                CREATE TABLE IF NOT EXISTS Historico (
//                    IdHistorico INT AUTO_INCREMENT PRIMARY KEY,
//                    IdJogador INT NOT NULL,
//                    Resultado VARCHAR(50) NOT NULL,
//                    Data DATETIME NOT NULL
//                );", conexao);
//                comando.ExecuteNonQuery();
//                conexao.Close();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Algo deu errado ao criar a tabela: " + ex.Message);
//            }
//        }

//        public void Adicionar(int idJogador, string resultado, DateTime data)
//        {
//            try
//            {
//                var conexao = new MySqlConnection(_connectionString);
//                conexao.Open();
//                var comando = new MySqlCommand("INSERT INTO Historico (IdJogador, Resultado, Data) VALUES (@IdJogador, @Resultado, @Data);", conexao);
//                comando.Parameters.AddWithValue("@IdJogador", idJogador);
//                comando.Parameters.AddWithValue("@Resultado", resultado);
//                comando.Parameters.AddWithValue("@Data", data);
//                comando.ExecuteNonQuery();
//                conexao.Close();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Algo deu errado ao adicionar o histórico: " + ex.Message);
//            }
//        }

//        public List<(int IdHistorico, int IdJogador, string Resultado, DateTime Data)> ObterTodos()
//        {
//            var historicos = new List<(int, int, string, DateTime)>();
//            try
//            {
//                var conexao = new MySqlConnection(_connectionString);
//                conexao.Open();
//                var comando = new MySqlCommand("SELECT * FROM Historico;", conexao);
//                using (var reader = comando.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        historicos.Add((
//                            reader.GetInt32("IdHistorico"),
//                            reader.GetInt32("IdJogador"),
//                            reader.GetString("Resultado"),
//                            reader.GetDateTime("Data")
//                        ));
//                    }
//                }
//                conexao.Close();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Algo deu errado ao buscar o histórico: " + ex.Message);
//            }

//            return historicos;
//        }

//        public void Atualizar(int idHistorico, int idJogador, string resultado, DateTime data)
//        {
//            try
//            {
//                var conexao = new MySqlConnection(_connectionString);
//                conexao.Open();
//                var comando = new MySqlCommand("UPDATE Historico SET IdJogador = @IdJogador, Resultado = @Resultado, Data = @Data WHERE IdHistorico = @IdHistorico;", conexao);
//                comando.Parameters.AddWithValue("@IdJogador", idJogador);
//                comando.Parameters.AddWithValue("@Resultado", resultado);
//                comando.Parameters.AddWithValue("@Data", data);
//                comando.Parameters.AddWithValue("@IdHistorico", idHistorico);
//                comando.ExecuteNonQuery();
//                conexao.Close();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Algo deu errado ao atualizar o histórico: " + ex.Message);
//            }
//        }

//        public void Deletar(int idHistorico)
//        {
//            try
//            {
//                var conexao = new MySqlConnection(_connectionString);
//                conexao.Open();
//                var comando = new MySqlCommand("DELETE FROM Historico WHERE IdHistorico = @IdHistorico;", conexao);
//                comando.Parameters.AddWithValue("@IdHistorico", idHistorico);
//                comando.ExecuteNonQuery();
//                conexao.Close();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Algo deu errado ao deletar o histórico: " + ex.Message);
//            }
//        }
//    }
//}
