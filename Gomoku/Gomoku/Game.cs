using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Game 
    {
        const int size = 15; //для реальной симуляции
        //const int size = 6; //для теста
        char[,] board = new char[size,size]; //элементы: W-белые, B - черные, E - пустая
        char[] players = { 'B', 'W' };
        List<(int, int)> sequenceOfMoves = new List<(int, int)>();
        bool GameIsOver; //флаг - показатель завершенности игры
        char currentPlayer;
        List<int[]> SuccessSteps = new List<int[]>(); //массив выигрышных ходов, нужно для отображения

        private int black_steps;
        private int steps;
        private int white_steps;

        Profile profile;

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

        public void NextTurn(int i, int j, char side)
        {
            sequenceOfMoves.Add((i, j)); //добавление последовательности шагов
            board[i, j] = side; //присвоении ячейки игроку
        }

        public List<(int, int)> GetSequenceOfMoves() // возвращает последовательность ходов
        {
            return sequenceOfMoves;
        }

        public void CancelTurn(ref int i, ref int j) // отменяет ход
        {
            if (sequenceOfMoves.Count > 0)
            {
                var lastMove = sequenceOfMoves[sequenceOfMoves.Count - 1];
                i = lastMove.Item1; // Последний x
                j = lastMove.Item2; // Последний y
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
            steps --;
        }


        public void AddToFile(string result, char Opponent, char sideopp) //запись сыгранного матча в файл
        {
            profile.LoadDatas() ;
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
            while (j < (size - 1) && (board[i, j] == 0 || board[i, j] == player) && verticalCount < 5/*если длинный ряд, прерывается*/)
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
            while (i < (size - 1) && (board[i, j] == 0 || board[i, j] == player) && horizontalCount < 5)
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
            while (j < (size - 1) && i < (size - 1) && (board[i, j] == 'E' || board[i, j] == player) && diagonalCount < 5)
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
            while (j < (size-1) && i > 0 && (board[i, j] == 'E' || board[i, j] == player) && diagonalCount < 5)
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
            while (j > 0 && i < (size-1) && (board[i, j] == 'E' || board[i, j] == player) && diagonalCount < 5)
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
            if (IsEmptySquares()) //(available.Count == 0)
                return 0; //ничья
            return 1;  //продолжить игру 
        }

        public bool IsEmptySquares()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 'E')
                    {
                        return false;
                    }
                }
            }
            SetGameIsOver(true);
            return true;
        }

        ///////

        public Game()
        {
            profile = new Profile("Sanya"); //подумать над тем как сохранять в тот же файл
            this.white_steps = 0;
            this.black_steps = 0;
            this.steps = 0;
            currentPlayer = 'B';
            GameIsOver = false;
            for (int j = 0; j < board.GetLength(0); j++)
                for (int i = 0; i < board.GetLength(1); i++)
                {
                    board[i, j] = 'E';
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

        public bool GetGameIsOver()//проверка на завершённость игры
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

        public char GetBoardValue(int i, int j)
        {
            return board[i, j];
        }

        public List<int[]> GetSuccessSteps()
        {
            return SuccessSteps;
        }

        public char[,] GetBoard()
        {
            return board;
        } 
    }
}
