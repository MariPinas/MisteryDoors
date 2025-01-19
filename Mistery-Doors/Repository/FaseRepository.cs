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
                    PortarParaVencer INT NOT NULL
                );", conexao);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu de errado ao criar a tabela: " + ex.Message);
            }
        }

        public void Adicionar(string dificuldade, int portarParaVencer)
        {
            try
            {
                var conexao = new MySqlConnection(_connectionString);
                conexao.Open();
                var comando = new MySqlCommand("INSERT INTO Fases (Dificuldade, PortarParaVencer) VALUES (@Dificuldade, @PortarParaVencer);", conexao);
                comando.Parameters.AddWithValue("@Dificuldade", dificuldade);
                comando.Parameters.AddWithValue("@PortarParaVencer", portarParaVencer);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu de errado ao adicionar a fase: " + ex.Message);
            }
        }

        public List<(int IdFase, string Dificuldade, int PortarParaVencer)> ObterTodas()
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
                            reader.GetInt32("PortarParaVencer")
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

        public void Atualizar(int idFase, string dificuldade, int portarParaVencer)
        {
            try
            {
                var conexao = new MySqlConnection(_connectionString);
                conexao.Open();
                var comando = new MySqlCommand("UPDATE Fases SET Dificuldade = @Dificuldade, PortarParaVencer = @PortarParaVencer WHERE IdFase = @IdFase;", conexao);
                comando.Parameters.AddWithValue("@Dificuldade", dificuldade);
                comando.Parameters.AddWithValue("@PortarParaVencer", portarParaVencer);
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
    }
}
