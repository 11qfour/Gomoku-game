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
    public partial class Rules : Form
    {
        const int sizerules = 5;
        int page = 0;//счетчик страниц , используется для перелистывания по кнопкам
        Rules[] manyrules = new Rules[sizerules];//массив форм правил из 5 элементов
        Image[] Images = new Image[sizerules];//заполнение массива изображений как в девятой лабе сишарп

        public Rules()
        {
            InitializeComponent();
           
        }

        private Rules SetNameOfRule(Rules ruu,string ru)//переименование формы согласно следованию
        {
            ruu.Name = ru;
            return ruu;
        }

        private void Rules_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < sizerules; i++)
            {
                Rules rule = new Rules();
                string ru = "Rule" + (i+1).ToString();
                manyrules[i] = SetNameOfRule(rule, ru);//занесение формы в массив
            }
            InitRule();
        }

        private void InitRule()//инициализация формы правило
        {
            //все что должно присваиваться тексту должно быть в массиве строк по этим элементам и будут выводиться значения
            manyrules[page].LNameRules.Text = "";
            manyrules[page].LFirstRule.Text = "";
            manyrules[page].LSecondRule.Text = "";
            manyrules[page].PBRules.Image = Images[page];
            manyrules[page].Show();//показать форму
        }

        private void LNameRules_Click(object sender, EventArgs e)
        {

        }

        private void BNext_Click(object sender, EventArgs e)
        {
            page++;
            InitRule();
        }

        private void BBackRules_Click(object sender, EventArgs e)
        {
            page--;
            InitRule();
        }
    }

    /*class Ruless
    {
        public void SetForm()
        {
            rules = new Rules();
        }

        public Form GetForm()
        {
            return rules;
        }

        public void SetMainNameRules(string Text)
        {
            rules.LNameRules.Text = Text;
        }

        public void SetLabelFirstRules(string Text)
        {
            rules.LFirstRule.Text = Text;
        }

        public void SetLabelSecondRules(string Text)
        {
            rules.LSecondRule.Text = Text;
        }

        public void SetPBRulesImage(Image image)
        {
            rules.PBRules.Image = image;
        }
    }*/
}
