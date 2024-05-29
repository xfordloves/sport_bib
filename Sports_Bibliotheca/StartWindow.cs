using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sports_Bibliotheca
{
    public partial class ChooseSportWindow : Form
    {
        public ChooseSportWindow()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(SW_KeyDown);
        }

        private void FB_pictureBox_Click(object sender, EventArgs e)
        {
            Football FB = new Football();
            FB.Show();
        }

        private void BB_pictureBox_Click(object sender, EventArgs e)
        {
            Basketball BB = new Basketball();
            BB.Show();
        }

        private void help_Click(object sender, EventArgs e)
        {
            Help_Window help = new Help_Window();
            help.Show();
        }

        private void SW_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                help.PerformClick();
            }
        }

        private void aboutus_Click(object sender, EventArgs e)
        {
            AboutUs aboutus = new AboutUs();
            aboutus.Show();
        }
    }
}
