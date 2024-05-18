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

        public void SetOppName(string s) //вывод имени противника
        {
            LOpp.Text = s;
        }

        private void Cell_Click(object sender, EventArgs e) //нажатие на ячейку игрового поля
        {
            if (!game.GetGameIsOver())
            {
                Panel cell = sender as Panel;
                if (cell != null && cell.BackgroundImage == null)
                {
                    int i = Math.Abs(Convert.ToInt32(cell.Tag) / 100);
                    int j = Math.Abs(Convert.ToInt32(cell.Tag) % 100);
                    cell.BackgroundImageLayout = ImageLayout.Center;
                    game.NextTurn(i, j);
                    if (game.GetSteps() == 0)
                    {
                        if (cell.BackColor == Color.Gray)
                        {
                            this.WindowState = FormWindowState.Maximized;
                            cell.BackgroundImage = black;
                            game.SetSteps(game.GetSteps() + 1);
                            game.SetBlackSteps(game.GetBlackSteps() + 1);
                            LWhoStep.Text = "Белых";
                        }
                    }
                    else
                    {
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
                    PaintChoosePanel();
                    int result = game.CheckWinner(i, j);
                    if (result == 0)
                    {
                        MessageBox.Show("Ничья!");
                        game.SetGameIsOver(true);
                    }
                    else if (result == 10)
                    {
                        PaintWinnerPanels(game.GetSuccessSteps());
                        if (game.GetCurrentPlayer() == 'B') //так как уже поменяли в nextturn при ходе
                        {
                            MessageBox.Show("Черные выиграли!\nВсего ходов: " + game.GetSteps() + "\nКоличество ходов победителя: " + game.GetBlackSteps() + "\nКоличество ходов проигравшего: " + game.GetWhiteSteps());
                            game.SetGameIsOver(true);
                        }
                        else
                        {
                            MessageBox.Show("Белые выиграли!\nВсего ходов: " + game.GetSteps() + "\nКоличество ходов победителя: " + game.GetWhiteSteps() + "\nКоличество ходов проигравшего: " + game.GetBlackSteps());
                            game.SetGameIsOver(true);
                        }
                    }
                    game.ChangeCurrentPlayer();
                }
            }
            else
            {

                profile.LoadDatas(); //внимание на то что каждый раз создается новый, значит нудно решить проеелму
            }
        }

        private void PaintWinnerPanels(List<int[]> array) //закраска выигрышнх клеток
        {
            for (int i = 0; i < array.Count; i++)
            {
                int row = array[i][0]; // Первый элемент массива - это строка
                int col = array[i][1]; // Второй элемент массива - это столбец
                Panel cell = LayGameFieldPC.GetControlFromPosition(col, row) as Panel;
                if (cell != null)
                {
                    cell.BackColor = Color.Gold;
                }
            }
        }

        private void PaintChoosePanel()//изменение панели, на которую был сделан ход
        {
            int i=7, j=7;
            if (game.GetSequenceOfMoves().Count == 1) //первый ход всегда в центр
            {
                var lastMove = game.GetSequenceOfMoves()[game.GetSequenceOfMoves().Count - 1];
                i = lastMove.Item1; // Последний x
                j = lastMove.Item2; // Последний y
                Panel cell = LayGameFieldPC.GetControlFromPosition(j, i) as Panel;
                cell.BackColor = Color.Peru;
            }
            else if (game.GetSequenceOfMoves().Count > 1)
            {
                var lastMove = game.GetSequenceOfMoves()[game.GetSequenceOfMoves().Count - 1];
                var previousLastMove = game.GetSequenceOfMoves()[game.GetSequenceOfMoves().Count - 2];
                i = lastMove.Item1; // Последний x
                j = lastMove.Item2; // Последний y
                int prevI = previousLastMove.Item1;
                int prevJ = previousLastMove.Item2;
                Panel cell = LayGameFieldPC.GetControlFromPosition(j, i) as Panel;
                cell.BackColor = Color.Peru;
                Panel prevCell = LayGameFieldPC.GetControlFromPosition(prevJ, prevI) as Panel;
                if (prevI==7 && prevJ == 7)
                    prevCell.BackColor= Color.Gray;
                else
                    prevCell.BackColor = Color.Transparent;
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
                    cell.Tag = i * 100 + j;
                    cell.Click += Cell_Click; // добавляем обработчик события клика на ячейку
                    num++;
                }
            }
        }

        private void GameWithPC_Load(object sender, EventArgs e)
        {
            LayGameFieldPC.CellPaint += LayGameFieldPC_CellPaint;

            game = new Game();

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
            int i = 0, j = 0;
            game.CancelTurn(ref i, ref j);
            if (i >= 0 && i < 15 && j >= 0 && j < 15) //проверка попадания и правимльного отбора из списка
            {
                Panel cell = LayGameFieldPC.GetControlFromPosition(j, i) as Panel;
                if (cell != null)
                    cell.BackgroundImage = null; //удаляем имейдж
                if (i == 7 && j == 7)
                    cell.BackColor = Color.Gray;
                else
                    cell.BackColor = Color.Transparent;
                PaintChoosePanel();
                if (game.GetCurrentPlayer() == 'W')
                {
                    LWhoStep.Text = "Белых";

                }
                else
                {
                    LWhoStep.Text = "Черных";
                }
            }
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
