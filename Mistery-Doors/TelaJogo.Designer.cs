namespace portasTestes
{
    partial class TelaJogo
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
            this.lblRes = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.lblDificuldade = new System.Windows.Forms.Label();
            this.lblNickname = new System.Windows.Forms.Label();
            this.msgRes = new System.Windows.Forms.PictureBox();
            this.Porta3 = new System.Windows.Forms.PictureBox();
            this.Porta2 = new System.Windows.Forms.PictureBox();
            this.Porta1 = new System.Windows.Forms.PictureBox();
            this.pctHeart3 = new System.Windows.Forms.PictureBox();
            this.pctHeart2 = new System.Windows.Forms.PictureBox();
            this.pctHeart1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.unit = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.msgRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Porta3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Porta2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Porta1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctHeart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctHeart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctHeart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRes
            // 
            this.lblRes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(195)))), ((int)(((byte)(171)))));
            this.lblRes.Font = new System.Drawing.Font("Impact", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRes.Location = new System.Drawing.Point(524, 126);
            this.lblRes.Name = "lblRes";
            this.lblRes.Size = new System.Drawing.Size(128, 23);
            this.lblRes.TabIndex = 9;
            this.lblRes.Text = "Resultado das portas";
            this.lblRes.Click += new System.EventHandler(this.lblRes_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.ForeColor = System.Drawing.Color.SandyBrown;
            this.btnVoltar.Location = new System.Drawing.Point(3, 9);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(94, 31);
            this.btnVoltar.TabIndex = 17;
            this.btnVoltar.Text = "🠔 VOLTAR";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnEntrar
            // 
            this.btnEntrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.btnEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrar.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnEntrar.Location = new System.Drawing.Point(303, 389);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(136, 50);
            this.btnEntrar.TabIndex = 18;
            this.btnEntrar.Text = "ENTRAR";
            this.btnEntrar.UseVisualStyleBackColor = false;
            // 
            // lblDificuldade
            // 
            this.lblDificuldade.AutoSize = true;
            this.lblDificuldade.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDificuldade.Location = new System.Drawing.Point(652, 389);
            this.lblDificuldade.Name = "lblDificuldade";
            this.lblDificuldade.Size = new System.Drawing.Size(0, 20);
            this.lblDificuldade.TabIndex = 15;
            this.lblDificuldade.Click += new System.EventHandler(this.lblDificuldade_Click);
            // 
            // lblNickname
            // 
            this.lblNickname.AutoSize = true;
            this.lblNickname.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNickname.Location = new System.Drawing.Point(644, 55);
            this.lblNickname.Name = "lblNickname";
            this.lblNickname.Size = new System.Drawing.Size(0, 17);
            this.lblNickname.TabIndex = 14;
            // 
            // msgRes
            // 
            this.msgRes.BackColor = System.Drawing.Color.Transparent;
            this.msgRes.Image = global::portasTestes.Properties.Resources.fundoRes;
            this.msgRes.Location = new System.Drawing.Point(514, 75);
            this.msgRes.Name = "msgRes";
            this.msgRes.Size = new System.Drawing.Size(287, 349);
            this.msgRes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.msgRes.TabIndex = 19;
            this.msgRes.TabStop = false;
            // 
            // Porta3
            // 
            this.Porta3.Image = global::portasTestes.Properties.Resources.porta3;
            this.Porta3.Location = new System.Drawing.Point(465, 99);
            this.Porta3.Name = "Porta3";
            this.Porta3.Size = new System.Drawing.Size(141, 155);
            this.Porta3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Porta3.TabIndex = 6;
            this.Porta3.TabStop = false;
            // 
            // Porta2
            // 
            this.Porta2.Image = global::portasTestes.Properties.Resources.porta2;
            this.Porta2.Location = new System.Drawing.Point(284, 99);
            this.Porta2.Name = "Porta2";
            this.Porta2.Size = new System.Drawing.Size(155, 151);
            this.Porta2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Porta2.TabIndex = 5;
            this.Porta2.TabStop = false;
            // 
            // Porta1
            // 
            this.Porta1.Image = global::portasTestes.Properties.Resources.porta1;
            this.Porta1.Location = new System.Drawing.Point(114, 87);
            this.Porta1.Name = "Porta1";
            this.Porta1.Size = new System.Drawing.Size(136, 163);
            this.Porta1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Porta1.TabIndex = 4;
            this.Porta1.TabStop = false;
            // 
            // pctHeart3
            // 
            this.pctHeart3.Image = global::portasTestes.Properties.Resources.heart;
            this.pctHeart3.Location = new System.Drawing.Point(736, 12);
            this.pctHeart3.Name = "pctHeart3";
            this.pctHeart3.Size = new System.Drawing.Size(40, 28);
            this.pctHeart3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctHeart3.TabIndex = 13;
            this.pctHeart3.TabStop = false;
            // 
            // pctHeart2
            // 
            this.pctHeart2.Image = global::portasTestes.Properties.Resources.heart;
            this.pctHeart2.Location = new System.Drawing.Point(688, 12);
            this.pctHeart2.Name = "pctHeart2";
            this.pctHeart2.Size = new System.Drawing.Size(44, 28);
            this.pctHeart2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctHeart2.TabIndex = 12;
            this.pctHeart2.TabStop = false;
            // 
            // pctHeart1
            // 
            this.pctHeart1.Image = global::portasTestes.Properties.Resources.heart;
            this.pctHeart1.Location = new System.Drawing.Point(645, 12);
            this.pctHeart1.Name = "pctHeart1";
            this.pctHeart1.Size = new System.Drawing.Size(40, 28);
            this.pctHeart1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctHeart1.TabIndex = 11;
            this.pctHeart1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::portasTestes.Properties.Resources.rect;
            this.pictureBox2.Location = new System.Drawing.Point(635, -2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(148, 54);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // unit
            // 
            this.unit.BackColor = System.Drawing.Color.Transparent;
            this.unit.Image = global::portasTestes.Properties.Resources.unit;
            this.unit.Location = new System.Drawing.Point(325, 321);
            this.unit.Name = "unit";
            this.unit.Size = new System.Drawing.Size(87, 118);
            this.unit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.unit.TabIndex = 2;
            this.unit.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::portasTestes.Properties.Resources.portas;
            this.pictureBox3.Location = new System.Drawing.Point(101, -1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(527, 464);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnConfirmar.Location = new System.Drawing.Point(603, 393);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(142, 49);
            this.btnConfirmar.TabIndex = 20;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click_1);
            // 
            // TelaJogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblRes);
            this.Controls.Add(this.msgRes);
            this.Controls.Add(this.btnEntrar);
            this.Controls.Add(this.unit);
            this.Controls.Add(this.Porta3);
            this.Controls.Add(this.Porta2);
            this.Controls.Add(this.Porta1);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.lblDificuldade);
            this.Controls.Add(this.lblNickname);
            this.Controls.Add(this.pctHeart3);
            this.Controls.Add(this.pctHeart2);
            this.Controls.Add(this.pctHeart1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TelaJogo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.msgRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Porta3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Porta2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Porta1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctHeart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctHeart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctHeart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox unit;
        private System.Windows.Forms.PictureBox Porta1;
        private System.Windows.Forms.PictureBox Porta2;
        private System.Windows.Forms.PictureBox Porta3;
        private System.Windows.Forms.Label lblRes;
        private System.Windows.Forms.PictureBox pctHeart1;
        private System.Windows.Forms.PictureBox pctHeart2;
        private System.Windows.Forms.PictureBox pctHeart3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.Label lblDificuldade;
        private System.Windows.Forms.Label lblNickname;
        private System.Windows.Forms.PictureBox msgRes;
        private System.Windows.Forms.Button btnConfirmar;
    }
}

