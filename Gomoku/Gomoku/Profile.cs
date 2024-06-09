using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku
{
    class Profile
    {
        private string Name;

        private int Rapid;
        private int CountMatches;
        private int WinEasyMode;
        private int WinMediumMode;
        private int LoseEasyMode;
        private int LoseMediumMode;
        private int Paritet;

        public Profile(string Name) //создать нового игрока
        {
            try
            {
                this.Name = Name;
                this.Rapid = 600;
                this.WinEasyMode = 0;
                this.WinMediumMode = 0;
                this.LoseEasyMode = 0;
                this.LoseMediumMode = 0;
                this.Paritet = 0;
                this.CountMatches = 0;

                string fileName = $"{Name}_matches.txt"; // Предполагается, что файл называется "<имя игрока>_profile.txt"

                if (File.Exists(fileName))
                {
                    string[] lines = File.ReadAllLines(fileName);
                    if (lines.Length >= 8)
                    {
                        for (int i = 1; i <= 7; i++) // Цикл для строк со второй по восьмую
                        {
                            if (int.TryParse(lines[i], out int value))
                            {
                                switch (i)
                                {
                                    case 1:
                                        this.Rapid = value; // Вторая строка в файле
                                        break;
                                    case 2:
                                        this.WinEasyMode = value; // Третья строка
                                        break;
                                    case 3:
                                        this.WinMediumMode = value; // Четвертая строка
                                        break;
                                    case 4:
                                        this.LoseEasyMode = value; // Пятая строка
                                        break;
                                    case 5:
                                        this.LoseMediumMode = value; // Шестая строка
                                        break;
                                    case 6:
                                        this.Paritet = value; // Седьмая строка
                                        break;
                                    case 7:
                                        this.CountMatches = value;
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Файл не найден!");
            }
        }

        public string GetName()
        {
            return this.Name;
        }

        public int GetRapid()
        {
            return this.Rapid;
        }

        public int GetWinEasyMode()
        {
            return this.WinEasyMode;
        }

        public int GetWinMediumMode()
        {
            return this.WinMediumMode;
        }

        public int GetLoseEasyMode()
        {
            return this.LoseEasyMode;
        }

        public int GetLoseMediumMode()
        {
            return this.LoseMediumMode;
        }

        public int GetParitet()
        {
            return this.Paritet;
        }

        public int GetCountMatches()
        {
            return this.CountMatches;
        }

        public Profile() //создает рандомный профиль
        {
            Random Rand = new Random();
            int r = Rand.Next(100, 1000);
            Name = "Player" + r.ToString();
            this.CountMatches = 0;
            this.Rapid = 600;
            this.WinEasyMode = 0;
            this.WinMediumMode = 0;
            this.LoseEasyMode = 0;
            this.LoseMediumMode = 0;
            this.Paritet = 0;
        }

        private int ChangingRapid(char typeEnemy, int result) //смена рейтинга
        {
            this.CountMatches++;
            int PresRapid = this.Rapid; //присвоение рапида в настоящее время
            if (result == 0) //ничья
            {
                this.Paritet++;
            }
            else if (typeEnemy == 'S')
            { //легкий уровень
                if (result == 10)
                {
                    PresRapid += 3;
                    this.WinEasyMode++;
                }
                else
                {
                    PresRapid -= 2;
                    this.LoseEasyMode++;
                }
            }
            else if (typeEnemy == 'M')
            { //средний уровень
                if (result == 10)
                {
                    PresRapid += 5;
                    this.WinMediumMode++;
                }
                else
                {
                    PresRapid -= 4;
                    this.LoseMediumMode++;
                }
            }

            int updatedRapid = PresRapid;
            int updatedWinEasy = this.WinEasyMode;
            int updatedWinMedium = this.WinMediumMode;
            int updatedLoseEasy = this.LoseEasyMode;
            int updatedLoseMedium = this.LoseMediumMode;
            int updatedDraw = this.Paritet;
            int updatedTotalMatches = this.CountMatches;

            string filename = Name + "_matches.txt";
            string[] lines = File.ReadAllLines(filename);

            // Обновление данных
            lines[1] = updatedRapid.ToString();
            lines[2] = updatedWinEasy.ToString();
            lines[3] = updatedWinMedium.ToString();
            lines[4] = updatedLoseEasy.ToString();
            lines[5] = updatedLoseMedium.ToString();
            lines[6] = updatedDraw.ToString();
            lines[7] = updatedTotalMatches.ToString();

            // Запись обновленных данных обратно в файл
            File.WriteAllLines(filename, lines);

            return PresRapid;
        }

        public void EditGamerInfo(string newName)
        {
            string oldFileName = $"{this.Name}_matches.txt";
            this.Name = newName;
            string newFileName = $"{this.Name}_matches.txt"; //Формируем новое имя файла на основе нового имени профиля
            try
            {
                if (File.Exists(oldFileName))
                {
                    File.Move(oldFileName, newFileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при переименовании файла: " + ex.Message);
            }
        }

        public void SaveToFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (StreamWriter writer = new StreamWriter(fileName, append: true))
                {
                    writer.WriteLine(this.Name);
                    writer.WriteLine(this.Rapid);
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.WriteLine(this.Name);
                    writer.WriteLine(this.Rapid);
                }
            }
        }

        public void AddMatchToProfileFile(string result, string opp, int steps, string time)
        {
            if (opp != "Друг") {
                if (result == "Вы выиграли Опытного Бота")
                    this.Rapid = ChangingRapid('M', 10);
                else if (result == "Вы выиграли Бота Новичка")
                    this.Rapid = ChangingRapid('S', 10);
                else if (result == "Выиграл Бот Новичок")
                    this.Rapid = ChangingRapid('S', -10);
                else if (result == "Выиграл Опытный Бот")
                    this.Rapid =  ChangingRapid('M', -10);
                else if ((result == "Ничья в матче с Ботом новичком")||(result == "Ничья в матче с опытным Ботом"))
                    this.Rapid = ChangingRapid('f', 0);
            }
            string filePath = $"{this.Name}_matches.txt";
            if (File.Exists(filePath))
            {
                using (StreamWriter writer = new StreamWriter(filePath, append: true))
                {
                    writer.WriteLine($"{result};{opp};{steps};{time}");
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(this.Name);
                    writer.WriteLine(this.Rapid);
                    writer.WriteLine($"{result};{opp};{steps};{time}");
                }
            }
        }
    }
}
