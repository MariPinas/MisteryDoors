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
                if (VerificarUsernameExistente(username)) {
                    MessageBox.Show("Esse nome de usuário já está em uso. Escolha outro.");
                    return;
                }

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
                conexao?.Close();
            }
        }

        public bool VerificarUsernameExistente(string username) {
            MySqlConnection conexao = null;
            try {
                conexao = new MySqlConnection(_connectionString);
                conexao.Open();

                var comando = new MySqlCommand("SELECT COUNT(*) FROM Jogadores WHERE Username = @Username", conexao);
                comando.Parameters.AddWithValue("@Username", username);

                int count = Convert.ToInt32(comando.ExecuteScalar());

                //se count>0 existe esse username
                return count > 0;
            } catch (Exception ex) {
                MessageBox.Show("Erro ao verificar username: " + ex.Message);
                return false;
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
                conexao?.Close();
            }

            return jogadores;
        }

        public void Atualizar(int idJogador, string username = null, string senha = null, int? vitorias = null, int? derrotas = null, int? personagemId = null) {
            MySqlConnection conexao = null;
            //esse att eh tipo aquele do anisio que ele deu nas ultimas aulas, que eh flexivel e vai somando no query
            try {
                conexao = new MySqlConnection(_connectionString);
                conexao.Open();

                var query = "UPDATE Jogadores SET ";
                //vai add os parametros nessa lista
                var parametros = new List<MySqlParameter>();

                //dai adiciona conforme os parametros que nao vieram nulos
                if (!string.IsNullOrEmpty(username)) {
                    query += "Username = @Username, ";
                    parametros.Add(new MySqlParameter("@Username", username));
                }

                if (!string.IsNullOrEmpty(senha)) {
                    query += "Senha = @Senha, ";
                    parametros.Add(new MySqlParameter("@Senha", senha));
                }

                if (vitorias.HasValue) {
                    query += "Vitorias = @Vitorias, ";
                    parametros.Add(new MySqlParameter("@Vitorias", vitorias.Value));
                }

                if (derrotas.HasValue) {
                    query += "Derrotas = @Derrotas, ";
                    parametros.Add(new MySqlParameter("@Derrotas", derrotas.Value));
                }

                if (personagemId.HasValue) {
                    query += "PersonagemId = @PersonagemId, ";
                    parametros.Add(new MySqlParameter("@PersonagemId", personagemId.Value));
                }
                query = query.TrimEnd(',', ' ') + " WHERE IdJogador = @IdJogador;";


                parametros.Add(new MySqlParameter("@IdJogador", idJogador));
                var comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddRange(parametros.ToArray());
                comando.ExecuteNonQuery();

            } catch (Exception ex) {
                MessageBox.Show("Erro ao atualizar jogador: " + ex.Message);
            } finally {
                conexao?.Close();
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

        public int getIdJogador(string username) {
            MySqlConnection conexao = null;
            try {
                conexao = new MySqlConnection(_connectionString);
                conexao.Open();
                var comando = new MySqlCommand("SELECT IdJogador FROM Jogadores WHERE Username = @Username;", conexao);
                comando.Parameters.AddWithValue("@Username", username);

                var reader = comando.ExecuteReader();
                if (reader.Read()) {
                    return reader.GetInt32("IdJogador");
                } else {
                    return -1;
                }
            } catch (Exception ex) {
                MessageBox.Show("Erro ao obter o ID do jogador: " + ex.Message);
                return -1;
            } finally {
                conexao?.Close();
            }
        }

    }
}
