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
    public partial class Settings : Form
    {
        Profile profile;
        bool save = true; //значение переменной показывает сохранены ли данные при изменении
        public Settings()
        { 
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            toolTip1.SetToolTip(BChngeNameSett, "Изменить имя");
            toolTip1.SetToolTip(BReloadingForm, "Обновить данные");
            toolTip1.SetToolTip(BChangeGamerSett, "Статистика пользователя");
            toolTip1.SetToolTip(BExit, "Выйти");
        }
        
        private void BChngeNameSett_Click(object sender, EventArgs e) //изменить имя пользователя
        {
            TBNameSett.Enabled = true;
            BSaveSett.Visible = true;
            save = false;
            MessageBox.Show("Вы можете изменить имя!");
        }

        private void BSaveSett_Click(object sender, EventArgs e) //сохранить изменённое имя пользователя
        {
            TBNameSett.Enabled = false;
            BSaveSett.Visible = false;
            MessageBox.Show("Имя успешно изменено!");
            save = true;
            profile.EditGamerInfo(TBNameSett.Text);
            //запустить обновление имени в файле со статистикой
        }

        private void BReloadingForm_Click(object sender, EventArgs e)
        {
            string filename = profile.GetName() + "_matches.txt";
            Reloads(filename);
            MessageBox.Show("Статистика обновлена!");
        }

        private void BChangeGamerSett_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show($"Соотношение результатов матчей с ботом новичком:{profile.GetWinEasyMode()}/{profile.GetLoseEasyMode()}\n"
                + $"Соотношение результатов матчей с опытным ботом:{profile.GetWinMediumMode()}/{profile.GetLoseMediumMode()}\n" +
                $"Всего матчей:{profile.GetCountMatches()}\nНичьи:{profile.GetParitet()}","Статистика пользователя", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BExit_Click(object sender, EventArgs e)
        {
            if (save)
                this.Close();
        }

        private void Reloads(string filename)//выгрузка данных на форму из файла
        {
            if (File.Exists(filename))
            {
                TBNameSett.Text = profile.GetName();
                TBRapidSett.Text = profile.GetRapid().ToString();
                //profile.LoadUserData("Gamer");
                string[] lines = File.ReadAllLines(filename);
                if (lines.Length >= 4)
                {
                    // Последние матчи
                    string[] lastMatch = lines.Skip(lines.Length - 4).ToArray();
                    DisplayMatchResults(lastMatch);

                    // Лучшие последние матчи
                    string[] bestMatches = GetBestMatches(lines);
                    DisplayMatchResults(bestMatches);
                }
            }
            else
            {
                MessageBox.Show("Файл не найден!");
            }
        }

        private void DisplayMatchResults(string[] matchData) //посмотреть статистику последних матчей
        {
            try
            {
                if (matchData.Length == 4) //последние матчи
                {
                    string[] lastMatchData1 = matchData[0].Split(';');
                    tb1.Text = lastMatchData1[0]; //результат
                    tb2.Text = lastMatchData1[1]; //противник
                    tb3.Text = lastMatchData1[2]; //количество ходов
                    tb4.Text = lastMatchData1[3]; //время
                    string[] lastMatchData2 = matchData[1].Split(';');
                    tb5.Text = lastMatchData2[0];
                    tb6.Text = lastMatchData2[1];
                    tb7.Text = lastMatchData2[2];
                    tb8.Text = lastMatchData2[3];
                    string[] lastMatchData3 = matchData[2].Split(';');
                    tb9.Text = lastMatchData3[0];
                    tb10.Text = lastMatchData3[1];
                    tb11.Text = lastMatchData3[2];
                    tb12.Text = lastMatchData3[3];
                    string[] lastMatchData4 = matchData[3].Split(';');
                    tb13.Text = lastMatchData4[0];
                    tb14.Text = lastMatchData4[1];
                    tb15.Text = lastMatchData4[2];
                    tb16.Text = lastMatchData4[3];
                }
                else if (matchData.Length == 3) //лучшие матчи
                {
                    string[] lastMatchData1 = matchData[0].Split(';');
                    TBPanel1.Text = lastMatchData1[0]; //результат
                    TBPanel2.Text = lastMatchData1[1]; //противник
                    TBPanel3.Text = lastMatchData1[2];//количество ходов
                    TBPanel4.Text = lastMatchData1[3]; //время
                    string[] lastMatchData2 = matchData[1].Split(';');
                    TBPanel5.Text = lastMatchData2[0];
                    TBPanel6.Text = lastMatchData2[1];
                    TBPanel7.Text = lastMatchData2[2];
                    TBPanel8.Text = lastMatchData2[3];
                    string[] lastMatchData3 = matchData[2].Split(';');
                    TBPanel9.Text = lastMatchData3[0];
                    TBPanel10.Text = lastMatchData3[1];
                    TBPanel11.Text = lastMatchData3[2];
                    TBPanel12.Text = lastMatchData3[3];
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Статистика пока недоступна, сыграйте более 5 матчей", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string[] GetBestMatches(string[] lines)
        {
            try
            {
                var bestMatches = lines.Skip(8).Select(line =>
                {
                    string[] matchData = line.Split(';');
                    return new
                    {
                        Result = matchData[0],
                        Opponent = matchData[1],
                        Moves = int.Parse(matchData[2]),
                        Time = TimeSpan.Parse(matchData[3])
                    };
                })
                .OrderBy(match => match.Moves)
                .ThenBy(match => match.Time)
                .Take(3)
                .Select(match => $"{match.Result};{match.Opponent};{match.Moves};{match.Time}")
                .ToArray();

                return bestMatches;
            }
            catch(Exception ee)
            {
                MessageBox.Show("Статистика пока недоступна, сыграйте более 5 матчей","Внимание",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return new string[1];
            }
        }


        private void Settings_Load(object sender, EventArgs e) //загрузка формы настроек и профиля
        {
            profile = new Profile("Gamer");
            this.WindowState = FormWindowState.Maximized;
            string filename = profile.GetName() + "_matches.txt";
            Reloads(filename);
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
    }
}
