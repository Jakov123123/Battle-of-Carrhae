namespace OTTER
{
    partial class BGL
    {


        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.syncRate = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lblPotez = new System.Windows.Forms.Label();
            this.lblLjudstvo = new System.Windows.Forms.Label();
            this.lblMoral = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // syncRate
            // 
            this.syncRate.AutoSize = true;
            this.syncRate.BackColor = System.Drawing.Color.Transparent;
            this.syncRate.Location = new System.Drawing.Point(12, 394);
            this.syncRate.Name = "syncRate";
            this.syncRate.Size = new System.Drawing.Size(55, 39);
            this.syncRate.TabIndex = 0;
            this.syncRate.Text = "60";
            this.syncRate.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 17;
            this.timer1.Tick += new System.EventHandler(this.Update);
            // 
            // timer2
            // 
            this.timer2.Interval = 250;
            this.timer2.Tick += new System.EventHandler(this.updateFrameRate);
            // 
            // lblPotez
            // 
            this.lblPotez.BackColor = System.Drawing.Color.White;
            this.lblPotez.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPotez.ForeColor = System.Drawing.Color.Black;
            this.lblPotez.Location = new System.Drawing.Point(37, 595);
            this.lblPotez.Name = "lblPotez";
            this.lblPotez.Size = new System.Drawing.Size(107, 24);
            this.lblPotez.TabIndex = 1;
            // 
            // lblLjudstvo
            // 
            this.lblLjudstvo.BackColor = System.Drawing.Color.White;
            this.lblLjudstvo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLjudstvo.ForeColor = System.Drawing.Color.Black;
            this.lblLjudstvo.Location = new System.Drawing.Point(179, 595);
            this.lblLjudstvo.Name = "lblLjudstvo";
            this.lblLjudstvo.Size = new System.Drawing.Size(119, 24);
            this.lblLjudstvo.TabIndex = 2;
            // 
            // lblMoral
            // 
            this.lblMoral.BackColor = System.Drawing.Color.White;
            this.lblMoral.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoral.ForeColor = System.Drawing.Color.Black;
            this.lblMoral.Location = new System.Drawing.Point(331, 595);
            this.lblMoral.Name = "lblMoral";
            this.lblMoral.Size = new System.Drawing.Size(136, 24);
            this.lblMoral.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(15, 557);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "Remaining moves:";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(331, 557);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "Morale:";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(179, 557);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 24);
            this.label6.TabIndex = 6;
            this.label6.Text = "Manpower:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(498, 521);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 98);
            this.label1.TabIndex = 7;
            this.label1.Text = "If you wish to surrender the battle click \"Exit\" in the left-hand side corner. If" +
    " you wish to skip your turn click \"K\".";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 651);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(700, 23);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 19);
            this.fileToolStripMenuItem.Text = "Exit";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // BGL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(20F, 39F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(700, 674);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblMoral);
            this.Controls.Add(this.lblLjudstvo);
            this.Controls.Add(this.lblPotez);
            this.Controls.Add(this.syncRate);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.MaximizeBox = false;
            this.Name = "BGL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2DGL";
            this.Load += new System.EventHandler(this.startTimer);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Draw);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mouseClicked);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label syncRate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label lblPotez;
        private System.Windows.Forms.Label lblLjudstvo;
        private System.Windows.Forms.Label lblMoral;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    }
}

