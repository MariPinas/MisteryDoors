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
                ON DUPLICATE KEY UPDATE dificuldade = VALUES(dificuldade);
            ";

            //    string seedArmas = @"
            //    INSERT INTO Equipamentos (IdEquipamento, Nome, Raridade, Dano) VALUES
            //    (1, 'Graveto afiado', 'Normal', 6),
            //    (2, 'Arco Simples', 'Normal', 10),
            //    (3, 'Espada de Dima', 'Epico', 15),
            //    (4, 'Cajado Magico', 'Lendario', 25)
            //    ON DUPLICATE KEY UPDATE Nome = VALUES(Nome);
            //"
            //    ;
                MySqlCommand comando = new MySqlCommand(seedFases, conexao);
                comando.ExecuteNonQuery();

                //comando.CommandText = seedArmas;
                //comando.ExecuteNonQuery();
            }
        }
    }

}

