using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using portasTestes.Repository;

namespace portasTestes
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string connectionString = "server=localhost;uid=root;pwd=admin;database=mistery_doors";

            IniciaDataBase(connectionString);

            BDSeeder bdseed = new BDSeeder();
            bdseed.Seed(connectionString);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TelaInicio());
        

        }

        public static void IniciaDataBase(string connectionString)
        {
            try
            {
                //var equipamentosRepo = new EquipamentoRepository(connectionString);
                //equipamentosRepo.CriarTabela();
                var fasesRepo = new FaseRepository(connectionString);
                fasesRepo.CriarTabela();
                //var historicoRepo = new HistoricoRepository(connectionString);
                //historicoRepo.CriarTabela();
                //var portasRepo = new PortasRepository(connectionString);
                //portasRepo.CriarTabela();
                var jogadoresRepo = new JogadorRepository(connectionString);
                jogadoresRepo.CriarTabela();
                //var inimigoRepo = new InimigoRepository(connectionString);
                //inimigoRepo.CriarTabela();
                var personagensRepo = new PersonagemRepository(connectionString);
                personagensRepo.CriarTabela();
                var progressoRepo = new ProgressoRepository(connectionString);
                progressoRepo.CriarTabela();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao inicializar o banco de dados: " + ex.Message);
            }
        }
    }
}
