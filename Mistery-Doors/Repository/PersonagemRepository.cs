using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
                        FOREIGN KEY (IdJogador) REFERENCES Jogadores(Id) ON DELETE CASCADE,
                        FOREIGN KEY (IdFase) REFERENCES Fases(IdFase));", conexao);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            //FOREIGN KEY(ProgressoId) REFERENCES Portas(IdPorta),
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado ao criar a tabela p: " + ex.Message);
            }
        }

        public Personagem AdicionarPersonagem(Personagem personagem)
        {
            try
            {
                using (MySqlConnection conexao = new MySqlConnection(_connectionString))
                {
                    conexao.Open();

                    string query = @"
            INSERT INTO Personagens (Name, IdFase, IdJogador, ProgressoId) 
            VALUES (@Nome, @IdFase, @IdJogador, @ProgressoId);";
                    MySqlCommand comando = new MySqlCommand(query, conexao);
                    comando.Parameters.AddWithValue("@IdFase", personagem.getFaseId());
                    comando.Parameters.AddWithValue("@Nome", personagem.getNomePersonagem());
                    comando.Parameters.AddWithValue("@IdJogador", personagem.getIdJogador());
                    comando.Parameters.AddWithValue("@ProgressoId", personagem.getProgressoId() > 0 ? personagem.getProgressoId() : (object)DBNull.Value);
                    comando.ExecuteNonQuery();

                    query = "SELECT LAST_INSERT_ID();";
                    comando = new MySqlCommand(query, conexao);
                    int personagemId = Convert.ToInt32(comando.ExecuteScalar());
                    personagem.setIdPersonagem(personagemId);

                    return personagem;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar personagem: " + ex.Message);
            }
            return null;
        }

        public void AtualizarProgressoNoPersonagem(int idPersonagem, int idProgresso)
        {
            try
            {
                using (var conexao = new MySqlConnection(_connectionString))
                {
                    conexao.Open();

                    var comando = new MySqlCommand(@"
                UPDATE Personagens 
                SET ProgressoId = @ProgressoId 
                WHERE IdPersonagem = @IdPersonagem;", conexao);

                    comando.Parameters.AddWithValue("@ProgressoId", idProgresso);
                    comando.Parameters.AddWithValue("@IdPersonagem", idPersonagem);

                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar progresso no personagem: " + ex.Message);
            }
        }

        public void AssociarPersonagemAoJogador(int personagemId, int jogadorId)
        {
            using (MySqlConnection conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open();

                //associa o jogador ao personagem
                string queryPersonagem = "UPDATE Personagens SET IdJogador = @IdJogador WHERE IdPersonagem = @PersonagemId;";
                MySqlCommand comandoPersonagem = new MySqlCommand(queryPersonagem, conexao);
                comandoPersonagem.Parameters.AddWithValue("@IdJogador", jogadorId);
                comandoPersonagem.Parameters.AddWithValue("@PersonagemId", personagemId);
                comandoPersonagem.ExecuteNonQuery();
            }
        }

        public void AtualizarDano(int idPersonagem, double danoPersonagem)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "UPDATE Personagens SET DanoPersonagem = @dano WHERE IdPersonagem = @id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@dano", danoPersonagem);
                    command.Parameters.AddWithValue("@id", idPersonagem);
                    Console.WriteLine("Dano atualizado");
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void AtualizarVida(int idPersonagem, double vidaPersonagem)
        {
            try
            {
                using (var conexao = new MySqlConnection(_connectionString))
                {
                    conexao.Open();
                    var comando = new MySqlCommand(@"
                    UPDATE Personagens
                    SET VidaPersonagem = @VidaPersonagem
                    WHERE IdPersonagem = @IdPersonagem;", conexao);
                    comando.Parameters.AddWithValue("@VidaPersonagem", vidaPersonagem);
                    comando.Parameters.AddWithValue("@IdPersonagem", idPersonagem);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado ao atualizar a vida do personagem: " + ex.Message);
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

        public Personagem ObterPersonagemPorJogador(int jogadorId)
        {
            try
            {
                using (var conexao = new MySqlConnection(_connectionString))
                {
                    conexao.Open();
                    string query = "SELECT * FROM Personagens WHERE IdJogador = @jogadorId LIMIT 1;";

                    using (var comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@jogadorId", jogadorId);
                        using (var reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var personagem = new Personagem(
                                    reader["Name"].ToString(),
                                    Convert.ToInt32(reader["IdFase"]),
                                    Convert.ToInt32(reader["IdJogador"])
                                );

                                personagem.setIdPersonagem(Convert.ToInt32(reader["IdPersonagem"]));
                                personagem.setVidaPersonagem(Convert.ToDouble(reader["VidaPersonagem"]));
                                personagem.setDanoPersonagem(Convert.ToDouble(reader["DanoPersonagem"]));
                                if (!reader.IsDBNull(reader.GetOrdinal("ProgressoId")))
                                {
                                    personagem.setProgresso(Convert.ToInt32(reader["ProgressoId"]));
                                }

                                return personagem; 
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar personagem: {ex.Message}");
            }

            return null;
        }

        public void AtualizarFasePersonagem(int idPersonagem, int faseId)
        {
            try
            {
                using (var conexao = new MySqlConnection(_connectionString))
                {
                    conexao.Open();

                    string query = @"
                        UPDATE Personagens
                        SET IdFase = @FaseId
                        WHERE IdPersonagem = @IdPersonagem;";

                    using (var comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@FaseId", faseId);
                        comando.Parameters.AddWithValue("@IdPersonagem", idPersonagem);

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar IdFase do personagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
