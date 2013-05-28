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
            this.nativeFractalPictureBox = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.renderButton = new System.Windows.Forms.Button();
            this.bigFloatFractalPictureBox = new System.Windows.Forms.PictureBox();
            this.timeSpent1Label = new System.Windows.Forms.Label();
            this.timeSpent2Label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.zoom10x = new System.Windows.Forms.RadioButton();
            this.zoom100x = new System.Windows.Forms.RadioButton();
            this.zoom1000x = new System.Windows.Forms.RadioButton();
            this.maxIterationsText = new System.Windows.Forms.TextBox();
            this.maxIterationsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nativeFractalPictureBox)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bigFloatFractalPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nativeFractalPictureBox
            // 
            this.nativeFractalPictureBox.Location = new System.Drawing.Point(0, 0);
            this.nativeFractalPictureBox.Name = "nativeFractalPictureBox";
            this.nativeFractalPictureBox.Size = new System.Drawing.Size(200, 200);
            this.nativeFractalPictureBox.TabIndex = 0;
            this.nativeFractalPictureBox.TabStop = false;
            this.nativeFractalPictureBox.Click += new System.EventHandler(this.fractalPictureBox_Click);
            this.nativeFractalPictureBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nativeFractalPictureBox_MouseDoubleClick);
            this.nativeFractalPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fractalPictureBox_MouseMove);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 309);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(443, 22);
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
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.toolStripProgressBar1.Visible = false;
            // 
            // renderButton
            // 
            this.renderButton.Location = new System.Drawing.Point(343, 10);
            this.renderButton.Name = "renderButton";
            this.renderButton.Size = new System.Drawing.Size(75, 23);
            this.renderButton.TabIndex = 4;
            this.renderButton.Text = "Render";
            this.renderButton.UseVisualStyleBackColor = true;
            this.renderButton.Click += new System.EventHandler(this.renderButton_Click);
            // 
            // bigFloatFractalPictureBox
            // 
            this.bigFloatFractalPictureBox.Location = new System.Drawing.Point(219, 0);
            this.bigFloatFractalPictureBox.Name = "bigFloatFractalPictureBox";
            this.bigFloatFractalPictureBox.Size = new System.Drawing.Size(200, 200);
            this.bigFloatFractalPictureBox.TabIndex = 13;
            this.bigFloatFractalPictureBox.TabStop = false;
            this.bigFloatFractalPictureBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.bigFloatFractalPictureBox_MouseDoubleClick);
            this.bigFloatFractalPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bigFloatFractalPictureBox_MouseMove);
            // 
            // timeSpent1Label
            // 
            this.timeSpent1Label.AutoSize = true;
            this.timeSpent1Label.Location = new System.Drawing.Point(3, 214);
            this.timeSpent1Label.Name = "timeSpent1Label";
            this.timeSpent1Label.Size = new System.Drawing.Size(10, 13);
            this.timeSpent1Label.TabIndex = 14;
            this.timeSpent1Label.Text = "-";
            // 
            // timeSpent2Label
            // 
            this.timeSpent2Label.AutoSize = true;
            this.timeSpent2Label.Location = new System.Drawing.Point(225, 214);
            this.timeSpent2Label.Name = "timeSpent2Label";
            this.timeSpent2Label.Size = new System.Drawing.Size(10, 13);
            this.timeSpent2Label.TabIndex = 15;
            this.timeSpent2Label.Text = "-";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.nativeFractalPictureBox);
            this.panel1.Controls.Add(this.timeSpent2Label);
            this.panel1.Controls.Add(this.bigFloatFractalPictureBox);
            this.panel1.Controls.Add(this.timeSpent1Label);
            this.panel1.Location = new System.Drawing.Point(12, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 243);
            this.panel1.TabIndex = 16;
            // 
            // zoom10x
            // 
            this.zoom10x.AutoSize = true;
            this.zoom10x.Checked = true;
            this.zoom10x.Location = new System.Drawing.Point(12, 15);
            this.zoom10x.Name = "zoom10x";
            this.zoom10x.Size = new System.Drawing.Size(42, 17);
            this.zoom10x.TabIndex = 17;
            this.zoom10x.TabStop = true;
            this.zoom10x.Text = "x10";
            this.zoom10x.UseVisualStyleBackColor = true;
            // 
            // zoom100x
            // 
            this.zoom100x.AutoSize = true;
            this.zoom100x.Location = new System.Drawing.Point(60, 15);
            this.zoom100x.Name = "zoom100x";
            this.zoom100x.Size = new System.Drawing.Size(48, 17);
            this.zoom100x.TabIndex = 18;
            this.zoom100x.TabStop = true;
            this.zoom100x.Text = "x100";
            this.zoom100x.UseVisualStyleBackColor = true;
            // 
            // zoom1000x
            // 
            this.zoom1000x.AutoSize = true;
            this.zoom1000x.Location = new System.Drawing.Point(114, 15);
            this.zoom1000x.Name = "zoom1000x";
            this.zoom1000x.Size = new System.Drawing.Size(54, 17);
            this.zoom1000x.TabIndex = 19;
            this.zoom1000x.TabStop = true;
            this.zoom1000x.Text = "x1000";
            this.zoom1000x.UseVisualStyleBackColor = true;
            // 
            // maxIterationsText
            // 
            this.maxIterationsText.Location = new System.Drawing.Point(283, 12);
            this.maxIterationsText.Name = "maxIterationsText";
            this.maxIterationsText.Size = new System.Drawing.Size(57, 20);
            this.maxIterationsText.TabIndex = 20;
            this.maxIterationsText.Text = "100";
            this.maxIterationsText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // maxIterationsLabel
            // 
            this.maxIterationsLabel.AutoSize = true;
            this.maxIterationsLabel.Location = new System.Drawing.Point(201, 17);
            this.maxIterationsLabel.Name = "maxIterationsLabel";
            this.maxIterationsLabel.Size = new System.Drawing.Size(76, 13);
            this.maxIterationsLabel.TabIndex = 21;
            this.maxIterationsLabel.Text = "Max Iterations:";
            // 
            // FractalsVisualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 331);
            this.Controls.Add(this.maxIterationsLabel);
            this.Controls.Add(this.maxIterationsText);
            this.Controls.Add(this.zoom1000x);
            this.Controls.Add(this.zoom100x);
            this.Controls.Add(this.zoom10x);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.renderButton);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FractalsVisualizer";
            this.Text = "ZHAW - Software Projekt II - FS 2013";
            ((System.ComponentModel.ISupportInitialize)(this.nativeFractalPictureBox)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bigFloatFractalPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox nativeFractalPictureBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button renderButton;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.PictureBox bigFloatFractalPictureBox;
        private System.Windows.Forms.Label timeSpent1Label;
        private System.Windows.Forms.Label timeSpent2Label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton zoom10x;
        private System.Windows.Forms.RadioButton zoom100x;
        private System.Windows.Forms.RadioButton zoom1000x;
        private System.Windows.Forms.TextBox maxIterationsText;
        private System.Windows.Forms.Label maxIterationsLabel;
    }
}

