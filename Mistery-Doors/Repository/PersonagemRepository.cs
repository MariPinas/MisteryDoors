using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace portasTestes.Repository
{
    public class PersonagemRepository
    {
        private readonly string _connectionString;

        public PersonagemRepository(string connectionString)
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
                CREATE TABLE IF NOT EXISTS Personagens (
                IdPersonagem INT AUTO_INCREMENT PRIMARY KEY,
                Name VARCHAR(255) NOT NULL,
                VidaPersonagem DOUBLE NOT NULL DEFAULT 3,
                DanoPersonagem DOUBLE NOT NULL DEFAULT 5,
                IdJogador INT NOT NULL,
                ProgressoId INT,
                IdFase INT,
                FOREIGN KEY (IdJogador) REFERENCES Jogadores(Id),
                FOREIGN KEY (ProgressoId) REFERENCES Portas(IdPorta),
                FOREIGN KEY (IdFase) REFERENCES Fases(IdFase)
                );", conexao);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado ao criar a tabela p: " + ex.Message);
            }
        }

        public Personagem AdicionarPersonagem(Personagem personagem) {
            using (MySqlConnection conexao = new MySqlConnection(_connectionString)) {
                conexao.Open();

                string query = "INSERT INTO Personagens (Name, IdFase, IdJogador) VALUES (@Nome, @IdFase, @IdJogador);";
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@IdFase", personagem.getFaseId());
                comando.Parameters.AddWithValue("@Nome", personagem.getNomePersonagem());
                comando.Parameters.AddWithValue("@IdJogador", personagem.getIdJogador());
                comando.ExecuteNonQuery();

                query = "SELECT LAST_INSERT_ID();";
                comando = new MySqlCommand(query, conexao);
                int personagemId = Convert.ToInt32(comando.ExecuteScalar());
                personagem.setIdPersonagem(personagemId);
                personagem.setNomePersonagem(personagem.getNomePersonagem());
                personagem.setIdJogador(personagem.getIdJogador());

                return personagem;
            }
        }

        public void AssociarPersonagemAoJogador(int personagemId, int jogadorId) {
            using (MySqlConnection conexao = new MySqlConnection(_connectionString)) {
                conexao.Open();

                //associa o jogador ao personagem
                string queryPersonagem = "UPDATE Personagens SET IdJogador = @IdJogador WHERE IdPersonagem = @PersonagemId;";
                MySqlCommand comandoPersonagem = new MySqlCommand(queryPersonagem, conexao);
                comandoPersonagem.Parameters.AddWithValue("@IdJogador", jogadorId);
                comandoPersonagem.Parameters.AddWithValue("@PersonagemId", personagemId);
                comandoPersonagem.ExecuteNonQuery();
            }
        }


        public List<(int IdPersonagem, string Name, double VidaPersonagem, double DanoPersonagem, int? ArmaId, int? ProgressoId, int? DificuldadeId)> ObterTodos()
        {
            var personagens = new List<(int, string, double, double, int?, int?, int?)>();
            try
            {
                var conexao = new MySqlConnection(_connectionString);
                conexao.Open();
                var comando = new MySqlCommand("SELECT * FROM Personagens;", conexao);
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        personagens.Add((
                            reader.GetInt32("IdPersonagem"),
                            reader.GetString("Name"),
                            reader.GetDouble("VidaPersonagem"),
                            reader.GetDouble("DanoPersonagem"),
                            reader.IsDBNull(reader.GetOrdinal("ArmaId")) ? (int?)null : reader.GetInt32("ArmaId"),
                            reader.IsDBNull(reader.GetOrdinal("ProgressoId")) ? (int?)null : reader.GetInt32("ProgressoId"),
                            reader.IsDBNull(reader.GetOrdinal("DificuldadeId")) ? (int?)null : reader.GetInt32("DificuldadeId")
                        ));
                    }
                }
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado ao buscar os personagens: " + ex.Message);
            }

            return personagens;
        }

        public void AtualizarDano(int idPersonagem, double danoPersonagem) {
            using (var connection = new MySqlConnection(_connectionString)) {
                connection.Open();
                var query = "UPDATE Personagens SET DanoPersonagem = @dano WHERE IdPersonagem = @id";
                using (var command = new MySqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@dano", danoPersonagem);
                    command.Parameters.AddWithValue("@id", idPersonagem);
                    Console.WriteLine("Dano atualizado");
                    command.ExecuteNonQuery();
                connection.Close();
                }
            }
        }

        public void AtualizarVida(int idPersonagem, double vidaPersonagem) {
            try {
                using (var conexao = new MySqlConnection(_connectionString)) {
                    conexao.Open();
                    var comando = new MySqlCommand(@"
                    UPDATE Personagens
                    SET VidaPersonagem = @VidaPersonagem
                    WHERE IdPersonagem = @IdPersonagem;", conexao);
                    comando.Parameters.AddWithValue("@VidaPersonagem", vidaPersonagem);
                    comando.Parameters.AddWithValue("@IdPersonagem", idPersonagem);
                    comando.ExecuteNonQuery();
                }
            } catch (Exception ex) {
                MessageBox.Show("Algo deu errado ao atualizar a vida do personagem: " + ex.Message);
            }
        }

        public void Atualizar(int idPersonagem, string name, double vidaPersonagem, double danoPersonagem, int? progressoId, int? dificuldadeId)
        {
            try
            {
                var conexao = new MySqlConnection(_connectionString);
                conexao.Open();
                var comando = new MySqlCommand(@"
                UPDATE Personagens
                SET Name = @Name, VidaPersonagem = @VidaPersonagem, DanoPersonagem = @DanoPersonagem, 
                ProgressoId = @ProgressoId, DificuldadeId = @DificuldadeId
                WHERE IdPersonagem = @IdPersonagem;", conexao);
                comando.Parameters.AddWithValue("@Name", name);
                comando.Parameters.AddWithValue("@VidaPersonagem", vidaPersonagem);
                comando.Parameters.AddWithValue("@DanoPersonagem", danoPersonagem);
                comando.Parameters.AddWithValue("@ProgressoId", progressoId.HasValue ? (object)progressoId.Value : DBNull.Value);
                comando.Parameters.AddWithValue("@DificuldadeId", dificuldadeId.HasValue ? (object)dificuldadeId.Value : DBNull.Value);
                comando.Parameters.AddWithValue("@IdPersonagem", idPersonagem);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado ao atualizar o personagem: " + ex.Message);
            }
        }

        public void Deletar(int idPersonagem)
        {
            try
            {
                var conexao = new MySqlConnection(_connectionString);
                conexao.Open();
                var comando = new MySqlCommand("DELETE FROM Personagens WHERE IdPersonagem = @IdPersonagem;", conexao);
                comando.Parameters.AddWithValue("@IdPersonagem", idPersonagem);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado ao deletar o personagem: " + ex.Message);
            }
        }
    }
}
