using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace portasTestes {
    public class BDSeeder {
        public void Seed(string connectionString) { //gente isso eh para gerar a semente automatica pre estabelecida no banco das fases e armas
            using (MySqlConnection conexao = new MySqlConnection(connectionString)) {
                conexao.Open();

                string seedFases = @"
                    INSERT INTO Fases (IdFase, dificuldade) VALUES
                        (1, 'facil'),
                        (2, 'medio'),
                        (3, 'dificil'),
                        (4, 'extremo')
                        ON DUPLICATE KEY UPDATE dificuldade = VALUES(dificuldade);";

                MySqlCommand comando = new MySqlCommand(seedFases, conexao);
                comando.ExecuteNonQuery();

            }
        }
    }

}

