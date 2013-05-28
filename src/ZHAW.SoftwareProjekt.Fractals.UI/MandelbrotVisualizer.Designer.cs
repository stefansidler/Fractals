namespace ZHAW.SoftwareProjekt.Fractals.UI
{
    partial class MandelbrotVisualizer
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.maxIterationsText = new System.Windows.Forms.TextBox();
            this.renderButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.maxIterationsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 800);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            // 
            // maxIterationsText
            // 
            this.maxIterationsText.Location = new System.Drawing.Point(94, 29);
            this.maxIterationsText.Name = "maxIterationsText";
            this.maxIterationsText.Size = new System.Drawing.Size(48, 20);
            this.maxIterationsText.TabIndex = 1;
            this.maxIterationsText.Text = "100";
            this.maxIterationsText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // renderButton
            // 
            this.renderButton.Location = new System.Drawing.Point(175, 27);
            this.renderButton.Name = "renderButton";
            this.renderButton.Size = new System.Drawing.Size(75, 23);
            this.renderButton.TabIndex = 2;
            this.renderButton.Text = "Render";
            this.renderButton.UseVisualStyleBackColor = true;
            this.renderButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(256, 27);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 3;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // maxIterationsLabel
            // 
            this.maxIterationsLabel.AutoSize = true;
            this.maxIterationsLabel.Location = new System.Drawing.Point(12, 32);
            this.maxIterationsLabel.Name = "maxIterationsLabel";
            this.maxIterationsLabel.Size = new System.Drawing.Size(76, 13);
            this.maxIterationsLabel.TabIndex = 4;
            this.maxIterationsLabel.Text = "Max Iterations:";
            // 
            // MandelbrotVisualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 893);
            this.Controls.Add(this.maxIterationsLabel);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.renderButton);
            this.Controls.Add(this.maxIterationsText);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MandelbrotVisualizer";
            this.Text = "MandelbrotVisualizer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox maxIterationsText;
        private System.Windows.Forms.Button renderButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label maxIterationsLabel;
    }
}