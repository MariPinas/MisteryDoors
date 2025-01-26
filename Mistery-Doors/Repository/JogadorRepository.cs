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
                    Id INT AUTO_INCREMENT PRIMARY KEY,
                    Username VARCHAR(255) NOT NULL,
                    Senha VARCHAR(255) NOT NULL,
                    Vitorias INT DEFAULT 0,
                    Derrotas INT DEFAULT 0
                );", conexao);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado ao criar a tabela j: " + ex.Message);
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

        public Jogador GetJogadorPorUsername(string username) {
            using (MySqlConnection conexao = new MySqlConnection(_connectionString)) {
                conexao.Open();

                var comando = new MySqlCommand("SELECT Id, Username, Senha FROM Jogadores WHERE Username = @Username;", conexao);
                comando.Parameters.AddWithValue("@Username", username);

                using (var reader = comando.ExecuteReader()) {
                    if (reader.Read()) {
                        return new Jogador {
                            IdJogador = reader.GetInt32("Id"),
                            Username = reader.GetString("Username"),
                            Senha = reader.GetString("Senha")
                        };
                    }
                }
            }
            return null;
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
                        reader.GetInt32("Id"),
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

        public void Atualizar(int idJogador, string username = null, string senha = null, int? vitorias = null, int? derrotas = null) {
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
          
                query = query.TrimEnd(',', ' ') + " WHERE Id = @Id;";


                parametros.Add(new MySqlParameter("@Id", idJogador));
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
                var comando = new MySqlCommand("DELETE FROM Jogadores WHERE Id = @Id;", conexao);
                comando.Parameters.AddWithValue("@Id", idJogador);
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
                var comando = new MySqlCommand("SELECT Id FROM Jogadores WHERE Username = @Username;", conexao);
                comando.Parameters.AddWithValue("@Username", username);

                var reader = comando.ExecuteReader();
                if (reader.Read()) {
                    return reader.GetInt32("Id");
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


        public List<int> ObterFasesDesbloqueadas(int jogadorId)
        {
            List<int> fasesDesbloqueadas = new List<int>();

            try
            {
                using (var conexao = new MySqlConnection(_connectionString))
                {
                    conexao.Open();
                    string query = "SELECT DISTINCT FaseAtual FROM ProgressoId WHERE IdJogador = @jogadorId";
                    using (var comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@jogadorId", jogadorId);

                        using (var reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                fasesDesbloqueadas.Add(Convert.ToInt32(reader["FaseAtual"]));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar fases desbloqueadas: {ex.Message}");
            }

            return fasesDesbloqueadas;
        }



        public void DesbloquearFase(int jogadorId, int novaFaseId)
        {
            try
            {
                using (var conexao = new MySqlConnection(_connectionString))
                {
                    conexao.Open();

                    string verificarQuery = "SELECT COUNT(*) FROM ProgressoId WHERE IdJogador = @jogadorId AND FaseAtual = @faseId";
                    using (var verificarComando = new MySqlCommand(verificarQuery, conexao))
                    {
                        verificarComando.Parameters.AddWithValue("@jogadorId", jogadorId);
                        verificarComando.Parameters.AddWithValue("@faseId", novaFaseId);

                        int count = Convert.ToInt32(verificarComando.ExecuteScalar());
                        if (count > 0) return; 
                    }

                    string query = "INSERT INTO ProgressoId (IdJogador, FaseAtual, PortasPassadas) VALUES (@jogadorId, @faseId, 0)";
                    using (var comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@jogadorId", jogadorId);
                        comando.Parameters.AddWithValue("@faseId", novaFaseId);
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao desbloquear nova fase: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int GetVitorias(int idJogador)
        {
            int vitorias = 0;
            try
            {
                using (var conexao = new MySqlConnection(_connectionString))
                {
                    conexao.Open();
                    var query = "SELECT Vitorias FROM Jogadores WHERE Id = @IdJogador";
                    var comando = new MySqlCommand(query, conexao);
                    comando.Parameters.AddWithValue("@IdJogador", idJogador);

                    object result = comando.ExecuteScalar();
                    if (result != null)
                    {
                        vitorias = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao obter vitórias: " + ex.Message);
            }

            return vitorias;
        }
        public int getDerrotas(int idJogador)
        {
            int derrotas = 0;
            try
            {
                using (var conexao = new MySqlConnection(_connectionString))
                {
                    conexao.Open();
                    var query = "SELECT Derrotas FROM Jogadores WHERE Id = @IdJogador";
                    var comando = new MySqlCommand(query, conexao);
                    comando.Parameters.AddWithValue("@IdJogador", idJogador);

                    object result = comando.ExecuteScalar();
                    if (result != null)
                    {
                        derrotas = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao obter Derrotas: " + ex.Message);
            }

            return derrotas;
        }
    }
}
