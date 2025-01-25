using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace portasTestes.Repository
{
    public class PortasRepository
    {
        private readonly string _connectionString;

        public PortasRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CriarTabela()
        {
            try
            {
                using (var conexao = new MySqlConnection(_connectionString))
                {
                    conexao.Open();
                    var comando = new MySqlCommand(@"
                CREATE TABLE IF NOT EXISTS Portas (
                    IdPorta INT AUTO_INCREMENT PRIMARY KEY,
                    Nome VARCHAR(255) NOT NULL,
                    ProbabilidadeInimigo DOUBLE NOT NULL DEFAULT 0.7,
                    ProbabilidadeBoss DOUBLE NOT NULL DEFAULT 0.2,
                    ProbabilidadeLoot DOUBLE NOT NULL DEFAULT 0.1
                );", conexao);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar a tabela: " + ex.Message);
            }
        }


    }
}
