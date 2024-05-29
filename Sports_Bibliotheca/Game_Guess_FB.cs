using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sports_Bibliotheca
{
    public partial class Game_Guess_FB : Form
    {
        private List<FootballPlayer> players;
        private FootballPlayer currentPlayer;
        private int attempts = 0;
        private int maxAttempts = 8;
        public Game_Guess_FB()
        {
            InitializeComponent();
            // Load players and display a random player on startup
            players = LoadPlayers();
            ShowRandomPlayer();

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Football_KeyDown);
        }

        public class FootballPlayer
        {
            public string Номер { get; set; }
            public string Імя { get; set; }
            public string Прізвище { get; set; }
            public string Позиція { get; set; }
            public string Національність { get; set; }
            public int Вік { get; set; }
            public string Клуб { get; set; }
            public string Фото { get; set; }
            public string ФотоКлуба { get; set; }
            public string Ліга { get; set; }
        }

        private List<FootballPlayer> LoadPlayers()
        {
            string json = File.ReadAllText("data\\Football_players.json");
            return JsonConvert.DeserializeObject<List<FootballPlayer>>(json, new JsonSerializerSettings
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
            league_pb.Value = 0;
            nation_pb.Value = 0;
            number_pb.Value = 0;
            position_pb.Value = 0;
            team_pb.Value = 0;
            leg_pict.Image = null;
            tm_pict.Image = null;
            age_lbl.Text = null;
            nat_pict.Image = null;
            numb_lbl.Text = null;
            pos_lbl.Text = null;
            pers_age.Text = null;
            pers_leag.Image = null;
            pers_nat.Text = null;
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

                MessageBox.Show($"Вірно, ви вгадали гравця \nЦе дійсно був: {name}");
                attempts = 0; // оновити спроби
                atempts_lbl.Text = $" {attempts}/8";
                ResetProgressBarsAndImages();
                ShowRandomPlayer(); // показати гравця
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
                    string clubname = currentPlayer.Клуб;
                    string league = currentPlayer.Ліга;
                    int age = currentPlayer.Вік;
                    string number = currentPlayer.Номер;
                    string nation = currentPlayer.Національність;

                    foreach (FootballPlayer player in players)
                    {
                        Image teamImage = Image.FromFile(currentPlayer.ФотоКлуба);
                        Image clubsImage = Image.FromFile(player.ФотоКлуба);

                        if (player.Імя.ToLower() + " " + player.Прізвище.ToLower() == guessedName)
                        {
                            if (player.Національність == nation)
                            {
                                TT.SetToolTip(pers_nat, player.Національність);
                                TT.SetToolTip(nat_pict, player.Національність);
                                nation_pb.Value = 100;
                                switch (nation)
                                {
                                    case "Бразилія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\brazil.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\brazil.png");
                                        break;
                                    case "Франція":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\france.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\france.png");
                                        break;
                                    case "Нідерланди":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\netherlands.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\netherlands.png");
                                        break;
                                    case "Англія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\england.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\england.png");
                                        break;
                                    case "Камерун":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\cameroon.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\cameroon.png");
                                        break;
                                    case "Шотландія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\scotland.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\scotland.png");
                                        break;
                                    case "Угорщина":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\hungary.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\hungary.png");
                                        break;
                                    case "Аргентина":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\argentina.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\argentina.png");
                                        break;
                                    case "Іспанія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\spain.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\spain.png");
                                        break;
                                    case "Колумбія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\colombia.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\colombia.png");
                                        break;
                                    case "Уругвай":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\uruguay.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\uruguay.png");
                                        break;
                                    case "Хорватія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\croatia.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\croatia.png");
                                        break;
                                    case "Швейцарія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\switzerland.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\switzerland.png");
                                        break;
                                    case "Бельгія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\belgium.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\belgium.png");
                                        break;
                                    case "Норвегія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\norway.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\norway.png");
                                        break;
                                    case "Україна":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\ukraine.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\ukraine.png");
                                        break;
                                    case "Японія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\japan.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\japan.png");
                                        break;
                                    case "Гана":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\ghana.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\ghana.png");
                                        break;
                                    case "Італія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\italy.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\italy.png");
                                        break;
                                    case "Німеччина":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\germany.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\germany.png");
                                        break;
                                    case "Сенегал":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\senegal.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\senegal.png");
                                        break;
                                    case "Кот-д'Івуар":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\ivory coast.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\ivory coast.png");
                                        break;
                                    case "Португалія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\portugal.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\portugal.png");
                                        break;
                                    case "Єгипет":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\egypt.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\egypt.png");
                                        break;
                                    case "Ірландія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\ireland.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\ireland.png");
                                        break;
                                    case "Швеція":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\sweden.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\sweden.png");
                                        break;
                                    case "США":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\usa.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\usa.png");
                                        break;
                                    case "Польща":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\poland.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\poland.png");
                                        break;
                                    case "Ямайка":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\jamaica.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\jamaica.png");
                                        break;
                                    case "Вельс":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\wales.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\wales.png");
                                        break;
                                    case "Данія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\denmark.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\denmark.png");
                                        break;
                                    case "Малі":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\mali.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\mali.png");
                                        break;
                                    case "Південна Корея":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\south korea.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\south korea.png");
                                        break;
                                    case "Ізраїль":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\israel.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\israel.png");
                                        break;
                                    case "Марокко":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\marocco.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\marocco.png");
                                        break;
                                    case "Греція":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\greece.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\greece.png");
                                        break;

                                    case "Чехія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\czech republic.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\czech republic.png");
                                        break;
                                    case "Мексика":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\mexico.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\mexico.png");
                                        break;
                                    case "Парагвай":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\paraguay.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\paraguay.png");
                                        break;
                                    case "Сербія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\serbia.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\serbia.png");
                                        break;
                                    case "Еквадор":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\ecuador.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\ecuador.png");
                                        break;
                                    case "Туреччина":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\turkey.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\turkey.png");
                                        break;
                                    case "Австрія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\austria.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\austria.png");
                                        break;
                                    case "Венесуела":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\venezuela.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\venezuela.png");
                                        break;
                                    case "Словенія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\slovenia.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\slovenia.png");
                                        break;
                                    case "Чорногорія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\montenegro.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\montenegro.png");
                                        break;
                                    case "Мозамбік":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\mozambique.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\mozambique.png");
                                        break;
                                    case "Туніс":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\tunisia.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\tunisia.png");
                                        break;
                                    case "Грузія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\georgia.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\georgia.png");
                                        break;
                                    case "Гвінея":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\guinea.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\guinea.png");
                                        break;
                                    case "Гваделупа":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\guadeloupe.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\guadeloupe.png");
                                        break;
                                    case "Чилі":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\chile.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\chile.png");
                                        break;
                                    case "Суринам":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\suriname.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\suriname.png");
                                        break;
                                    case "Нігерія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\nigeria.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\nigeria.png");
                                        break;
                                    case "Буркіна-Фасо":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\burkina faso.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\burkina faso.png");
                                        break;
                                    case "Вірменія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\armenia.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\armenia.png");
                                        break;
                                    case "Косово":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\kosovo.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\kosovo.png");
                                        break;
                                    case "Албанія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\albania.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\albania.png");
                                        break;
                                    case "Боснія і Герцеговина":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\bosnia.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\bosnia.png");
                                        break;
                                    case "Словакія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\slovakia.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\slovakia.png");
                                        break;
                                    case "Ангола":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\angola.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\angola.png");
                                        break;
                                    case "Ісландія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\iceland.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\iceland.png");
                                        break;
                                    case "Коста-Рика":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\costa rica.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\costa rica.png");
                                        break;
                                    case "Алжир":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\algeria.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\algeria.png");
                                        break;
                                    case "Канада":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\canada.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\canada.png");
                                        break;
                                    case "Бурунді":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\burundi.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\burundi.png");
                                        break;
                                    case "ДР Конго":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\dr congo.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\dr congo.png");
                                        break;
                                    case "ЦАР":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\car.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\car.png");
                                        break;
                                    case "Гвінея-Бісау":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\guinea-bissau.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\guinea-bissau.png");
                                        break;
                                    case "Габон":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\gabon.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\gabon.png");
                                        break;
                                    case "Фінляндія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\finland.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\finland.png");
                                        break;
                                    case "Сирія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\syria.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\syria.png");
                                        break;
                                    case "Північна Македонія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\macedonia.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\macedonia.png");
                                        break;
                                    case "Іран":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\iran.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\iran.png");
                                        break;
                                    case "Саудівська Аравія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\saudi arabia.png");
                                        pers_nat.Image = Image.FromFile("mini_nations_pics\\saudi arabia.png");
                                        break;
                                }
                            }
                            else 
                            {
                                TT.SetToolTip(nat_pict, player.Національність);
                                nation_pb.Value = 0;
                                switch (player.Національність)
                                {
                                    case "Бразилія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\brazil.png");
                                       
                                        break;
                                    case "Франція":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\france.png");
                                        
                                        break;
                                    case "Нідерланди":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\netherlands.png");
                                        
                                        break;
                                    case "Англія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\england.png");
                                        
                                        break;
                                    case "Камерун":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\cameroon.png");
                                        
                                        break;
                                    case "Шотландія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\scotland.png");
                                        
                                        break;
                                    case "Угорщина":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\hungary.png");
                                        
                                        break;
                                    case "Аргентина":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\argentina.png");
                                        
                                        break;
                                    case "Іспанія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\spain.png");
                                        
                                        break;
                                    case "Колумбія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\colombia.png");
                                        
                                        break;
                                    case "Уругвай":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\uruguay.png");
                                        
                                        break;
                                    case "Хорватія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\croatia.png");
                                        
                                        break;
                                    case "Швейцарія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\switzerland.png");
                                        
                                        break;
                                    case "Бельгія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\belgium.png");
                                        
                                        break;
                                    case "Норвегія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\norway.png");
                                       
                                        break;
                                    case "Україна":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\ukraine.png");
                                        
                                        break;
                                    case "Японія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\japan.png");
                                        
                                        break;
                                    case "Гана":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\ghana.png");
                                        
                                        break;
                                    case "Італія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\italy.png");
                                        
                                        break;
                                    case "Німеччина":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\germany.png");
                                        
                                        break;
                                    case "Сенегал":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\senegal.png");
                                        
                                        break;
                                    case "Кот-д'Івуар":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\ivory coast.png");
                                        
                                        break;
                                    case "Португалія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\portugal.png");
                                        
                                        break;
                                    case "Єгипет":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\egypt.png");
                                        
                                        break;
                                    case "Ірландія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\ireland.png");
                                        
                                        break;
                                    case "Швеція":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\sweden.png");
                                        
                                        break;
                                    case "США":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\usa.png");
                                        
                                        break;
                                    case "Польща":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\poland.png");
                                        
                                        break;
                                    case "Ямайка":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\jamaica.png");
                                        
                                        break;
                                    case "Вельс":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\wales.png");
                                        
                                        break;
                                    case "Данія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\denmark.png");
                                        
                                        break;
                                    case "Малі":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\mali.png");
                                        
                                        break;
                                    case "Південна Корея":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\south korea.png");
                                        
                                        break;
                                    case "Ізраїль":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\israel.png");
                                        
                                        break;
                                    case "Марокко":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\marocco.png");
                                        
                                        break;
                                    case "Греція":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\greece.png");
                                        
                                        break;

                                    case "Чехія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\czech republic.png");
                                        
                                        break;
                                    case "Мексика":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\mexico.png");
                                        
                                        break;
                                    case "Парагвай":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\paraguay.png");
                                        
                                        break;
                                    case "Сербія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\serbia.png");
                                        
                                        break;
                                    case "Еквадор":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\ecuador.png");
                                        
                                        break;
                                    case "Туреччина":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\turkey.png");
                                        
                                        break;
                                    case "Австрія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\austria.png");
                                        
                                        break;
                                    case "Венесуела":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\venezuela.png");
                                        
                                        break;
                                    case "Словенія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\slovenia.png");
                                        
                                        break;
                                    case "Чорногорія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\montenegro.png");
                                        
                                        break;
                                    case "Мозамбік":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\mozambique.png");
                                        
                                        break;
                                    case "Туніс":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\tunisia.png");
                                        
                                        break;
                                    case "Грузія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\georgia.png");
                                        
                                        break;
                                    case "Гвінея":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\guinea.png");
                                        
                                        break;
                                    case "Гваделупа":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\guadeloupe.png");
                                        
                                        break;
                                    case "Чилі":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\chile.png");
                                        
                                        break;
                                    case "Суринам":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\suriname.png");
                                        
                                        break;
                                    case "Нігерія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\nigeria.png");
                                       
                                        break;
                                    case "Буркіна-Фасо":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\burkina faso.png");
                                        
                                        break;
                                    case "Вірменія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\armenia.png");
                                        
                                        break;
                                    case "Косово":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\kosovo.png");
                                        
                                        break;
                                    case "Албанія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\albania.png");
                                        
                                        break;
                                    case "Боснія і Герцеговина":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\bosnia.png");
                                        
                                        break;
                                    case "Словакія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\slovakia.png");
                                        
                                        break;
                                    case "Ангола":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\angola.png");
                                        
                                        break;
                                    case "Ісландія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\iceland.png");
                                        
                                        break;
                                    case "Коста-Рика":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\costa rica.png");
                                        
                                        break;
                                    case "Алжир":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\algeria.png");
                                        
                                        break;
                                    case "Канада":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\canada.png");
                                        
                                        break;
                                    case "Бурунді":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\burundi.png");
                                        
                                        break;
                                    case "ДР Конго":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\dr congo.png");
                                        
                                        break;
                                    case "ЦАР":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\car.png");
                                        
                                        break;
                                    case "Гвінея-Бісау":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\guinea-bissau.png");
                                        
                                        break;
                                    case "Габон":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\gabon.png");
                                        
                                        break;
                                    case "Фінляндія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\finland.png");
                                        
                                        break;
                                    case "Сирія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\syria.png");
                                        
                                        break;
                                    case "Північна Македонія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\macedonia.png");
                                        
                                        break;
                                    case "Іран":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\iran.png");
                                        
                                        break;
                                    case "Саудівська Аравія":
                                        nat_pict.Image = Image.FromFile("mini_nations_pics\\saudi arabia.png");
                                        
                                        break;
                                }
                            }

                            if (player.Клуб == clubname)
                            {
                                TT.SetToolTip(pers_tm, player.Клуб);
                                TT.SetToolTip(tm_pict, player.Клуб);
                                team_pb.Value = 100;
                                switch (clubname)
                                {
                                    case "Ліверпуль":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Манчестер Юнайтед":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Борнмут":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Атлетік Більбао":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Мілан":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Монако":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Баварія Мюнхен":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Айнтрахт Франкфурт":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Феєноорд":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                        //
                                    case "Манчестер Сіті":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Олімпік Марсель":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Арсенал":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Жирона":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Севілья":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Ніцца":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Байер Леверкузен":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Штутгарт":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "РБ Лейпциг":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "ПСВ":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Астон Вілла":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Тотенхем Хотспур":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Атлетіко Мадрид":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Дженоа":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "ЛОСК Лілль":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Вест Хем Юнайтед":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Рома":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                        //
                                    case "Ньюкасл Юнайтед":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Олімпік Ліон":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Челсі":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Брайтон енд Гоув Альбіон":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Евертон":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Барселона":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Реал Сосьєдад":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Аталанта":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Порту":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Динамо Київ":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Реал Мадрид":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Аякс":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Валенсія":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    //
                                    case "Ювентус":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Боруссія Менхенгладбах":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Аль Іттіхад":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Реал Бетіс":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Спортінг Лісабон":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Аль Аглі":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Вілереал":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Парі Сен-Жермен (ПСЖ)":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    //
                                    case "Інтернаціонале":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Аль Хіляль":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Наполі":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Болонья":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Фіорентіна":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Лаціо":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Боруссія Дортмунд":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Вольфсбург":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Бенфіка":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Аль Наср":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    //
                                    case "Інтер Маямі":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    case "Шахтар":
                                        tm_pict.Image = clubsImage;
                                        pers_tm.Image = teamImage;
                                        break;
                                    
                                }
                            }
                            else
                            {
                                TT.SetToolTip(tm_pict, player.Клуб);
                                team_pb.Value = 0;
                                switch (player.Клуб)
                                {
                                    case "Ліверпуль":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Манчестер Юнайтед":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Борнмут":
                                        tm_pict.Image = clubsImage;
                                       
                                        break;
                                    case "Атлетік Більбао":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Мілан":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Монако":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Баварія Мюнхен":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Айнтрахт Франкфурт":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Феєноорд":
                                        tm_pict.Image = clubsImage;
                                       
                                        break;
                                    //
                                    case "Манчестер Сіті":
                                        tm_pict.Image = clubsImage;
                                       
                                        break;
                                    case "Олімпік Марсель":
                                        tm_pict.Image = clubsImage;
                                       
                                        break;
                                    case "Арсенал":
                                        tm_pict.Image = clubsImage;
                                       
                                        break;
                                    case "Жирона":
                                        tm_pict.Image = clubsImage;
                                       
                                        break;
                                    case "Севілья":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Ніцца":
                                        tm_pict.Image = clubsImage;
                                       
                                        break;
                                    case "Байер Леверкузен":
                                        tm_pict.Image = clubsImage;
                                       
                                        break;
                                    case "Штутгарт":
                                        tm_pict.Image = clubsImage;
                                       
                                        break;
                                    case "РБ Лейпциг":
                                        tm_pict.Image = clubsImage;
                                       
                                        break;
                                    case "ПСВ":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Астон Вілла":
                                        tm_pict.Image = clubsImage;
                                      
                                        break;
                                    case "Тотенхем Хотспур":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Атлетіко Мадрид":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Дженоа":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "ЛОСК Лілль":
                                        tm_pict.Image = clubsImage;
                                       
                                        break;
                                    case "Вест Хем Юнайтед":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Рома":
                                        tm_pict.Image = clubsImage;
                                       
                                        break;
                                    //
                                    case "Ньюкасл Юнайтед":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Олімпік Ліон":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Челсі":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Брайтон енд Гоув Альбіон":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Евертон":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Барселона":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Реал Сосьєдад":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Аталанта":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Порту":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Динамо Київ":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Реал Мадрид":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Аякс":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Валенсія":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    //
                                    case "Ювентус":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Боруссія Менхенгладбах":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Аль Іттіхад":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Реал Бетіс":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Спортінг Лісабон":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Аль Аглі":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Вілереал":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Парі Сен-Жермен (ПСЖ)":
                                        tm_pict.Image = clubsImage;
                                       
                                        break;
                                    //
                                    case "Інтернаціонале":
                                        tm_pict.Image = clubsImage;
                                       
                                        break;
                                    case "Аль Хіляль":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Наполі":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Болонья":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Фіорентіна":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Лаціо":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Боруссія Дортмунд":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Вольфсбург":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Бенфіка":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    case "Аль Наср":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                    //
                                    case "Інтер Маямі":
                                        tm_pict.Image = clubsImage;
                                       
                                        break;
                                    case "Шахтар":
                                        tm_pict.Image = clubsImage;
                                        
                                        break;
                                }
                            }

                            string guess_player = ""; string guessed_player = "";

                            if (player.Позиція == "Центральний Захисник" || player.Позиція == "Правий Захисник" || player.Позиція == "Лівийй Захисник") { guess_player = "Захисник"; }
                            if (player.Позиція == "Центральний Півзахисник" || player.Позиція == "Опорний Півзахисник" || player.Позиція == "Атакувальний Півзахисник" || player.Позиція == "Правий Півзахисник" || player.Позиція == "Лівий Півзахисник") { guess_player = "Півзахисник"; }
                            if (player.Позиція == "Центральний Нападник" || player.Позиція == "Відтянутий Нападник" || player.Позиція == "Правий Вінгер" || player.Позиція == "Лівий Вінгер") { guess_player = "Нападник"; }

                            if (currentPlayer.Позиція == "Центральний Захисник" || currentPlayer.Позиція == "Правий Захисник" || currentPlayer.Позиція == "Лівийй Захисник") { guessed_player = "Захисник"; }
                            if (currentPlayer.Позиція == "Центральний Півзахисник" || currentPlayer.Позиція == "Опорний Півзахисник" || currentPlayer.Позиція == "Атакувальний Півзахисник" || currentPlayer.Позиція == "Правий Півзахисник" || currentPlayer.Позиція == "Лівий Півзахисник") { guessed_player = "Півзахисник"; }
                            if (currentPlayer.Позиція == "Центральний Нападник" || currentPlayer.Позиція == "Відтянутий Нападник" || currentPlayer.Позиція == "Правий Вінгер" || currentPlayer.Позиція == "Лівий Вінгер") { guessed_player = "Нападник"; }

                            if (guess_player == guessed_player)
                            {
                                position_pb.Value = 100;
                                switch (guessed_player)
                                {
                                    case "Воротар":
                                        pos_lbl.Text = "ВРТ";
                                        pers_pos.Text = "ВРТ";
                                        TT.SetToolTip(pers_pos, "Позиція: Воротар");
                                        TT.SetToolTip(pos_lbl, "Позиція: Воротар");
                                        TT.SetToolTip(position_pb, "Позиція: Воротар");
                                        break;
                                    case "Захисник":
                                        pos_lbl.Text = "З";
                                        pers_pos.Text = "З";
                                        TT.SetToolTip(pers_pos, "Позиція: Захисник");
                                        TT.SetToolTip(pos_lbl, "Позиція: Захисник");
                                        TT.SetToolTip(position_pb, "Позиція: Захисник");
                                        break;
                                    case "Півзахисник":
                                        pos_lbl.Text = "ПЗ";
                                        pers_pos.Text = "ПЗ";
                                        TT.SetToolTip(pers_pos, "Позиція: Півзахисник");
                                        TT.SetToolTip(pos_lbl, "Позиція: Півзахисник");
                                        TT.SetToolTip(position_pb, "Позиція: Півзахисник");
                                        break;
                                    case "Нападник":
                                        pos_lbl.Text = "НАП";
                                        pers_pos.Text = "НАП";
                                        TT.SetToolTip(pers_pos, "Позиція: Нападник");
                                        TT.SetToolTip(pos_lbl, "Позиція: Нападник");
                                        TT.SetToolTip(position_pb, "Позиція: Нападник");
                                        break;
                                }
                            }
                            else
                            {
                                position_pb.Value = 0;
                                switch (guess_player)
                                {
                                    case "Воротар":
                                        pos_lbl.Text = "ВРТ";
                                        TT.SetToolTip(pos_lbl, "Позиція: Воротар");
                                        TT.SetToolTip(position_pb, "Позиція: Воротар");
                                        break;
                                    case "Захисник":
                                        pos_lbl.Text = "З";
                                        TT.SetToolTip(pos_lbl, "Позиція: Захисник");
                                        TT.SetToolTip(position_pb, "Позиція: Захисник");
                                        break;
                                    case "Півзахисник":
                                        pos_lbl.Text = "ПЗ";
                                        TT.SetToolTip(pos_lbl, "Позиція: Півзахисник");
                                        TT.SetToolTip(position_pb, "Позиція: Півзахисник");
                                        break;
                                    case "Нападник":
                                        pos_lbl.Text = "НАП";
                                        TT.SetToolTip(pos_lbl, "Позиція: Нападник");
                                        TT.SetToolTip(position_pb, "Позиція: Нападник");
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
                                numb_lbl.Text = "#" + player.Номер;
                                number_pb.Value = 0;
                                TT.SetToolTip(pers_numb, "Номер");
                                TT.SetToolTip(numb_lbl, "Номер");
                                TT.SetToolTip(number_pb, "Номер");
                            }

                            

                            if (player.Ліга == league)
                            {
                                TT.SetToolTip(pers_leag, player.Ліга);
                                TT.SetToolTip(leg_pict, player.Ліга);
                                leg_pict.BackColor = Color.White;
                                league_pb.Value = 100;
                                switch (league)
                                {

                                    case "Бундесліга (Німеччина)":
                                        leg_pict.Image = Image.FromFile("mini_clubs_pics\\FB\\de1.png");
                                        pers_leag.Image = Image.FromFile("mini_clubs_pics\\FB\\de1.png");
                                        break;
                                    case "Вища Ліга Футболу (США)":
                                        leg_pict.Image = Image.FromFile("mini_clubs_pics\\FB\\us1.png");
                                        pers_leag.Image = Image.FromFile("mini_clubs_pics\\FB\\us1.png");
                                        break;
                                    case "Ередивізі (Нідерланди)":
                                        leg_pict.Image = Image.FromFile("mini_clubs_pics\\FB\\nl1.png");
                                        pers_leag.Image = Image.FromFile("mini_clubs_pics\\FB\\nl1.png");
                                        break;
                                    case "Ла Ліга (Іспанія)":
                                        leg_pict.Image = Image.FromFile("mini_clubs_pics\\FB\\es1.png");
                                        pers_leag.Image = Image.FromFile("mini_clubs_pics\\FB\\es1.png");
                                        break;
                                    case "Ліга Бетклік (Португалія)":
                                        leg_pict.Image = Image.FromFile("mini_clubs_pics\\FB\\pt1.png");
                                        pers_leag.Image = Image.FromFile("mini_clubs_pics\\FB\\pt1.png");
                                        leg_pict.BackColor = Color.Gray;
                                        break;
                                    case "Ліга 1 (Франція)":
                                        leg_pict.Image = Image.FromFile("mini_clubs_pics\\FB\\fr1.png");
                                        pers_leag.Image = Image.FromFile("mini_clubs_pics\\FB\\fr1.png");
                                        break;
                                    case "Прем'єр Ліга (Англія)":
                                        leg_pict.Image = Image.FromFile("mini_clubs_pics\\FB\\en1.png");
                                        pers_leag.Image = Image.FromFile("mini_clubs_pics\\FB\\en1.png");
                                        break;
                                    case "Прем'єр Ліга (Україна)":
                                        leg_pict.Image = Image.FromFile("mini_clubs_pics\\FB\\ua1.png");
                                        pers_leag.Image = Image.FromFile("mini_clubs_pics\\FB\\ua1.png");
                                        break;
                                    case "Саудівська Про Ліга (Саудівська Аравія)":
                                        leg_pict.Image = Image.FromFile("mini_clubs_pics\\FB\\sa1.png");
                                        pers_leag.Image = Image.FromFile("mini_clubs_pics\\FB\\sa1.png");
                                        leg_pict.BackColor = Color.Gray;
                                        break;
                                    case "Серія А (Італія)":
                                        leg_pict.Image = Image.FromFile("mini_clubs_pics\\FB\\it1.png");
                                        pers_leag.Image = Image.FromFile("mini_clubs_pics\\FB\\it1.png");
                                        break;
                                }
                            }
                            else
                            {
                                TT.SetToolTip(leg_pict, player.Ліга);
                                league_pb.Value = 0;
                                switch (player.Ліга)
                                {
                                    case "Бундесліга (Німеччина)":
                                        leg_pict.Image = Image.FromFile("mini_clubs_pics\\FB\\de1.png");
                                        
                                        break;
                                    case "Вища Ліга Футболу (США)":
                                        leg_pict.Image = Image.FromFile("mini_clubs_pics\\FB\\us1.png");
                                        
                                        break;
                                    case "Ередивізі (Нідерланди)":
                                        leg_pict.Image = Image.FromFile("mini_clubs_pics\\FB\\nl1.png");
                                        
                                        break;
                                    case "Ла Ліга (Іспанія)":
                                        leg_pict.Image = Image.FromFile("mini_clubs_pics\\FB\\es1.png");
                                        
                                        break;
                                    case "Ліга Бетклік (Португалія)":
                                        leg_pict.Image = Image.FromFile("mini_clubs_pics\\FB\\pt1.png");
                                        leg_pict.BackColor = Color.Gray;
                                        break;
                                    case "Ліга 1 (Франція)":
                                        leg_pict.Image = Image.FromFile("mini_clubs_pics\\FB\\fr1.png");
                                        
                                        break;
                                    case "Прем'єр Ліга (Англія)":
                                        leg_pict.Image = Image.FromFile("mini_clubs_pics\\FB\\en1.png");
                                        
                                        break;
                                    case "Прем'єр Ліга (Україна)":
                                        leg_pict.Image = Image.FromFile("mini_clubs_pics\\FB\\ua1.png");
                                        
                                        break;
                                    case "Саудівська Про Ліга (Саудівська Аравія)":
                                        leg_pict.Image = Image.FromFile("mini_clubs_pics\\FB\\sa1.png");
                                        leg_pict.BackColor = Color.Gray;
                                        break;
                                    case "Серія А (Італія)":
                                        leg_pict.Image = Image.FromFile("mini_clubs_pics\\FB\\it1.png");
                                        
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
                MessageBox.Show("Hint: " + currentPlayer.Імя + " " + currentPlayer.Прізвище);
                
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

        private void Football_KeyDown(object sender, KeyEventArgs e)
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
