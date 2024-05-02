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

namespace Gomoku
{
    public partial class GameWithPC : Form
    {
        int all_sec = 0;
        Image black = Image.FromFile("blacknew.png");
        Image white = Image.FromFile("whitenew.png");
        ToolTip toolTip1 = new ToolTip();
        Game game;
        Profile profile;
        public GameWithPC()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            toolTip1.SetToolTip(BHelp, "Подсказка");
            toolTip1.SetToolTip(BReturnStep, "Отменить ход");
            toolTip1.SetToolTip(BExit, "Завершить игру и выйти");
            timer = new Timer();
            timer.Interval = 1000; // Интервал в миллисекундах (1 секунда)
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            if (!game.GetGameIsOver())
            {
                Panel cell = sender as Panel;
                if (cell != null)
                {
                    int i = Math.Abs(Convert.ToInt32(cell.Tag) / 100); // получаем координаты
                    int j = Math.Abs(Convert.ToInt32(cell.Tag) % 100);
                    game.NextTurn(i, j);
                    if (cell.BackgroundImage == null)//проверка занята ли ячейка изображением
                    {
                        // Разрешаем обработку клика только на панели [7,7] когда steps = 0
                        if (game.GetSteps() == 0)
                        {
                            cell.BackgroundImageLayout = ImageLayout.Center;
                            if (cell.BackColor == Color.Gray)
                            {
                                cell.BackgroundImage = black;
                                game.SetSteps(game.GetSteps() + 1);
                                game.SetBlackSteps(game.GetBlackSteps() + 1);
                                LWhoStep.Text = "Белых";
                            }
                        }
                        else
                        {
                            cell.BackgroundImageLayout = ImageLayout.Center;
                            if (cell.BackColor == Color.Transparent)
                            {
                                if (game.GetSteps() % 2 == 0) // устанавливаем черный цвет фишки
                                {
                                    cell.BackgroundImage = black;
                                    game.SetSteps(game.GetSteps() + 1);
                                    game.SetBlackSteps(game.GetBlackSteps() + 1);
                                    LWhoStep.Text = "Белых";
                                }
                                else // устанавливаем белый цвет фишки
                                {
                                    cell.BackgroundImage = white;
                                    game.SetSteps(game.GetSteps() + 1);
                                    game.SetWhiteSteps(game.GetWhiteSteps() + 1);
                                    LWhoStep.Text = "Черных";
                                }
                            }
                        }
                    }
                    int result = game.CheckWinner(i, j);
                    if (result == 0)
                    {
                        MessageBox.Show("Ничья!");
                        game.SetGameIsOver(true);
                    }
                    else if (result == 10)
                    {
                        if (game.GetCurrentPlayer() == 'B') //так как уже поменяли в nextturn при ходе
                        {
                            MessageBox.Show("Черные выиграли!");
                            game.SetGameIsOver(true);
                        }
                        else
                        {
                            MessageBox.Show("Белые выиграли!");
                            game.SetGameIsOver(true);
                        }
                    }
                    game.ChangeCurrentPlayer();
                }
            }
            else
            {
                timer.Stop();
                profile.LoadDatas();
            }
        }

        private void LoadPanels() //закраска панелей
        {
            int num = 0;
            for (int i = 0; i < LayGameFieldPC.RowCount; i++)
            {
                for (int j = 0; j < LayGameFieldPC.ColumnCount; j++)
                {
                    Panel cell = LayGameFieldPC.GetControlFromPosition(j, i) as Panel;
                    if (i == 7 && j == 7)
                    {
                        cell.BackColor = Color.Gray;
                    }
                    else
                    {
                        cell.BackColor = Color.Transparent;
                    }
                    cell.Dock = DockStyle.Fill;
                    cell.Name = "Panel" + num.ToString();//для номера панели
                    cell.Tag = i*100+j;
                    cell.Click += Cell_Click; // добавляем обработчик события клика на ячейку
                    num++;
                }
            }
        }

        private void GameWithPC_Load(object sender, EventArgs e)
        {
            LayGameFieldPC.CellPaint += LayGameFieldPC_CellPaint;
            game = new Game();
            profile = new Profile();
            LoadPanels();//нужно более быстрая перерисовка панелей при изменении размеров окна
        }

        private void LayGameFieldPC_CellPaint(object sender, TableLayoutCellPaintEventArgs e)//перерисовывание ячейки
        {
            ControlPaint.DrawBorder(e.Graphics, e.CellBounds, Color.Black, 1, ButtonBorderStyle.Solid, Color.Black, 1, ButtonBorderStyle.Solid, Color.Black, 1, ButtonBorderStyle.Solid, Color.Black, 1, ButtonBorderStyle.Solid);
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
            //обработка шаг назад
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
            LTimeMin.Text = minuts.ToString() + "Мин.";
            LTimeSec.Text = seconds.ToString() + "Сек.";
        }

        private void GameWithPC_Resize(object sender, EventArgs e)
        {
            double aspectRatio = 816.0 / 489.0; // Соотношение сторон исходного размера формы
            int newWidth = this.Width;
            int newHeight = Convert.ToInt32(newWidth / aspectRatio);

            // Проверка, чтобы TableLayoutPanel не выходил за пределы размеров формы
            if (newHeight > this.Height)
            {
                newHeight = this.Height;
                newWidth = Convert.ToInt32(this.Height * aspectRatio);
            }

            LayGameFieldPC.Size = new Size(newWidth, newHeight);
        }
    }
}
