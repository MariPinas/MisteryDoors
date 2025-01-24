using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
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
                    FOREIGN KEY (IdJogador) REFERENCES Jogadores(IdJogador)
                );", conexao);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado ao criar a tabela: " + ex.Message);
            }
        }

        public void Adicionar(int idJogador, int faseAtual, int portasPassadas)
        {
            try
            {
                var conexao = new MySqlConnection(_connectionString);
                conexao.Open();
                var comando = new MySqlCommand(@"
                INSERT INTO ProgressoId (IdJogador, FaseAtual, PortasPassadas)
                VALUES (@IdJogador, @FaseAtual, @PortasPassadas);", conexao);
                comando.Parameters.AddWithValue("@IdJogador", idJogador);
                comando.Parameters.AddWithValue("@FaseAtual", faseAtual);
                comando.Parameters.AddWithValue("@PortasPassadas", portasPassadas);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado ao adicionar o progresso: " + ex.Message);
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
    }
}
