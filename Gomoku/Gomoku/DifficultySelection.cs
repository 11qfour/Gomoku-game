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
    public partial class DifficultySelection : Form
    {
        public DifficultySelection()
        {
            InitializeComponent();
            toolTip1.SetToolTip(TBTimerDS, "Введите ограничение в формате <мин>:<сек>");
        }

        private void startGame(char level, int time, bool hasTimeLimit, char botPlayer, string botName)
        {
            GameWithPC gamewithpc = new GameWithPC();
            gamewithpc.setIsTimeLimit(level, time, hasTimeLimit, botPlayer);
            gamewithpc.SetOppName(botName);
            gamewithpc.SetGameWithBot(true);
            gamewithpc.Show();
        }

        private int parsesTimerLimit(string timeLimit)
        {
            try
            {
                string[] parts = timeLimit.Split(':');

                int minutes = 0;
                int seconds = 0;
                int filledValues = 0;


                if (parts.Length >= 1)
                {
                    minutes = int.Parse(parts[0]);
                    filledValues++;
                }

                if (parts.Length >= 2)
                {
                    seconds = int.Parse(parts[1]);
                    filledValues++;
                }

                if (filledValues < 2)
                {
                    throw new Exception("Данные должны быть введены в формате <мин>:<сек>");
                }
                if ((minutes==0 && seconds < 15) || minutes>60)
                {
                    throw new Exception("Минимальное ограничение по времени 15 секунд\nМаксимальное ограничение по времени 60 минут");
                }
                // Рассчитываем общее количество миллисекунд
                int totalMilliseconds = (minutes * 60 + seconds) * 1000;

                return totalMilliseconds;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Данные введены неверно!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -10000;
            }
        }

        private void BStartDS_Click(object sender, EventArgs e)
        {
            try
            {
                if (ChLBDS.CheckedIndices.Count == 1) // если выбран только один режим игры
                {
                    char BotPlayer = 'E'; // по умолчанию неприсвоено

                    if (RBBlackDS.Checked) //пользователь играет черными
                    {
                        BotPlayer ='W'; // бот играет белыми - ходит вторым
                    }
                    else if (RBWhiteDS.Checked)//пользователь играет белыми
                    {
                        BotPlayer = 'B'; // бот играет за черных - ходит первым
                    }
                    else
                    {
                        MessageBox.Show("Не выбрана сторона пользователя!");
                        return;
                    }

                    char level;
                    int time = -10000;
                    bool hasTimeLimit = false;

                    if (RBTimerDS.Checked) //ограничение на время
                    {
                        string timers = TBTimerDS.Text;
                        time = parsesTimerLimit(timers);
                        hasTimeLimit = true;
                    }
                    if (RBNoTimeDS.Checked)
                    {
                        hasTimeLimit = false;
                        time = 0;
                    }
                    if (ChLBDS.GetItemChecked(0)) // простой уровень
                    {
                        level = 'S'; // simple
                        if (time != 10000 && time >= 15000)
                        {
                            startGame(level, time, hasTimeLimit, BotPlayer, "Бот новичок");
                        }
                        else if (time == 0 && !hasTimeLimit)
                        {
                            startGame(level, time, hasTimeLimit, BotPlayer, "Бот новичок");
                        }
                    }
                    else if (ChLBDS.GetItemChecked(1)) // средний уровень
                    {
                        level = 'M'; // medium
                        if (time != 10000 && time >= 15000)
                        {
                            startGame(level, time, hasTimeLimit, BotPlayer, "Опытный Бот");
                        }
                        else if (time == 0 && !hasTimeLimit)
                        {
                            startGame(level, time, hasTimeLimit, BotPlayer, "Опытный Бот");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Не выбран параметр сложности игры!");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < ChLBDS.Items.Count; i++)
                    if (i != ChLBDS.SelectedIndex)
                        ChLBDS.SetItemChecked(i, false); // Снять выбор со всех элементов, кроме последнего выбранного
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void RBTimerDS_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bool flag1 = TBTimerDS.Visible; //показатели видимости обоих компонентов равны, потому используем один флаг для двоих
                flag1 = !flag1;
                TBTimerDS.Visible = flag1;
                L3DS.Visible = flag1;
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void DifficultySelection_Load(object sender, EventArgs e)
        {
             
        }

        private void RBNoTimeDS_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
