﻿using System;
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

        private void startGame(char level, int time, bool hasTimeLimit, char botPlayer, string botName)
        {
            AIBotPlayer aIBot = new AIBotPlayer(level, time, hasTimeLimit, botPlayer);
            GameWithPC gamewithpc = new GameWithPC();
            gamewithpc.SetOppName(botName);
            gamewithpc.Show();
        }

        private void BStartDS_Click(object sender, EventArgs e)
        {
            try
            {
                if (ChLBDS.CheckedIndices.Count == 1) // если выбран только один режим игры
                {
                    char BotPlayer = 'E'; // по умолчанию неприсвоено

                    if (RBBlackDS.Checked)
                    {
                        BotPlayer = 'B'; // бот играет черных - ходит первым
                    }
                    else if (RBWhiteDS.Checked)
                    {
                        BotPlayer = 'W'; // бот играет белыми - ходит вторым
                    }
                    else
                    {
                        MessageBox.Show("Не выбрана сторона!");
                        return;
                    }

                    char level;
                    int time = 0;
                    bool hasTimeLimit = false;

                    if (RBTimerDS.Checked)
                    {
                        time = int.Parse(TBTimerDS.Text);
                        hasTimeLimit = true;
                    }

                    if (ChLBDS.GetItemChecked(0)) // простой уровень
                    {
                        level = 'S'; // simple
                        startGame(level, time, hasTimeLimit, BotPlayer, "Бот новичок");
                    }
                    else if (ChLBDS.GetItemChecked(1)) // средний уровень
                    {
                        level = 'M'; // medium
                        startGame(level, time, hasTimeLimit, BotPlayer, "Опытный Бот");
                    }
                    else if (ChLBDS.GetItemChecked(2)) // высокий уровень
                    {
                        level = 'H'; // hard
                        startGame(level, time, hasTimeLimit, BotPlayer, "Бот Профи");
                    }
                }
                else
                {
                    MessageBox.Show("Не выбрать параметр сложности игры!");
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
    }
}
