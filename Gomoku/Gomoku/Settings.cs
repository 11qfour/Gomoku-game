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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            toolTip1.SetToolTip(BChngeNameSett, "Изменить имя");
            toolTip1.SetToolTip(BReloadingForm, "Обновить данные");
            toolTip1.SetToolTip(BChangeGamerSett, "Сменить пользователя");
            toolTip1.SetToolTip(BExit, "Выйти");
        }
       static bool save = true; //флаг который ответчает за то, сохранены ли данные при изменении
        private void BChngeNameSett_Click(object sender, EventArgs e)
        {
            TBNameSett.Enabled = true;
            BSaveSett.Visible = true;
            save = false;
            MessageBox.Show("Вы можете изменить имя!");
        }

        private void BSaveSett_Click(object sender, EventArgs e)
        {
            TBNameSett.Enabled = false;
            BSaveSett.Visible = false;
            MessageBox.Show("Имя успешно изменено!");
            save = true;
            //запустить обновление имени в файле со статистикой
        }

        private void BExit_Click(object sender, EventArgs e)
        {
            //обработка сохранены данные или нет

            this.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Settings_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        /////// Анимация /////////
        Image Edit = Image.FromFile("edit.gif");
        Image Editt = Image.FromFile("editt.png");
        private void BChngeNameSett_MouseEnter(object sender, EventArgs e)//обработка наведения на кнопку изменения имени
        {
            BChngeNameSett.Image = Edit;
        }

        private void BChngeNameSett_MouseLeave(object sender, EventArgs e)//обработка покидания курсора с кнопки изменения имени
        {
            BChngeNameSett.Image = Editt;
        }
        Image Reload = Image.FromFile("reloading.gif");
        Image Reloadd = Image.FromFile("reloadd.png");
        private void BReloadingForm_MouseEnter(object sender, EventArgs e)//обработка наведения на кнопку перезагрузка формы
        {
            BReloadingForm.Image = Reload;
        }

        private void BReloadingForm_MouseLeave(object sender, EventArgs e)//обработка покидания курсора с кнопки перезагрузка формы
        {
            BReloadingForm.Image = Reloadd;
        }
        Image Gamer = Image.FromFile("changeprofile.gif");
        Image Gamerr = Image.FromFile("changee.png");
        private void BChangeGamerSett_MouseEnter(object sender, EventArgs e)//обработка наведения на кнопку изменения игрока
        {
            BChangeGamerSett.Image = Gamer;
        }

        private void BChangeGamerSett_MouseLeave(object sender, EventArgs e)//обработка покидания курсора с кнопки изменения игрока
        {
            BChangeGamerSett.Image = Gamerr;
        }

        private void BReloadingForm_Click(object sender, EventArgs e)
        {

        }

        private void BChangeGamerSett_Click(object sender, EventArgs e)
        {

        }
    }
}
