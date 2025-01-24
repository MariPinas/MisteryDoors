using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data.SqlClient;

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
                dificuldade VARCHAR(255) NOT NULL
                );", conexao);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu de errado ao criar a tabela: " + ex.Message);
            }
        }

        public void AdicionarFase(Fase fase) {
            using (var connection = new SqlConnection(_connectionString)) {
                connection.Open();
                var query = "INSERT INTO Fases (dificuldade) VALUES (@dificuldade)";
                using (var command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@dificuldade", fase.dificuldade);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Fase> GetAll() {
            var fases = new List<Fase>();

            using (var connection = new SqlConnection(_connectionString)) {
                connection.Open();
                var query = "SELECT IdFase, dificuldade FROM Fases";
                using (var command = new SqlCommand(query, connection)) {
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            fases.Add(new Fase {
                                IdFase = reader.GetInt32(0),
                                dificuldade = reader.GetString(1)
                            });
                        }
                    }
                }
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

        public Fase GetById(int idFase) {
            Fase fase = null;

            using (var connection = new SqlConnection(_connectionString)) {
                connection.Open();
                var query = "SELECT IdFase, dificuldade FROM Fases WHERE IdFase = @IdFase";
                using (var command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@IdFase", idFase);
                    using (var reader = command.ExecuteReader()) {
                        if (reader.Read()) {
                            fase = new Fase {
                                IdFase = reader.GetInt32(0),
                                dificuldade = reader.GetString(1)
                            };
                        }
                    }
                }
            }

            return fase;
        }

        public int ObterIdDificuldade(string dificuldade) {
            int idFase = -1; //-1 pois se nao encontrar o id, retorna -1

            try {
                using (MySqlConnection conexao = new MySqlConnection(_connectionString)) {
                    conexao.Open();

                    string query = "SELECT IdFase FROM Fases WHERE Dificuldade = @Dificuldade";
                    using (MySqlCommand comando = new MySqlCommand(query, conexao)) {
                        comando.Parameters.AddWithValue("@Dificuldade", dificuldade);

                        object resultado = comando.ExecuteScalar();
                        if (resultado != null) {
                            idFase = Convert.ToInt32(resultado);
                        }
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine($"Erro ao obter o ID da dificuldade '{dificuldade}': {ex.Message}");
            }

            return idFase;
        }
    }
}
