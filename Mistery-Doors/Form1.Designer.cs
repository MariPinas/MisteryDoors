namespace Mistery_Maze
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.player1 = new Mistery_Maze.Player();
            this.SuspendLayout();
            // 
            // player1
            // 
            this.player1.Location = new System.Drawing.Point(209, 145);
            this.player1.Name = "player1";
            this.player1.Size = new System.Drawing.Size(92, 108);
            this.player1.TabIndex = 0;
            this.player1.Load += new System.EventHandler(this.player1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.player1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.a);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private Player player1;
    }
}

