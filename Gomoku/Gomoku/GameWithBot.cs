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

        public Players GetPlayers (int order)
        {
            return this.players[order];
        }

        public char GetLevel()
        {
            return this.GameLevel;
        }

        public void SetBotPlayerSide(char side)
        {
            this.botPlayerSide = side;
        }

        public void SetLevel(char level)
        {
            this.GameLevel = level ;
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

        /*public char GetGameLevel()
        {
            return this.GameLevel;
        }*/
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



        public List<(int, int)> bestMove(Players players)
        {
            List<(int, int)> BotStep = new List<(int, int)> { (stepI, stepJ) };
            
            int moveScore = evaluation(GetOpponent(players));
            if (moveScore==int.MinValue)
            {
                while (!checkEmptyPanel(stepI, stepJ))
                {
                    Random rand = new Random();
                    stepI = rand.Next(0, GetBoard().Length - 1);
                    stepJ = rand.Next(0, GetBoard().Length - 1);
                }
            }
            BotStep.Clear();
            BotStep.Add((stepI, stepJ));
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
        private int positionValue(Players currentPlayer, ref int i, ref int j) //получаем лучшее эвристическое значение клетки
        {
            char player = GetBoardValue(i, j);
            initPattens(currentPlayer);
            bool endCheck = false;
            if (CheckPatternHorizontal(ref i, ref j, patterns[0], ref endCheck) || CheckPatternVertical(ref i, ref j, patterns[0], ref endCheck) || CheckPatternAscendingDiagonal(ref i, ref j, patterns[0], ref endCheck) || CheckPatternDescendingDiagonal(ref i, ref j, patterns[0],ref endCheck))
            {
                //нашлась открытая 4ка возвращается координаты первой клетки по обходу
                return 100000000;
            }
            if (CheckPatternHorizontal(ref i, ref j, patterns[1], ref endCheck) || CheckPatternVertical(ref i, ref j, patterns[1], ref endCheck) || CheckPatternAscendingDiagonal(ref i, ref j, patterns[1], ref endCheck) || CheckPatternDescendingDiagonal(ref i, ref j, patterns[1], ref endCheck))
            {
                //нашлась закрытая 4ка возвращается координаты первой клетки по обходу
                return 100000000;
            }
            if (CheckPatternHorizontal(ref i, ref j, patterns[2], ref endCheck) || CheckPatternVertical(ref i, ref j, patterns[2], ref endCheck) || CheckPatternAscendingDiagonal(ref i, ref j, patterns[2], ref endCheck) || CheckPatternDescendingDiagonal(ref i, ref j, patterns[2], ref endCheck))
            {
                //нашлась закрытая 4ка возвращается координаты первой клетки по обходу
                return 100000000;
            }
            if (CheckPatternHorizontal(ref i, ref j, patterns[3], ref endCheck) || CheckPatternVertical(ref i, ref j, patterns[3], ref endCheck) || CheckPatternAscendingDiagonal(ref i, ref j, patterns[3], ref endCheck) || CheckPatternDescendingDiagonal(ref i, ref j, patterns[3], ref endCheck))
            {
                return 99999999;
            }
            if (CheckPatternHorizontal(ref i, ref j, patterns[4], ref endCheck) || CheckPatternVertical(ref i, ref j, patterns[4], ref endCheck) || CheckPatternAscendingDiagonal(ref i, ref j, patterns[4], ref endCheck) || CheckPatternDescendingDiagonal(ref i, ref j, patterns[4], ref endCheck))
            {
                return 4000000;
            }
            if (CheckPatternHorizontal(ref i, ref j, patterns[5], ref endCheck) || CheckPatternVertical(ref i, ref j, patterns[5], ref endCheck) || CheckPatternAscendingDiagonal(ref i, ref j, patterns[5], ref endCheck) || CheckPatternDescendingDiagonal(ref i, ref j, patterns[5], ref endCheck))
            {
                return 4000000;
            }
            if (CheckPatternHorizontal(ref i, ref j, patterns[6], ref endCheck) || CheckPatternVertical(ref i, ref j, patterns[6], ref endCheck) || CheckPatternAscendingDiagonal(ref i, ref j, patterns[6], ref endCheck) || CheckPatternDescendingDiagonal(ref i, ref j, patterns[6], ref endCheck))
            {
                return 500;
            }
            if (CheckPatternHorizontal(ref i, ref j, patterns[7], ref endCheck) || CheckPatternVertical(ref i, ref j, patterns[7], ref endCheck) || CheckPatternAscendingDiagonal(ref i, ref j, patterns[7], ref endCheck) || CheckPatternDescendingDiagonal(ref i, ref j, patterns[7], ref endCheck))
            {
                return 50;
            }
            if (CheckPatternHorizontal(ref i, ref j, patterns[8], ref endCheck) || CheckPatternVertical(ref i, ref j, patterns[8], ref endCheck) || CheckPatternAscendingDiagonal(ref i, ref j, patterns[8], ref endCheck) || CheckPatternDescendingDiagonal(ref i, ref j, patterns[8], ref endCheck))
            {
                return 50;
            }
            if (CheckPatternHorizontal(ref i, ref j, patterns[9], ref endCheck) || CheckPatternVertical(ref i, ref j, patterns[9], ref endCheck) || CheckPatternAscendingDiagonal(ref i, ref j, patterns[9], ref endCheck) || CheckPatternDescendingDiagonal(ref i, ref j, patterns[9], ref endCheck))
            {
                return 25;
            }
            if (CheckPatternHorizontal(ref i, ref j, patterns[10], ref endCheck) || CheckPatternVertical(ref i, ref  j, patterns[10], ref endCheck) || CheckPatternAscendingDiagonal(ref i, ref j, patterns[10], ref endCheck) || CheckPatternDescendingDiagonal(ref i, ref j, patterns[10], ref endCheck))
            {
                return 25;
            }
            if (CheckPatternHorizontal(ref i, ref j, patterns[11], ref endCheck) || CheckPatternVertical(ref i, ref j, patterns[11], ref endCheck) || CheckPatternAscendingDiagonal(ref i, ref j, patterns[11], ref endCheck) || CheckPatternDescendingDiagonal(ref i, ref j, patterns[11], ref endCheck))
            {
                return 25;
            }

            if (CheckPatternHorizontal(ref i, ref j, patterns[12], ref endCheck) || CheckPatternVertical(ref i, ref j, patterns[12], ref endCheck) || CheckPatternAscendingDiagonal(ref i, ref j, patterns[12], ref endCheck) || CheckPatternDescendingDiagonal(ref i, ref j, patterns[12], ref endCheck))
            {
                return -100000000;
            }
            if (CheckPatternHorizontal(ref i, ref j, patterns[13], ref endCheck) || CheckPatternVertical(ref i, ref j, patterns[13], ref endCheck) || CheckPatternAscendingDiagonal(ref i, ref j, patterns[13], ref endCheck) || CheckPatternDescendingDiagonal(ref i, ref j, patterns[13], ref endCheck))
            {
                return -100000000;
            }
            if (CheckPatternHorizontal(ref i, ref j, patterns[14], ref endCheck) || CheckPatternVertical(ref i, ref j, patterns[14], ref endCheck) || CheckPatternAscendingDiagonal(ref i, ref j, patterns[14], ref endCheck) || CheckPatternDescendingDiagonal(ref i, ref j, patterns[14], ref endCheck))
            {
                return -100000000;
            }
            if (CheckPatternHorizontal(ref i, ref j, patterns[15], ref endCheck) || CheckPatternVertical(ref i, ref j, patterns[15], ref endCheck) || CheckPatternAscendingDiagonal(ref i, ref j, patterns[15], ref endCheck) || CheckPatternDescendingDiagonal(ref i, ref j, patterns[15], ref endCheck))
            {
                return -99999999;
            }
            if (CheckPatternHorizontal(ref i, ref j, patterns[16], ref endCheck) || CheckPatternVertical(ref i, ref j, patterns[16], ref endCheck) || CheckPatternAscendingDiagonal(ref i, ref j, patterns[16], ref endCheck) || CheckPatternDescendingDiagonal(ref i, ref j, patterns[16], ref endCheck))
            {
                return -4000000;
            }
            if (CheckPatternHorizontal(ref i, ref j, patterns[17], ref endCheck) || CheckPatternVertical(ref i, ref j, patterns[17], ref endCheck) || CheckPatternAscendingDiagonal(ref i, ref j, patterns[17], ref endCheck) || CheckPatternDescendingDiagonal(ref i, ref j, patterns[17], ref endCheck))
            {
                return -4000000;
            }
            if (CheckPatternHorizontal(ref i, ref j, patterns[18], ref endCheck) || CheckPatternVertical(ref i, ref j, patterns[18], ref endCheck) || CheckPatternAscendingDiagonal(ref i, ref j, patterns[18], ref endCheck) || CheckPatternDescendingDiagonal(ref i, ref j, patterns[18], ref endCheck))
            {
                return -500;
            }
            if (CheckPatternHorizontal(ref i, ref j, patterns[19], ref endCheck) || CheckPatternVertical(ref i, ref j, patterns[19], ref endCheck) || CheckPatternAscendingDiagonal(ref i, ref j, patterns[19], ref endCheck) || CheckPatternDescendingDiagonal(ref i, ref j, patterns[19], ref endCheck))
            {
                return -50;
            }
            if (CheckPatternHorizontal(ref i, ref j, patterns[20], ref endCheck) || CheckPatternVertical(ref i, ref j, patterns[20], ref endCheck) || CheckPatternAscendingDiagonal(ref i, ref j, patterns[20], ref endCheck) || CheckPatternDescendingDiagonal(ref i, ref j, patterns[20], ref endCheck))
            {
                return -50;
            }
            if (CheckPatternHorizontal(ref i, ref j, patterns[21], ref endCheck) || CheckPatternVertical(ref i, ref j, patterns[21], ref endCheck) || CheckPatternAscendingDiagonal(ref i, ref j, patterns[21], ref endCheck) || CheckPatternDescendingDiagonal(ref i, ref j, patterns[21], ref endCheck))
            {
                return -25;
            }
            if (CheckPatternHorizontal(ref i, ref j, patterns[22], ref endCheck) || CheckPatternVertical(ref i, ref j, patterns[22], ref endCheck) || CheckPatternAscendingDiagonal(ref i, ref j, patterns[22], ref endCheck) || CheckPatternDescendingDiagonal(ref i, ref j, patterns[22], ref endCheck))
            {
                return -25;
            }
            if (CheckPatternHorizontal(ref i, ref j, patterns[23], ref endCheck) || CheckPatternVertical(ref i, ref j, patterns[23], ref endCheck) || CheckPatternAscendingDiagonal(ref i, ref j, patterns[23], ref endCheck) || CheckPatternDescendingDiagonal(ref i, ref j, patterns[23], ref endCheck))
            {
                return -25;
            }
            return int.MinValue;  //шаблона не найдено
        }

        private bool CheckPatternHorizontal(ref int row, ref int col, string pattern, ref bool endCheck) //проверка паттерна по горизонтали
        {
            if (!endCheck)
            {
                int tempI = row;
                int tempJ = col;
                bool flag = true;
                for (int i = 0; i < pattern.Length; i++)
                {
                    if (col + i >= GetBoard().GetLength(0) || GetBoardValue(row, col + i) != pattern[i])
                    {
                        flag = false;
                        break;
                    }
                    if (pattern[i] == 'E') //если встретилась пустая клетка в паттерне и он подойдет то мы вернем координаты пустой клетки паттерна
                    {
                        tempJ = col + i;
                    }
                }
                if (flag)
                {
                    endCheck = true;
                    row = tempI;
                    col = tempJ;
                    return flag;
                }
                flag = true;
                for (int i = 0; i < pattern.Length; i++)
                {
                    if ((col - i) < 0 || GetBoardValue(row, col - i) != pattern[i])
                    {
                        flag = false;
                        break;
                    }
                    if (pattern[i] == 'E') //если встретилась пустая клетка в паттерне и он подойдет то мы вернем координаты пустой клетки паттерна
                    {
                        tempJ = col - i;
                    }
                }
                if (flag)
                {
                    endCheck = true;
                    row = tempI;
                    col = tempJ;
                }
                return flag;
            }
            return true;
        }

        private bool CheckPatternVertical(ref int row, ref int col, string pattern,ref  bool endCheck) //проверка паттерна по вертикали
        {
            if (!endCheck) { 
            int tempI = row;
            int tempJ = col;
            bool flag = true; ;
            for (int i = 0; i < pattern.Length; i++)
            {
                if (row + i >= GetBoard().GetLength(0) || GetBoardValue(row + i, col) != pattern[i])
                {
                    flag = false;
                    break;
                }
                if (pattern[i] == 'E') //если встретилась пустая клетка в паттерне и он подойдет то мы вернем координаты пустой клетки паттерна
                {
                    tempI = row + i;
                }
            }
            if (flag)
            {
                    endCheck = true;
                    row = tempI;
                col = tempJ;
                return flag;
            }
            flag = true;
            for (int i = 0; i < pattern.Length; i++)
            {
                if ((row - i) < 0 || GetBoardValue(row-i, col) != pattern[i])
                {
                    flag = false;
                    break;
                }
                if (pattern[i] == 'E') //если встретилась пустая клетка в паттерне и он подойдет то мы вернем координаты пустой клетки паттерна
                {
                    tempI = row - i;
                }
            }
            if (flag)
            {
                    endCheck = true;
                    row = tempI;
                col = tempJ;
            }
            return flag;
            }
            return true;
        }

        private bool CheckPatternAscendingDiagonal(ref int row, ref int col, string pattern, ref bool endCheck) //проверка паттерна по восходящей диагонали
        {
            if (!endCheck)
            {
                bool flag = true;
                int tempI = row;
                int tempJ = col;
                for (int i = 0; i < pattern.Length; i++)
                {
                    if (row - i < 0 || col + i >= GetBoard().GetLength(1) || GetBoardValue(row - i, col + i) != pattern[i])
                    {
                        return false;
                    }
                    if (pattern[i] == 'E')
                    {
                        tempI = row - i;
                        tempJ = col + i;
                    }
                }
                if (flag)
                {
                    endCheck = true;
                    row = tempI;
                    col = tempJ;
                }
                return flag;
            }
            return true;
        }

        private bool CheckPatternDescendingDiagonal(ref int row, ref int col, string pattern, ref bool endCheck) //проверка по главной диагонали(нисходящей)
        {
            if (!endCheck)
            {
                bool flag = true;
                int tempI = row;
                int tempJ = col;
                for (int i = 0; i < pattern.Length; i++)
                {
                    if (row + i >= GetBoard().GetLength(0) || col + i >= GetBoard().GetLength(1) || GetBoardValue(row + i, col + i) != pattern[i])
                    {
                        return false;
                    }
                    if (pattern[i] == 'E')
                    {
                        tempI = row + i;
                        tempJ = col + i;
                    }
                }
                if (flag)
                {
                    endCheck = true;
                    row = tempI;
                    col = tempJ;
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
                for (int j =0; j < tempBoard.GetLength(1); j++)
                {
                    int tempI = i;
                    int tempJ = j;
                    int score = positionValue(currentPlayer,ref tempI, ref tempJ);
                    if (score > bestScore)
                    {
                        stepI = tempI;
                        stepJ = tempJ;
                        bestScore = score;
                        //break;
                    }
                }
            }
            return bestScore;
        }

        private int AplhaBetaPruning(int depth, Players currentPlayer, int alpha, int beta)
        {
            if (IsWinner(currentPlayer))
                return 10;
            currentPlayer = GetOpponent(currentPlayer);
            if (IsWinner(currentPlayer))
                return 10;
            currentPlayer = GetOpponent(currentPlayer);
            if (IsEmptySquares() || depth == 3)
                return 0;

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
