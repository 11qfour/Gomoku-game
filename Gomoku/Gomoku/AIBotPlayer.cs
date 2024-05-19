using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class AIBotPlayer : Game//наследуем от Game все методы
    {
        private char GameLevel; //уровень игры компьютера
        private int TimeLimit=int.MaxValue; //ограничение по времени
        private bool IsTimeLimit; //есть ограничение по времени или нет
        private char BotPlayer; //за какую сторону играет Бот

        private int stepI;
        private int stepJ;

        public AIBotPlayer(char level, int limit, bool isTimeLimit, char value)
        {
            this.GameLevel = level;
            this.IsTimeLimit = isTimeLimit;
            this.BotPlayer = value;
            if (isTimeLimit)
                this.TimeLimit = limit;
        }

        public void RandomSelection()
        {
            List<(int, int)> tempSeqOfMoves = GetSequenceOfMoves();
            if (tempSeqOfMoves.Count > 0)
            {
                Random rand = new Random();
                var lastMove = tempSeqOfMoves[tempSeqOfMoves.Count - 1];
                int i = lastMove.Item1; // Последний x
                int j = lastMove.Item2; // Последний y
                int[,] tempMoore = GetMooreNeighborhood(i, j);
                int RandNum = rand.Next(1, tempMoore.Length);
                stepI = tempMoore[RandNum,0];
                stepJ = tempMoore[RandNum, 1];
            }
        }

        private int [,] GetMooreNeighborhood(int i, int j)
        {
            int[,] Moore = new int[2, 8];
            Moore[0, 0] = i - 1; Moore[0, 1] = j + 1;
            Moore[1, 0] = i; Moore[1, 1] = j + 1;
            Moore[2, 0] = i + 1; Moore[2, 1] = j + 1;
            Moore[3, 0] = i - 1; Moore[3, 1] = j;
            Moore[4, 0] = i + 1; Moore[4, 1] = j;
            Moore[5, 0] = i - 1; Moore[5, 1] = j - 1;
            Moore[6, 0] = i ; Moore[6,1] = j - 1;
            Moore[7, 0] = i + 1; Moore[7, 1] = j - 1;
            return Moore;
        }

        public void AlphaBetaPruning()
        {

        }

        public void MonteCarloTreeSearch()
        {

        }
    }
}
