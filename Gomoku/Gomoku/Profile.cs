using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Profile
    {
        private string Name;

        private int Rapid;
        private int Count_Matches;
        private int WinEasyMode;
        private int WinMediumMode;
        private int WinHardMode;
        private int LoseEasyMode;
        private int LoseMediumMode;
        private int LoseHardMode;
        private int Paritet;
        public StreamWriter streamWriter;

        public Profile(string Name) //создать нового игрока
        {
            this.Name = Name;
            this.Count_Matches = 0;
            this.Rapid = 600;
            this.WinEasyMode = 0;
            this.WinMediumMode = 0;
            this.WinHardMode = 0;
            this.LoseEasyMode = 0;
            this.LoseMediumMode = 0;
            this.LoseHardMode = 0;
            this.Paritet = 0;
        }

        public Profile() //создает рандомный профиль
        {
            Random Rand = new Random();
            int r = Rand.Next(100, 1000);
            Name = "Player" + r.ToString();
            this.Count_Matches = 0;
            this.Rapid = 600;
            this.WinEasyMode = 0;
            this.WinMediumMode = 0;
            this.WinHardMode = 0;
            this.LoseEasyMode = 0;
            this.LoseMediumMode = 0;
            this.LoseHardMode = 0;
            this.Paritet = 0;
        }

        public int ChangingRapid(char typeEnemy, int result)
        {
            int PresRapid = this.Rapid; //присвоение рапида в настоящее время
            if (result == 0) //ничья
            {
                this.Paritet++;
            }
            else if (typeEnemy == 'e')
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
            else if (typeEnemy == 'm')
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
            else if (typeEnemy == 'h')
            { //сложный уровень
                if (result == 10) //если выиграл
                {
                    PresRapid += 7;
                    this.WinHardMode++;
                }
                else
                {
                    PresRapid -= 6;
                    this.LoseHardMode++;
                }
            }
            this.Count_Matches++;
            return PresRapid;
        }

        public void AddGamerInfo(string Name)
        {

        }

        public void EditGamerInfo(string Name)
        {

        }

        public void DeleteGamer(string Name) //удалить все сведения об этом игроке
        {

        }

        public void LoadDatas()
        {
            //запомнить текущую дату, время, колиечство ходов своих
        }
    }
}
