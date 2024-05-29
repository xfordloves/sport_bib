﻿using System;
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
    public partial class Help_Window : Form
    {
        public Help_Window()
        {
            InitializeComponent();
            ShowReason();
        }
        private void ShowReason() 
        {
            reason_txt.Text = "  Ця програма призначена для ознайомлення з спортсменами двох видів спорту. Данні про яких систематизовані у вигляді зручних таблиць. І згідно цих даних користувач може проаналізувати потрібну йому інформацію та скористатися нею у майбутньому.";
        }
        private void startw_btn_Click(object sender, EventArgs e)
        {
            guide_txt.Text = "  У 'Початковому Вікні' користувач повинен обрати вид спорту про спортсменів, якого він чи вона бажає дізнатись. Інтерфейс представлений у вигляді двох картинок на котрі можна натиснути і відповідно від картинки відкриється відповідний 'Довідник Фаната'. Якщо користувачеві не зрозуміло, котра з картинок яка, то направивши курсор на одну з картинок з'явиться назва виду спорту, що представляє картинка. ";
        }

        private void dovidnykF_btn_Click(object sender, EventArgs e)
        {
            guide_txt.Text = "  У 'Футбольному Довіднику Фаната' присутній пошук гравців за відповідними критеріями. До уваги користувача представлений відповідний куточок в якому присутні усі необхідні поля для пошуку футболістів. Щоб розпочати можна натиснути кнопку з зображенням збільшувального скла (Примітка: якщо всі поля для пошуку пусті то з'являться всі футболісти, що є в базі даних програми), попердньо можна внести критерії пошуку. Якщо користувачеві не зрозуміло, які типи даних вводити у пошукові поля, то нижче зазначений необхідний перелік: \n\n    Ім'я = Текст (Наприклад: Олександр);\n    Прізвище = Текст (Наприклад: Зінченко);\n    Клуб = Текст (Наприклад: Арсенал);\n    Зріст = Число (Наприклад: 175);\n    Національність = Оберіть 1 з 75 (Наприклад: Україна);\n    Вік = Число (Наприклад: 27);\n    Номер = Число (Наприклад: 35);\n    Позиція: Оберіть 1 з 13 (Наприклад: Лівий Захисник);\n    Ліга: Оберіть 1 з 10 (Наприклад: Прем'єр Ліга (Англія));\n    Трофеї: Число (Наприклад: 11);\n\n  Після того як користувач заповнив поля пошуку і натиснув клавішу 'Enter' або кнопку зі збільшувальним склом. Далі користувач побачить таблицю тих гравців, які підходять під обрані критерії. Користувач може натиснути на рядок в якому знаходиться той чи інший футболіст, і побачити додаткову інформацію про цього футболіста. Додаткова інформація представлена у вигляді 'Рейтинга', який вираховується з 6 харакетеристик , що зображені поряд , також користувач може побачити 'Поличку досягненнь' цього гравця.\n  Також користуач може взаємодіяти з меню цього вікна, яке можна побачити зверху вікна. В цьому меню розташовані три кнопки:\n  'Довідка',яка активується по натисканні на неї або за допомгою клавіші 'F1';\n  'Про нас', яка слугує для знайомства з розробниками цього застосунку;\n  'Гра' це кнопка, яка слугує для того щоб зіграти в гру 'Вгадай футболіста'";
        }

        private void dovidnykB_btn_Click(object sender, EventArgs e)
        {
            guide_txt.Text = "  У 'Баскетбольному Довіднику Фаната' присутній пошук гравців за відповідними критеріями. До уваги користувача представлений відповідний куточок в якому присутні усі необхідні поля для пошуку баскетболістів. Щоб розпочати можна натиснути кнопку з зображенням збільшувального скла (Примітка: якщо всі поля для пошуку пусті то з'являться всі баскетболісти, що є в базі даних програми), попердньо можна внести критерії пошуку. Якщо користувачеві не зрозуміло, які типи даних вводити у пошукові поля, то нижче зазначений необхідний перелік: \n\n    Ім'я = Текст (Наприклад: Святослав);\n    Прізвище = Текст (Наприклад: Михайлюк);\n    Команда = Текст (Наприклад: Бостон Селтікс);\n    Зріст = Число (Наприклад: 201);\n    Національність = Оберіть 1 з 38 (Наприклад: Україна);\n    Вік = Число (Наприклад: 26);\n    Номер = Число (Наприклад: 50; \nПримітка: так як в баскетболі присутні номери #0 та #00 ви також можете їх ввести);\n    Позиція: Оберіть 1 з 7 (Наприклад: Захисник-Форвард);\n    Конференція: Оберіть 1 з 2 (Наприклад: Східна Конференція);\n    Трофеї: Число (Наприклад: 0);\n\n  Після того як користувач заповнив поля пошуку і натиснув клавішу 'Enter' або кнопку зі збільшувальним склом. Далі користувач побачить таблицю тих гравців, які підходять під обрані критерії. Користувач може натиснути на рядок в якому знаходиться той чи інший баскетболіст, і побачити додаткову інформацію про цього баскетболіста. Додаткова інформація представлена у вигляді 'Рейтинга', який вираховується з 6 харакетеристик , що зображені поряд , також користувач може побачити 'Поличку досягненнь' цього гравця.\n  Також користуач може взаємодіяти з меню цього вікна, яке можна побачити зверху вікна. В цьому меню розташовані три кнопки:\n  'Довідка',яка активується по натисканні на неї або за допомгою клавіші 'F1';\n  'Про нас', яка слугує для знайомства з розробниками цього застосунку;\n  'Гра' це кнопка, яка слугує для того щоб зіграти в гру 'Вгадай баскетболіста'";
        }

        private void gameF_btn_Click(object sender, EventArgs e)
        {
            guide_txt.Text = "  Головна ціль цієї гри це вгадати загданого випадковим чином футболіста. На початку ви можете обрати чи сховати , чи показати фото загаданого футболіста , тобто ускладнити собі завдання чи спростити. Після чого користувач повинен вписувати Ім'я та Прізвище футболіста, щоб вгадати його. На поміч користувачеві з'являтимуться підказки які будуть спочатку відображатись під фотографією гравця, а саме якщо один з показників вгаданий правильно то він засяє зеленим та з'явиться поруч з фото загаданого гравця. Таким чином методом виключення можна здогадатися хто саме загаданий. Також варто зазначити, що у користувача обмежена кількість спроб, а саме 8 та наявна кнопка 'Підказка', яка допоможе якщо виникнуть складнощі. Перевірка гравця виконується за допомогою відповідної кнопки та при натисканні клавіші 'Enter'.";
        }

        private void gameB_btn_Click(object sender, EventArgs e)
        {
            guide_txt.Text = "  Головна ціль цієї гри це вгадати загданого випадковим чином баскетболіста. На початку ви можете обрати чи сховати , чи показати фото загаданого футболіста , тобто ускладнити собі завдання чи спростити. Після чого користувач повинен вписувати Ім'я та Прізвище баскетболіста, щоб вгадати його. На поміч користувачеві з'являтимуться підказки які будуть спочатку відображатись під фотографією гравця, а саме якщо один з показників вгаданий правильно то він засяє зеленим та з'явиться поруч з фото загаданого гравця. Таким чином методом виключення можна здогадатися хто саме загаданий. Також варто зазначити, що у користувача обмежена кількість спроб, а саме 8 та наявна кнопка 'Підказка', яка допоможе якщо виникнуть складнощі. Перевірка гравця виконується за допомогою відповідної кнопки та при натисканні клавіші 'Enter'.";
        }
    }
}
