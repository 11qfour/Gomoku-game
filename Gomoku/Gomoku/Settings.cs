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
            SizeChanged += Settings_SizeChanged;
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

        private void Settings_SizeChanged(object sender, EventArgs e)
        {
            SuspendLayout(); // Приостанавливаем перерисовку контролов

                float scaleWidth = (float)Width / (float)this.Width; // Коэффициент сохранения ширины
                float scaleHeight = (float)Height / (float)this.Height; // Коэффициент сохранения высоты
                PagesSett.Size= new Size((int)(PagesSett.Width * scaleWidth), (int)(PagesSett.Height * scaleHeight));
                tabPage1.Size = new Size((int)(tabPage1.Width * scaleWidth), (int)(tabPage1.Height * scaleHeight));
                TBNameSett.Size = new Size((int)(TBNameSett.Width * scaleWidth), (int)(TBNameSett.Height * scaleHeight));
                LMainSett.Size = new Size((int)(LMainSett.Width * scaleWidth), (int)(LMainSett.Height * scaleHeight));
                BSaveSett.Size = new Size((int)(BSaveSett.Width * scaleWidth), (int)(BSaveSett.Height * scaleHeight));
                BChngeNameSett.Size = new Size((int)(BChngeNameSett.Width * scaleWidth), (int)(BChngeNameSett.Height * scaleHeight));
                BReloadingForm.Size = new Size((int)(BReloadingForm.Width * scaleWidth), (int)(BReloadingForm.Height * scaleHeight));
                LSett1.Size = new Size((int)(LSett1.Width * scaleWidth), (int)(LSett1.Height * scaleHeight));
                TBRapidSett.Size = new Size((int)(TBRapidSett.Width * scaleWidth), (int)(TBRapidSett.Height * scaleHeight));
                LSett2.Size = new Size((int)(LSett2.Width * scaleWidth), (int)(LSett2.Height * scaleHeight));
                TLPSett.Size = new Size((int)(TLPSett.Width * scaleWidth), (int)(TLPSett.Height * scaleHeight));
                BExit.Size = new Size((int)(BExit.Width * scaleWidth), (int)(BExit.Height * scaleHeight));
                // Дополнительные действия при изменении размера окна
          

            ResumeLayout(); // Возобновляем перерисовку контролов
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
    }
}
