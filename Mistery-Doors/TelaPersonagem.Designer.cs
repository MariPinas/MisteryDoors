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
            this.PersonagemBox = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // PersonagemBox
            // 
            this.PersonagemBox.Location = new System.Drawing.Point(252, 48);
            this.PersonagemBox.Name = "PersonagemBox";
            this.PersonagemBox.Size = new System.Drawing.Size(306, 332);
            this.PersonagemBox.TabIndex = 0;
            this.PersonagemBox.TabStop = false;
            // 
            // TelaPersonagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PersonagemBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TelaPersonagem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaPersonagem";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox PersonagemBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}