using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mistery_Maze
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Form formInicial = new Form
            {
                Text = "Tela 2",
                Size = new System.Drawing.Size(1920, 1080)
            };
            Tela2 inicioControl = new Tela2();
            formInicial.Controls.Add(inicioControl);
            Application.Run(formInicial);
        }
    }
}
