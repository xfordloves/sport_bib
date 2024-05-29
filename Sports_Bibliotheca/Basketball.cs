using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Sports_Bibliotheca
{
    public partial class Basketball : Form
    {
        public Basketball()
        {
            InitializeComponent();
            ResolutionSettings();

            nation_comboBox.Items.Add("Австралія");
            nation_comboBox.Items.Add("Австрія");
            nation_comboBox.Items.Add("Ангола");
            nation_comboBox.Items.Add("Багамські острови");
            nation_comboBox.Items.Add("Бельгія");
            nation_comboBox.Items.Add("Болгарія");
            nation_comboBox.Items.Add("Боснія і Герцеговина");
            nation_comboBox.Items.Add("Велика Британія");
            nation_comboBox.Items.Add("Греція");
            nation_comboBox.Items.Add("Грузія");
            nation_comboBox.Items.Add("Домініканська Республіка");
            nation_comboBox.Items.Add("ДР Конго");
            nation_comboBox.Items.Add("Ізраїль");
            nation_comboBox.Items.Add("Іспанія");
            nation_comboBox.Items.Add("Італія");
            nation_comboBox.Items.Add("Камерун");
            nation_comboBox.Items.Add("Канада");
            nation_comboBox.Items.Add("Латвія");
            nation_comboBox.Items.Add("Литва");
            nation_comboBox.Items.Add("Нігерія");
            nation_comboBox.Items.Add("Німеччина");
            nation_comboBox.Items.Add("Нова Зеландія");
            nation_comboBox.Items.Add("Південний Судан");
            nation_comboBox.Items.Add("Польща");
            nation_comboBox.Items.Add("Сент-Люсія");
            nation_comboBox.Items.Add("Сербія");
            nation_comboBox.Items.Add("Словенія");
            nation_comboBox.Items.Add("Судан");
            nation_comboBox.Items.Add("США");
            nation_comboBox.Items.Add("Туреччина");
            nation_comboBox.Items.Add("Україна");
            nation_comboBox.Items.Add("Фінляндія");
            nation_comboBox.Items.Add("Франція");
            nation_comboBox.Items.Add("Хорватія");
            nation_comboBox.Items.Add("Чорногорія");
            nation_comboBox.Items.Add("Швейцарія");
            nation_comboBox.Items.Add("Ямайка");
            nation_comboBox.Items.Add("Японія");

            position_comboBox.Items.Add("Захисник");
            position_comboBox.Items.Add("Захисник-Форвард");
            position_comboBox.Items.Add("Форвард");
            position_comboBox.Items.Add("Форвард-Захисник");
            position_comboBox.Items.Add("Форвард-Центровий");
            position_comboBox.Items.Add("Центровий");
            position_comboBox.Items.Add("Центровий-Форвард");

            conf_comboBox.Items.Add("Східна Конференція");
            conf_comboBox.Items.Add("Західна Конференція");

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Basketball_KeyDown);

        }

        public class Player
        {
            public string Номер { get; set; }
            public string Імя { get; set; }
            public string Прізвище { get; set; }
            public string Позиція { get; set; }
            public int Вік { get; set; }
            public string Національність { get; set; }
            public string Команда { get; set; }
            public int Зріст { get; set; }
            public string Фото { get; set; }
            public string ФотоКоманди { get; set; }
            public int Рейтинг { get; set; }
            public int Ч { get; set; }
            public int МВП { get; set; }
            public int АЛС { get; set; }
            public int ДПР { get; set; }
            public int МВПФ { get; set; }
            public int АЛНТ { get; set; }
            public int МІП { get; set; }
            public int АЛДТ { get; set; }
            public int ЗовнішнійКидок { get; set; }
            public int ВнутрішнійКидок { get; set; }
            public int Розігрування { get; set; }
            public int Підбирання { get; set; }
            public int Захист { get; set; }
            public int Атлетизм { get; set; }
            public string Конференція { get; set; }
        }

        private List<Player> LoadPlayers()
        {
            //завнатаження гравців з бази даних
            string json = File.ReadAllText("data\\Basketball_players.json");
            //десереалізація
            return JsonConvert.DeserializeObject<List<Player>>(json, new JsonSerializerSettings
            {
                DateParseHandling = DateParseHandling.None,
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        //фільтрування гравців (залежить від заповнених полів)
        private List<Player> FilterPlayers(List<Player> players)
        {
           //сюде додаватимуться гравці що підходять
            List<Player> filteredPlayers = new List<Player>();

           
            foreach (Player player in players)
            {
                
                bool matchesCriteria = true;

                if (age_numericUpDown.Value != 0)
                {
                    matchesCriteria &= player.Вік == age_numericUpDown.Value;
                }

                if (!string.IsNullOrEmpty(club_textBox.Text))
                {
                    matchesCriteria &= player.Команда.ToLower().Contains(club_textBox.Text.ToLower());
                }

                if (!string.IsNullOrEmpty(surname_textBox.Text))
                {
                    matchesCriteria &= player.Прізвище.ToLower().Contains(surname_textBox.Text.ToLower());
                }

                if (!string.IsNullOrEmpty(name_textBox.Text))
                {
                    matchesCriteria &= player.Імя.ToLower().Contains(name_textBox.Text.ToLower());
                }

                if (position_comboBox.SelectedIndex != -1)
                {
                    matchesCriteria &= player.Позиція == position_comboBox.SelectedItem.ToString();
                }

                if (!string.IsNullOrEmpty(number_textBox.Text))
                {
                    string searchTerm = @"\b" + Regex.Escape(number_textBox.Text.ToLower()) + @"\b";
                    matchesCriteria &= Regex.IsMatch(player.Номер.ToLower(), searchTerm);
                }

                if (!string.IsNullOrEmpty(height_textBox.Text))
                {
                    matchesCriteria &= player.Зріст == int.Parse(height_textBox.Text);
                }

                if (nation_comboBox.SelectedIndex != -1)
                {
                    matchesCriteria &= player.Національність == nation_comboBox.SelectedItem.ToString();
                }

                if (conf_comboBox.SelectedIndex != -1)
                {
                    matchesCriteria &= player.Конференція == conf_comboBox.SelectedItem.ToString();
                }

                if (alltrophies_numericUpDown.Value != 0)
                {
                    int alltrophies = player.АЛС + player.АЛДТ + player.АЛНТ + player.ДПР + player.МІП + player.МВП + player.МВПФ + player.Ч;
                    matchesCriteria &= alltrophies == alltrophies_numericUpDown.Value;
                }

                
                if (matchesCriteria)
                {
                    filteredPlayers.Add(player);
                }
            }

            List<Player> sortedPlayers = filteredPlayers.OrderByDescending(player => player.Рейтинг).ToList();

            return sortedPlayers;
        }



        private void search_button_Click(object sender, EventArgs e)
        {
            List<Player> players = LoadPlayers();

            List<Player> filteredPlayers = FilterPlayers(players);

            if (filteredPlayers.Any())
            {
                BB_dataGridView.DataSource = filteredPlayers;
            }
            else
            {
                MessageBox.Show("Не знайдено баскетболістів, що відповідають критеріям пошуку", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        private void BB_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                
                Player selectedPlayer = (Player)BB_dataGridView.Rows[e.RowIndex].DataBoundItem;
                if (selectedPlayer != null)
                {
                    
                    if ((!string.IsNullOrEmpty(selectedPlayer.Фото) && File.Exists(selectedPlayer.Фото)))
                    {

                        
                        Image playerImage = Image.FromFile(selectedPlayer.Фото);
                        if (selectedPlayer.Рейтинг > 80)
                        {
                            Overall.Text = "Рейтинг Гравця";
                            Rate.Text = selectedPlayer.Рейтинг.ToString();
                            rate_pictureBox.BackColor = Color.Green;
                        }
                        if (selectedPlayer.Рейтинг > 70 && selectedPlayer.Рейтинг <= 80)
                        {
                            Overall.Text = "Рейтинг Гравця";
                            Rate.Text = selectedPlayer.Рейтинг.ToString();
                            rate_pictureBox.BackColor = Color.LightGreen;
                        }
                        if (selectedPlayer.Рейтинг <= 70 && selectedPlayer.Рейтинг >= 50)
                        {
                            Overall.Text = "Рейтинг Гравця";
                            Rate.Text = selectedPlayer.Рейтинг.ToString();
                            rate_pictureBox.BackColor = Color.DarkOrange;
                        }
                        if (selectedPlayer.Рейтинг < 50)
                        {
                            Overall.Text = "Рейтинг Гравця";
                            Rate.Text = selectedPlayer.Рейтинг.ToString();
                            rate_pictureBox.BackColor = Color.OrangeRed;
                        }
                        if (selectedPlayer.Рейтинг == 0)
                        {
                            Overall.Text = "Рейтинг Гравця";
                            Rate.Text = "??";
                            rate_pictureBox.BackColor = Color.RoyalBlue;
                        }

                        Cover.Visible = false;
                        trophies_label.Text = "Поличка досягнень";
                        champ_label.Text = selectedPlayer.Ч.ToString();
                        mvp_label.Text = selectedPlayer.МВП.ToString();
                        allstar_label.Text = selectedPlayer.АЛС.ToString();
                        alldef_label.Text = selectedPlayer.АЛДТ.ToString();
                        finmvp_label.Text = selectedPlayer.МВПФ.ToString();
                        allnba_label.Text = selectedPlayer.АЛНТ.ToString();
                        dpoy_label.Text = selectedPlayer.ДПР.ToString();
                        mip_label.Text = selectedPlayer.МІП.ToString();

                        
                        photo_pictureBox.Image = playerImage;

                        outside_score.Value = selectedPlayer.ЗовнішнійКидок;
                        inside_score.Value = selectedPlayer.ВнутрішнійКидок;
                        playmaking.Value = selectedPlayer.Розігрування;
                        rebound.Value = selectedPlayer.Підбирання;
                        defense.Value = selectedPlayer.Захист;
                        athleticism.Value = selectedPlayer.Атлетизм;

                        val_outscore.Text = selectedPlayer.ЗовнішнійКидок.ToString();
                        val_insscore.Text = selectedPlayer.ВнутрішнійКидок.ToString();
                        val_play.Text = selectedPlayer.Розігрування.ToString();
                        val_reb.Text = selectedPlayer.Підбирання.ToString();
                        val_def.Text = selectedPlayer.Захист.ToString();
                        val_athlet.Text = selectedPlayer.Атлетизм.ToString();

                        if (selectedPlayer.Команда == "Атланта Гокс")
                        {
                            this.BackColor = Color.Red;
                        }
                        if (selectedPlayer.Команда == "Бостон Селтікс")
                        {
                            this.BackColor = Color.ForestGreen;
                        }
                        if ((selectedPlayer.Команда == "Бруклін Нетс") || (selectedPlayer.Команда == "Юта Джаз"))
                        {
                            this.BackColor = Color.Black;
                        }
                        if (selectedPlayer.Команда == "Шарлот Горнетс")
                        {
                            this.BackColor = Color.DarkTurquoise;
                        }
                        if ((selectedPlayer.Команда == "Чикаго Буллс") || (selectedPlayer.Команда == "Х'юстон Рокетс") || (selectedPlayer.Команда == "Портленд Трейл-Блейзерс") || (selectedPlayer.Команда == "Торонто Репторз"))
                        {
                            this.BackColor = Color.Crimson;
                        }
                        if (selectedPlayer.Команда == "Клівленд Кавальєрс")
                        {
                            this.BackColor = Color.Firebrick;
                        }
                        if ((selectedPlayer.Команда == "Даллас Маверікс") || (selectedPlayer.Команда == "Детройт Пістонс") || (selectedPlayer.Команда == "Нью-Йорк Нікс"))
                        {
                            this.BackColor = Color.RoyalBlue;
                        }
                        if ((selectedPlayer.Команда == "Денвер Наггетс") || (selectedPlayer.Команда == "Індіана Пейсерс") || (selectedPlayer.Команда == "Лос-Анджелес Кліпперс"))
                        {
                            this.BackColor = Color.MidnightBlue;
                        }
                        if ((selectedPlayer.Команда == "Голден-Стейт Ворріорс") || (selectedPlayer.Команда == "Філадельфія Севенті-Сіксерс"))
                        {
                            this.BackColor = Color.MediumBlue;
                        }
                        if ((selectedPlayer.Команда == "Лос-Анджелес Лейкерс") || (selectedPlayer.Команда == "Сакраменто Кінгз"))
                        {
                            this.BackColor = Color.DarkViolet;
                        }
                        if (selectedPlayer.Команда == "Мемфіс Гріззліс")
                        {
                            this.BackColor = Color.DarkSlateBlue;
                        }
                        if (selectedPlayer.Команда == "Маямі Гіт")
                        {
                            this.BackColor = Color.Brown;
                        }
                        if (selectedPlayer.Команда == "Мілвокі Бакс")
                        {
                            this.BackColor = Color.DarkGreen;
                        }
                        if (selectedPlayer.Команда == "Міннесота Тімбервулвз")
                        {
                            this.BackColor = Color.SteelBlue;
                        }
                        if ((selectedPlayer.Команда == "Нью-Орлінс Пеліканс") || (selectedPlayer.Команда == "Вашингтон Візардс"))
                        {
                            this.BackColor = Color.Navy;
                        }
                        if ((selectedPlayer.Команда == "Оклахома-Сіті Тандер") || (selectedPlayer.Команда == "Орландо Меджик"))
                        {
                            this.BackColor = Color.DodgerBlue;
                        }
                        if (selectedPlayer.Команда == "Фінікс Санз")
                        {
                            this.BackColor = Color.Indigo;
                        }
                        if (selectedPlayer.Команда == "Сан-Антоніо Сперс")
                        {
                            this.BackColor = Color.Gray;
                        }

                    }
                    else
                    {
                        
                        Cover.Visible = true;
                        photo_pictureBox.Image = Image.FromFile("images_FB\\default_player.jpg");
                        Rate.Text = "??";
                        rate_pictureBox.BackColor = Color.RoyalBlue;

                    }
                    //Перевірка наявності фото клубу
                    if ((!string.IsNullOrEmpty(selectedPlayer.ФотоКоманди) && File.Exists(selectedPlayer.ФотоКоманди)))
                    {
                        
                        Image teamImage = Image.FromFile(selectedPlayer.ФотоКоманди);

                        team_pictureBox.Image = teamImage;
                    }
                    else
                    {
                        Cover.Visible = true;
                        team_pictureBox.Image = Image.FromFile("images_FB\\default_club.png");
                    }
                }
                else
                {
                    MessageBox.Show("Наразі таблиця пустіє , розпочніть пошук", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void Basketball_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //пошук
                search_button.PerformClick();
            }
            if (e.KeyCode == Keys.F1)
            {
                //довідка
                help.PerformClick();
            }
        }

        private void Game_Click(object sender, EventArgs e)
        {
            Game_Guess_BB game = new Game_Guess_BB();
            game.Show();
        }

        private void help_Click(object sender, EventArgs e)
        {
            Help_Window help = new Help_Window();
            help.Show();
        }

        private void aboutus_Click(object sender, EventArgs e)
        {
            AboutUs aboutus = new AboutUs();
            aboutus.Show();
        }

        private void ResolutionSettings()
        {
            Screen primaryScreen = Screen.PrimaryScreen;

           
            int screenWidth = primaryScreen.Bounds.Width;
            int screenHeight = primaryScreen.Bounds.Height;

            
            if (screenWidth == 1536 && screenHeight == 864)
            {
                

            }
            if (screenWidth == 1366 && screenHeight == 768)
            {
                
                label.Location = new Point(406, 30);
                //outscore_lbl
                outscore_lbl.Location = new Point(350, 59);

                //outside_score
                outside_score.Location = new Point(352, 75);
                outside_score.Size = new Size(100, 5);

                //val_outscore
                val_outscore.Location = new Point(438, 59);

                //--------------------------------------------------
                //insscore_lbl
                insscore_lbl.Location = new Point(350, 83);

                //inside_score
                inside_score.Location = new Point(352, 98);
                inside_score.Size = new Size(100, 5);

                //val_shoot
                val_insscore.Location = new Point(438, 83);

                //--------------------------------------------------
                //play_lbl
                play_lbl.Location = new Point(350, 110);

                //playmaking
                playmaking.Location = new Point(352, 125);
                playmaking.Size = new Size(100, 5);

                //val_play
                val_play.Location = new Point(438, 110);

                //--------------------------------------------------
                //reb_lbl
                reb_lbl.Location = new Point(481, 60);

                //rebound
                rebound.Location = new Point(481, 74);
                rebound.Size = new Size(100, 5);

                //val_reb
                val_reb.Location = new Point(566, 60);

                //--------------------------------------------------
                //defense_lbl
                def_lbl.Location = new Point(481, 84);

                //defense
                defense.Location = new Point(481, 98);
                defense.Size = new Size(100, 5);

                //val_defense
                val_def.Location = new Point(566, 84);

                //--------------------------------------------------
                //athlet_lbl
                athlet_lbl.Location = new Point(479, 110);

                //athleticism
                athleticism.Location = new Point(481, 125);
                athleticism.Size = new Size(100, 5);

                //val_athlet
                val_athlet.Location = new Point(566, 110);

                //--------------------------------------------------

                trophies_label.Location = new Point(700, 15);

                pictureBox4.Location = new Point(600, 38);
                champ_label.Location = new Point(660, 60);

                pictureBox1.Location = new Point(600, 100);
                finmvp_label.Location = new Point(660, 122);

                pictureBox2.Location = new Point(682, 38);
                mvp_label.Location = new Point(740, 60);

                pictureBox5.Location = new Point(682, 100);
                allnba_label.Location = new Point(740, 122);

                pictureBox3.Location = new Point(762, 38);
                allstar_label.Location = new Point(820, 60);

                pictureBox7.Location = new Point(762, 100);
                dpoy_label.Location = new Point(820, 122);

                pictureBox8.Location = new Point(842, 38);
                alldef_label.Location = new Point(900, 122);

                pictureBox6.Location = new Point(842, 100);
                mip_label.Location = new Point(900, 60);
            }

            if (screenWidth == 1344 && screenHeight == 840)
            {
                
                label.Location = new Point(406, 30);
                //outscore_lbl
                outscore_lbl.Location = new Point(350, 59);

                //outside_score
                outside_score.Location = new Point(352, 75);
                outside_score.Size = new Size(100, 5);

                //val_outscore
                val_outscore.Location = new Point(438, 59);

                //--------------------------------------------------
                //insscore_lbl
                insscore_lbl.Location = new Point(350, 83);

                //inside_score
                inside_score.Location = new Point(352, 98);
                inside_score.Size = new Size(100, 5);

                //val_shoot
                val_insscore.Location = new Point(438, 83);

                //--------------------------------------------------
                //play_lbl
                play_lbl.Location = new Point(350, 110);

                //playmaking
                playmaking.Location = new Point(352, 125);
                playmaking.Size = new Size(100, 5);

                //val_play
                val_play.Location = new Point(438, 110);

                //--------------------------------------------------
                //reb_lbl
                reb_lbl.Location = new Point(481, 60);

                //rebound
                rebound.Location = new Point(481, 74);
                rebound.Size = new Size(100, 5);

                //val_reb
                val_reb.Location = new Point(566, 60);

                //--------------------------------------------------
                //defense_lbl
                def_lbl.Location = new Point(481, 84);

                //defense
                defense.Location = new Point(481, 98);
                defense.Size = new Size(100, 5);

                //val_defense
                val_def.Location = new Point(566, 84);

                //--------------------------------------------------
                //athlet_lbl
                athlet_lbl.Location = new Point(479, 110);

                //athleticism
                athleticism.Location = new Point(481, 125);
                athleticism.Size = new Size(100, 5);

                //val_athlet
                val_athlet.Location = new Point(566, 110);

                //--------------------------------------------------

                trophies_label.Location = new Point(700, 15);

                pictureBox4.Location = new Point(585, 38);
                champ_label.Location = new Point(645, 60);

                pictureBox1.Location = new Point(585, 100);
                finmvp_label.Location = new Point(645, 122);

                pictureBox2.Location = new Point(667, 38);
                mvp_label.Location = new Point(725, 60);

                pictureBox5.Location = new Point(672, 100);
                allnba_label.Location = new Point(725, 122);

                pictureBox3.Location = new Point(747, 38);
                allstar_label.Location = new Point(805, 60);

                pictureBox7.Location = new Point(747, 100);
                dpoy_label.Location = new Point(805, 122);

                pictureBox8.Location = new Point(827, 38);
                alldef_label.Location = new Point(885, 122);

                pictureBox6.Location = new Point(827, 100);
                mip_label.Location = new Point(885, 60);
            }


        }
    }
}
