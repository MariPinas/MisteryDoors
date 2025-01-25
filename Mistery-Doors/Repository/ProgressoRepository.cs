using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace portasTestes.Repository
{
    public class ProgressoRepository
    {
        private readonly string _connectionString;

        public ProgressoRepository(string connectionString)
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
                CREATE TABLE IF NOT EXISTS ProgressoId (
                    IdProgresso INT AUTO_INCREMENT PRIMARY KEY,
                    IdJogador INT NOT NULL,
                    FaseAtual INT NOT NULL,
                    PortasPassadas INT NOT NULL,
                    FOREIGN KEY (IdJogador) REFERENCES Jogadores(Id)
                );", conexao);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado ao criar a tabela: " + ex.Message);
            }
        }

        public int ObterOuCriarProgresso(int idJogador, int faseAtual, int portasPassadas)
        {
            try
            {
                using (var conexao = new MySqlConnection(_connectionString))
                {
                    conexao.Open();
                    var comando = new MySqlCommand(@"
                SELECT IdProgresso FROM ProgressoId WHERE IdJogador = @IdJogador;", conexao);

                    comando.Parameters.AddWithValue("@IdJogador", idJogador);
                    object result = comando.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);  // Retorna o ID já existente
                    }
                    var comandoInsert = new MySqlCommand(@"
                INSERT INTO ProgressoId (IdJogador, FaseAtual, PortasPassadas)
                VALUES (@IdJogador, @FaseAtual, @PortasPassadas);
                SELECT LAST_INSERT_ID();", conexao);

                    comandoInsert.Parameters.AddWithValue("@IdJogador", idJogador);
                    comandoInsert.Parameters.AddWithValue("@FaseAtual", faseAtual);
                    comandoInsert.Parameters.AddWithValue("@PortasPassadas", portasPassadas);

                    int novoIdProgresso = Convert.ToInt32(comandoInsert.ExecuteScalar());
                    return novoIdProgresso;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao obter/criar progresso: " + ex.Message);
                return 0;
            }
        }

        public List<(int IdProgresso, int IdJogador, int FaseAtual, int PortasPassadas)> ObterTodos()
        {
            var progressos = new List<(int, int, int, int)>();
            try
            {
                var conexao = new MySqlConnection(_connectionString);
                conexao.Open();
                var comando = new MySqlCommand("SELECT * FROM ProgressoId;", conexao);
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        progressos.Add((
                            reader.GetInt32("IdProgresso"),
                            reader.GetInt32("IdJogador"),
                            reader.GetInt32("FaseAtual"),
                            reader.GetInt32("PortasPassadas")
                        ));
                    }
                }
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado ao buscar os progressos: " + ex.Message);
            }

            return progressos;
        }

        public void Atualizar(int idProgresso, int faseAtual, int portasPassadas)
        {
            try
            {
                var conexao = new MySqlConnection(_connectionString);
                conexao.Open();
                var comando = new MySqlCommand(@"
                UPDATE ProgressoId
                SET FaseAtual = @FaseAtual, PortasPassadas = @PortasPassadas
                WHERE IdProgresso = @IdProgresso;", conexao);
                comando.Parameters.AddWithValue("@FaseAtual", faseAtual);
                comando.Parameters.AddWithValue("@PortasPassadas", portasPassadas);
                comando.Parameters.AddWithValue("@IdProgresso", idProgresso);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado ao atualizar o progresso: " + ex.Message);
            }
        }

        public void Deletar(int idProgresso)
        {
            try
            {
                var conexao = new MySqlConnection(_connectionString);
                conexao.Open();
                var comando = new MySqlCommand("DELETE FROM ProgressoId WHERE IdProgresso = @IdProgresso;", conexao);
                comando.Parameters.AddWithValue("@IdProgresso", idProgresso);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado ao deletar o progresso: " + ex.Message);
            }
        }
        public void IncrementarPortasPassadas(int idJogador)
        {
            try
            {
                using (var conexao = new MySqlConnection(_connectionString))
                {
                    conexao.Open();

                    var comando = new MySqlCommand(@"
                UPDATE ProgressoId 
                SET PortasPassadas = PortasPassadas + 1
                WHERE IdJogador = @IdJogador;", conexao);

                    comando.Parameters.AddWithValue("@IdJogador", idJogador);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar o contador de portas: " + ex.Message);
            }
        }
        public int ObterPortasPassadas(int idJogador)
        {
            try
            {
                using (var conexao = new MySqlConnection(_connectionString))
                {
                    conexao.Open();

                    var comando = new MySqlCommand(@"
                SELECT PortasPassadas 
                FROM ProgressoId 
                WHERE IdJogador = @IdJogador;", conexao);

                    comando.Parameters.AddWithValue("@IdJogador", idJogador);
                    int portasPassadas = Convert.ToInt32(comando.ExecuteScalar());

                    return portasPassadas;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao obter total de portas passadas: " + ex.Message);
                return 0;
            }
        }
    }
}
