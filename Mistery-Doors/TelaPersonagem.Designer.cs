namespace portasTestes {
    partial class TelaPersonagem {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txtNickname = new System.Windows.Forms.TextBox();
            this.botaoJogar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFacil = new System.Windows.Forms.Button();
            this.btnMedio = new System.Windows.Forms.Button();
            this.btnDificil = new System.Windows.Forms.Button();
            this.btnExtremo = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnPerfil = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblNomePersonagem = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNickname
            // 
            this.txtNickname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(55)))), ((int)(((byte)(39)))));
            this.txtNickname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNickname.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNickname.ForeColor = System.Drawing.Color.SandyBrown;
            this.txtNickname.Location = new System.Drawing.Point(292, 345);
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.Size = new System.Drawing.Size(221, 43);
            this.txtNickname.TabIndex = 1;
            this.txtNickname.Text = "NICKNAME HERE";
            this.txtNickname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNickname.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // botaoJogar
            // 
            this.botaoJogar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.botaoJogar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoJogar.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoJogar.ForeColor = System.Drawing.Color.SandyBrown;
            this.botaoJogar.Location = new System.Drawing.Point(592, 418);
            this.botaoJogar.Name = "botaoJogar";
            this.botaoJogar.Size = new System.Drawing.Size(213, 33);
            this.botaoJogar.TabIndex = 5;
            this.botaoJogar.Text = "JOGAR! ➜";
            this.botaoJogar.UseVisualStyleBackColor = false;
            this.botaoJogar.Click += new System.EventHandler(this.botaoJogar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(189)))), ((int)(((byte)(128)))));
            this.label1.Font = new System.Drawing.Font("Impact", 8.25F);
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(81, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "0 VITORIAS";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(189)))), ((int)(((byte)(128)))));
            this.label2.Font = new System.Drawing.Font("Impact", 8.25F);
            this.label2.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label2.Location = new System.Drawing.Point(85, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "0 MORTES";
            // 
            // btnFacil
            // 
            this.btnFacil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(189)))), ((int)(((byte)(128)))));
            this.btnFacil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFacil.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacil.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnFacil.Location = new System.Drawing.Point(621, 123);
            this.btnFacil.Name = "btnFacil";
            this.btnFacil.Size = new System.Drawing.Size(129, 36);
            this.btnFacil.TabIndex = 8;
            this.btnFacil.Text = "NIVEL FACIL";
            this.btnFacil.UseVisualStyleBackColor = false;
            this.btnFacil.Click += new System.EventHandler(this.btnFacil_Click);
            // 
            // btnMedio
            // 
            this.btnMedio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(189)))), ((int)(((byte)(128)))));
            this.btnMedio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedio.Font = new System.Drawing.Font("Impact", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedio.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnMedio.Location = new System.Drawing.Point(621, 181);
            this.btnMedio.Name = "btnMedio";
            this.btnMedio.Size = new System.Drawing.Size(129, 36);
            this.btnMedio.TabIndex = 9;
            this.btnMedio.Text = "NIVEL MEDIO";
            this.btnMedio.UseVisualStyleBackColor = false;
            this.btnMedio.Click += new System.EventHandler(this.btnMedio_Click);
            // 
            // btnDificil
            // 
            this.btnDificil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(189)))), ((int)(((byte)(128)))));
            this.btnDificil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDificil.Font = new System.Drawing.Font("Impact", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDificil.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnDificil.Location = new System.Drawing.Point(621, 247);
            this.btnDificil.Name = "btnDificil";
            this.btnDificil.Size = new System.Drawing.Size(129, 36);
            this.btnDificil.TabIndex = 10;
            this.btnDificil.Text = "NIVEL DIFICIL";
            this.btnDificil.UseVisualStyleBackColor = false;
            this.btnDificil.Click += new System.EventHandler(this.btnDificil_Click);
            // 
            // btnExtremo
            // 
            this.btnExtremo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(189)))), ((int)(((byte)(128)))));
            this.btnExtremo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExtremo.Font = new System.Drawing.Font("Impact", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtremo.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnExtremo.Location = new System.Drawing.Point(621, 314);
            this.btnExtremo.Name = "btnExtremo";
            this.btnExtremo.Size = new System.Drawing.Size(129, 36);
            this.btnExtremo.TabIndex = 11;
            this.btnExtremo.Text = "NIVEL EXTREMO";
            this.btnExtremo.UseVisualStyleBackColor = false;
            this.btnExtremo.Click += new System.EventHandler(this.btnExtremo_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.ForeColor = System.Drawing.Color.SandyBrown;
            this.btnVoltar.Location = new System.Drawing.Point(16, 12);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(112, 33);
            this.btnVoltar.TabIndex = 12;
            this.btnVoltar.Text = "🠔 VOLTAR";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnPerfil
            // 
            this.btnPerfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.btnPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPerfil.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPerfil.ForeColor = System.Drawing.Color.SandyBrown;
            this.btnPerfil.Location = new System.Drawing.Point(-3, 418);
            this.btnPerfil.Name = "btnPerfil";
            this.btnPerfil.Size = new System.Drawing.Size(253, 33);
            this.btnPerfil.TabIndex = 13;
            this.btnPerfil.Text = "☻ PERFIL DO JOGADOR";
            this.btnPerfil.UseVisualStyleBackColor = false;
            this.btnPerfil.Click += new System.EventHandler(this.btnPerfil_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::portasTestes.Properties.Resources.mortesBox;
            this.pictureBox4.Location = new System.Drawing.Point(16, 236);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(210, 66);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::portasTestes.Properties.Resources.vitoriasBox;
            this.pictureBox3.Location = new System.Drawing.Point(12, 123);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(214, 66);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::portasTestes.Properties.Resources.selecionarFaseV;
            this.pictureBox2.Location = new System.Drawing.Point(592, 39);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(184, 369);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::portasTestes.Properties.Resources.quadradoMeio2;
            this.pictureBox1.Location = new System.Drawing.Point(250, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(299, 372);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblNomePersonagem
            // 
            this.lblNomePersonagem.AutoSize = true;
            this.lblNomePersonagem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(55)))), ((int)(((byte)(39)))));
            this.lblNomePersonagem.Font = new System.Drawing.Font("Impact", 26.25F);
            this.lblNomePersonagem.ForeColor = System.Drawing.Color.SandyBrown;
            this.lblNomePersonagem.Location = new System.Drawing.Point(347, 345);
            this.lblNomePersonagem.Name = "lblNomePersonagem";
            this.lblNomePersonagem.Size = new System.Drawing.Size(110, 43);
            this.lblNomePersonagem.TabIndex = 14;
            this.lblNomePersonagem.Text = "label3";
            this.lblNomePersonagem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TelaPersonagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblNomePersonagem);
            this.Controls.Add(this.btnPerfil);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnExtremo);
            this.Controls.Add(this.btnDificil);
            this.Controls.Add(this.btnMedio);
            this.Controls.Add(this.btnFacil);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botaoJogar);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtNickname);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TelaPersonagem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaPersonagem";
            this.Load += new System.EventHandler(this.TelaPersonagem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtNickname;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button botaoJogar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFacil;
        private System.Windows.Forms.Button btnMedio;
        private System.Windows.Forms.Button btnDificil;
        private System.Windows.Forms.Button btnExtremo;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnPerfil;
        private System.Windows.Forms.Label lblNomePersonagem;
    }
}