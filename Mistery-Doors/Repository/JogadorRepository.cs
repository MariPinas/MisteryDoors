using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
                    Username VARCHAR(255) NOT NULL,
                    Senha VARCHAR(255) NOT NULL,
                    PersonagemId INT,
                    Vitorias INT DEFAULT 0,
                    Derrotas INT DEFAULT 0,
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

        public void Adicionar(string username, string senha)
        {
            try
            {
                var conexao = new MySqlConnection(_connectionString);
                conexao.Open();
                var comando = new MySqlCommand("INSERT INTO Jogadores (Username, Senha) VALUES (@Username, @Senha);", conexao);
                comando.Parameters.AddWithValue("@Username", username);
                comando.Parameters.AddWithValue("@Senha", senha);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado ao adicionar o jogador: " + ex.Message);
            }
        }

        public void AssociarPersonagemAoJogador(int idJogador, int personagemId) {
            Atualizar(idJogador, null, null, 0, 0, personagemId);   
        }

        public bool VerificarUsuarioExistente(string username, string senha) {
            MySqlConnection conexao = null;
            try {
                conexao = new MySqlConnection(_connectionString);
                conexao.Open();

                var comando = new MySqlCommand("SELECT COUNT(*) FROM Jogadores WHERE Username = @Username AND Senha = @Senha;", conexao);
                comando.Parameters.AddWithValue("@Username", username);
                comando.Parameters.AddWithValue("@Senha", senha);

                return Convert.ToInt32(comando.ExecuteScalar()) > 0;


            } catch (Exception ex) {
                MessageBox.Show("Erro ao verificar usuário: " + ex.Message);
                return false;
            } finally {
                if (conexao != null) {
                    conexao.Close();
                }
            }
        }

        public List<(int IdJogador, string Username, int Vitorias, int Derrotas, int? PersonagemId)> ObterTodos() {
            var jogadores = new List<(int, string, int, int, int?)>();
            MySqlConnection conexao = null;
            try {
                conexao = new MySqlConnection(_connectionString);
                conexao.Open();
                var comando = new MySqlCommand("SELECT * FROM Jogadores;", conexao);
                var reader = comando.ExecuteReader();
                while (reader.Read()) {
                    jogadores.Add((
                        reader.GetInt32("IdJogador"),
                        reader.GetString("Username"),
                        reader.GetInt32("Vitorias"),
                        reader.GetInt32("Derrotas"),
                        reader.IsDBNull(reader.GetOrdinal("PersonagemId")) ? (int?)null : reader.GetInt32("PersonagemId")
                    ));
                }
            } catch (Exception ex) {
                MessageBox.Show("Erro ao obter jogadores: " + ex.Message);
            } finally {
                if (conexao != null) {
                    conexao.Close();
                }
            }

            return jogadores;
        }

        public void Atualizar(int idJogador, string username, string senha, int vitorias, int derrotas, int? personagemId) {
            MySqlConnection conexao = null;
            try {
                conexao = new MySqlConnection(_connectionString);
                conexao.Open();
                var comando = new MySqlCommand(@"
                    UPDATE Jogadores 
                    SET Username = @Username, Senha = @Senha, Vitorias = @Vitorias, Derrotas = @Derrotas, PersonagemId = @PersonagemId 
                    WHERE IdJogador = @IdJogador;", conexao);
                comando.Parameters.AddWithValue("@Username", username);
                comando.Parameters.AddWithValue("@Senha", senha);
                comando.Parameters.AddWithValue("@Vitorias", vitorias);
                comando.Parameters.AddWithValue("@Derrotas", derrotas);
                comando.Parameters.AddWithValue("@PersonagemId", personagemId.HasValue ? (object)personagemId.Value : DBNull.Value);
                comando.Parameters.AddWithValue("@IdJogador", idJogador);
                comando.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show("Erro ao atualizar jogador: " + ex.Message);
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
