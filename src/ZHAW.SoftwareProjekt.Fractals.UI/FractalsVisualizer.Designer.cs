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
            this.fractalsList = new System.Windows.Forms.ComboBox();
            this.fractalsLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.renderButton = new System.Windows.Forms.Button();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.fractalPictureBox)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fractalPictureBox
            // 
            this.fractalPictureBox.Location = new System.Drawing.Point(12, 39);
            this.fractalPictureBox.Name = "fractalPictureBox";
            this.fractalPictureBox.Size = new System.Drawing.Size(800, 800);
            this.fractalPictureBox.TabIndex = 0;
            this.fractalPictureBox.TabStop = false;
            this.fractalPictureBox.Click += new System.EventHandler(this.fractalPictureBox_Click);
            this.fractalPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fractalPictureBox_MouseMove);
            // 
            // fractalsList
            // 
            this.fractalsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fractalsList.FormattingEnabled = true;
            this.fractalsList.Location = new System.Drawing.Point(62, 12);
            this.fractalsList.Name = "fractalsList";
            this.fractalsList.Size = new System.Drawing.Size(121, 21);
            this.fractalsList.TabIndex = 1;
            // 
            // fractalsLabel
            // 
            this.fractalsLabel.AutoSize = true;
            this.fractalsLabel.Location = new System.Drawing.Point(12, 15);
            this.fractalsLabel.Name = "fractalsLabel";
            this.fractalsLabel.Size = new System.Drawing.Size(44, 13);
            this.fractalsLabel.TabIndex = 2;
            this.fractalsLabel.Text = "Fracals:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 860);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(824, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(81, 17);
            this.toolStripStatusLabel1.Text = "Image Coords";
            // 
            // renderButton
            // 
            this.renderButton.Location = new System.Drawing.Point(737, 10);
            this.renderButton.Name = "renderButton";
            this.renderButton.Size = new System.Drawing.Size(75, 23);
            this.renderButton.TabIndex = 4;
            this.renderButton.Text = "Render";
            this.renderButton.UseVisualStyleBackColor = true;
            this.renderButton.Click += new System.EventHandler(this.renderButton_Click);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(70, 17);
            this.toolStripStatusLabel2.Text = "Real Coords";
            // 
            // FractalsVisualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 882);
            this.Controls.Add(this.renderButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.fractalsLabel);
            this.Controls.Add(this.fractalsList);
            this.Controls.Add(this.fractalPictureBox);
            this.Name = "FractalsVisualizer";
            this.Text = "ZHAW - Software Projekt II - FS 2013";
            ((System.ComponentModel.ISupportInitialize)(this.fractalPictureBox)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox fractalPictureBox;
        private System.Windows.Forms.ComboBox fractalsList;
        private System.Windows.Forms.Label fractalsLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button renderButton;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}

