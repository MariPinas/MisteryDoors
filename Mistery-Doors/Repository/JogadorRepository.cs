using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace portasTestes.Repository
{
    public class JogadorRepository
    {
        private readonly string _connectionString;

        public JogadorRepository(string connectionString)
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
                CREATE TABLE IF NOT EXISTS Jogadores (
                    IdJogador INT AUTO_INCREMENT PRIMARY KEY,
                    Nome VARCHAR(255) NOT NULL,
                    Vidas INT NOT NULL DEFAULT 3,
                    PersonagemId INT,
                    FOREIGN KEY (PersonagemId) REFERENCES Personagens(IdPersonagem)
                );", conexao);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado ao criar a tabela: " + ex.Message);
            }
        }

        public void Adicionar(string nome, int vidas, int? personagemId)
        {
            try
            {
                var conexao = new MySqlConnection(_connectionString);
                conexao.Open();
                var comando = new MySqlCommand("INSERT INTO Jogadores (Nome, Vidas, PersonagemId) VALUES (@Nome, @Vidas, @PersonagemId);", conexao);
                comando.Parameters.AddWithValue("@Nome", nome);
                comando.Parameters.AddWithValue("@Vidas", vidas);
                comando.Parameters.AddWithValue("@PersonagemId", personagemId.HasValue ? (object)personagemId.Value : DBNull.Value);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado ao adicionar o jogador: " + ex.Message);
            }
        }

        public List<(int IdJogador, string Nome, int Vidas, int? PersonagemId)> ObterTodos()
        {
            var jogadores = new List<(int, string, int, int?)>();
            try
            {
                var conexao = new MySqlConnection(_connectionString);
                conexao.Open();
                var comando = new MySqlCommand("SELECT * FROM Jogadores;", conexao);
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        jogadores.Add((
                            reader.GetInt32("IdJogador"),
                            reader.GetString("Nome"),
                            reader.GetInt32("Vidas"),
                            reader.IsDBNull(reader.GetOrdinal("PersonagemId")) ? (int?)null : reader.GetInt32("PersonagemId")
                        ));
                    }
                }
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado ao buscar os jogadores: " + ex.Message);
            }

            return jogadores;
        }

        public void Atualizar(int idJogador, string nome, int vidas, int? personagemId)
        {
            try
            {
                var conexao = new MySqlConnection(_connectionString);
                conexao.Open();
                var comando = new MySqlCommand("UPDATE Jogadores SET Nome = @Nome, Vidas = @Vidas, PersonagemId = @PersonagemId WHERE IdJogador = @IdJogador;", conexao);
                comando.Parameters.AddWithValue("@Nome", nome);
                comando.Parameters.AddWithValue("@Vidas", vidas);
                comando.Parameters.AddWithValue("@PersonagemId", personagemId.HasValue ? (object)personagemId.Value : DBNull.Value);
                comando.Parameters.AddWithValue("@IdJogador", idJogador);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado ao atualizar o jogador: " + ex.Message);
            }
        }

        public void Deletar(int idJogador)
        {
            try
            {
                var conexao = new MySqlConnection(_connectionString);
                conexao.Open();
                var comando = new MySqlCommand("DELETE FROM Jogadores WHERE IdJogador = @IdJogador;", conexao);
                comando.Parameters.AddWithValue("@IdJogador", idJogador);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado ao deletar o jogador: " + ex.Message);
            }
        }
    }
}
