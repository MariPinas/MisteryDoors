using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace portasTestes.Repository
{
    internal class EquipamentoRepository
    {
        private readonly string _connectionString;

        public EquipamentoRepository(string connectionString)
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
                    CREATE TABLE IF NOT EXISTS Equipamentos (
                        IdEquipamento INT AUTO_INCREMENT PRIMARY KEY,
                        Nome VARCHAR(255) NOT NULL,
                        Raridade VARCHAR(255) NOT NULL,
                        Dano INT NOT NULL
                    );", conexao);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex) {
                 MessageBox.Show("Algo deu de errado ao criar a tabela: " +  ex.Message);   
            }
        }

        public void Adicionar(string nome, string raridade, int dano)
        {
            try
            {
                var conexao = new MySqlConnection(_connectionString);
                conexao.Open();
                var comando = new MySqlCommand("INSERT INTO Equipamentos (Nome, Raridade, Dano) VALUES (@Nome, @Raridade, @Dano);", conexao);
                comando.Parameters.AddWithValue("@Nome", nome);
                comando.Parameters.AddWithValue("@Raridade", raridade);
                comando.Parameters.AddWithValue("@Dano", dano);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu de errado ao adicionar o equipamento: " + ex.Message);
            }
        }

        public List<(int IdEquipamento, string Nome, string Raridade, int Dano)> ObterTodos()
        {
            var equipamentos = new List<(int, string, string, int)>();
            try
            {
                var conexao = new MySqlConnection(_connectionString);
                conexao.Open();
                var comando = new MySqlCommand("SELECT * FROM Equipamentos;", conexao);
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        equipamentos.Add((
                            reader.GetInt32("IdEquipamento"),
                            reader.GetString("Nome"),
                            reader.GetString("Raridade"),
                            reader.GetInt32("Dano")
                        ));
                    }
                }
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu de errado ao buscar os equipamentos: " + ex.Message);
            }

            return equipamentos;
        }

        public void Atualizar(int idEquipamento, string nome, string raridade, int dano)
        {
            try
            {
                var conexao = new MySqlConnection(_connectionString);
                conexao.Open();
                var comando = new MySqlCommand("UPDATE Equipamentos SET Nome = @Nome, Raridade = @Raridade, Dano = @Dano WHERE IdEquipamento = @IdEquipamento;", conexao);
                comando.Parameters.AddWithValue("@Nome", nome);
                comando.Parameters.AddWithValue("@Raridade", raridade);
                comando.Parameters.AddWithValue("@Dano", dano);
                comando.Parameters.AddWithValue("@IdEquipamento", idEquipamento);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu de errado ao atualizar o equipamento: " + ex.Message);
            }
        }

        public void Deletar(int idEquipamento)
        {
            try
            {
                var conexao = new MySqlConnection(_connectionString);
                conexao.Open();
                var comando = new MySqlCommand("DELETE FROM Equipamentos WHERE IdEquipamento = @IdEquipamento;", conexao);
                comando.Parameters.AddWithValue("@IdEquipamento", idEquipamento);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu de errado ao deletar o equipamento: " + ex.Message);
            }
        }
    }
}
