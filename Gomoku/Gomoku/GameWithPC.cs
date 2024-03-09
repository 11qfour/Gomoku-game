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
    public partial class GameWithPC : Form
    {
        int all_sec=0;
        int steps;
        int white_steps;
        Image black = Image.FromFile("black.png");
        Image white = Image.FromFile("white.png");
        int black_steps;
        public GameWithPC()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            /*Resize += MainMenu_Resize;*/
            SizeChanged += GameWithPC_SizeChanged;

            timer = new Timer();
            timer.Interval = 1000; // Интервал в миллисекундах (1 секунда)
            timer.Tick += timer_Tick;

            timer.Start();
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel; // Приводим sender к типу Panel
            if (panel != null) // Проверяем, успешно ли приведение к типу Panel
            {
                if (panel.BackgroundImage == null)//проверка занята ли ячейка изображением
                {
                    panel.BackgroundImageLayout = ImageLayout.Center;
                    if (panel.BackColor == Color.Transparent)
                    {
                        if (steps % 2 == 0) // устанавливаем черный цвет фишки
                        {//сделать на полный экран
                            panel.BackgroundImage = black;
                            steps++;
                            black_steps++;
                            LOpp.Text = "Белых";
                        }
                        else // устанавливаем белый цвет фишки
                        {
                            panel.BackgroundImage = white;
                            steps++;
                            white_steps++;
                            LOpp.Text = "Черных";
                        }
                    }
                }
            }
        }

        private void LoadPanels()
        {
            for (int i = 0; i < LayGameFieldPC.RowCount; i++)
            {
                for (int j = 0; j < LayGameFieldPC.ColumnCount; j++)
                {
                    Panel cell = new Panel
                    {
                        BackColor = Color.Transparent,
                        Dock = DockStyle.Fill
                    };
                    cell.Click += Cell_Click; // добавляем обработчик события клика на ячейку

                    LayGameFieldPC.Controls.Add(cell, j, i); // добавляем ячейку в таблицу
                }
            }
        }

        private void GameWithPC_Load(object sender, EventArgs e)
        {
            steps = 0;
            white_steps = 0;
            black_steps = 0;
            LayGameFieldPC.CellPaint += LayGameFieldPC_CellPaint;
            LoadPanels();//нужно более быстрая перерисовка панелей при изменении размеров окна

        }

        private void LayGameFieldPC_CellPaint(object sender, TableLayoutCellPaintEventArgs e)//перерисовывание ячейки
        {
            ControlPaint.DrawBorder(e.Graphics, e.CellBounds, Color.Black, 1, ButtonBorderStyle.Solid, Color.Black, 1, ButtonBorderStyle.Solid, Color.Black, 1, ButtonBorderStyle.Solid, Color.Black, 1, ButtonBorderStyle.Solid);
        }

        private void GameWithPC_SizeChanged(object sender, EventArgs e)
        {
            SuspendLayout(); // Приостанавливаем перерисовку контролов

            if (WindowState == FormWindowState.Maximized || WindowState == FormWindowState.Normal)
            {
                float scaleWidth = (float)Width / (float)this.Width; // Коэффициент сохранения ширины
                float scaleHeight = (float)Height / (float)this.Height; // Коэффициент сохранения высоты
                LayGameFieldPC.Size = new Size((int)(LayGameFieldPC.Width * scaleWidth), (int)(LayGameFieldPC.Height * scaleHeight));
                LNameOpp.Size= new Size((int)(LNameOpp.Width * scaleWidth), (int)(LNameOpp.Height * scaleHeight));
                LNameTime.Size= new Size((int)(LNameTime.Width * scaleWidth), (int)(LNameTime.Height * scaleHeight));
                LTimeSec.Size = new Size((int)(LTimeSec.Width * scaleWidth), (int)(LTimeSec.Height * scaleHeight));
                LOpp.Size= new Size((int)(LOpp.Width * scaleWidth), (int)(LOpp.Height * scaleHeight));
                LNowStepsGame.Size= new Size((int)(LNowStepsGame.Width * scaleWidth), (int)(LNowStepsGame.Height * scaleHeight));
                LWhoStep.Size= new Size((int)(LWhoStep.Width * scaleWidth), (int)(LWhoStep.Height * scaleHeight));
                BHelp.Size = new Size((int)(BHelp.Width * scaleWidth), (int)(BHelp.Height * scaleHeight));
                BExit.Size= new Size((int)(BHelp.Width * scaleWidth), (int)(BHelp.Height * scaleHeight));
                BReturnStep.Size= new Size((int)(BHelp.Width * scaleWidth), (int)(BHelp.Height * scaleHeight));
                // Дополнительные действия при изменении размера окна
            }

            ResumeLayout(); // Возобновляем перерисовку контролов
        }

        private void GameWithPC_FormClosing(object sender, FormClosingEventArgs e)//действия перед закрытием формы
        {
            /*В обработчике этого события можно выполнить действия для подготовки к закрытию формы, например, сохранить данные, проверить наличие несохраненных изменений и запросить подтверждение пользователя.
Если отменить закрытие формы в обработчике FormClosing, вызвав e.Cancel = true;, форма останется открытой и закрытие будет отменено. */
        }

        private void GameWithPC_FormClosed(object sender, FormClosedEventArgs e)//действия уже после закрытия формы
        {
            timer.Stop();//подумать над сохранением в формклоусед
            /*Используйте это событие, если вам нужно выполнить какие-то действия после того, например, очистить временные данные или выполнить завершающие действия. */
        }

        private void BExit_Click(object sender, EventArgs e)
        {
            DialogResult resultdialog = MessageBox.Show("Вы уверены что хотите закончить игровую сессию?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultdialog == DialogResult.Yes)
            {
                timer.Stop();//подумать над сохранением в формклоусед
                this.Close();
            }
        }

        private void BHelp_Click(object sender, EventArgs e)//подсказка
        {

        }

        private void BReturnStep_Click(object sender, EventArgs e)//возвращение хода
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int currentValue = all_sec;
            all_sec++;
            currentValue++;
            int minuts = (currentValue / 60);
            int seconds = (currentValue % 60);
            if (minuts == 0)
            {
                LTimeMin.Visible = false;
            }
            else
            {
                LTimeMin.Visible = true;
            }
            LTimeMin.Text = minuts.ToString()+"Мин.";
            LTimeSec.Text = seconds.ToString()+"Сек.";
        }
    }
}
