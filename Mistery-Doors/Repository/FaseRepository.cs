using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace portasTestes.Repository
{
    public class FaseRepository
    {
        private readonly string _connectionString;

        public FaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CriarTabela()
        {
            try
            {
                var conexao = new MySqlConnection(_connectionString);
                conexao.Open();
                var comando = new MySqlCommand(@"
                CREATE TABLE IF NOT EXISTS Fases (
                    IdFase INT AUTO_INCREMENT PRIMARY KEY,
                    Dificuldade VARCHAR(255) NOT NULL,
                    PortasParaVencer INT NOT NULL
                );", conexao);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu de errado ao criar a tabela: " + ex.Message);
            }
        }

        public int AdicionarFase(Fase fase) {
            using (MySqlConnection conexao = new MySqlConnection(_connectionString)) {
                conexao.Open();
                string query = "INSERT INTO Fases (Dificuldade, PortasParaVencer) VALUES (@Dificuldade, @PortasParaVencer);";
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@Dificuldade", fase.Dificuldade);
                comando.Parameters.AddWithValue("@PortasParaVencer", fase.PortasParaVencer);

                comando.ExecuteNonQuery();

                query = "SELECT LAST_INSERT_ID();";
                comando = new MySqlCommand(query, conexao);
                return Convert.ToInt32(comando.ExecuteScalar()); 
            }
        }

        public List<(int IdFase, string DificuldadeId, int PortasParaVencer)> ObterTodas()
        {
            var fases = new List<(int, string, int)>();
            try
            {
                var conexao = new MySqlConnection(_connectionString);
                conexao.Open();
                var comando = new MySqlCommand("SELECT * FROM Fases;", conexao);
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        fases.Add((
                            reader.GetInt32("IdFase"),
                            reader.GetString("Dificuldade"),
                            reader.GetInt32("PortasParaVencer")
                        ));
                    }
                }
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu de errado ao buscar as fases: " + ex.Message);
            }

            return fases;
        }

        public void Atualizar(int idFase, string dificuldade, int PortasParaVencer)
        {
            try
            {
                var conexao = new MySqlConnection(_connectionString);
                conexao.Open();
                var comando = new MySqlCommand("UPDATE Fases SET Dificuldade = @Dificuldade, PortasParaVencer = @PortasParaVencer WHERE IdFase = @IdFase;", conexao);
                comando.Parameters.AddWithValue("@Dificuldade", dificuldade);
                comando.Parameters.AddWithValue("@PortasParaVencer", PortasParaVencer);
                comando.Parameters.AddWithValue("@IdFase", idFase);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu de errado ao atualizar a fase: " + ex.Message);
            }
        }

        public void Deletar(int idFase)
        {
            try
            {
                var conexao = new MySqlConnection(_connectionString);
                conexao.Open();
                var comando = new MySqlCommand("DELETE FROM Fases WHERE IdFase = @IdFase;", conexao);
                comando.Parameters.AddWithValue("@IdFase", idFase);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu de errado ao deletar a fase: " + ex.Message);
            }
        }

        public int ObterIdDificuldade(string dificuldade) {
            int dificuldadeId = -1;

            using (MySqlConnection conexao = new MySqlConnection(_connectionString)) {
                conexao.Open();
                string query = "SELECT IdFase FROM Fases WHERE Dificuldade = @Dificuldade";
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@Dificuldade", dificuldade);
                dificuldadeId = Convert.ToInt32(comando.ExecuteScalar());
            }

            return dificuldadeId;
        }

        public int ObterOuCriarFase(string dificuldade) {
            int dificuldadeId = -1;

            using (MySqlConnection conexao = new MySqlConnection(_connectionString)) {
                conexao.Open();

                // verificar se fase ja existe
                string queryExistente = "SELECT IdFase FROM Fases WHERE Dificuldade = @Dificuldade";
                MySqlCommand comandoExistente = new MySqlCommand(queryExistente, conexao);
                comandoExistente.Parameters.AddWithValue("@Dificuldade", dificuldade);

                var resultadoExistente = comandoExistente.ExecuteScalar();

                if (resultadoExistente != null && resultadoExistente != DBNull.Value) {
                   
                    dificuldadeId = Convert.ToInt32(resultadoExistente);
                } else {
                    
                    string queryInserir = "INSERT INTO Fases (Dificuldade, PortasParaVencer) VALUES (@Dificuldade, @PortasParaVencer)";
                    MySqlCommand comandoInserir = new MySqlCommand(queryInserir, conexao);
                    comandoInserir.Parameters.AddWithValue("@Dificuldade", dificuldade);
                    comandoInserir.Parameters.AddWithValue("@PortasParaVencer", 10); // Exemplo de número de portas, você pode personalizar isso

                    comandoInserir.ExecuteNonQuery();

                  
                    dificuldadeId = Convert.ToInt32(comandoInserir.LastInsertedId);
                }
            }

            return dificuldadeId;
        }
    }
}
