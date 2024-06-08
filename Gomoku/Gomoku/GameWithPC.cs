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
        Game game = new Game();

        bool gameWithBot = false;
        GameWithBot botPlayer;

        private int dataTimeLimit = int.MaxValue; //ограничение по времени
        private bool IsTimeLimit; //есть ограничение по времени или нет
       /* private readonly IFileServices _fileService = new FileServices();
        private readonly ILoggerService<GameWithBot> _loggerService = new LoggerService<GameWithBot>(_fileService);*/
        public void SetGameWithBot(bool flag)
        {
            this.gameWithBot = flag;
        }

     

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

            //_loggerService = new LoggerService<Game>(_fileService);
        }

        public void setIsTimeLimit(char level, int time, bool hasTimeLimit, char botPlayerSide) //установление временных ограничений
        {
            this.IsTimeLimit = hasTimeLimit;
            if (IsTimeLimit)
                this.dataTimeLimit = time;
            this.botPlayer = new GameWithBot(level, botPlayerSide);
            if (botPlayerSide=='W') //установиваем противоположное значение стороны, за которую играет пользователь
                botPlayer.SetCurrentPlayer('B');
            else
                botPlayer.SetCurrentPlayer('W');
        }

        private void SetTimeLimit(bool flag) //контроль за временными ограничениями
        {
            //описание таймеров
        }

        public void SetOppName(string s) //вывод имени противника
        {
            LOpp.Text = s;
        }

        private void Cell_Click(object sender, EventArgs e) //нажатие на ячейку игрового поля при игре 1 на 1
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
                            game.AddToFile("tie",'f',game.GetCurrentPlayer());
                            game.SetGameIsOver(true);
                            DialogResult dr = MessageBox.Show("Это была достойная борьба!","Ничья!", MessageBoxButtons.OK,MessageBoxIcon.Information);
                            if (dr == DialogResult.OK)
                            {
                                this.Close();
                            }
                            return;
                        }
                        else if (result == 10)
                        {
                            EndGame(game.GetCurrentPlayer());
                            return;
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void PaintWinnerPanels(List<int[]> array) //закраска выигрышнх клеток
        {
            try
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
                        Panel cell = LayGameFieldPC.GetControlFromPosition(j, i) as Panel;
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
                        Panel cell = LayGameFieldPC.GetControlFromPosition(j, i) as Panel;
                        cell.BackColor = Color.Peru;
                        Panel prevCell = LayGameFieldPC.GetControlFromPosition(prevJ, prevI) as Panel;
                        if (prevI == 7 && prevJ == 7)
                            prevCell.BackColor = Color.Gray;
                        else
                            prevCell.BackColor = Color.Transparent;
                    }
                }
                else
                {
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
                        if (prevI == 7 && prevJ == 7)
                            prevCell.BackColor = Color.Gray;
                        else
                            prevCell.BackColor = Color.Transparent;
                    }
                }
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
               // _loggerService.Log(Microsoft.Extensions.Logging.LogLevel.Information, "Hello");
                if (!botPlayer.GetGameIsOver())
                {
                    Panel cell = sender as Panel;
                    if (cell != null && cell.BackgroundImage == null)
                    {
                        int i = Math.Abs(Convert.ToInt32(cell.Tag) / 100);
                        int j = Math.Abs(Convert.ToInt32(cell.Tag) % 100);
                        cell.BackgroundImageLayout = ImageLayout.Center;
                        botPlayer.NextTurn(i, j, botPlayer.GetCurrentPlayer());
                        UpdateGameUI(cell, i, j);
                        int result = botPlayer.CheckWinner(i, j);
                        if (result == 0)
                        {
                            botPlayer.AddToFile("tie", botPlayer.GetLevel(), botPlayer.GetBotPlayerSide());
                            botPlayer.SetGameIsOver(true);
                            DialogResult dr = MessageBox.Show("Это была достойная борьба!", "Ничья!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (dr == DialogResult.OK)
                            {
                                this.Close();
                            }
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
                            Panel botCell = LayGameFieldPC.GetControlFromPosition(botJ, botI) as Panel;
                            if (botCell != null && botCell.BackgroundImage == null)
                            {
                                botCell.BackgroundImageLayout = ImageLayout.Center;
                                botPlayer.NextTurn(botI, botJ, botPlayer.GetBotPlayerSide());
                                UpdateGameUI(botCell, botI, botJ);
                                result = botPlayer.CheckWinner(botI, botJ);
                                if (result == 0)
                                {
                                    timer.Stop();
                                    botPlayer.AddToFile("tie",botPlayer.GetLevel(), botPlayer.GetBotPlayerSide());
                                    botPlayer.SetGameIsOver(true);
                                    DialogResult dr = MessageBox.Show("Это была достойная борьба!", "Ничья!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    if (dr == DialogResult.OK)
                                    {
                                        this.Close();
                                    }
                                    return;
                                }
                                else if (result == 10)
                                {
                                    EndGame(botPlayer.GetBotPlayerSide());
                                    return;
                                }
                            }
                        }
                    }
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
                if (botPlayer.GetSteps() == 0)
                {
                    if (cell.BackColor == Color.Gray)
                    {
                        this.WindowState = FormWindowState.Maximized;
                        cell.BackgroundImage = black;
                        botPlayer.SetSteps(botPlayer.GetSteps() + 1);
                        botPlayer.SetBlackSteps(botPlayer.GetBlackSteps() + 1);
                        LWhoStep.Text = "Белых";
                    }
                }
                else
                {
                    if (cell.BackColor == Color.Transparent || cell.BackColor == Color.Chocolate)
                    {
                        if (botPlayer.GetSteps() % 2 == 0) // устанавливаем черный цвет фишки
                        {
                            cell.BackgroundImage = black;
                            botPlayer.SetSteps(botPlayer.GetSteps() + 1);
                            botPlayer.SetBlackSteps(botPlayer.GetBlackSteps() + 1);
                            LWhoStep.Text = "Белых";
                        }
                        else // устанавливаем белый цвет фишки
                        {
                            cell.BackgroundImage = white;
                            botPlayer.SetSteps(botPlayer.GetSteps() + 1);
                            botPlayer.SetWhiteSteps(botPlayer.GetWhiteSteps() + 1);
                            LWhoStep.Text = "Черных";
                        }
                    }
                }
            }
            else
            {
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
                game.ChangeCurrentPlayer();
            }
            PaintChoosePanel();
        }

        private void EndGame(char player)
        {
            DialogResult dialogResult = DialogResult.OK;
            if (gameWithBot)
            {
                botPlayer.SetGameIsOver(true);
                PaintWinnerPanels(botPlayer.GetSuccessSteps());
                if (botPlayer.GetBotPlayerSide() == player) //так как уже поменяли в nextturn при ходе
                {
                    botPlayer.AddToFile("human", botPlayer.GetLevel(), botPlayer.GetBotPlayerSide());
                    dialogResult = MessageBox.Show("Всего ходов: " + botPlayer.GetSteps() + "\nКоличество ходов победителя: " + botPlayer.GetBlackSteps() + "\nКоличество ходов проигравшего: " + botPlayer.GetWhiteSteps(), "ВЫ ПРОИГРАЛИ!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
                else
                {
                    botPlayer.AddToFile("bot", botPlayer.GetLevel(), botPlayer.GetBotPlayerSide());
                    dialogResult = MessageBox.Show("Всего ходов: " + botPlayer.GetSteps() + "\nКоличество ходов победителя: " + botPlayer.GetWhiteSteps() + "\nКоличество ходов проигравшего: " + botPlayer.GetBlackSteps(), "ВЫ ВЫИГРАЛИ!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                game.SetGameIsOver(true);
                PaintWinnerPanels(game.GetSuccessSteps());
                if (game.GetCurrentPlayer() == 'W')//так как уже поменяли в nextturn при ходе
                {
                    game.AddToFile("черные",'f', game.GetCurrentPlayer());
                    dialogResult = MessageBox.Show("Всего ходов: " + game.GetSteps() + "\nКоличество ходов победителя: " + game.GetBlackSteps() + "\nКоличество ходов проигравшего: " + game.GetWhiteSteps(), "Черные выиграли!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                else
                {
                    game.AddToFile("белые", 'f', game.GetCurrentPlayer());
                    dialogResult = MessageBox.Show("Всего ходов: " + game.GetSteps() + "\nКоличество ходов победителя: " + game.GetWhiteSteps() + "\nКоличество ходов проигравшего: " + game.GetBlackSteps(), "Белые выиграли!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            if (dialogResult == DialogResult.OK)
            {
                this.Close();
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
                    if (gameWithBot)
                        cell.Click += Cell_Click_Bot; //игру с ботом
                    else
                        cell.Click += Cell_Click; // добавляем обработчик события клика на ячейку
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

        private void GameWithPC_Load(object sender, EventArgs e)
        {
            LayGameFieldPC.CellPaint += LayGameFieldPC_CellPaint;
            LoadPanels();
        }

        private void LayGameFieldPC_CellPaint(object sender, TableLayoutCellPaintEventArgs e)//перерисовывание ячейки
        {
            ControlPaint.DrawBorder(e.Graphics, e.CellBounds, Color.Black, 1, ButtonBorderStyle.Solid, Color.Black, 1, ButtonBorderStyle.Solid, Color.Black, 1, ButtonBorderStyle.Solid, Color.Black, 1, ButtonBorderStyle.Solid);
        }

        private void GameWithPC_FormClosed(object sender, FormClosedEventArgs e)//действия уже после закрытия формы
        {
            timer.Stop();
            timer.Dispose();
        }

        private void BExit_Click(object sender, EventArgs e)
        {
            DialogResult resultdialog = MessageBox.Show("Вы уверены что хотите закончить игровую сессию?", "Выйти без сохранения", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultdialog == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private List<(int, int)> promptStep;
        private void BHelp_Click(object sender, EventArgs e)//подсказка
        {
            if (gameWithBot)
            {
                promptStep = botPlayer.bestMove(botPlayer.GetPlayers(0));
                botPlayer.bestMove(botPlayer.GetPlayers(0));
                int promptI = promptStep[0].Item1;
                int promptJ = promptStep[0].Item2;
                Panel promptCell = LayGameFieldPC.GetControlFromPosition(promptJ, promptI) as Panel;
                promptCell.BackColor = Color.Chocolate;
            }
            else
            {
                DialogResult dR = MessageBox.Show("Вы можете воспользоваться подсказкой только при игре с компьютером!", "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                timer.Stop();
                if (dR == DialogResult.OK)
                {
                    timer.Start();
                }
            }
        }

        private void BReturnStep_Click(object sender, EventArgs e)//возвращение хода
        {
            try
            {
                int i = 0, j = 0;
                if (gameWithBot)
                {
                    int repeat = 2;
                    while (repeat != 0) //2 отмены хода: посл. ход бота и игрока
                    {
                        botPlayer.CancelTurn(ref i, ref j);
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
                            if (botPlayer.GetCurrentPlayer() == 'W')
                            {
                                LWhoStep.Text = "Белых";
                            }
                            else
                            {
                                LWhoStep.Text = "Черных";
                            }
                        }
                        repeat--;
                    }
                }
                else
                {
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
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            all_sec++;
            int minuts = (all_sec / 60);
            int seconds = (all_sec % 60);
            if (minuts == 0)
            {
                LTimeMin.Visible = false;
            }
            else
            {
                LTimeMin.Visible = true;
            }
            LTimeMin.Text = minuts.ToString() + " Мин.";
            LTimeSec.Text = seconds.ToString() + " Сек.";
            dataTimeLimit -= 1000; // Уменьшаем время ограничения на 1 секунду
            if (dataTimeLimit <= 0)
            {
                timer.Stop();
                DialogResult dR = MessageBox.Show("Время вышло! ⏰","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                if (dR == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                //MessageBox.Show($"Оставшееся время: {dataTimeLimit / 1000} сек.");
            }
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
