namespace Sports_Bibliotheca
{
    partial class Help_Window
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
            this.startw_btn = new System.Windows.Forms.Button();
            this.dovidnykF_btn = new System.Windows.Forms.Button();
            this.dovidnykB_btn = new System.Windows.Forms.Button();
            this.gameF_btn = new System.Windows.Forms.Button();
            this.gameB_btn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.reason_txt = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.guide_txt = new System.Windows.Forms.RichTextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // startw_btn
            // 
            this.startw_btn.Location = new System.Drawing.Point(12, 28);
            this.startw_btn.Name = "startw_btn";
            this.startw_btn.Size = new System.Drawing.Size(195, 74);
            this.startw_btn.TabIndex = 0;
            this.startw_btn.Text = "Початкове Вікно";
            this.startw_btn.UseVisualStyleBackColor = true;
            this.startw_btn.Click += new System.EventHandler(this.startw_btn_Click);
            // 
            // dovidnykF_btn
            // 
            this.dovidnykF_btn.Location = new System.Drawing.Point(12, 108);
            this.dovidnykF_btn.Name = "dovidnykF_btn";
            this.dovidnykF_btn.Size = new System.Drawing.Size(195, 74);
            this.dovidnykF_btn.TabIndex = 1;
            this.dovidnykF_btn.Text = "Довідник Фаната \r\n(Футбол)";
            this.dovidnykF_btn.UseVisualStyleBackColor = true;
            this.dovidnykF_btn.Click += new System.EventHandler(this.dovidnykF_btn_Click);
            // 
            // dovidnykB_btn
            // 
            this.dovidnykB_btn.Location = new System.Drawing.Point(12, 188);
            this.dovidnykB_btn.Name = "dovidnykB_btn";
            this.dovidnykB_btn.Size = new System.Drawing.Size(195, 74);
            this.dovidnykB_btn.TabIndex = 2;
            this.dovidnykB_btn.Text = "Довідник Фаната\r\n(Баскетбол)";
            this.dovidnykB_btn.UseVisualStyleBackColor = true;
            this.dovidnykB_btn.Click += new System.EventHandler(this.dovidnykB_btn_Click);
            // 
            // gameF_btn
            // 
            this.gameF_btn.Location = new System.Drawing.Point(12, 268);
            this.gameF_btn.Name = "gameF_btn";
            this.gameF_btn.Size = new System.Drawing.Size(195, 74);
            this.gameF_btn.TabIndex = 3;
            this.gameF_btn.Text = "Гра\r\n(Футбол)";
            this.gameF_btn.UseVisualStyleBackColor = true;
            this.gameF_btn.Click += new System.EventHandler(this.gameF_btn_Click);
            // 
            // gameB_btn
            // 
            this.gameB_btn.Location = new System.Drawing.Point(12, 348);
            this.gameB_btn.Name = "gameB_btn";
            this.gameB_btn.Size = new System.Drawing.Size(195, 74);
            this.gameB_btn.TabIndex = 5;
            this.gameB_btn.Text = "Гра\r\n(Баскетбол)";
            this.gameB_btn.UseVisualStyleBackColor = true;
            this.gameB_btn.Click += new System.EventHandler(this.gameB_btn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.reason_txt);
            this.groupBox3.Location = new System.Drawing.Point(213, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(575, 105);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Для чого це все ?";
            // 
            // reason_txt
            // 
            this.reason_txt.BackColor = System.Drawing.SystemColors.Control;
            this.reason_txt.Location = new System.Drawing.Point(15, 21);
            this.reason_txt.Name = "reason_txt";
            this.reason_txt.ReadOnly = true;
            this.reason_txt.Size = new System.Drawing.Size(554, 78);
            this.reason_txt.TabIndex = 0;
            this.reason_txt.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.guide_txt);
            this.groupBox1.Location = new System.Drawing.Point(213, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 283);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Як користуватися ?";
            // 
            // guide_txt
            // 
            this.guide_txt.BackColor = System.Drawing.SystemColors.Control;
            this.guide_txt.Location = new System.Drawing.Point(15, 21);
            this.guide_txt.Name = "guide_txt";
            this.guide_txt.ReadOnly = true;
            this.guide_txt.Size = new System.Drawing.Size(554, 256);
            this.guide_txt.TabIndex = 0;
            this.guide_txt.Text = "";
            // 
            // Help_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 435);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gameB_btn);
            this.Controls.Add(this.gameF_btn);
            this.Controls.Add(this.dovidnykB_btn);
            this.Controls.Add(this.dovidnykF_btn);
            this.Controls.Add(this.startw_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Help_Window";
            this.Text = "Довідка";
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startw_btn;
        private System.Windows.Forms.Button dovidnykF_btn;
        private System.Windows.Forms.Button dovidnykB_btn;
        private System.Windows.Forms.Button gameF_btn;
        private System.Windows.Forms.Button gameB_btn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox reason_txt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox guide_txt;
    }
}