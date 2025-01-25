//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using MySql.Data.MySqlClient;
//using System.Windows.Forms;

//namespace portasTestes.Repository
//{
//    public class InimigoRepository
//    {
//        private readonly string _connectionString;

//        public InimigoRepository(string connectionString)
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
//                CREATE TABLE IF NOT EXISTS Inimigos (
//                    IdInimigo INT AUTO_INCREMENT PRIMARY KEY,
//                    Nome VARCHAR(255) NOT NULL,
//                    Dano INT NOT NULL
//                );", conexao);
//                comando.ExecuteNonQuery();
//                conexao.Close();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Algo deu errado ao criar a tabela: " + ex.Message);
//            }
//        }

//        public void Adicionar(string nome, int dano)
//        {
//            try
//            {
//                var conexao = new MySqlConnection(_connectionString);
//                conexao.Open();
//                var comando = new MySqlCommand("INSERT INTO Inimigos (Nome, Dano) VALUES (@Nome, @Dano);", conexao);
//                comando.Parameters.AddWithValue("@Nome", nome);
//                comando.Parameters.AddWithValue("@Dano", dano);
//                comando.ExecuteNonQuery();
//                conexao.Close();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Algo deu errado ao adicionar o inimigo: " + ex.Message);
//            }
//        }

//        public List<(int IdInimigo, string Nome, int Dano)> ObterTodos()
//        {
//            var inimigos = new List<(int, string, int)>();
//            try
//            {
//                var conexao = new MySqlConnection(_connectionString);
//                conexao.Open();
//                var comando = new MySqlCommand("SELECT * FROM Inimigos;", conexao);
//                using (var reader = comando.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        inimigos.Add((
//                            reader.GetInt32("IdInimigo"),
//                            reader.GetString("Nome"),
//                            reader.GetInt32("Dano")
//                        ));
//                    }
//                }
//                conexao.Close();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Algo deu errado ao buscar os inimigos: " + ex.Message);
//            }

//            return inimigos;
//        }

//        public void Atualizar(int idInimigo, string nome, int dano)
//        {
//            try
//            {
//                var conexao = new MySqlConnection(_connectionString);
//                conexao.Open();
//                var comando = new MySqlCommand("UPDATE Inimigos SET Nome = @Nome, Dano = @Dano WHERE IdInimigo = @IdInimigo;", conexao);
//                comando.Parameters.AddWithValue("@Nome", nome);
//                comando.Parameters.AddWithValue("@Dano", dano);
//                comando.Parameters.AddWithValue("@IdInimigo", idInimigo);
//                comando.ExecuteNonQuery();
//                conexao.Close();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Algo deu errado ao atualizar o inimigo: " + ex.Message);
//            }
//        }

//        public void Deletar(int idInimigo)
//        {
//            try
//            {
//                var conexao = new MySqlConnection(_connectionString);
//                conexao.Open();
//                var comando = new MySqlCommand("DELETE FROM Inimigos WHERE IdInimigo = @IdInimigo;", conexao);
//                comando.Parameters.AddWithValue("@IdInimigo", idInimigo);
//                comando.ExecuteNonQuery();
//                conexao.Close();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Algo deu errado ao deletar o inimigo: " + ex.Message);
//            }
//        }
//    }
//}
