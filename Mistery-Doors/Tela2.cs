using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mistery_Maze
{
    internal class Tela2 : UserControl
    {
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;

        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Mistery_Maze.Properties.Resources.tela2;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1920, 1080);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Mistery_Maze.Properties.Resources.btnFacil;
            this.pictureBox2.Location = new System.Drawing.Point(1481, 279);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(305, 97);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Tela2
            // 
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Tela2";
            this.Size = new System.Drawing.Size(1920, 1080);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }
        public Tela2()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill; // vai ocupar toda a tela possivel com o usercontrol
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Point cursorPosition = pictureBox1.PointToClient(Cursor.Position);
            Rectangle clickArea = new Rectangle(1490, 287, 283, 71);

            if (clickArea.Contains(cursorPosition))
            {
                MessageBox.Show("NIVEL FACIL!");

                Form1 form1 = new Form1();
                form1.Show();

                Form mainForm = this.FindForm();
                mainForm.Hide();
            }
        }
    }
}