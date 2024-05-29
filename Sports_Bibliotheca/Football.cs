using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace Sports_Bibliotheca
{
    public partial class Football : Form
    {

        public Football()
        {
            InitializeComponent();
            ResolutionSettings();

            nation_comboBox.Items.Add("Аргентина");nation_comboBox.Items.Add("Австрія");
            nation_comboBox.Items.Add("Алжир"); nation_comboBox.Items.Add("Албанія"); 
            nation_comboBox.Items.Add("Англія"); nation_comboBox.Items.Add("Ангола");
            nation_comboBox.Items.Add("Бельгія"); nation_comboBox.Items.Add("Боснія і Герцеговина");
            nation_comboBox.Items.Add("Бразилія"); nation_comboBox.Items.Add("Буркіна-Фасо"); 
            nation_comboBox.Items.Add("Бурунді"); nation_comboBox.Items.Add("Венесуела"); 
            nation_comboBox.Items.Add("Вельс"); nation_comboBox.Items.Add("Вірменія"); 
            nation_comboBox.Items.Add("Габон"); nation_comboBox.Items.Add("Гана");
            nation_comboBox.Items.Add("Гваделупа");nation_comboBox.Items.Add("Гвінея");
            nation_comboBox.Items.Add("Гвінея-Бісау"); nation_comboBox.Items.Add("Греція");
            nation_comboBox.Items.Add("Грузія"); nation_comboBox.Items.Add("Данія");
            nation_comboBox.Items.Add("ДР Конго");  nation_comboBox.Items.Add("Еквадор");
            nation_comboBox.Items.Add("Єгипет"); nation_comboBox.Items.Add("Ізраїль");
            nation_comboBox.Items.Add("Іран"); nation_comboBox.Items.Add("Ірландія");
            nation_comboBox.Items.Add("Ісландія");nation_comboBox.Items.Add("Іспанія");
            nation_comboBox.Items.Add("Італія");  nation_comboBox.Items.Add("Канада");
            nation_comboBox.Items.Add("Камерун"); nation_comboBox.Items.Add("Колумбія");
            nation_comboBox.Items.Add("Косово");  nation_comboBox.Items.Add("Коста-Рика");
            nation_comboBox.Items.Add("Кот-д'Івуар"); nation_comboBox.Items.Add("Малі");
            nation_comboBox.Items.Add("Марокко");nation_comboBox.Items.Add("Мексика");
            nation_comboBox.Items.Add("Мозамбік"); nation_comboBox.Items.Add("Нігерія");
            nation_comboBox.Items.Add("Німеччина"); nation_comboBox.Items.Add("Нідерланди");
            nation_comboBox.Items.Add("Норвегія");  nation_comboBox.Items.Add("Парагвай");
            nation_comboBox.Items.Add("Південна Корея"); nation_comboBox.Items.Add("Північна Македонія");
            nation_comboBox.Items.Add("Польща");nation_comboBox.Items.Add("Португалія");
            nation_comboBox.Items.Add("Саудівська Аравія"); nation_comboBox.Items.Add("Сенегал");
            nation_comboBox.Items.Add("Сербія"); nation_comboBox.Items.Add("Сирія");
            nation_comboBox.Items.Add("Словакія"); nation_comboBox.Items.Add("Словенія");
            nation_comboBox.Items.Add("Суринам");nation_comboBox.Items.Add("США");
            nation_comboBox.Items.Add("Туніс"); nation_comboBox.Items.Add("Туреччина");
            nation_comboBox.Items.Add("Угорщина"); nation_comboBox.Items.Add("Україна");
            nation_comboBox.Items.Add("Уругвай"); nation_comboBox.Items.Add("Фінляндія");
            nation_comboBox.Items.Add("Франція"); nation_comboBox.Items.Add("Хорватія");
            nation_comboBox.Items.Add("ЦАР");  nation_comboBox.Items.Add("Чехія");
            nation_comboBox.Items.Add("Чилі"); nation_comboBox.Items.Add("Чорногорія");
            nation_comboBox.Items.Add("Швейцарія"); nation_comboBox.Items.Add("Шотландія");
            nation_comboBox.Items.Add("Швеція"); nation_comboBox.Items.Add("Ямайка");
            nation_comboBox.Items.Add("Японія");


            position_comboBox.Items.Add("Воротар"); position_comboBox.Items.Add("Центральний Захисник"); position_comboBox.Items.Add("Лівий Захисник");
            position_comboBox.Items.Add("Правий Захисник"); position_comboBox.Items.Add("Опорний Півзахисник"); position_comboBox.Items.Add("Центральний Півзахисник");
            position_comboBox.Items.Add("Лівий Півзахисник"); position_comboBox.Items.Add("Правий Півзахисник"); position_comboBox.Items.Add("Атакувальний Півзахисник");
            position_comboBox.Items.Add("Лівий Вінгер"); position_comboBox.Items.Add("Правий Вінгер"); position_comboBox.Items.Add("Відтянутий Нападник");
            position_comboBox.Items.Add("Центральний Нападник");

            league_comboBox.Items.Add("Бундесліга (Німеччина)"); 
            league_comboBox.Items.Add("Вища Ліга Футболу (США)"); 
            league_comboBox.Items.Add("Ередивізі (Нідерланди)"); 
            league_comboBox.Items.Add("Ла Ліга (Іспанія)"); 
            league_comboBox.Items.Add("Ліга Бетклік (Португалія)"); 
            league_comboBox.Items.Add("Ліга 1 (Франція)"); 
            league_comboBox.Items.Add("Прем'єр Ліга (Англія)"); 
            league_comboBox.Items.Add("Прем'єр Ліга (Україна)"); 
            league_comboBox.Items.Add("Саудівська Про Ліга (Саудівська Аравія)"); 
            league_comboBox.Items.Add("Серіа А (Італія)"); 
            
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Football_KeyDown);
        }

        public class Player
        {
            public int Номер { get; set; }
            public string Імя { get; set; }
            public string Прізвище { get; set; }
            public string Позиція { get; set; }
            public int Вік { get; set; }
            public string Національність { get; set; }
            public string Клуб { get; set; }
            public int Зріст { get; set; }
            public string Фото { get; set; }
            public string ФотоКлуба { get; set; }
            public int Рейтинг { get; set; }
            public int ЛЧ { get; set; }
            public int ЛЄ { get; set; }
            public int ЛК { get; set; }
            public int Ч { get; set; }
            public int НК { get; set; }
            public int ЧС { get; set; }
            public int КК { get; set; }
            public int ЗМ { get; set; }
            public int Швидкість_Стрибки { get; set; }
            public int Удар_ГР { get; set; }
            public int Паси_ГН { get; set; }
            public int Дриблінг_Рефлекси { get; set; }
            public int Захист_ШК { get; set; }
            public int ФізичніНавички_Поз { get; set; }
            public string Ліга { get; set; }

        }

        private List<Player> LoadPlayers()
        {
            string json = File.ReadAllText("data\\Football_players.json");
            return JsonConvert.DeserializeObject<List<Player>>(json, new JsonSerializerSettings
            {
                DateParseHandling = DateParseHandling.None,
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        private List<Player> FilterPlayers(List<Player> players)
        {
            // Create a list to store the filtered players
            List<Player> filteredPlayers = new List<Player>();

            // Iterate through each player in the data source
            foreach (Player player in players)
            {
                // Check if the player matches the search criteria
                bool matchesCriteria = true;

                if (age_numericUpDown.Value != 0)
                {
                    matchesCriteria &= player.Вік == age_numericUpDown.Value;
                }

                if (!string.IsNullOrEmpty(club_textBox.Text))
                {
                    matchesCriteria &= player.Клуб.ToLower().Contains(club_textBox.Text.ToLower());
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

                if (number_numericUpDown.Value != 0)
                {
                    matchesCriteria &= player.Номер == number_numericUpDown.Value;
                }

                if (!string.IsNullOrEmpty(height_textBox.Text))
                {
                    matchesCriteria &= player.Зріст == int.Parse(height_textBox.Text);
                }

                if (nation_comboBox.SelectedIndex != -1)
                {
                    matchesCriteria &= player.Національність == nation_comboBox.SelectedItem.ToString();
                }

                if (league_comboBox.SelectedIndex != -1)
                {
                    matchesCriteria &= player.Ліга == league_comboBox.SelectedItem.ToString();
                }

                if (alltrophies_numericUpDown.Value != 0)
                {
                    int alltrophies = player.Ч + player.ЧС + player.НК + player.КК + player.ЛЧ + player.ЛЄ + player.ЛК + player.ЗМ;
                    matchesCriteria &= alltrophies == alltrophies_numericUpDown.Value;
                }

                // If the player matches all the search criteria, add it to the filtered players list
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
            // Load the list of players from the JSON file
            List<Player> players = LoadPlayers();

            // Filter the players based on the input fields in the search_groupBox
            List<Player> filteredPlayers = FilterPlayers(players);

            // Check if the filtered players list is not empty
            if (filteredPlayers.Any())
            {
                // Display the filtered players in the FB_dataGridView
                FB_dataGridView.DataSource = filteredPlayers;
            }
            else
            {
                // Display a message if the filtered players list is empty
                MessageBox.Show("Не знайдено футболістів, що відповідають критеріям пошуку", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FB_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked row is not the header row
            if (e.RowIndex >= 0)
            {
                // Get the selected player from the data grid view
                Player selectedPlayer = (Player)FB_dataGridView.Rows[e.RowIndex].DataBoundItem;

                if (selectedPlayer != null)
                {
                    // Check if the photo file exists
                    if ((!string.IsNullOrEmpty(selectedPlayer.Фото) && File.Exists(selectedPlayer.Фото)))
                    {



                        // Create an Image object from the photo file
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
                        UCl_label.Text = selectedPlayer.ЛЧ.ToString();
                        UEL_label.Text = selectedPlayer.ЛЄ.ToString();
                        CL_label.Text = selectedPlayer.ЛК.ToString();
                        BDOR_label.Text = selectedPlayer.ЗМ.ToString();
                        Champ_label.Text = selectedPlayer.Ч.ToString();
                        LeagueCup_label.Text = selectedPlayer.НК.ToString();
                        WC_label.Text = selectedPlayer.ЧС.ToString();
                        Continental_label.Text = selectedPlayer.КК.ToString();

                        // Display the image in the photo_pictureBox
                        photo_pictureBox.Image = playerImage;

                        pace.Value = selectedPlayer.Швидкість_Стрибки;
                        shoot.Value = selectedPlayer.Удар_ГР;
                        pass.Value = selectedPlayer.Паси_ГН;
                        dribble.Value = selectedPlayer.Дриблінг_Рефлекси;
                        defense.Value = selectedPlayer.Захист_ШК;
                        physicality.Value = selectedPlayer.ФізичніНавички_Поз;

                        val_pace.Text = selectedPlayer.Швидкість_Стрибки.ToString();
                        val_shoot.Text = selectedPlayer.Удар_ГР.ToString();
                        val_pass.Text = selectedPlayer.Паси_ГН.ToString();
                        val_dribble.Text = selectedPlayer.Дриблінг_Рефлекси.ToString();
                        val_defense.Text = selectedPlayer.Захист_ШК.ToString();
                        val_phys.Text = selectedPlayer.ФізичніНавички_Поз.ToString();

                        just_text.ForeColor = Color.White;
                        label1.ForeColor = Color.White;

                        if ((selectedPlayer.Клуб == "Ліверпуль") || (selectedPlayer.Клуб == "Манчестер Юнайтед")
                            || (selectedPlayer.Клуб == "Борнмут") || (selectedPlayer.Клуб == "Атлетік Більбао")
                            || (selectedPlayer.Клуб == "Мілан") || (selectedPlayer.Клуб == "Монако")
                            || (selectedPlayer.Клуб == "Ренн") || (selectedPlayer.Клуб == "Баварія Мюнхен")
                            || (selectedPlayer.Клуб == "Айнтрахт Франкфурт") || (selectedPlayer.Клуб == "Феєноорд"))
                        {
                            this.BackColor = Color.Red;
                        }

                        if ((selectedPlayer.Клуб == "Манчестер Сіті") || (selectedPlayer.Клуб == "Олімпік Марсель"))
                        {
                            this.BackColor = Color.DeepSkyBlue;
                        }

                        if ((selectedPlayer.Клуб == "Арсенал") || (selectedPlayer.Клуб == "Жирона")
                            || (selectedPlayer.Клуб == "Севілья") || (selectedPlayer.Клуб == "Ніцца")
                            || (selectedPlayer.Клуб == "Байер Леверкузен") || (selectedPlayer.Клуб == "Штутгарт")
                            || (selectedPlayer.Клуб == "РБ Лейпциг") || (selectedPlayer.Клуб == "ПСВ")|| (selectedPlayer.Клуб == "Бенфіка"))
                        {
                            this.BackColor = Color.Crimson;
                        }

                        if (selectedPlayer.Клуб == "Астон Вілла")
                        {
                            this.BackColor = Color.MediumVioletRed;
                        }

                        if ((selectedPlayer.Клуб == "Тотенхем Хотспур") || (selectedPlayer.Клуб == "Атлетіко Мадрид")
                            || (selectedPlayer.Клуб == "Дженоа") || (selectedPlayer.Клуб == "ЛОСК Лілль"))
                        {
                            this.BackColor = Color.Navy;
                        }

                        if ((selectedPlayer.Клуб == "Вест Хем Юнайтед") || (selectedPlayer.Клуб == "Рома"))
                        {
                            this.BackColor = Color.Brown;
                        }

                        if (selectedPlayer.Клуб == "Ньюкасл Юнайтед")
                        {
                            this.BackColor = Color.DarkTurquoise;
                        }

                        if ((selectedPlayer.Клуб == "Олімпік Ліон") || (selectedPlayer.Клуб == "Челсі"))
                        {
                            this.BackColor = Color.MediumBlue;
                        }

                        if ((selectedPlayer.Клуб == "Брайтон енд Гоув Альбіон") || (selectedPlayer.Клуб == "Евертон")
                            || (selectedPlayer.Клуб == "Барселона") || (selectedPlayer.Клуб == "Реал Сосьєдад")
                            || (selectedPlayer.Клуб == "Аталанта") || (selectedPlayer.Клуб == "Порту")
                            || (selectedPlayer.Клуб == "Динамо Київ"))
                        {
                            this.BackColor = Color.RoyalBlue;
                        }

                        if ((selectedPlayer.Клуб == "Реал Мадрид") || (selectedPlayer.Клуб == "Аякс"))
                        {
                            this.BackColor = Color.SeaShell;
                            just_text.ForeColor = Color.Black;
                            label1.ForeColor = Color.Black;
                        }

                        if ((selectedPlayer.Клуб == "Валенсія") || (selectedPlayer.Клуб == "Ювентус")
                            || (selectedPlayer.Клуб == "Боруссія Менхенгладбах") || (selectedPlayer.Клуб == "Аль Іттіхад"))
                        {
                            this.BackColor = Color.Black;
                        }

                        if ((selectedPlayer.Клуб == "Реал Бетіс") || (selectedPlayer.Клуб == "Спортінг Лісабон") || (selectedPlayer.Клуб == "Аль Аглі"))
                        {
                            this.BackColor = Color.SeaGreen;
                        }

                        if ((selectedPlayer.Клуб == "Вілереал") || (selectedPlayer.Клуб == "Парі Сен-Жермен (ПСЖ)"))
                        {
                            this.BackColor = Color.MidnightBlue;
                        }

                        if ((selectedPlayer.Клуб == "Інтернаціонале") || (selectedPlayer.Клуб == "Аль Хіляль"))
                        {
                            this.BackColor = Color.Blue;
                        }

                        if (selectedPlayer.Клуб == "Наполі")
                        {
                            this.BackColor = Color.DodgerBlue;
                        }

                        if (selectedPlayer.Клуб == "Болонья")
                        {
                            this.BackColor = Color.Firebrick;
                        }

                        if (selectedPlayer.Клуб == "Фіорентіна")
                        {
                            this.BackColor = Color.DarkSlateBlue;
                        }

                        if (selectedPlayer.Клуб == "Лаціо")
                        {
                            this.BackColor = Color.SkyBlue;
                        }

                        if (selectedPlayer.Клуб == "Боруссія Дортмунд")
                        {
                            this.BackColor = Color.Yellow;
                        }

                        if (selectedPlayer.Клуб == "Вольфсбург")
                        {
                            this.BackColor = Color.Lime;
                        }

                        if (selectedPlayer.Клуб == "Аль Наср")
                        {
                            this.BackColor = Color.Gold;
                        }

                        if (selectedPlayer.Клуб == "Інтер Маямі")
                        {
                            this.BackColor = Color.Pink;
                        }

                        if (selectedPlayer.Клуб == "Шахтар")
                        {
                            this.BackColor = Color.DarkOrange;
                        }

                        if (selectedPlayer.Позиція == "Воротар")
                        {
                            pace_lbl.Text = "Стрибки";
                            shoot_lbl.Text = "Гра Руками";
                            pass_lbl.Text = "Гра Ногами";
                            dribble_lbl.Text = "Рефлекси";
                            defense_lbl.Text = "Швидкість";
                            physica_lbl.Text = "Позиціонування";
                        }
                        else
                        {
                            pace_lbl.Text = "Швидкість";
                            shoot_lbl.Text = "Удар";
                            pass_lbl.Text = "Паси";
                            dribble_lbl.Text = "Дриблінг";
                            defense_lbl.Text = "Захист";
                            physica_lbl.Text = "Фізичні Навички";
                        }

                    }


                    else
                    {
                        // Display a default image if the photo file does not exist
                        Cover.Visible = true;
                        photo_pictureBox.Image = Image.FromFile("images_FB\\default_player.jpg");
                        Rate.Text = "??";
                        rate_pictureBox.BackColor = Color.RoyalBlue;

                    }
                    //Перевірка наявності фото клубу
                    if ((!string.IsNullOrEmpty(selectedPlayer.ФотоКлуба) && File.Exists(selectedPlayer.ФотоКлуба)))
                    {
                        // Create an Image object from the photo file

                        Image teamImage = Image.FromFile(selectedPlayer.ФотоКлуба);

                        // Display the image in the photo_pictureBox
                        team_pictureBox.Image = teamImage;
                    }
                    else
                    {
                        // Display a default image if the photo file does not exist
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

        private void Football_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Викликайте метод пошуку, коли натискається Enter
                search_button.PerformClick();
            }
            if (e.KeyCode == Keys.F1)
            {
               
                help.PerformClick();
            }
        }

        private void game_Click(object sender, EventArgs e)
        {
            Game_Guess_FB game = new Game_Guess_FB();
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

            // Отримання роздільної здатності екрану
            int screenWidth = primaryScreen.Bounds.Width;
            int screenHeight = primaryScreen.Bounds.Height;

            // Перевірка розрядності екрану
            if (screenWidth == 1536 && screenHeight == 864)
            {

                
            }
            if(screenWidth == 1366 && screenHeight == 768)
            {

                label.Location = new Point(406,30);
                //pace_lbl
                pace_lbl.Location = new Point(350, 59);

                //pace
                pace.Location = new Point(352, 75);
                pace.Size = new Size(100, 5);

                //val_pace
                val_pace.Location = new Point(438, 59);

                //--------------------------------------------------
                //shoot_lbl
                shoot_lbl.Location = new Point(350, 83);

                //shoot
                shoot.Location = new Point(352, 98);
                shoot.Size = new Size(100, 5);

                //val_shoot
                val_shoot.Location = new Point(438, 83);

                //--------------------------------------------------
                //pass_lbl
                pass_lbl.Location = new Point(350, 110);

                //pass
                pass.Location = new Point(352, 125);
                pass.Size = new Size(100, 5);

                //val_pass
                val_pass.Location = new Point(438, 110);

                //--------------------------------------------------
                //dribble_lbl
                dribble_lbl.Location = new Point(481, 60);

                //dribble
                dribble.Location = new Point(481, 74);
                dribble.Size = new Size(100, 5);

                //val_dribble
                val_dribble.Location = new Point(566, 60);

                //--------------------------------------------------
                //defense_lbl
                defense_lbl.Location = new Point(481, 84);

                //defense
                defense.Location = new Point(481, 98);
                defense.Size = new Size(100, 5);

                //val_defense
                val_defense.Location = new Point(566, 84);

                //--------------------------------------------------
                //physica_lbl
                physica_lbl.Location = new Point(479, 110);

                //physicality
                physicality.Location = new Point(481, 125);
                physicality.Size = new Size(100, 5);

                //val_phys
                val_phys.Location = new Point(566, 110);

                //--------------------------------------------------

                trophies_label.Location = new Point(700,15);

                pictureBox4.Location = new Point(600,38);
                UCl_label.Location = new Point(662,60);

                pictureBox1.Location = new Point(600,100);
                Champ_label.Location = new Point(662,122);

                pictureBox2.Location = new Point(682, 38);
                UEL_label.Location = new Point(742, 60);

                pictureBox5.Location = new Point(682, 100);
                LeagueCup_label.Location = new Point(742, 122);

                pictureBox3.Location = new Point(762, 38);
                CL_label.Location = new Point(822, 60);

                pictureBox7.Location = new Point(762, 100);
                WC_label.Location = new Point(822, 122);

                pictureBox8.Location = new Point(842, 38);
                Continental_label.Location = new Point(902, 122);

                pictureBox6.Location = new Point(842, 100);
                BDOR_label.Location = new Point(902, 60);
            }
            if(screenWidth == 1344 && screenHeight == 840)
            {

                label.Location = new Point(406,30);
                //pace_lbl
                pace_lbl.Location = new Point(350, 59);

                //pace
                pace.Location = new Point(352, 75);
                pace.Size = new Size(100, 5);

                //val_pace
                val_pace.Location = new Point(438, 59);

                //--------------------------------------------------
                //shoot_lbl
                shoot_lbl.Location = new Point(350, 83);

                //shoot
                shoot.Location = new Point(352, 98);
                shoot.Size = new Size(100, 5);

                //val_shoot
                val_shoot.Location = new Point(438, 83);

                //--------------------------------------------------
                //pass_lbl
                pass_lbl.Location = new Point(350, 110);

                //pass
                pass.Location = new Point(352, 125);
                pass.Size = new Size(100, 5);

                //val_pass
                val_pass.Location = new Point(438, 110);

                //--------------------------------------------------
                //dribble_lbl
                dribble_lbl.Location = new Point(481, 60);

                //dribble
                dribble.Location = new Point(481, 74);
                dribble.Size = new Size(100, 5);

                //val_dribble
                val_dribble.Location = new Point(566, 60);

                //--------------------------------------------------
                //defense_lbl
                defense_lbl.Location = new Point(481, 84);

                //defense
                defense.Location = new Point(481, 98);
                defense.Size = new Size(100, 5);

                //val_defense
                val_defense.Location = new Point(566, 84);

                //--------------------------------------------------
                //physica_lbl
                physica_lbl.Location = new Point(479, 110);

                //physicality
                physicality.Location = new Point(481, 125);
                physicality.Size = new Size(100, 5);

                //val_phys
                val_phys.Location = new Point(566, 110);

                //--------------------------------------------------

                trophies_label.Location = new Point(700,15);

                pictureBox4.Location = new Point(585,38);
                UCl_label.Location = new Point(647,60);

                pictureBox1.Location = new Point(585,100);
                Champ_label.Location = new Point(647,122);

                pictureBox2.Location = new Point(667, 38);
                UEL_label.Location = new Point(727, 60);

                pictureBox5.Location = new Point(667, 100);
                LeagueCup_label.Location = new Point(727, 122);

                pictureBox3.Location = new Point(747, 38);
                CL_label.Location = new Point(807, 60);

                pictureBox7.Location = new Point(747, 100);
                WC_label.Location = new Point(807, 122);

                pictureBox8.Location = new Point(827, 38);
                Continental_label.Location = new Point(887, 122);

                pictureBox6.Location = new Point(827, 100);
                BDOR_label.Location = new Point(887, 60);
            }
        }

    }
}

