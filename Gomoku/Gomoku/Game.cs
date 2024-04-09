using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Game
    {
        char [,] board; //элементы: w-белые, b - черные, e - пустая
        bool GaneIsOver; //флаг - показатель завершенности игры

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
