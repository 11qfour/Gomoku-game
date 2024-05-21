using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class BotPlayer : Game//наследуем от Game все методы
    {
        private char GameLevel; //уровень игры компьютера
        private char botPlayerSide; //за какую сторону играет Бот

        private int stepI;
        private int stepJ;

        public BotPlayer(char level, char value)
        {
            this.GameLevel = level;
            this.botPlayerSide = value;
        }

        public char GetBotPlayerSide()
        {
            return this.botPlayerSide;
        }
        public char GetGameLevel()
        {
            return this.GameLevel;
        }
        public List <(int, int)> DoStep()
        {
            if (GameLevel == 'S')
            {
                return RandomSelection();
            }
            else if (GameLevel == 'M')
            {
               return AlphaBetaPruning();
            }
            else
            {
               return AlphaBetaPruning();
            }
        }

        public List<(int, int)> RandomSelection()
        {
            List<(int, int)> tempSeqOfMoves = GetSequenceOfMoves();
            Random rand = new Random();
            int cntAvailableSteps = 8; //доступные клетки в окрестности Мура
            do {
                if (tempSeqOfMoves.Count > 0)
                {
                    var lastMove = tempSeqOfMoves[tempSeqOfMoves.Count - 1];
                    int i = lastMove.Item1; // Последний x
                    int j = lastMove.Item2; // Последний y
                    int[,] tempMoore = GetMooreNeighborhood(i, j);
                    int RandNum = rand.Next(0, 7);
                    stepI = tempMoore[RandNum, 0];
                    stepJ = tempMoore[RandNum, 1];
                    cntAvailableSteps--;
                }
            } while (!checkEmptyPanel(stepI,stepJ) && cntAvailableSteps!=0);
            while (!checkEmptyPanel(stepI, stepJ))
            {
                stepI = rand.Next(0, 14);
                stepJ = rand.Next(0, 14);
            }
            List < (int, int) > BotStep = new List<(int, int)> { (stepI, stepJ) };
            return BotStep;
        }

        private bool checkEmptyPanel(int i, int j) //проверка занята ли клетка игрового поля
        {
            if (i>=0 && j>=0 && i<=14 && j <= 14) {
                if (GetBoardValue(i, j) == 'E')
                    return true;
            }
            return false;
        }

        private int [,] GetMooreNeighborhood(int i, int j) //окрестность мура для клетки i,j
        {
            int[,] Moore = new int[8, 2];
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

        public List<(int, int)> AlphaBetaPruning()
        {
            List<(int, int)> BotStep = new List<(int, int)> { (stepI, stepJ) };
            return BotStep;
        }

        public void MonteCarloTreeSearch()
        {

        }
    }
}
