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
    public partial class Game_Guess_BB : Form
    {
        private List<BasketballPlayer> players;
        private BasketballPlayer currentPlayer;
        private int attempts = 0;
        private int maxAttempts = 8;
       
       
        public Game_Guess_BB()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            

            // Load players and display a random player on startup
            players = LoadPlayers();
            ShowRandomPlayer();

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Basketball_KeyDown);
        }

        public class BasketballPlayer
        {
            public string Номер { get; set; }
            public string Імя { get; set; }
            public string Прізвище { get; set; }
            public string Позиція { get; set; }
            public int Вік { get; set; }
            public string Команда { get; set; }
            public int Зріст { get; set; }
            public string Фото { get; set; }
            public string ФотоКоманди { get; set; }
            public string Конференція { get; set; }
            
        }

        private List<BasketballPlayer> LoadPlayers()
        {
            string json = File.ReadAllText("data\\Basketball_players.json");
            return JsonConvert.DeserializeObject<List<BasketballPlayer>>(json, new JsonSerializerSettings
            {
                DateParseHandling = DateParseHandling.None,
                NullValueHandling = NullValueHandling.Ignore
            });
        }

       

        private void ShowRandomPlayer()
        {
            Random random = new Random();
            currentPlayer = players[random.Next(players.Count)];

            try
            {
                Image playerImage = Image.FromFile(currentPlayer.Фото);
                photo_pictureBox.Image = playerImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка в завантаженні фотографії грацвя: " + ex.Message);
            }
        }

        private void ResetProgressBarsAndImages()
        {
            age_pb.Value = 0;
            conf_pb.Value = 0;
            height_pb.Value = 0;
            number_pb.Value = 0;
            position_pb.Value = 0;
            team_pb.Value = 0;
            con_pict.Image = null;
            tm_pict.Image = null;
            age_lbl.Text = null;
            height_lbl.Text = null;
            numb_lbl.Text = null;
            pos_lbl.Text = null;
            pers_age.Text = null;
            pers_conf.Image = null;
            pers_height.Text = null;
            pers_numb.Text = null;
            pers_pos.Text = null;
            pers_tm.Image = null;
        }

        private void check_btn_Click(object sender, EventArgs e)
        {
            
            string name = currentPlayer.Імя + " " + currentPlayer.Прізвище;
            string guessedName = search_txtbox.Text.Trim().ToLower();
            string fullName = name.Trim().ToLower();

           

            if (guessedName == fullName)
            {

                MessageBox.Show($"Вірно, ви вгадали гравця!\nЦе дійсно був: {name}");
                attempts = 0;
                atempts_lbl.Text = $" {attempts}/8";
                ResetProgressBarsAndImages();
                ShowRandomPlayer();
            }
            else
            {
                attempts++;
                atempts_lbl.Text = $" {attempts}/8";
                
                MessageBox.Show("Не вірно. Спробуйте ще!");
                if (attempts >= maxAttempts)
                {
                    MessageBox.Show("Ви досягли максимальної кільксоті спроб. правильна відповідь це: " + currentPlayer.Імя + " " + currentPlayer.Прізвище);
                    
                    attempts = 0;
                    atempts_lbl.Text = $" {attempts}/8";
                    ShowRandomPlayer();
                }
                else
                {
                    string teamname = currentPlayer.Команда;
                    string position = currentPlayer.Позиція;
                    string conf = currentPlayer.Конференція;
                    int age = currentPlayer.Вік;
                    string number = currentPlayer.Номер;
                    int height = currentPlayer.Зріст;

                    foreach (BasketballPlayer player in players)
                    {
                        Image teamImage = Image.FromFile(currentPlayer.ФотоКоманди);
                        if (player.Імя.ToLower() + " " + player.Прізвище.ToLower() == guessedName)
                        {
                            if (player.Команда == teamname)
                            {
                                TT.SetToolTip(pers_tm, player.Команда);
                                TT.SetToolTip(tm_pict, player.Команда);
                                team_pb.Value = 100;
                                switch (teamname)
                                {
                                    case "Атланта Гокс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Hawks.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Бостон Селтікс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Celtics.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Бруклін Нетс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Nets.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Шарлот Горнетс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Hornets.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Чикаго Буллс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Bulls.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Клівленд Кавальєрс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Cavaliers.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Даллас Маверікс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Mavericks.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Денвер Наггетс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Nuggets.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Детройт Пістонс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Pistons.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Голден-Стейт Ворріорс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Warriors.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Х'юстон Рокетс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Rockets.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Індіана Пейсерс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Pacers.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Лос-Анджелес Кліпперс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Clippers.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Лос-Анджелес Лейкерс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Lakers.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Мемфіс Гріззліс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Grizzlies.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Маямі Гіт":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Heat.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Мілвокі Бакс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Bucks.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Міннесота Тімбревулвз":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Timberwolves.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Нью-Орлінс Пеліканс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Pelicans.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Нью-Йорк Нікс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Knicks.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Оклахома-Сіті Тандер":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Thunder.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Орландо Меджик":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Magic.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Філадельфія Севенті-Сіксерс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\76ers.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Фінікс Санз":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Suns.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Портленд Трейл-Блейзерс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Blazers.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Сакраменто Кінгз":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Kings.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Сан-Антоніо Сперс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Spurs.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Торонто Репторз":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Raptors.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Юта Джаз":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Jazz.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Вашингтон Візардс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Wizards.png");
                                        pers_tm.Image = teamImage;
                                        break;
                                }
                            }
                            else
                            {
                                team_pb.Value = 0;
                                
                                TT.SetToolTip(tm_pict, player.Команда);
                                switch (player.Команда)
                                {
                                    case "Атланта Гокс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Hawks.png");
                                        
                                        
                                        break;
                                    case "Бостон Селтікс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Celtics.png");

                                        break;
                                    case "Бруклін Нетс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Nets.png");

                                        break;
                                    case "Шарлот Горнетс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Hornets.png");

                                        break;
                                    case "Чикаго Буллс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Bulls.png");

                                        break;
                                    case "Клівленд Кавальєрс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Cavaliers.png");

                                        break;
                                    case "Даллас Маверікс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Mavericks.png");

                                        break;
                                    case "Денвер Наггетс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Nuggets.png");

                                        break;
                                    case "Детройт Пістонс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Pistons.png");

                                        break;
                                    case "Голден-Стейт Ворріорс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Warriors.png");

                                        break;
                                    case "Х'юстон Рокетс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Rockets.png");

                                        break;
                                    case "Індіана Пейсерс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Pacers.png");

                                        break;
                                    case "Лос-Анджелес Кліпперс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Clippers.png");

                                        break;
                                    case "Лос-Анджелес Лейкерс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Lakers.png");

                                        break;
                                    case "Мемфіс Гріззліс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Grizzlies.png");

                                        break;
                                    case "Маямі Гіт":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Heat.png");

                                        break;
                                    case "Мілвокі Бакс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Bucks.png");

                                        break;
                                    case "Міннесота Тімбервулвз":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Timberwolves.png");

                                        break;
                                    case "Нью-Орлінс Пеліканс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Pelicans.png");

                                        break;
                                    case "Нью-Йорк Нікс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Knicks.png");

                                        break;
                                    case "Оклахома-Сіті Тандер":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Thunder.png");

                                        break;
                                    case "Орландо Меджик":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Magic.png");

                                        break;
                                    case "Філадельфія Севенті-Сіксерс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\76ers.png");

                                        break;
                                    case "Фінікс Санз":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Suns.png");

                                        break;
                                    case "Портленд Трейл-Блейзерс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Blazers.png");

                                        break;
                                    case "Сакраменто Кінгз":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Kings.png");

                                        break;
                                    case "Сан-Антоніо Сперс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Spurs.png");

                                        break;
                                    case "Торонто Репторз":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Raptors.png");

                                        break;
                                    case "Юта Джаз":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Jazz.png");

                                        break;
                                    case "Вашингтон Візардс":
                                        tm_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\Wizards.png");

                                        break;
                                }
                            }

                            if (player.Позиція == "Захисник" || player.Позиція == "Захисник-Форвард") { player.Позиція = "Захисник"; }
                            if (player.Позиція == "Форвард" || player.Позиція == "Форвард-Захисник" || player.Позиція == "Форвард-Центровий") { player.Позиція = "Форвард"; }
                            if (player.Позиція == "Центровий" || player.Позиція == "Центровий-Форвард") { player.Позиція = "Центровий"; }

                            if (currentPlayer.Позиція == "Захисник" || currentPlayer.Позиція == "Захисник-Форвард") { currentPlayer.Позиція = "Захисник"; }
                            if (currentPlayer.Позиція == "Форвард" || currentPlayer.Позиція == "Форвард-Захисник" || currentPlayer.Позиція == "Форвард-Центровий") { player.Позиція = "Форвард"; }
                            if (currentPlayer.Позиція == "Центровий" || currentPlayer.Позиція == "Центровий-Форвард") { currentPlayer.Позиція = "Центровий"; }

                            if (player.Позиція == position)
                            {
                                position_pb.Value = 100;
                                switch (currentPlayer.Позиція)
                                {
                                    case "Захисник":
                                        pos_lbl.Text = "З";
                                        pers_pos.Text = "З";
                                        TT.SetToolTip(pers_pos, "Позиція: Захисник");
                                        TT.SetToolTip(pos_lbl, "Позиція: Захисник");
                                        TT.SetToolTip(position_pb, "Позиція: Захисник");
                                        break;
                                    case "Форвард":
                                        pos_lbl.Text = "Ф";
                                        pers_pos.Text = "Ф";
                                        TT.SetToolTip(pers_pos, "Позиція: Форвард");
                                        TT.SetToolTip(pos_lbl, "Позиція: Форвард");
                                        TT.SetToolTip(position_pb, "Позиція: Форвард");
                                        break;
                                    case "Центровий":
                                        pos_lbl.Text = "Ц";
                                        pers_pos.Text = "Ц";
                                        TT.SetToolTip(pers_pos, "Позиція: Центровий");
                                        TT.SetToolTip(pos_lbl, "Позиція: Центровий");
                                        TT.SetToolTip(position_pb, "Позиція: Центровий");
                                        break;
                                }
                            }
                            else
                            {
                                position_pb.Value = 0;
                                switch (player.Позиція)
                                {

                                    case "Захисник":
                                        pos_lbl.Text = "З";
                                        TT.SetToolTip(pers_pos, "Позиція: Захисник");
                                        TT.SetToolTip(pos_lbl, "Позиція: Захисник");
                                        TT.SetToolTip(position_pb, "Позиція: Захисник");
                                        break;
                                    case "Форвард":
                                        pos_lbl.Text = "Ф";
                                        TT.SetToolTip(pers_pos, "Позиція: Форвард");
                                        TT.SetToolTip(pos_lbl, "Позиція: Форвард");
                                        TT.SetToolTip(position_pb, "Позиція: Форвард");
                                        break;
                                    case "Центровий":
                                        pos_lbl.Text = "Ц";
                                        TT.SetToolTip(pers_pos, "Позиція: Центровий");
                                        TT.SetToolTip(pos_lbl, "Позиція: Центровий");
                                        TT.SetToolTip(position_pb, "Позиція: Центровий");
                                        break;

                                }
                            }

                            if (player.Вік == age)
                            {
                                age_lbl.Text = player.Вік.ToString();
                                age_pb.Value = 100;
                                pers_age.Text = age.ToString();
                                TT.SetToolTip(pers_age, "Вік");
                                TT.SetToolTip(age_lbl, "Вік");
                                TT.SetToolTip(age_pb, "Вік");
                            }
                            else
                            {
                                age_lbl.Text = player.Вік.ToString();
                                age_pb.Value = 0;
                                TT.SetToolTip(pers_age, "Вік");
                                TT.SetToolTip(age_lbl, "Вік");
                                TT.SetToolTip(age_pb, "Вік");
                            }

                            if (player.Зріст == height)
                            {
                                height_lbl.Text = player.Зріст.ToString();
                                height_pb.Value = 100;
                                pers_height.Text = height.ToString();
                                TT.SetToolTip(pers_height, "Зріст");
                                TT.SetToolTip(height_lbl, "Зріст");
                                TT.SetToolTip(height_pb, "Зріст");
                            }
                            else
                            {
                                height_lbl.Text = player.Зріст.ToString();
                                height_pb.Value = 0;
                                
                                TT.SetToolTip(height_lbl, "Зріст");
                                TT.SetToolTip(height_pb, "Зріст");
                            }

                            if (player.Номер == number)
                            {
                                numb_lbl.Text = "#" + player.Номер;
                                number_pb.Value = 100;
                                pers_numb.Text = "#" + number;
                                TT.SetToolTip(pers_numb, "Номер");
                                TT.SetToolTip(numb_lbl, "Номер");
                                TT.SetToolTip(number_pb, "Номер");
                            }
                            else
                            {
                                numb_lbl.Text = player.Номер;
                                number_pb.Value = 0;
                                
                                TT.SetToolTip(numb_lbl, "Номер");
                                TT.SetToolTip(number_pb, "Номер");
                            }

                            if (player.Конференція == conf)
                            {
                                conf_pb.Value = 100;
                                switch (conf)
                                {
                                    case "Східна Конференція":
                                        con_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\EAST.png");
                                        pers_conf.Image = Image.FromFile("mini_clubs_pics\\BB\\EAST.png");
                                        TT.SetToolTip(con_pict, "Східна Конференція");
                                        TT.SetToolTip(pers_conf, "Cхідна Конференція");
                                        break;
                                    case "Західна Конференція":
                                        con_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\WEST.png");
                                        pers_conf.Image = Image.FromFile("mini_clubs_pics\\BB\\WEST.png");
                                        TT.SetToolTip(con_pict, "Західна Конференція");
                                        TT.SetToolTip(pers_conf, "Західна Конференція");
                                        break;
                                }
                            }
                            else 
                            {
                                conf_pb.Value = 0;
                                switch (player.Конференція)
                                {
                                    case "Східна Конференція":
                                        con_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\EAST.png");
                                        TT.SetToolTip(con_pict,"Східна Конференція");
                                        break;
                                    case "Західна Конференція":
                                        con_pict.Image = Image.FromFile("mini_clubs_pics\\BB\\WEST.png");
                                        TT.SetToolTip(con_pict, "Західна Конференція");
                                        break;
                                }
                            }
                        }
                    }
                }
            }

            search_txtbox.Text = ""; // Clear the search box
        }

        private void hint_btn_Click(object sender, EventArgs e)
        {

            if (currentPlayer.Прізвище.Length > attempts)
            {
                MessageBox.Show("Підказка: " + currentPlayer.Імя + " " + currentPlayer.Прізвище);
                
            }
            else
            {
                MessageBox.Show("Нажаль у вас закінчилися підказки");
            }
        }



        private void hide_btn_Click(object sender, EventArgs e)
        {
            hide_btn.Visible = false;
            show_btn.Visible = false;
            search_txtbox.Visible = true;

        }

        private void show_btn_Click(object sender, EventArgs e)
        {
            photo2.Visible = false;
            hide_btn.Visible = false;
            show_btn.Visible = false;
            search_txtbox.Visible = true;
        }

        private void Basketball_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Check.PerformClick();
            }
            if (e.KeyCode == Keys.F1)
            {
                help.PerformClick();
            }
        }

        private void help_Click(object sender, EventArgs e)
        {
            Help_Window help = new Help_Window();
            help.Show();
        }
    }
}
