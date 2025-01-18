using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace portasTestes {
    public partial class TelaPersonagem : Form {
        public TelaPersonagem() {
            this.Text = "Tela personagem";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;


            this.Resize += (s, e) => this.Invalidate();
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            // cores do figma
            Color[] cores = {
            ColorTranslator.FromHtml("#EFC981"),
            ColorTranslator.FromHtml("#EE9E69"),
            ColorTranslator.FromHtml("#AE6245")
        };


            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle, cores[0], cores[2], LinearGradientMode.Vertical)) {

                ColorBlend blend = new ColorBlend {
                    Colors = cores,
                    Positions = new float[] { 0.0f, 0.5f, 1.0f } // proporcas d cores
                };

                brush.InterpolationColors = blend;

                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }



        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e) {

        }

        //private void textBox1_Enter(object sender, EventArgs e) {
        //    if (textBox1.Text == "NICKNAME HERE") {
        //        textBox1.Text = ""; 
        //        textBox1.ForeColor = Color.Black; 
        //    }
        //}

        //private void textBox1_Leave(object sender, EventArgs e) {
        //    if (string.IsNullOrEmpty(textBox1.Text)) {
        //        textBox1.Text = "NICKNAME HERE";
        //        textBox1.ForeColor = Color.Gray; 
        //    }
        //}
    }
}


