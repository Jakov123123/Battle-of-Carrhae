
namespace OTTER
{
    partial class Izbornik
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
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnIzadi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(32, 40);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnRestart.Size = new System.Drawing.Size(149, 36);
            this.btnRestart.TabIndex = 0;
            this.btnRestart.Text = "Start game";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnIzadi
            // 
            this.btnIzadi.Location = new System.Drawing.Point(32, 94);
            this.btnIzadi.Name = "btnIzadi";
            this.btnIzadi.Size = new System.Drawing.Size(149, 36);
            this.btnIzadi.TabIndex = 2;
            this.btnIzadi.Text = "Exit";
            this.btnIzadi.UseVisualStyleBackColor = true;
            this.btnIzadi.Click += new System.EventHandler(this.btnIzadi_Click);
            // 
            // Izbornik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 157);
            this.Controls.Add(this.btnIzadi);
            this.Controls.Add(this.btnRestart);
            this.Name = "Izbornik";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnIzadi;
    }
}