namespace ZHAW.SoftwareProjekt.Fractals.UI
{
    partial class FractalsVisualizer
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
            this.fractalPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.fractalPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // fractalPictureBox
            // 
            this.fractalPictureBox.Location = new System.Drawing.Point(12, 12);
            this.fractalPictureBox.Name = "fractalPictureBox";
            this.fractalPictureBox.Size = new System.Drawing.Size(800, 800);
            this.fractalPictureBox.TabIndex = 0;
            this.fractalPictureBox.TabStop = false;
            this.fractalPictureBox.Click += new System.EventHandler(this.fractalPictureBox_Click);
            // 
            // FractalsVisualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 824);
            this.Controls.Add(this.fractalPictureBox);
            this.Name = "FractalsVisualizer";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.fractalPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox fractalPictureBox;
    }
}

