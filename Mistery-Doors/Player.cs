using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mistery_Maze
{
    internal class Player : UserControl
    {
        private Timer playerTimer;
        private System.ComponentModel.IContainer components;
        private PictureBox pictureBox1;

        private int speed = 3;
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.playerTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Mistery_Maze.Properties.Resources.unit3;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // playerTimer
            // 
            this.playerTimer.Enabled = true;
            this.playerTimer.Interval = 33;
            this.playerTimer.Tick += new System.EventHandler(this.Update);
            // 
            // Player
            // 
            this.Controls.Add(this.pictureBox1);
            this.Name = "Player";
            this.Size = new System.Drawing.Size(92, 108);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        public Player()
        {
            InitializeComponent();
        }

        private void Update(object sender, EventArgs e)
        {
            if (Core.IsUp)
                Top -= speed;
            if (Core.IsDown)
                Top += speed;
            if (Core.IsLeft)
                Left -= speed;
            if (Core.IsRight)
                Left += speed;
        }
    }
}
