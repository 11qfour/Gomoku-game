using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Gomoku
{
    public partial class RulesForm : Form
    {
        const int sizerules = 4; //всего страниц
        int page = 0;//счетчик страниц , используется для перелистывания по кнопкам
        Image[] Images;//заполнение массива изображений как в девятой лабе сишарп
        public RulesForm()
        {
            InitializeComponent();
        }
        private void Rules_Load(object sender, EventArgs e)
        {
            InitImages();
            InitRules1(); 
        }

        private void InitImages() //иницициализация массива с соответсвующими рисунками
        {
            Images = new Image[8];
            Images[0] = Image.FromFile("close three.jpg");
            Images[1] = Image.FromFile("three.jpg");
            Images[2] = Image.FromFile("close four.jpg");
            Images[3] = Image.FromFile("four.jpg");
            Images[4] = Image.FromFile("five.jpg");
            Images[5] = Image.FromFile("long.jpg");
            Images[6] = Image.FromFile("33.jpg");
            Images[7] = Image.FromFile("44.jpg");
        }

        private void InitRules1()//инициализация правил 1
        {
            BBackRules.Visible = false;
            LNameRules.Text = "Тройка";
            LFirstRule.Text = "Тройка – тройка, которая на следующий ход образовывает четвёрку," +
                " противник может\nпомешать этому блоком своей фишки с другой стороны";
            LSecondRule.Text = "Открытая тройка – тройка, которая угрожает сделать открытую четвёрку," +
                " противник должен\n«закрыть тройку» - поставить фишку с любой стороны";
            PB1Rules.Image = Images[0];
            LUnderPic1Rules.Text = "Тройка / Закрытая тройка";
            PB2Rules.Image = Images[1];
            LUnderPic2Rules.Text = "Открытая тройка";
        }

        private void InitRules2()//инициализация правил 2
        {
            BBackRules.Visible = true;
            LNameRules.Text = "Четверка";
            LFirstRule.Text = "Четвёрка – четвёрка, угрожающая пятеркой при следующем ходе, " +
                "достроена до пяти\nможет быть единственно возможным ходом";
            LSecondRule.Text = "Открытая четверка – гарантированная победа игрока, который её создаст, " +
                "есть два варианта\nпоставить камень при следующем ходе, чтобы выиграть";
            PB1Rules.Image = Images[2];
            LUnderPic1Rules.Text = "Четверка / Закрытая четверка";
            PB2Rules.Image = Images[3];
            LUnderPic2Rules.Text = "Открытая четверка";
        }

        private void InitRules3()//инициализация правил 3
        {
            BNext.Visible = true;
            LNameRules.Text = "Условия выигрыша";
            LFirstRule.Text = "Пятерка – пять камней, соединённые прямой линией, основное условие победы игрока";
            LSecondRule.Text = "Длинный ряд – шесть или более камней в ряд, не является выигрышной";
            PB1Rules.Image = Images[4];
            LUnderPic1Rules.Text = "Пятерка";
            PB2Rules.Image = Images[5];
            LUnderPic2Rules.Text = "Длинный ряд";
        }

        private void InitRules4()//инициализация правил 4
        {
            BNext.Visible = false;
            LNameRules.Text = "Вилки";
            LFirstRule.Text = "Вилка 3x3 – ситуация, при которой игрок обеспечивает себе " +
                "создание открытой четвёрки\nвне зависимости от игры противника";
            LSecondRule.Text = "Вилка 4x4 - ситуация, при которой образуются 2 закрытых четвёрки," +
                "перекрывание любой,\nозначает превращение другой в пятерку";
            PB1Rules.Image = Images[6];
            LUnderPic1Rules.Text = "Вилка 3x3";
            PB2Rules.Image = Images[7];
            LUnderPic2Rules.Text = "Вилка 4x4";
        }

        private void BNext_Click(object sender, EventArgs e) // перейти на следующий список правил
        {
            if (page < sizerules)
            {
                page++;
                if (page == 2)
                {
                    InitRules2();
                }
                else if (page == 3)
                {
                    InitRules3();
                }
                else if (page == 4)
                {
                    InitRules4();
                }
            }
            else
            {
                //обработка если нет выше форм -> можно не обрабатывать, решена visible навигационных кнопок
            }
        }

        private void BBackRules_Click(object sender, EventArgs e) //перейти на предыдущий список правил
        {
            if (page > 0)
            {
                page--;
                if (page == 2)
                {
                    InitRules2();
                }
                else if (page == 3)
                {
                    InitRules3();
                }
                else if (page == 1)
                {
                    InitRules1();
                }
            }
            else
            {
                //обработка если нет форм ниже, можно не обрабатывать, решена visible навигационных кнопок
            }
        }

        private void ExitMainButton_Click(object sender, EventArgs e) //выйти в главное меню
        {
            this.Close();
        }
    }
}
