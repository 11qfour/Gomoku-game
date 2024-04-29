using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Game
    {
        char [,] board = new char[15,15]; //элементы: W-белые, B - черные, E - пустая
        char[] players = { 'B', 'W' };
       
        bool GaneIsOver; //флаг - показатель завершенности игры
        char currentPlayer;
        List<int []> available = new List<int[]>();

        private int black_steps;
        private int steps;
        private int white_steps;

        public void NextTurn(ref int first, ref int second)
        {
            Random rand = new Random();
            int index = /*Math.Floor(*/rand.Next(available.Count);
            int [] spot = available.ElementAt(index);
            available.RemoveAt(index);
            int i = spot[0];
            int j = spot[1];
            board[i,j] = currentPlayer;
            if (currentPlayer == 'W')
                currentPlayer = 'B';
            else
                currentPlayer = 'W';
            first = i;
            second = j;
        }

        public int CheckWinner(int i, int j)
        {
            char player = board[i,j];
            if (player == 'E')
                Console.WriteLine("Ошибка!");
            // Проверка горизонтали
            int horizontalCount = 1;
            for (int k = 1; k < 5; k++)
            {
                // Влево
                if (j - k >= 0 && board[i, j - k] == player)
                {
                    horizontalCount++;
                }
                else
                {
                    break;
                }
            }
            for (int k = 1; k < 5; k++)
            {
                // Вправо
                if (j + k < 14 && board[i, j + k] == player)
                {
                    horizontalCount++;
                }
                else
                {
                    break;
                }
            }
            if (horizontalCount >= 5)
            {
                return 10; // Победитель найден по горизонтали
            }

            // Проверка вертикали
            int verticalCount = 1;
            for (int k = 1; k < 5; k++)
            {
                // Вверх
                if (i - k >= 0 && board[i - k, j] == player)
                {
                    verticalCount++;
                }
                else
                {
                    break;
                }
            }
            for (int k = 1; k < 5; k++)
            {
                // Вниз
                if (i + k < 14 && board[i + k, j] == player)
                {
                    verticalCount++;
                }
                else
                {
                    break;
                }
            }
            if (verticalCount >= 5)
            {
                return 10; // Победитель найден по вертикали
            }

            // Проверка диагонали 1 (слева сверху направо вниз)
            int diagonal1Count = 1;
            for (int k = 1; k < 5; k++)
            {
                // Слева сверху
                if (i - k >= 0 && j - k >= 0 && board[i - k, j - k] == player)
                {
                    diagonal1Count++;
                }
                else
                {
                    break;
                }
            }
            for (int k = 1; k < 5; k++)
            {
                // Справа снизу
                if (i + k < 14 && j + k < 14 && board[i + k, j + k] == player)
                {
                    diagonal1Count++;
                }
                else
                {
                    break;
                }
            }
            if (diagonal1Count >= 5)
            {
                return 10; // Победитель найден по диагонали 1
            }

            // Проверка диагонали 2 (слева снизу направо сверху)
            int diagonal2Count = 1;
            for (int k = 1; k < 5; k++)
            {
                // Слева снизу
                if (i + k < 14 && j - k >= 0 && board[i + k, j - k] == player)
                {
                    diagonal2Count++;
                }
                else
                {
                    break;
                }
            }
            for (int k = 1; k < 5; k++)
            {
                // Справа сверху
                if (i - k >= 0 && j + k < 14 && board[i - k, j + k] == player)
                {
                    diagonal2Count++;
                }
                else
                {
                    break;
                }
            }
            if (diagonal2Count >= 5)
            {
                return 10; // Победитель найден по диагонали 2
            }



            if (available.Count == 0)
                return 0;
            return 1;   
        }

        ///////

        public Game()
        {
            this.white_steps = 0;
            this.black_steps = 0;
            this.steps = 0;
            currentPlayer = 'B';
            for (int j = 0; j < 14; j++)
                for (int i = 0; i < 14; i++)
                    available.Add(new int[] { i, j });
        }

        public void SetBlackSteps(int cnt)
        {
            this.black_steps = cnt;
        }

        public void SetWhiteSteps(int cnt)
        {
            this.white_steps = cnt;
        }

        public void SetSteps(int cnt)
        {
            this.steps = cnt;
        }


        public int GetBlackSteps()
        {
            return this.black_steps;
        }

        public int GetWhiteSteps()
        {
            return this.white_steps;
        }

        public int GetSteps()
        {
            return this.steps;
        }

        public char GetCurrentPlayer()
        {
            return currentPlayer;
        }
        /////////////////////////////////

        private int MiniMaxAlgorithm(int depth, bool isMaximizingPlayer, int MaxDepth)
        {
            /*if (depth >= maxDepth || gameIsOver)
            {
                return Evaluate(); // Оценка текущего состояния игры на достигнутой глубине или в терминальном узле
            }*/

            int score = Evaluate();

            if (score == 10)
                return score;
            if (score == -10)
                return score;
            if (!IsMovesLeft())
                return 0;

            if (isMaximizingPlayer)
            {
                int bestScore = int.MinValue;

                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        if (board[i, j] == 'e')
                        {
                            board[i, j] = 'X';
                            bestScore = Math.Max(bestScore, MiniMaxAlgorithm(depth + 1, !isMaximizingPlayer,MaxDepth));
                            board[i, j] = 'e';
                        }
                    }
                }

                return bestScore;
            }
            else
            {
                int bestScore = int.MaxValue;

                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        if (board[i, j] == 'e')
                        {
                            board[i, j] = 'O';
                            bestScore = Math.Min(bestScore, MiniMaxAlgorithm(depth + 1, !isMaximizingPlayer, MaxDepth));
                            board[i, j] = 'e';
                        }
                    }
                }

                return bestScore;
            }
        }

        private bool IsMovesLeft()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 'e')
                    {
                        return true; // есть доступные ходы
                    }
                }
            }
            return false; // Нет доступных ходов
        }

        public void MakeMove(string difficultyLevel) //сделать ход
        {
            int bestScore;
            bool isMaximizingPlayer;
            if (difficultyLevel == "middle")
            {
                int maxdepth = 3;
                isMaximizingPlayer = false;
                bestScore = MiniMaxAlgorithm(0, isMaximizingPlayer, maxdepth);
            }
            else if (difficultyLevel == "hard")
            {
                int maxdepth = 6;
                isMaximizingPlayer = true;
                bestScore = MiniMaxAlgorithm(0, isMaximizingPlayer, maxdepth);
            }
            else if (difficultyLevel == "easy")
            {
                //функция случайного выбора хода

            }
            else
            {
                throw new ArgumentException("Присвоена некорректная сложность. Сложности игры с противником-компьютером: Низкая, Средняя и Высокая сложности.");
            }

            /*int bestMove = -1;
            int bestScore = int.MinValue;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 'e')
                    {
                        board[i, j] = isMaximizingPlayer ? 'X' : 'O';
                        int score = MiniMaxAlgorithm(0, !isMaximizingPlayer, maxDepth);
                        board[i, j] = 'e';

                        if (score > bestScore)
                        {
                            bestScore = score;
                            bestMove = i * board.GetLength(1) + j; // Преобразование индексов в одномерное представление
                        }
                    }
                }
            }*/

            //реализация хода используя бестмув

        }

        private int Evaluate()
        { 
            int WScore = EvaluatePlayerScore('w'); //Оценка для белых
            int BScore = EvaluatePlayerScore('b'); // Оценка для черны[
            // Возвращаем разницу между оценками игроков
            return WScore - BScore;
        }

        private int EvaluatePlayerScore(char player)
        {
            int score = 0;

            // Подсчет количества рядов и столбцов с фишками игрока
            for (int i = 0; i < board.GetLength(0); i++)
            {
                int rowCount = 0;
                int colCount = 0;

                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == player)
                        rowCount++;

                    if (board[j, i] == player)
                        colCount++;
                }

                // Увеличиваем оценку на количество рядов и столбцов с фишками игрока
                score += rowCount + colCount;
            }

            // Возвращаем общую оценку для игрока
            return score;
        }
        

    }
}
