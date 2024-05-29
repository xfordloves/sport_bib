namespace Sports_Bibliotheca
{
    partial class ChooseSportWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseSportWindow));
            this.FB_pictureBox = new System.Windows.Forms.PictureBox();
            this.BB_pictureBox = new System.Windows.Forms.PictureBox();
            this.Sports = new System.Windows.Forms.ToolTip(this.components);
            this.SW_menuStrip = new System.Windows.Forms.MenuStrip();
            this.help = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutus = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.FB_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BB_pictureBox)).BeginInit();
            this.SW_menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // FB_pictureBox
            // 
            this.FB_pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FB_pictureBox.BackColor = System.Drawing.Color.White;
            this.FB_pictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FB_pictureBox.BackgroundImage")));
            this.FB_pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FB_pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FB_pictureBox.Location = new System.Drawing.Point(12, 36);
            this.FB_pictureBox.Name = "FB_pictureBox";
            this.FB_pictureBox.Size = new System.Drawing.Size(352, 414);
            this.FB_pictureBox.TabIndex = 0;
            this.FB_pictureBox.TabStop = false;
            this.Sports.SetToolTip(this.FB_pictureBox, "Футбол");
            this.FB_pictureBox.Click += new System.EventHandler(this.FB_pictureBox_Click);
            // 
            // BB_pictureBox
            // 
            this.BB_pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BB_pictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BB_pictureBox.BackgroundImage")));
            this.BB_pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BB_pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BB_pictureBox.Location = new System.Drawing.Point(436, 36);
            this.BB_pictureBox.Name = "BB_pictureBox";
            this.BB_pictureBox.Size = new System.Drawing.Size(352, 414);
            this.BB_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BB_pictureBox.TabIndex = 1;
            this.BB_pictureBox.TabStop = false;
            this.Sports.SetToolTip(this.BB_pictureBox, "Баскетбол");
            this.BB_pictureBox.Click += new System.EventHandler(this.BB_pictureBox_Click);
            // 
            // SW_menuStrip
            // 
            this.SW_menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.SW_menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.help,
            this.aboutus});
            this.SW_menuStrip.Location = new System.Drawing.Point(0, 0);
            this.SW_menuStrip.Name = "SW_menuStrip";
            this.SW_menuStrip.Size = new System.Drawing.Size(800, 30);
            this.SW_menuStrip.TabIndex = 2;
            this.SW_menuStrip.Text = "BB_menuStrip";
            // 
            // help
            // 
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(77, 26);
            this.help.Text = "Довідка";
            this.help.Click += new System.EventHandler(this.help_Click);
            // 
            // aboutus
            // 
            this.aboutus.Name = "aboutus";
            this.aboutus.Size = new System.Drawing.Size(80, 26);
            this.aboutus.Text = "Про нас";
            this.aboutus.Click += new System.EventHandler(this.aboutus_Click);
            // 
            // ChooseSportWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SW_menuStrip);
            this.Controls.Add(this.BB_pictureBox);
            this.Controls.Add(this.FB_pictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(818, 497);
            this.MinimumSize = new System.Drawing.Size(818, 497);
            this.Name = "ChooseSportWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Оберіть вид спорту";
            ((System.ComponentModel.ISupportInitialize)(this.FB_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BB_pictureBox)).EndInit();
            this.SW_menuStrip.ResumeLayout(false);
            this.SW_menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox FB_pictureBox;
        private System.Windows.Forms.PictureBox BB_pictureBox;
        private System.Windows.Forms.ToolTip Sports;
        private System.Windows.Forms.MenuStrip SW_menuStrip;
        private System.Windows.Forms.ToolStripMenuItem help;
        private System.Windows.Forms.ToolStripMenuItem aboutus;
    }
}

