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
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.renderButton = new System.Windows.Forms.Button();
            this.zoomXmin = new System.Windows.Forms.TextBox();
            this.zoomXmax = new System.Windows.Forms.TextBox();
            this.zoomYmin = new System.Windows.Forms.TextBox();
            this.zoomYmax = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fractalPictureBox)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fractalPictureBox
            // 
            this.fractalPictureBox.Location = new System.Drawing.Point(12, 39);
            this.fractalPictureBox.Name = "fractalPictureBox";
<<<<<<< HEAD
            this.fractalPictureBox.Size = new System.Drawing.Size(100, 100);
=======
            this.fractalPictureBox.Size = new System.Drawing.Size(200, 200);
>>>>>>> 98979fa9aed3bd638f1f35c9a0eb5d8c7d5bafaa
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
            this.fractalsList.SelectedIndexChanged += new System.EventHandler(this.fractalsList_SelectedIndexChanged);
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
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
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
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(70, 17);
            this.toolStripStatusLabel2.Text = "Real Coords";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(63, 17);
            this.toolStripStatusLabel3.Text = "Used Time";
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
            // zoomXmin
            // 
            this.zoomXmin.Location = new System.Drawing.Point(228, 13);
            this.zoomXmin.Name = "zoomXmin";
            this.zoomXmin.Size = new System.Drawing.Size(90, 20);
            this.zoomXmin.TabIndex = 5;
            // 
            // zoomXmax
            // 
            this.zoomXmax.Location = new System.Drawing.Point(363, 13);
            this.zoomXmax.Name = "zoomXmax";
            this.zoomXmax.Size = new System.Drawing.Size(90, 20);
            this.zoomXmax.TabIndex = 6;
            // 
            // zoomYmin
            // 
            this.zoomYmin.Location = new System.Drawing.Point(498, 13);
            this.zoomYmin.Name = "zoomYmin";
            this.zoomYmin.Size = new System.Drawing.Size(90, 20);
            this.zoomYmin.TabIndex = 7;
            // 
            // zoomYmax
            // 
            this.zoomYmax.Location = new System.Drawing.Point(633, 12);
            this.zoomYmax.Name = "zoomYmax";
            this.zoomYmax.Size = new System.Drawing.Size(90, 20);
            this.zoomYmax.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Xmin:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(594, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ymax:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(459, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ymin:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(324, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Xmax:";
            // 
            // FractalsVisualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 882);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zoomYmax);
            this.Controls.Add(this.zoomYmin);
            this.Controls.Add(this.zoomXmax);
            this.Controls.Add(this.zoomXmin);
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
        private System.Windows.Forms.TextBox zoomXmin;
        private System.Windows.Forms.TextBox zoomXmax;
        private System.Windows.Forms.TextBox zoomYmin;
        private System.Windows.Forms.TextBox zoomYmax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
    }
}

