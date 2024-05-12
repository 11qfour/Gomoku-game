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
        }
        private void BStartDS_Click(object sender, EventArgs e)
        {
            try
            {

                if (ChLBDS.CheckedIndices.Count > 0 && ChLBDS.CheckedIndices.Count < 2) //если выбран только один режим игры
                {
                    char BotPlayer = 'E'; //по умолчанию неприсвоено
                    if (RBBlackDS.Checked)
                    {
                        BotPlayer = 'B'; //бот играет черных - ходит первым
                    }
                    else if (RBWhiteDS.Checked)
                    {
                        BotPlayer = 'W'; //бот играет черных - ходит вторым
                    }
                    else
                    {
                        MessageBox.Show("Не выбрана сторона!");
                        return;
                    }
                    if (ChLBDS.GetItemChecked(0)) //простой уровень
                    {
                        if (RBNoTimeDS.Checked) //нет ограничения по времени
                        {
                            char level = 'S'; //simple
                            AIBotPlayer aIBot = new AIBotPlayer(level, 0, false, BotPlayer);
                            GameWithPC gamewithpc = new GameWithPC();
                            gamewithpc.SetOppName("Бот новичок");
                            gamewithpc.Show();

                        }
                        else if (RBTimerDS.Checked) //есть ограничение по времени
                        {
                            char level = 'S'; //simple
                            int time = int.Parse(TBTimerDS.Text);
                            AIBotPlayer aIBot = new AIBotPlayer(level, time, true, BotPlayer);
                            GameWithPC gamewithpc = new GameWithPC();
                            gamewithpc.SetOppName("Бот новичок");
                            gamewithpc.Show();
                        }
                        else
                        {
                            MessageBox.Show("Не выбран параметр ограничения!");
                            return;
                        }
                    }
                    else if (ChLBDS.GetItemChecked(1)) //средний уровень
                    {
                        if (RBNoTimeDS.Checked)
                        {
                            char level = 'M'; //medium
                            AIBotPlayer aIBot = new AIBotPlayer(level, 0, false, BotPlayer);
                            GameWithPC gamewithpc = new GameWithPC();
                            gamewithpc.SetOppName("Опытный Бот");
                            gamewithpc.Show();
                        }
                        else if (RBTimerDS.Checked)
                        {
                            char level = 'M';
                            int time = int.Parse(TBTimerDS.Text);
                            AIBotPlayer aIBot = new AIBotPlayer(level, time, true, BotPlayer);
                            GameWithPC gamewithpc = new GameWithPC();
                            gamewithpc.SetOppName("Опытный Бот");
                            gamewithpc.Show();
                        }
                        else
                        {
                            MessageBox.Show("Не выбран параметр ограничения!");
                            return;
                        }
                    }
                    else if (ChLBDS.GetItemChecked(2)) //выоский уровень
                    {

                        char level = 'H'; //hard
                        AIBotPlayer aIBot = new AIBotPlayer(level, 0, false, BotPlayer);
                        GameWithPC gamewithpc = new GameWithPC();
                        gamewithpc.SetOppName("Бот Профи");
                        gamewithpc.Show();

                    }
                    else if (RBTimerDS.Checked)
                    {
                        char level = 'H';
                        int time = int.Parse(TBTimerDS.Text);
                        AIBotPlayer aIBot = new AIBotPlayer(level, time, true, BotPlayer);
                        GameWithPC gamewithpc = new GameWithPC();
                        gamewithpc.SetOppName("Бот Профи");
                        gamewithpc.Show();
                    }
                    else
                    {
                        MessageBox.Show("Не выбран параметр ограничения!");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Не выбрать параметр сложности игры!");
                    return;
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
    }
}
