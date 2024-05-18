using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Game 
    {
        char[,] board = new char[15, 15]; //элементы: W-белые, B - черные, E - пустая
        char[] players = { 'B', 'W' };
        List<(int, int)> sequenceOfMoves = new List<(int, int)>();
        bool GameIsOver; //флаг - показатель завершенности игры
        char currentPlayer;
        List<int[]> available = new List<int[]>();
        List<int[]> SuccessSteps = new List<int[]>(); //массив выигрышных ходов, нужно для отображения

        private int black_steps;
        private int steps;
        private int white_steps;

        public void ChangeCurrentPlayer()
        {
            if (currentPlayer == 'W')
            {
                currentPlayer = 'B';
            }
            else
            {
                currentPlayer = 'W';
            }
        }

        public void NextTurn(int i, int j)
        {
            /*Random rand = new Random();
            int index = *//*Math.Floor(*//*rand.Next(available.Count);
            int [] spot = available.ElementAt(index);
            available.RemoveAt(index);
            int i = spot[0];
            int j = spot[1];*/
            sequenceOfMoves.Add((i, j)); //добавление последовательности шагов
            board[i, j] = currentPlayer; //присвоении ячейки игроку
        }

        public List<(int, int)> GetSequenceOfMoves()
        {
            return sequenceOfMoves;
        }

        public void CancelTurn(ref int i, ref int j)
        {
            if (sequenceOfMoves.Count > 0)
            {
                var lastMove = sequenceOfMoves[sequenceOfMoves.Count - 1];
                i = lastMove.Item1; // Последний x
                j = lastMove.Item2; // Последний y
                // Удаляем последнюю пару из списка
                sequenceOfMoves.RemoveAt(sequenceOfMoves.Count - 1);
            }
            if (board[i, j] == 'W')
            {
                currentPlayer = 'W';
                white_steps--;
            }
            else
            {
                currentPlayer = 'B';
                black_steps--;
            }
            board[i, j] = 'E'; //клетка пуста
            steps--;
        }

        public int CheckWinner(int i, int j)
        {
            char player = board[i, j];
            SuccessSteps.Add(new int[] { i, j });
            List<int[]> tempArraySuccess = SuccessSteps;
            if (player == 'E') //клетка после хода не может быть пустой
                Console.WriteLine("Ошибка!");
            int start, finish; //параметры проверки
            start = i;
            finish = j;
            int horizontalCount = 1; //по умолчанию 1, т.к. не считаем саму ячейку, где уже есть player
            int verticalCount = 1;
            //проверка горизонтали
            while (j < 14 && (board[i, j] == 0 || board[i, j] == player) && verticalCount < 5/*если длинный ряд, прерывается*/)
            {
                j++; //вправо
                if (board[i, j] == player)
                {
                    verticalCount++;
                    SuccessSteps.Add(new int[] { i, j });
                    if (verticalCount == 5)
                        return 10;
                }
            }
            SuccessSteps=tempArraySuccess;
            verticalCount = 1;
            j = finish;
            i = start;
            while (j > 0 && (board[i, j] == 0 || board[i, j] == player) && verticalCount < 5)
            {
                j--; //влево
                if (board[i, j] == player)
                {
                    verticalCount++;
                    SuccessSteps.Add(new int[] { i, j });
                    if (verticalCount == 5)
                        return 10;
                }
            }
            SuccessSteps = tempArraySuccess;
            //проверка вертикали
            j = finish;
            i = start;
            while (i < 14 && (board[i, j] == 0 || board[i, j] == player) && horizontalCount < 5)
            {
                i++; //вверх
                if (board[i, j] == player)
                {
                    horizontalCount++;
                    SuccessSteps.Add(new int[] { i, j });
                    if (horizontalCount == 5)
                        return 10;
                }
            }
            SuccessSteps = tempArraySuccess;
            horizontalCount = 1;
            i = start;
            j = finish;
            while (i > 0 && (board[i, j] == 0 || board[i, j] == player) && horizontalCount < 5)
            {
                i--; //вниз
                if (board[i, j] == player)
                {
                    horizontalCount++;
                    SuccessSteps.Add(new int[] { i, j });
                    if (horizontalCount == 5)
                        return 10;
                }
            }
            SuccessSteps = tempArraySuccess;
            //проверка диагонали
            int diagonalCount = 1;
            j = finish;
            i = start;
            while (j < 14 && i < 14 && (board[i, j] == 'E' || board[i, j] == player) && diagonalCount < 5)
            {
                j++;
                i++;
                if (board[i, j] == player)
                {
                    diagonalCount++;
                    SuccessSteps.Add(new int[] { i, j });
                    if (diagonalCount == 5)
                        return 10;
                }
            }
            diagonalCount = 1;
            SuccessSteps = tempArraySuccess;
            j = finish;
            i = start;
            while (j < 14 && i > 0 && (board[i, j] == 'E' || board[i, j] == player) && diagonalCount < 5)
            {
                j++;
                i--;
                if (board[i, j] == player)
                {
                    diagonalCount++;
                    SuccessSteps.Add(new int[] { i, j });
                    if (diagonalCount == 5)
                        return 10;
                }
            }
            diagonalCount = 1;
            SuccessSteps = tempArraySuccess;
            j = finish;
            i = start;
            while (j > 0 && i < 14 && (board[i, j] == 'E' || board[i, j] == player) && diagonalCount < 5)
            {
                j--;
                i++;
                if (board[i, j] == player)
                {
                    diagonalCount++;
                    SuccessSteps.Add(new int[] { i, j });
                    if (diagonalCount == 5)
                        return 10;
                }
            }
            diagonalCount = 1;
            SuccessSteps = tempArraySuccess;
            j = finish;
            i = start;
            while (j > 0 && i > 0 && (board[i, j] == 'E' || board[i, j] == player) && diagonalCount < 5)
            {
                j--;
                i--;
                if (board[i, j] == player)
                {
                    diagonalCount++;
                    SuccessSteps.Add(new int[] { i, j });
                    if (diagonalCount == 5)
                        return 10;
                }
            }
            SuccessSteps.Clear();
            if (available.Count == 0)
                return 0; //ничья
            return 1;  //продолжить игру 
        }



        ///////

        public Game()
        {
            this.white_steps = 0;
            this.black_steps = 0;
            this.steps = 0;
            currentPlayer = 'B';
            GameIsOver = false;
            for (int j = 0; j < 14; j++)
                for (int i = 0; i < 14; i++)
                {
                    board[i, j] = 'E';
                    available.Add(new int[] { i, j }); //??
                }
        }

        public void SetCurrentPlayer(char value)
        {
            this.currentPlayer = value;
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

        public bool GetGameIsOver()
        {
            return GameIsOver;
        }

        public void SetGameIsOver(bool t)
        {
            this.GameIsOver = t;
        }

        public void SetBoardValue(int i, int j, char value)
        {
            this.board[i,j] = value;
        }

        public char GetbBoardValue(int i, int j)
        {
            return board[i, j];
        }

        public List<int[]> GetSuccessSteps()
        {
            return SuccessSteps;
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
                            bestScore = Math.Max(bestScore, MiniMaxAlgorithm(depth + 1, !isMaximizingPlayer, MaxDepth));
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
