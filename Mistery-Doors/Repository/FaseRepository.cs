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

        public void Adicionar(string dificuldade, int PortasParaVencer)
        {
            try
            {
                var conexao = new MySqlConnection(_connectionString);
                conexao.Open();
                var comando = new MySqlCommand("INSERT INTO Fases (Dificuldade, PortasParaVencer) VALUES (@DificuldadeId, @PortasParaVencer);", conexao);
                comando.Parameters.AddWithValue("@Dificuldade", dificuldade);
                comando.Parameters.AddWithValue("@PortasParaVencer", PortasParaVencer);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu de errado ao adicionar a fase: " + ex.Message);
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
                string query = "SELECT IdFase FROM Fase WHERE Dificuldade = @Dificuldade";
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@Dificuldade", dificuldade);
                dificuldadeId = Convert.ToInt32(comando.ExecuteScalar());
            }

            return dificuldadeId;
        }
    }
}
