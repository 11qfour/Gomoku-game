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
    public partial class Experiment : Form
    {
        int all_sec = 0;
        Image black = Image.FromFile("blacknew.png");
        Image white = Image.FromFile("whitenew.png");
        ToolTip toolTip1 = new ToolTip();
        //Game game = new Game();
        GameWithBot botPlayer;
        bool gameWithBot = true;
        private int dataTimeLimit = int.MaxValue; //ограничение по времени
        private bool IsTimeLimit; //есть ограничение по времени или нет
        public Experiment()
        {
            InitializeComponent();
            /*timer = new Timer();
            timer.Interval = 1000; // Интервал в миллисекундах (1 секунда)
            timer.Tick += timer_Tick;
            timer.Start();*/
        }

        private void Experiment_Load(object sender, EventArgs e)
        {
            LoadPanels();
            SetGameWithBot(true);
            botPlayer = new GameWithBot('M', 'W');
        }

        public void SetGameWithBot(bool flag)
        {
            this.gameWithBot = flag;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int currentValue = all_sec;
            all_sec++;
            currentValue++;
            int minuts = (currentValue / 60);
            int seconds = (currentValue % 60);
            TimeLabel.Text = seconds.ToString() + " Сек.";
        }
        /*private void Cell_Click(object sender, EventArgs e) //нажатие на ячейку игрового поля при игре 1 на 1
        {
            try
            {
                if (!game.GetGameIsOver())
                {
                    Panel cell = sender as Panel;
                    if (cell != null && cell.BackgroundImage == null)
                    {
                        int i = Math.Abs(Convert.ToInt32(cell.Tag) / 100);
                        int j = Math.Abs(Convert.ToInt32(cell.Tag) % 100);
                        cell.BackgroundImageLayout = ImageLayout.Center;
                        game.NextTurn(i, j, game.GetCurrentPlayer());
                        UpdateGameUI(cell, i, j);
                        int result = game.CheckWinner(i, j);
                        if (result == 0)
                        {
                            MessageBox.Show("Ничья!");
                            game.SetGameIsOver(true);
                            return;
                        }
                        else if (result == 10)
                        {
                            EndGame(game.GetCurrentPlayer());
                            return;
                        }
                    }
                }
                else
                {

                  
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }*/

        private void PaintWinnerPanels(List<int[]> array) //закраска выигрышнх клеток
        {
            try
            {
                for (int i = 0; i < array.Count; i++)
                {
                    int row = array[i][0]; // Первый элемент массива - это строка
                    int col = array[i][1]; // Второй элемент массива - это столбец
                    Panel cell = tableLayoutPanel1.GetControlFromPosition(col, row) as Panel;
                    if (cell != null)
                    {
                        cell.BackColor = Color.Gold;
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void PaintChoosePanel()//изменение панели, на которую был сделан ход
        {
            try
            {
                int i = 7, j = 7;
                if (gameWithBot)
                {
                    if (botPlayer.GetSequenceOfMoves().Count == 1) //первый ход всегда в центр
                    {
                        var lastMove = botPlayer.GetSequenceOfMoves()[botPlayer.GetSequenceOfMoves().Count - 1];
                        i = lastMove.Item1; // Последний x
                        j = lastMove.Item2; // Последний y
                        Panel cell = tableLayoutPanel1.GetControlFromPosition(j, i) as Panel;
                        cell.BackColor = Color.Peru;
                    }
                    else if (botPlayer.GetSequenceOfMoves().Count > 1)
                    {
                        var lastMove = botPlayer.GetSequenceOfMoves()[botPlayer.GetSequenceOfMoves().Count - 1];
                        var previousLastMove = botPlayer.GetSequenceOfMoves()[botPlayer.GetSequenceOfMoves().Count - 2];
                        i = lastMove.Item1; // Последний x
                        j = lastMove.Item2; // Последний y
                        int prevI = previousLastMove.Item1;
                        int prevJ = previousLastMove.Item2;
                        Panel cell = tableLayoutPanel1.GetControlFromPosition(j, i) as Panel;
                        cell.BackColor = Color.Peru;
                        Panel prevCell = tableLayoutPanel1.GetControlFromPosition(prevJ, prevI) as Panel;
                        if (prevI == 7 && prevJ == 7)
                            prevCell.BackColor = Color.Gray;
                        else
                            prevCell.BackColor = Color.Transparent;
                    }
                }
               /* else
                {
                    if (game.GetSequenceOfMoves().Count == 1) //первый ход всегда в центр
                    {
                        var lastMove = game.GetSequenceOfMoves()[game.GetSequenceOfMoves().Count - 1];
                        i = lastMove.Item1; // Последний x
                        j = lastMove.Item2; // Последний y
                        Panel cell = tableLayoutPanel1.GetControlFromPosition(j, i) as Panel;
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
                        Panel cell = tableLayoutPanel1.GetControlFromPosition(j, i) as Panel;
                        cell.BackColor = Color.Peru;
                        Panel prevCell = tableLayoutPanel1.GetControlFromPosition(prevJ, prevI) as Panel;
                        if (prevI == 7 && prevJ == 7)
                            prevCell.BackColor = Color.Gray;
                        else
                            prevCell.BackColor = Color.Transparent;
                    }
                }*/
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        private void Cell_Click_Bot(object sender, EventArgs e)
        {
            try
            {
                if (!botPlayer.GetGameIsOver())
                {
                    Panel cell = sender as Panel;
                    if (cell != null && cell.BackgroundImage == null)
                    {
                        int i = Math.Abs(Convert.ToInt32(cell.Tag) / 100);
                        int j = Math.Abs(Convert.ToInt32(cell.Tag) % 100);
                        cell.BackgroundImageLayout = ImageLayout.Center;
                        botPlayer.NextTurn(i, j, 'B');
                        UpdateGameUI(cell, i, j);
                        int result = botPlayer.CheckWinner(i, j);
                        if (result == 0)
                        {
                            MessageBox.Show("Ничья!");
                            botPlayer.SetGameIsOver(true);
                            return;
                        }
                        else if (result == 10)
                        {
                            EndGame(botPlayer.GetCurrentPlayer());
                            return;
                        }
                        // Ход бота
                        if (!botPlayer.GetGameIsOver())
                        {

                            List<(int, int)> botMove = botPlayer.DoStep(); //бот делает ход
                            int botI = botMove[0].Item1;
                            int botJ = botMove[0].Item2;
                            if (botPlayer.rightCoordination(botI, botJ))
                            {
                                Panel botCell = tableLayoutPanel1.GetControlFromPosition(botJ, botI) as Panel;
                                if (botPlayer.GetBoardValue(botI, botJ)!='E')
                                {
                                    DialogResult resultdialog = MessageBox.Show("Клетка, в которую противник-компьютер хочет поставить свой камень, уже занята!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    if (resultdialog == DialogResult.OK)
                                    {
                                        this.Close();
                                    }
                                }
                                if (botCell != null && botCell.BackgroundImage == null)
                                {
                                    botCell.BackgroundImageLayout = ImageLayout.Center;
                                    botPlayer.NextTurn(botI, botJ, botPlayer.GetBotPlayerSide());
                                    UpdateGameUI(botCell, botI, botJ);
                                    result = botPlayer.CheckWinner(botI, botJ);
                                    if (result == 0)
                                    {
                                        MessageBox.Show("Ничья!");
                                        botPlayer.SetGameIsOver(true);
                                        return;
                                    }
                                    else if (result == 10)
                                    {
                                        EndGame(botPlayer.GetBotPlayerSide());
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                DialogResult resultdialog = MessageBox.Show($"Индексы {botI} и {botJ} вне границ игрового поля, которые равны {botPlayer.GetBoard().Length}!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                if (resultdialog == DialogResult.OK)
                                {
                                    this.Close();
                                }
                            }
                        }
                    }
                }
                else
                {
                    
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void UpdateGameUI(Panel cell, int i, int j)
        {
            if (gameWithBot)
            {
                if (cell.BackgroundImage == null)
                {
                    if (botPlayer.GetSteps() % 2 == 0) // устанавливаем черный цвет фишки
                    {
                        cell.BackgroundImage = black;
                        botPlayer.SetSteps(botPlayer.GetSteps() + 1);
                        botPlayer.SetBlackSteps(botPlayer.GetBlackSteps() + 1);
                        WhoStep.Text = "Белых";
                    }
                    else // устанавливаем белый цвет фишки
                    {
                        cell.BackgroundImage = white;
                        botPlayer.SetSteps(botPlayer.GetSteps() + 1);
                        botPlayer.SetWhiteSteps(botPlayer.GetWhiteSteps() + 1);
                        WhoStep.Text = "Черных";
                    }
                }
            }
            /*else
            {

                if (game.GetSteps() % 2 == 0) // устанавливаем черный цвет фишки
                {
                    cell.BackgroundImage = black;
                    game.SetSteps(game.GetSteps() + 1);
                    game.SetBlackSteps(game.GetBlackSteps() + 1);
                    WhoStep.Text = "Белых";
                }
                else // устанавливаем белый цвет фишки
                {
                    cell.BackgroundImage = white;
                    game.SetSteps(game.GetSteps() + 1);
                    game.SetWhiteSteps(game.GetWhiteSteps() + 1);
                    WhoStep.Text = "Черных";
                }
                game.ChangeCurrentPlayer();
            }*/
            PaintChoosePanel();
        }
           

        private void EndGame(char player)
        {

            if (gameWithBot)
            {
                botPlayer.SetGameIsOver(true);
                PaintWinnerPanels(botPlayer.GetSuccessSteps());
                if (botPlayer.GetBotPlayerSide() == player) //так как уже поменяли в nextturn при ходе
                {
                    MessageBox.Show("Вы проиграли!\nВсего ходов: " + botPlayer.GetSteps() + "\nКоличество ходов противника: " + botPlayer.GetBlackSteps() + "\nКоличество ходов пользователя: " + botPlayer.GetWhiteSteps());
                }
                else
                {
                    MessageBox.Show("Вы выиграли!\nВсего ходов: " + botPlayer.GetSteps() + "\nКоличество ходов пользователя: " + botPlayer.GetWhiteSteps() + "\nКоличество ходов противника: " + botPlayer.GetBlackSteps());
                }
            }
            /*else
            {
                game.SetGameIsOver(true);
                PaintWinnerPanels(game.GetSuccessSteps());
                if (game.GetCurrentPlayer() == 'W')//так как уже поменяли в nextturn при ходе
                {
                    MessageBox.Show("Черные выиграли!\nВсего ходов: " + game.GetSteps() + "\nКоличество ходов победителя: " + game.GetBlackSteps() + "\nКоличество ходов проигравшего: " + game.GetWhiteSteps());
                }
                else
                {
                    MessageBox.Show("Белые выиграли!\nВсего ходов: " + game.GetSteps() + "\nКоличество ходов победителя: " + game.GetWhiteSteps() + "\nКоличество ходов проигравшего: " + game.GetBlackSteps());
                }
            }*/
        }

        private void Experiment_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Stop();//подумать над сохранением в формклоусед
        }

        private void LoadPanels() //закраска панелей
        {
            int num = 0;
            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
            {
                for (int j = 0; j < tableLayoutPanel1.ColumnCount; j++)
                {
                    Panel cell = tableLayoutPanel1.GetControlFromPosition(j, i) as Panel;
                    if (gameWithBot)
                        cell.Click += Cell_Click_Bot; //игру с ботом
                    /*else
                        cell.Click += Cell_Click; // добавляем обработчик события клика на ячейку*/
                    if (i == 7 && j == 7)
                    {
                        cell.BackColor = Color.Gray;
                        if (gameWithBot && botPlayer.GetCurrentPlayer() == 'W')
                        {
                            cell.BackgroundImageLayout = ImageLayout.Center;
                            botPlayer.SetBoardValue(i, j, 'B');
                            cell.BackgroundImage = black;
                            botPlayer.SetBlackSteps(botPlayer.GetBlackSteps() + 1);
                            botPlayer.SetSteps(botPlayer.GetSteps() + 1);
                        }
                    }
                    else
                    {
                        cell.BackColor = Color.Transparent;
                    }
                    cell.Dock = DockStyle.Fill;
                    cell.Name = "Panel" + num.ToString();//для номера панели
                    cell.Tag = i * 100 + j;
                    num++;
                }
            }
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.CellBounds, Color.Black, 1, ButtonBorderStyle.Solid, Color.Black, 1, ButtonBorderStyle.Solid, Color.Black, 1, ButtonBorderStyle.Solid, Color.Black, 1, ButtonBorderStyle.Solid);
        }

        private Timer delayTimer;
        private void UIFork3x3()                //модуляция вилки 3 на 3
        {
            //черные
            botPlayer.SetBoardValue(2, 3, 'B');
            Panel cell = tableLayoutPanel1.GetControlFromPosition(3, 2) as Panel;
            cell.BackgroundImageLayout = ImageLayout.Center;
            cell.BackgroundImage = black;
            botPlayer.SetBoardValue(4, 2, 'B');
            cell = tableLayoutPanel1.GetControlFromPosition(2, 4) as Panel; 
            cell.BackgroundImageLayout = ImageLayout.Center;
            cell.BackgroundImage = black;
            botPlayer.SetBoardValue(3, 3, 'B');
            cell = tableLayoutPanel1.GetControlFromPosition(3, 3) as Panel;
            cell.BackgroundImageLayout = ImageLayout.Center;
            cell.BackgroundImage = black;
            botPlayer.SetBoardValue(4, 1, 'B');
            cell = tableLayoutPanel1.GetControlFromPosition(1, 4) as Panel;
            cell.BackgroundImageLayout = ImageLayout.Center;
            cell.BackgroundImage = black;
            //белые
            botPlayer.SetBoardValue(3, 0, 'W');
            cell = tableLayoutPanel1.GetControlFromPosition(0, 3) as Panel;
            cell.BackgroundImageLayout = ImageLayout.Center;
            cell.BackgroundImage = white;
            botPlayer.SetBoardValue(1, 2, 'W');
            cell = tableLayoutPanel1.GetControlFromPosition(2, 1) as Panel;
            cell.BackgroundImageLayout = ImageLayout.Center;
            cell.BackgroundImage = white;
            botPlayer.SetBoardValue(2, 2, 'W');
            cell = tableLayoutPanel1.GetControlFromPosition(2, 2) as Panel;
            cell.BackgroundImageLayout = ImageLayout.Center;
            cell.BackgroundImage = white;
            botPlayer.SetBoardValue(3, 2, 'W');
            cell = tableLayoutPanel1.GetControlFromPosition(2, 3) as Panel;
            cell.BackgroundImageLayout = ImageLayout.Center;
            cell.BackgroundImage = white;

        }

        private void modulationBotStep()
        {
            botPlayer.SetCurrentPlayer('W');
            List<(int, int)> botMove = botPlayer.DoStep();
            int botI = botMove[0].Item1;
            int botJ = botMove[0].Item2;
            if (botPlayer.rightCoordination(botI, botJ))
            {
                Panel botCell = tableLayoutPanel1.GetControlFromPosition(botJ, botI) as Panel;
                if (botPlayer.GetBoardValue(botI, botJ) != 'E')
                {
                    DialogResult resultdialog = MessageBox.Show("Клетка, в которую противник-компьютер хочет поставить свой камень, уже занята!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (resultdialog == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                if (botCell != null && botCell.BackgroundImage == null)
                {
                    botCell.BackgroundImageLayout = ImageLayout.Center;
                    botPlayer.NextTurn(botI, botJ, botPlayer.GetBotPlayerSide());
                    UpdateGameUI(botCell, botI, botJ);
                }
            }
        }

     

        private void modulationFork3x3()
        {
            BHelp.Visible = false;
            DialogResult dialogResult = MessageBox.Show("Тест Вилка 3х3\tБот новичок\nПродолжить?", "Режим модуляции", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (dialogResult == DialogResult.Yes)
            {
                UIFork3x3();
                botPlayer.SetLevel('S');
                botPlayer.SetBotPlayerSide('B');
                modulationBotStep();

                DialogResult dialogResult2 = MessageBox.Show("Тест Вилка 3х3\tОпытный бот\nПродолжить?", "Режим модуляции", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (dialogResult2 == DialogResult.Yes)
                {
                    botPlayer.SetClearBoard();//сброс
                    botPlayer.SetSteps(botPlayer.GetSteps() - 1); //сбрасываем количество шагов для грамотного отображения UI
                    UIFork3x3();
                    botPlayer.SetLevel('M');
                    botPlayer.SetBotPlayerSide('B');
                    modulationBotStep();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
            DialogResult dialogResult3 = MessageBox.Show("Режим модуляции завершен. Желаете закрыть форму?", "Режим модуляции", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (dialogResult3 == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void BBotStepExp_Click(object sender, EventArgs e)
        {
            modulationFork3x3();
        }
    }
}
