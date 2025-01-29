using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace portasTestes.Repository
{
    public class FaseRepository
    {
        private readonly string _connectionString;

        public FaseRepository(string connectionString)
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
                CREATE TABLE IF NOT EXISTS Fases (
                IdFase INT AUTO_INCREMENT PRIMARY KEY,
                dificuldade VARCHAR(255) NOT NULL
                );", conexao);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu de errado ao criar a tabela: " + ex.Message);
            }
        }


        public int ObterIdDificuldade(string dificuldade) {
            int idFase = -1; //-1 pois se nao encontrar o id, retorna -1

            try {
                using (MySqlConnection conexao = new MySqlConnection(_connectionString)) {
                    conexao.Open();

                    string query = "SELECT IdFase FROM Fases WHERE Dificuldade = @Dificuldade";
                    using (MySqlCommand comando = new MySqlCommand(query, conexao)) {
                        comando.Parameters.AddWithValue("@Dificuldade", dificuldade);

                        object resultado = comando.ExecuteScalar();
                        if (resultado != null) {
                            idFase = Convert.ToInt32(resultado);
                        }
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine($"Erro ao obter o ID da dificuldade '{dificuldade}': {ex.Message}");
            }

            return idFase;
        }
    }
}
