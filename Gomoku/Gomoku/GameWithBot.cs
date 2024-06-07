using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class GameWithBot : Game//наследуем от Game все методы
    {
        private char GameLevel; //уровень игры компьютера
        private int stepI;
        private int stepJ;
        private char botPlayerSide;
        Players[] players = new Players[2];
        string[] patterns = new string[24]; //всевозможные ситуации на игровом поле

        public char GetLevel()
        {
            return GameLevel;
        }

        public char GetBotPlayerSide()
        {
            return botPlayerSide;
        }

        public GameWithBot(char level, char value)
        {
            this.GameLevel = level;
            char botSide, humanSide;
            if (value == 'B')
            {
                botPlayerSide=botSide = 'B';
                humanSide = 'W';
            }
            else
            {
                botPlayerSide=botSide = 'W';
                humanSide = 'B';
            }
            players[0] = new Players(Player.BotPlayer, botSide, 1);
            players[1] = new Players(Player.Human, humanSide, 2);
        }

        public bool rightCoordination(int i, int j)
        {
            if (i < 0 ||j <0 || i >= GetBoard().GetLength(0) || j >= GetBoard().GetLength(1))
                return false;
            return true;
        }

        public char GetGameLevel()
        {
            return this.GameLevel;
        }
        public List<(int, int)> DoStep()
        {
            if (GameLevel == 'S')
            {
                return RandomSelection();
            }
            else
            {
                return bestMove(players[0]);
            }
        }

        public List<(int, int)> RandomSelection()
        {
            List<(int, int)> tempSeqOfMoves = GetSequenceOfMoves();
            Random rand = new Random();
            int cntAvailableSteps = 8; //доступные клетки в окрестности Мура
            do
            {
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
            } while (!checkEmptyPanel(stepI, stepJ) && cntAvailableSteps != 0);
            while (!checkEmptyPanel(stepI, stepJ))
            {
                stepI = rand.Next(0, GetBoard().Length-1);
                stepJ = rand.Next(0, GetBoard().Length-1);
            }
            List<(int, int)> BotStep = new List<(int, int)> { (stepI, stepJ) };
            return BotStep;
        }
        private bool checkEmptyPanel(int i, int j) //проверка занята ли клетка игрового поля
        {
            if (i >= 0 && j >= 0 && i <= GetBoard().GetLength(0) && j <= GetBoard().GetLength(1))
            {
                if (GetBoardValue(i, j) == 'E')
                    return true;
            }
            return false;
        }
        private int[,] GetMooreNeighborhood(int i, int j) //окрестность мура для клетки i,j
        {
            int[,] Moore = new int[8, 2];
            Moore[0, 0] = i - 1; Moore[0, 1] = j + 1;
            Moore[1, 0] = i; Moore[1, 1] = j + 1;
            Moore[2, 0] = i + 1; Moore[2, 1] = j + 1;
            Moore[3, 0] = i - 1; Moore[3, 1] = j;
            Moore[4, 0] = i + 1; Moore[4, 1] = j;
            Moore[5, 0] = i - 1; Moore[5, 1] = j - 1;
            Moore[6, 0] = i; Moore[6, 1] = j - 1;
            Moore[7, 0] = i + 1; Moore[7, 1] = j - 1;
            return Moore;
        }



        private List<(int, int)> bestMove(Players players)
        {
            bool changing = false;
            List<(int, int)> BotStep = new List<(int, int)> { (stepI, stepJ) };
            int bestScore = int.MinValue;
            for (int i = 0; i < GetBoard().GetLength(0); i++)
            {
                for (int j = 0; j < GetBoard().GetLength(1); j++)
                {
                    if (GetBoardValue(i, j) == 'E')
                    {
                        /*SetBoardValue(i, j, players.PlayerMarker);*/
                        int moveScore = evaluation(GetOpponent(players));
                       /* SetBoardValue(i, j, 'E');*/
                        if (moveScore > bestScore)
                        {
                            bestScore = moveScore;
                            changing = true;
                            BotStep.Clear();
                            BotStep.Add((stepI, stepJ)); //добавляем координаты оптимального хода
                        }
                    }
                }
            }
            if (GetBoardValue(stepI, stepJ) != 'E')
                changing = false;
            if (!changing) //если не нашлось подходящих паттернов
            {
                while (!checkEmptyPanel(stepI, stepJ))
                {
                    Random rand = new Random();
                    stepI = rand.Next(0, GetBoard().Length - 1);
                    stepJ = rand.Next(0, GetBoard().Length - 1);
                    BotStep.Clear();
                    BotStep.Add((stepI, stepJ));
                }
            }
            return BotStep;
        }

        private void initPattens(Players currentPlayer) //инициализируем всевозможные ситуации на игровом поле
        {
            char currValue = currentPlayer.PlayerMarker;
            char oppValue = (currValue == 'B') ? 'W' : 'B';

            string openForth = "E"+new string (currValue,4)+"E";
            string closeForth1 = "E" + new string(currValue, 4) + oppValue.ToString();
            string closeForth2 = oppValue.ToString() + new string(currValue, 4) + "E";

            string openThird = "E" + new string(currValue, 3) + "E";
            string closeThird1 = "E"+new string(currValue, 3)+ oppValue.ToString();
            string closeThird2 = oppValue.ToString() + new string(currValue, 3) + "E";

            string openSecond = "E" + new string(currValue, 2) + "E";
            string closeSecond1 = "E" + new string(currValue, 2) + oppValue.ToString();
            string closeSecond2 = oppValue.ToString() + new string(currValue, 2) + "E";

            string openFirst = "E" + currValue.ToString() + "E";
            string closeFirst1 = "E" + currValue.ToString() + oppValue.ToString();
            string closeFirst2 = oppValue.ToString() + currValue.ToString() + "E";

            string openOppForth = "E" + new string(oppValue, 4) + "E";
            string closeOppForth1 = "E" + new string(oppValue, 4) + currValue.ToString();
            string closeOppForth2 = currValue.ToString() + new string(oppValue, 4) + "E";

            string openOppThird = "E" + new string(oppValue, 3) + "E";
            string closeOppThird1 = "E" + new string(oppValue, 3) + currValue.ToString();
            string closeOppThird2 = currValue.ToString() + new string(oppValue, 3) + "E";

            string openOppSecond = "E" + new string(oppValue, 2) + "E";
            string closeOppSecond1 = "E" + new string(oppValue, 2) + currValue.ToString();
            string closeOppSecond2 = currValue.ToString() + new string(oppValue, 2) + "E";

            string openOppFirst = "E" + oppValue.ToString() + "E";
            string closeOppFirst1 = "E" + oppValue.ToString() + currValue.ToString();
            string closeOppFirst2 = currValue.ToString() + oppValue.ToString() + "E";

            patterns[0] = openForth;
            patterns[1] = closeForth1;
            patterns[2] = closeForth2;
            patterns[3] = openThird;
            patterns[4] = closeThird1;
            patterns[5] = closeThird2;
            patterns[6] = openSecond;
            patterns[7] = closeSecond1;
            patterns[8] = closeSecond2;
            patterns[9] = openFirst;
            patterns[10] = closeFirst1;
            patterns[11] = closeFirst2;

            patterns[12] = openOppForth;
            patterns[13] = closeOppForth1;
            patterns[14] = closeOppForth2;
            patterns[15] = openOppThird;
            patterns[16] = closeOppThird1;
            patterns[17] = closeOppThird2;
            patterns[18] = openOppSecond;
            patterns[19] = closeOppSecond1;
            patterns[20] = closeOppSecond2;
            patterns[21] = openOppFirst;
            patterns[22] = closeOppFirst1;
            patterns[23] = closeOppFirst2;
        }
        private int positionValue(Players currentPlayer, int i, int j) //получаем лучшее эвристическое значение клетки
        {
            char player = GetBoardValue(i, j);
            initPattens(currentPlayer);
            if (CheckPatternHorizontal(i, j, patterns[0]) || CheckPatternVertical(i,j,patterns[0]) || CheckPatternAscendingDiagonal(i,j,patterns[0]) || CheckPatternDescendingDiagonal(i, j, patterns[0]))
                return 100000000;
            if (CheckPatternHorizontal(i, j, patterns[1]) || CheckPatternVertical(i, j, patterns[1]) || CheckPatternAscendingDiagonal(i, j, patterns[1]) || CheckPatternDescendingDiagonal(i, j, patterns[1]))
                return 100000000;
            if (CheckPatternHorizontal(i, j, patterns[2]) || CheckPatternVertical(i, j, patterns[2]) || CheckPatternAscendingDiagonal(i, j, patterns[2]) || CheckPatternDescendingDiagonal(i, j, patterns[2]))
                return 100000000;
            if (CheckPatternHorizontal(i, j, patterns[3]) || CheckPatternVertical(i, j, patterns[3]) || CheckPatternAscendingDiagonal(i, j, patterns[3]) || CheckPatternDescendingDiagonal(i, j, patterns[3]))
                return 99999999;
            if (CheckPatternHorizontal(i, j, patterns[4]) || CheckPatternVertical(i, j, patterns[4]) || CheckPatternAscendingDiagonal(i, j, patterns[4]) || CheckPatternDescendingDiagonal(i, j, patterns[4]))
                return 4000000;
            if (CheckPatternHorizontal(i, j, patterns[5]) || CheckPatternVertical(i, j, patterns[5]) || CheckPatternAscendingDiagonal(i, j, patterns[5]) || CheckPatternDescendingDiagonal(i, j, patterns[5]))
                return 4000000;
            if (CheckPatternHorizontal(i, j, patterns[6]) || CheckPatternVertical(i, j, patterns[6]) || CheckPatternAscendingDiagonal(i, j, patterns[6]) || CheckPatternDescendingDiagonal(i, j, patterns[6]))
                return 500;
            if (CheckPatternHorizontal(i, j, patterns[7]) || CheckPatternVertical(i, j, patterns[7]) || CheckPatternAscendingDiagonal(i, j, patterns[7]) || CheckPatternDescendingDiagonal(i, j, patterns[7]))
                return 50;
            if (CheckPatternHorizontal(i, j, patterns[8]) || CheckPatternVertical(i, j, patterns[8]) || CheckPatternAscendingDiagonal(i, j, patterns[8]) || CheckPatternDescendingDiagonal(i, j, patterns[8]))
                return 50;
            if (CheckPatternHorizontal(i, j, patterns[9]) || CheckPatternVertical(i, j, patterns[9]) || CheckPatternAscendingDiagonal(i, j, patterns[9]) || CheckPatternDescendingDiagonal(i, j, patterns[9]))
                return 25;
            if (CheckPatternHorizontal(i, j, patterns[10]) || CheckPatternVertical(i, j, patterns[10]) || CheckPatternAscendingDiagonal(i, j, patterns[10]) || CheckPatternDescendingDiagonal(i, j, patterns[10]))
                return 25;
            if (CheckPatternHorizontal(i, j, patterns[11]) || CheckPatternVertical(i, j, patterns[11]) || CheckPatternAscendingDiagonal(i, j, patterns[11]) || CheckPatternDescendingDiagonal(i, j, patterns[11]))
                return 25;

            if (CheckPatternHorizontal(i, j, patterns[12]) || CheckPatternVertical(i, j, patterns[12]) || CheckPatternAscendingDiagonal(i, j, patterns[12]) || CheckPatternDescendingDiagonal(i, j, patterns[12]))
                return -100000000;
            if (CheckPatternHorizontal(i, j, patterns[13]) || CheckPatternVertical(i, j, patterns[13]) || CheckPatternAscendingDiagonal(i, j, patterns[13]) || CheckPatternDescendingDiagonal(i, j, patterns[13]))
                return -100000000;
            if (CheckPatternHorizontal(i, j, patterns[14]) || CheckPatternVertical(i, j, patterns[14]) || CheckPatternAscendingDiagonal(i, j, patterns[14]) || CheckPatternDescendingDiagonal(i, j, patterns[14]))
                return -100000000;
            if (CheckPatternHorizontal(i, j, patterns[15]) || CheckPatternVertical(i, j, patterns[15]) || CheckPatternAscendingDiagonal(i, j, patterns[15]) || CheckPatternDescendingDiagonal(i, j, patterns[15]))
                return -99999999;
            if (CheckPatternHorizontal(i, j, patterns[16]) || CheckPatternVertical(i, j, patterns[16]) || CheckPatternAscendingDiagonal(i, j, patterns[16]) || CheckPatternDescendingDiagonal(i, j, patterns[16]))
                return -4000000;
            if (CheckPatternHorizontal(i, j, patterns[17]) || CheckPatternVertical(i, j, patterns[17]) || CheckPatternAscendingDiagonal(i, j, patterns[17]) || CheckPatternDescendingDiagonal(i, j, patterns[17]))
                return -4000000;
            if (CheckPatternHorizontal(i, j, patterns[18]) || CheckPatternVertical(i, j, patterns[18]) || CheckPatternAscendingDiagonal(i, j, patterns[18]) || CheckPatternDescendingDiagonal(i, j, patterns[18]))
                return -500;
            if (CheckPatternHorizontal(i, j, patterns[19]) || CheckPatternVertical(i, j, patterns[19]) || CheckPatternAscendingDiagonal(i, j, patterns[19]) || CheckPatternDescendingDiagonal(i, j, patterns[19]))
                return -50;
            if (CheckPatternHorizontal(i, j, patterns[20]) || CheckPatternVertical(i, j, patterns[20]) || CheckPatternAscendingDiagonal(i, j, patterns[20]) || CheckPatternDescendingDiagonal(i, j, patterns[20]))
                return -50;
            if (CheckPatternHorizontal(i, j, patterns[21]) || CheckPatternVertical(i, j, patterns[21]) || CheckPatternAscendingDiagonal(i, j, patterns[21]) || CheckPatternDescendingDiagonal(i, j, patterns[21]))
                return -25;
            if (CheckPatternHorizontal(i, j, patterns[22]) || CheckPatternVertical(i, j, patterns[22]) || CheckPatternAscendingDiagonal(i, j, patterns[22]) || CheckPatternDescendingDiagonal(i, j, patterns[22]))
                return -25;
            if (CheckPatternHorizontal(i, j, patterns[23]) || CheckPatternVertical(i, j, patterns[23]) || CheckPatternAscendingDiagonal(i, j, patterns[23]) || CheckPatternDescendingDiagonal(i, j, patterns[23]))
                return -25;
            return int.MinValue;  //шаблона не найдено
        }

        private bool CheckPatternHorizontal(int row, int col, string pattern) //проверка паттерна по горизонтали
        {
            bool flag = true; ;
            for (int i = 0; i < pattern.Length; i++)
            {
                if (col + i >= GetBoard().GetLength(0) || GetBoardValue(row, col + i) != pattern[i])
                {
                    flag=false;
                    break;
                }
            }
            if (flag)
                return flag;
            flag = true;
            for (int i = 0; i < pattern.Length; i++)
            {
                if ((col - i) < 0 || GetBoardValue(row, col - i) != pattern[i])
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        private bool CheckPatternVertical(int row, int col, string pattern) //проверка паттерна по вертикали
        {
            bool flag = true; ;
            for (int i = 0; i < pattern.Length; i++)
            {
                if (row + i >= GetBoard().GetLength(0) || GetBoardValue(row + i, col) != pattern[i])
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
                return flag;
            flag = true;
            for (int i = 0; i < pattern.Length; i++)
            {
                if ((row - i) < 0 || GetBoardValue(row-i, col) != pattern[i])
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        private bool CheckPatternAscendingDiagonal(int row, int col, string pattern) //проверка паттерна по восходящей диагонали
        {
            for (int i = 0; i < pattern.Length; i++)
            {
                if (row - i < 0 || col + i >= GetBoard().GetLength(1) || GetBoardValue(row - i, col + i) != pattern[i])
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckPatternDescendingDiagonal(int row, int col, string pattern) //проверка по главной диагонали(нисходящей)
        {
            for (int i = 0; i < pattern.Length; i++)
            {
                if (row + i >= GetBoard().GetLength(0) || col + i >= GetBoard().GetLength(1) || GetBoardValue(row + i, col + i) != pattern[i])
                {
                    return false;
                }
            }
            return true;
        }

        private int evaluation(Players currentPlayer)
        {
            int bestScore = int.MinValue;
            char[,] tempBoard = GetBoard();
            for (int i = 0; i < tempBoard.GetLength(0); i++)
            {
                for (int j = 0; j < tempBoard.GetLength(1); j++)
                {
                    int score = positionValue(currentPlayer,i, j);
                    if (score > bestScore)
                    {
                        stepI = i;
                        stepJ = j;
                        bestScore = score;
                        //break;
                    }
                }
            }
            return bestScore;
        }

        private int AplhaBetaPruning(int depth, Players currentPlayer, int alpha, int beta)
        {
            if (evaluation(currentPlayer) == int.MinValue)
            {
                if (IsEmptySquares())
                    return 0; //ничья
                int bestValue = currentPlayer.Player == Player.BotPlayer ? int.MinValue : int.MaxValue;

                for (int i = 0; i < GetBoard().GetLength(0); i++)
                {
                    for (int j = 0; j < GetBoard().GetLength(1); j++)
                    {
                        if (GetBoardValue(i, j) == 'E')
                        {
                            SetBoardValue(i, j, currentPlayer.PlayerMarker);
                            int moveValue = AplhaBetaPruning(depth + 1, GetOpponent(currentPlayer), alpha, beta);
                            SetBoardValue(i, j, 'E');

                            if (currentPlayer.Player == Player.BotPlayer)
                            {
                                bestValue = Math.Max(bestValue, moveValue);
                                alpha = Math.Max(alpha, bestValue);
                                stepI = i;
                                stepJ = j;
                                if (beta <= alpha)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                bestValue = Math.Min(bestValue, moveValue);
                                beta = Math.Min(beta, bestValue);
                                if (beta <= alpha)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }

                return bestValue;
            }
            else
                return evaluation(currentPlayer);
        }

        private Players GetOpponent(Players curentPlayer) //смена игрока для алгоритма
        {
            foreach (var player in players)
            {
                if (curentPlayer.Player != player.Player)
                {
                    return player;
                }
            }
            return null;
        }

        private bool IsWinner(Players player)
        {
            char tempplayerMarker = player.PlayerMarker; // Присваиваем маркер в зависимости от типа перечисления
            for (int row = 0; row < GetBoard().GetLength(0); row++)
            {
                for (int col = 0; col < GetBoard().GetLength(1); col++)
                {
                    if (GetBoardValue(row, col) == tempplayerMarker)
                        if (CheckWinner(row, col) != 1) //если игра не продолжается
                            return true;
                }
            }
            return false;
        }

    }
}
