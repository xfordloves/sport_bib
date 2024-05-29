namespace Sports_Bibliotheca
{
    partial class Game_Guess_BB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game_Guess_BB));
            this.photo_pictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.help = new System.Windows.Forms.ToolStripMenuItem();
            this.Check = new System.Windows.Forms.ToolStripMenuItem();
            this.Hint = new System.Windows.Forms.ToolStripMenuItem();
            this.hide_btn = new System.Windows.Forms.Button();
            this.show_btn = new System.Windows.Forms.Button();
            this.search_txtbox = new System.Windows.Forms.TextBox();
            this.conf_pb = new System.Windows.Forms.ProgressBar();
            this.team_pb = new System.Windows.Forms.ProgressBar();
            this.number_pb = new System.Windows.Forms.ProgressBar();
            this.age_pb = new System.Windows.Forms.ProgressBar();
            this.position_pb = new System.Windows.Forms.ProgressBar();
            this.con_pict = new System.Windows.Forms.PictureBox();
            this.tm_pict = new System.Windows.Forms.PictureBox();
            this.pos_lbl = new System.Windows.Forms.Label();
            this.age_lbl = new System.Windows.Forms.Label();
            this.numb_lbl = new System.Windows.Forms.Label();
            this.photo2 = new System.Windows.Forms.PictureBox();
            this.atempts_lbl = new System.Windows.Forms.Label();
            this.pers_conf = new System.Windows.Forms.PictureBox();
            this.pers_tm = new System.Windows.Forms.PictureBox();
            this.pers_pos = new System.Windows.Forms.Label();
            this.pers_age = new System.Windows.Forms.Label();
            this.pers_numb = new System.Windows.Forms.Label();
            this.height_pb = new System.Windows.Forms.ProgressBar();
            this.height_lbl = new System.Windows.Forms.Label();
            this.pers_height = new System.Windows.Forms.Label();
            this.TT = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.photo_pictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.con_pict)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tm_pict)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.photo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pers_conf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pers_tm)).BeginInit();
            this.SuspendLayout();
            // 
            // photo_pictureBox
            // 
            this.photo_pictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.photo_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("photo_pictureBox.Image")));
            this.photo_pictureBox.Location = new System.Drawing.Point(290, 97);
            this.photo_pictureBox.Name = "photo_pictureBox";
            this.photo_pictureBox.Size = new System.Drawing.Size(147, 193);
            this.photo_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.photo_pictureBox.TabIndex = 0;
            this.photo_pictureBox.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.help,
            this.Check,
            this.Hint});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(718, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // help
            // 
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(77, 24);
            this.help.Text = "Довідка";
            this.help.Click += new System.EventHandler(this.help_Click);
            // 
            // Check
            // 
            this.Check.Name = "Check";
            this.Check.Size = new System.Drawing.Size(95, 24);
            this.Check.Text = "Перевірка";
            this.Check.Click += new System.EventHandler(this.check_btn_Click);
            // 
            // Hint
            // 
            this.Hint.Name = "Hint";
            this.Hint.Size = new System.Drawing.Size(83, 24);
            this.Hint.Text = "Підказка";
            this.Hint.Click += new System.EventHandler(this.hint_btn_Click);
            // 
            // hide_btn
            // 
            this.hide_btn.Location = new System.Drawing.Point(228, 296);
            this.hide_btn.Name = "hide_btn";
            this.hide_btn.Size = new System.Drawing.Size(130, 46);
            this.hide_btn.TabIndex = 4;
            this.hide_btn.Text = "Сховати Фото";
            this.hide_btn.UseVisualStyleBackColor = true;
            this.hide_btn.Click += new System.EventHandler(this.hide_btn_Click);
            // 
            // show_btn
            // 
            this.show_btn.Location = new System.Drawing.Point(364, 296);
            this.show_btn.Name = "show_btn";
            this.show_btn.Size = new System.Drawing.Size(130, 46);
            this.show_btn.TabIndex = 5;
            this.show_btn.Text = "Показати Фото";
            this.show_btn.UseVisualStyleBackColor = true;
            this.show_btn.Click += new System.EventHandler(this.show_btn_Click);
            // 
            // search_txtbox
            // 
            this.search_txtbox.Location = new System.Drawing.Point(228, 308);
            this.search_txtbox.Name = "search_txtbox";
            this.search_txtbox.Size = new System.Drawing.Size(266, 22);
            this.search_txtbox.TabIndex = 6;
            this.search_txtbox.Visible = false;
            // 
            // conf_pb
            // 
            this.conf_pb.BackColor = System.Drawing.SystemColors.Control;
            this.conf_pb.Location = new System.Drawing.Point(25, 355);
            this.conf_pb.Name = "conf_pb";
            this.conf_pb.Size = new System.Drawing.Size(107, 105);
            this.conf_pb.TabIndex = 8;
            // 
            // team_pb
            // 
            this.team_pb.Location = new System.Drawing.Point(138, 355);
            this.team_pb.Name = "team_pb";
            this.team_pb.Size = new System.Drawing.Size(107, 105);
            this.team_pb.TabIndex = 9;
            // 
            // number_pb
            // 
            this.number_pb.Location = new System.Drawing.Point(477, 355);
            this.number_pb.Name = "number_pb";
            this.number_pb.Size = new System.Drawing.Size(107, 105);
            this.number_pb.TabIndex = 12;
            // 
            // age_pb
            // 
            this.age_pb.Location = new System.Drawing.Point(364, 355);
            this.age_pb.Name = "age_pb";
            this.age_pb.Size = new System.Drawing.Size(107, 105);
            this.age_pb.TabIndex = 11;
            // 
            // position_pb
            // 
            this.position_pb.Location = new System.Drawing.Point(251, 355);
            this.position_pb.Name = "position_pb";
            this.position_pb.Size = new System.Drawing.Size(107, 105);
            this.position_pb.TabIndex = 10;
            // 
            // con_pict
            // 
            this.con_pict.Location = new System.Drawing.Point(37, 367);
            this.con_pict.Name = "con_pict";
            this.con_pict.Size = new System.Drawing.Size(83, 83);
            this.con_pict.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.con_pict.TabIndex = 14;
            this.con_pict.TabStop = false;
            // 
            // tm_pict
            // 
            this.tm_pict.Location = new System.Drawing.Point(151, 367);
            this.tm_pict.Name = "tm_pict";
            this.tm_pict.Size = new System.Drawing.Size(83, 83);
            this.tm_pict.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.tm_pict.TabIndex = 15;
            this.tm_pict.TabStop = false;
            // 
            // pos_lbl
            // 
            this.pos_lbl.AutoSize = true;
            this.pos_lbl.Font = new System.Drawing.Font("Rubik", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pos_lbl.Location = new System.Drawing.Point(293, 395);
            this.pos_lbl.Name = "pos_lbl";
            this.pos_lbl.Size = new System.Drawing.Size(26, 28);
            this.pos_lbl.TabIndex = 16;
            this.pos_lbl.Text = "?";
            // 
            // age_lbl
            // 
            this.age_lbl.AutoSize = true;
            this.age_lbl.Font = new System.Drawing.Font("Rubik", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.age_lbl.Location = new System.Drawing.Point(396, 395);
            this.age_lbl.Name = "age_lbl";
            this.age_lbl.Size = new System.Drawing.Size(54, 28);
            this.age_lbl.TabIndex = 17;
            this.age_lbl.Text = "???";
            // 
            // numb_lbl
            // 
            this.numb_lbl.AutoSize = true;
            this.numb_lbl.Font = new System.Drawing.Font("Rubik", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numb_lbl.Location = new System.Drawing.Point(507, 395);
            this.numb_lbl.Name = "numb_lbl";
            this.numb_lbl.Size = new System.Drawing.Size(56, 28);
            this.numb_lbl.TabIndex = 18;
            this.numb_lbl.Text = "#??";
            // 
            // photo2
            // 
            this.photo2.BackColor = System.Drawing.SystemColors.Control;
            this.photo2.Image = ((System.Drawing.Image)(resources.GetObject("photo2.Image")));
            this.photo2.Location = new System.Drawing.Point(290, 97);
            this.photo2.Name = "photo2";
            this.photo2.Size = new System.Drawing.Size(147, 193);
            this.photo2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.photo2.TabIndex = 24;
            this.photo2.TabStop = false;
            // 
            // atempts_lbl
            // 
            this.atempts_lbl.AutoSize = true;
            this.atempts_lbl.Font = new System.Drawing.Font("Rubik", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.atempts_lbl.Location = new System.Drawing.Point(333, 66);
            this.atempts_lbl.Name = "atempts_lbl";
            this.atempts_lbl.Size = new System.Drawing.Size(55, 28);
            this.atempts_lbl.TabIndex = 25;
            this.atempts_lbl.Text = "0/8";
            // 
            // pers_conf
            // 
            this.pers_conf.Location = new System.Drawing.Point(201, 108);
            this.pers_conf.Name = "pers_conf";
            this.pers_conf.Size = new System.Drawing.Size(83, 83);
            this.pers_conf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pers_conf.TabIndex = 26;
            this.pers_conf.TabStop = false;
            // 
            // pers_tm
            // 
            this.pers_tm.Location = new System.Drawing.Point(201, 197);
            this.pers_tm.Name = "pers_tm";
            this.pers_tm.Size = new System.Drawing.Size(83, 83);
            this.pers_tm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pers_tm.TabIndex = 27;
            this.pers_tm.TabStop = false;
            // 
            // pers_pos
            // 
            this.pers_pos.AutoSize = true;
            this.pers_pos.Font = new System.Drawing.Font("Rubik", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pers_pos.Location = new System.Drawing.Point(461, 99);
            this.pers_pos.Name = "pers_pos";
            this.pers_pos.Size = new System.Drawing.Size(26, 28);
            this.pers_pos.TabIndex = 28;
            this.pers_pos.Text = "?";
            // 
            // pers_age
            // 
            this.pers_age.AutoSize = true;
            this.pers_age.Font = new System.Drawing.Font("Rubik", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pers_age.Location = new System.Drawing.Point(452, 145);
            this.pers_age.Name = "pers_age";
            this.pers_age.Size = new System.Drawing.Size(40, 28);
            this.pers_age.TabIndex = 29;
            this.pers_age.Text = "??";
            // 
            // pers_numb
            // 
            this.pers_numb.AutoSize = true;
            this.pers_numb.Font = new System.Drawing.Font("Rubik", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pers_numb.Location = new System.Drawing.Point(443, 197);
            this.pers_numb.Name = "pers_numb";
            this.pers_numb.Size = new System.Drawing.Size(56, 28);
            this.pers_numb.TabIndex = 30;
            this.pers_numb.Text = "#??";
            // 
            // height_pb
            // 
            this.height_pb.Location = new System.Drawing.Point(590, 355);
            this.height_pb.Name = "height_pb";
            this.height_pb.Size = new System.Drawing.Size(107, 105);
            this.height_pb.TabIndex = 31;
            // 
            // height_lbl
            // 
            this.height_lbl.AutoSize = true;
            this.height_lbl.Font = new System.Drawing.Font("Rubik", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.height_lbl.Location = new System.Drawing.Point(620, 395);
            this.height_lbl.Name = "height_lbl";
            this.height_lbl.Size = new System.Drawing.Size(54, 28);
            this.height_lbl.TabIndex = 32;
            this.height_lbl.Text = "???";
            // 
            // pers_height
            // 
            this.pers_height.AutoSize = true;
            this.pers_height.Font = new System.Drawing.Font("Rubik", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pers_height.Location = new System.Drawing.Point(443, 240);
            this.pers_height.Name = "pers_height";
            this.pers_height.Size = new System.Drawing.Size(54, 28);
            this.pers_height.TabIndex = 33;
            this.pers_height.Text = "???";
            // 
            // Game_Guess_BB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 523);
            this.Controls.Add(this.pers_height);
            this.Controls.Add(this.height_lbl);
            this.Controls.Add(this.height_pb);
            this.Controls.Add(this.pers_numb);
            this.Controls.Add(this.pers_age);
            this.Controls.Add(this.pers_pos);
            this.Controls.Add(this.pers_tm);
            this.Controls.Add(this.pers_conf);
            this.Controls.Add(this.atempts_lbl);
            this.Controls.Add(this.photo2);
            this.Controls.Add(this.numb_lbl);
            this.Controls.Add(this.age_lbl);
            this.Controls.Add(this.pos_lbl);
            this.Controls.Add(this.tm_pict);
            this.Controls.Add(this.con_pict);
            this.Controls.Add(this.number_pb);
            this.Controls.Add(this.age_pb);
            this.Controls.Add(this.position_pb);
            this.Controls.Add(this.team_pb);
            this.Controls.Add(this.conf_pb);
            this.Controls.Add(this.search_txtbox);
            this.Controls.Add(this.show_btn);
            this.Controls.Add(this.hide_btn);
            this.Controls.Add(this.photo_pictureBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Game_Guess_BB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Хто я ?";
            ((System.ComponentModel.ISupportInitialize)(this.photo_pictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.con_pict)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tm_pict)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.photo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pers_conf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pers_tm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox photo_pictureBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem help;
        private System.Windows.Forms.Button hide_btn;
        private System.Windows.Forms.Button show_btn;
        private System.Windows.Forms.TextBox search_txtbox;
        private System.Windows.Forms.ProgressBar conf_pb;
        private System.Windows.Forms.ProgressBar team_pb;
        private System.Windows.Forms.ProgressBar number_pb;
        private System.Windows.Forms.ProgressBar age_pb;
        private System.Windows.Forms.ProgressBar position_pb;
        private System.Windows.Forms.PictureBox con_pict;
        private System.Windows.Forms.PictureBox tm_pict;
        private System.Windows.Forms.Label pos_lbl;
        private System.Windows.Forms.Label age_lbl;
        private System.Windows.Forms.Label numb_lbl;
        private System.Windows.Forms.PictureBox photo2;
        private System.Windows.Forms.ToolStripMenuItem Check;
        private System.Windows.Forms.ToolStripMenuItem Hint;
        private System.Windows.Forms.Label atempts_lbl;
        private System.Windows.Forms.PictureBox pers_conf;
        private System.Windows.Forms.PictureBox pers_tm;
        private System.Windows.Forms.Label pers_pos;
        private System.Windows.Forms.Label pers_age;
        private System.Windows.Forms.Label pers_numb;
        private System.Windows.Forms.ProgressBar height_pb;
        private System.Windows.Forms.Label height_lbl;
        private System.Windows.Forms.Label pers_height;
        private System.Windows.Forms.ToolTip TT;
    }
}