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
                    ArmaId INT,
                    ProgressoId INT,
                    DificuldadeId INT,
                    FOREIGN KEY (ArmaId) REFERENCES Equipamentos(IdEquipamento),
                    FOREIGN KEY (ProgressoId) REFERENCES Portas(IdPorta),
                    FOREIGN KEY (DificuldadeId) REFERENCES Fases(IdFase)
                );", conexao);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado ao criar a tabela: " + ex.Message);
            }
        }

        public int AdicionarPersonagem(Personagem personagem) {
            using (MySqlConnection conexao = new MySqlConnection(_connectionString)) {
                conexao.Open();
                string query = "INSERT INTO Personagens (Name, DificuldadeId) VALUES (@Nome, @IdFase);";
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@IdFase", personagem.getFaseId());
                comando.Parameters.AddWithValue("@Nome", personagem.getNomePersonagem());  // Assumindo que personagem tem um Nome

                comando.ExecuteNonQuery();

                query = "SELECT LAST_INSERT_ID();";
                comando = new MySqlCommand(query, conexao);
                return Convert.ToInt32(comando.ExecuteScalar());  // Retorna o Id do Personagem criado
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

        public void Atualizar(int idPersonagem, string name, double vidaPersonagem, double danoPersonagem, int? armaId, int? progressoId, int? dificuldadeId)
        {
            try
            {
                var conexao = new MySqlConnection(_connectionString);
                conexao.Open();
                var comando = new MySqlCommand(@"
                UPDATE Personagens
                SET Name = @Name, VidaPersonagem = @VidaPersonagem, DanoPersonagem = @DanoPersonagem,
                    ArmaId = @ArmaId, ProgressoId = @ProgressoId, DificuldadeId = @DificuldadeId
                WHERE IdPersonagem = @IdPersonagem;", conexao);
                comando.Parameters.AddWithValue("@Name", name);
                comando.Parameters.AddWithValue("@VidaPersonagem", vidaPersonagem);
                comando.Parameters.AddWithValue("@DanoPersonagem", danoPersonagem);
                comando.Parameters.AddWithValue("@ArmaId", armaId.HasValue ? (object)armaId.Value : DBNull.Value);
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
