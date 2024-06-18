using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Game 
    {
        private const int size = 15; //для реальной симуляции
        //private const int size = 6; //для теста
        private char[,] board = new char[size,size]; //элементы: W-белые, B - черные, E - пустая
        private char[] players = { 'B', 'W' };
        private List<(int, int)> sequenceOfMoves = new List<(int, int)>();
        private bool GameIsOver; //флаг - показатель завершенности игры
        private char currentPlayer;
        private List<int[]> SuccessSteps = new List<int[]>(); //массив выигрышных ходов, нужно для отображения

        private int blackSteps; //кол-во черных камней
        private int steps; //количество камней
        private int whiteSteps; //количество белых камней
        Profile profile;
        
        public void SetSequenceStepsValue(int i, int j)
        {
            this.sequenceOfMoves.Add((i, j));
        }

        public void SetClearBoard()
        {
            for (int i = 0; i< board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = 'E';
                }
            }
        }


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

        public void сancelTurn(ref int i, ref int j) // отменяет ход
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
                whiteSteps--;
            }
            else
            {
                currentPlayer = 'B';
                blackSteps--;
            }
            board[i, j] = 'E'; //клетка пуста
            steps --;
        }


        public void AddToFile(string result, char Opponent, int time) //запись сыгранного матча в файл
        {
            string opp="";
            if (result == "bot" && Opponent == 'M')
            {
                result = "Выиграл Опытный Бот";
                opp = "Опытный Бот";
            }
            else if (result == "bot" && Opponent == 'S')
            {
                result = "Выиграл Бот Новичок";
                opp = "Бот Новичок";
            }
            else if (result == "human" && Opponent == 'M')
            {
                result = "Вы выиграли Опытного Бота";
                opp = "Опытный Бот";
            }
            else if (result == "human" && Opponent == 'S')
            {
                result = "Вы выиграли Бота Новичка";
                opp = "Бот Новичок";
            }
            else if (result == "черные" && Opponent == 'f')
            {
                result = "Сторона черных победила";
                opp = "Друг";
            }
            else if (result == "белые" && Opponent == 'f')
            {
                result = "Сторона белых победила";
                opp = "Друг";
            }
            else if (result == "tie") {
                if (Opponent == 'S')
                {
                    result = "Ничья в матче с Ботом новичком";
                    opp = "Бот Новичок";
                }
                else if (Opponent == 'M')
                {
                    result = "Ничья в матче с опытным Ботом";
                    opp = "Опытный Бот";
                }
                else
                {
                    result = "Ничья в матче с другом";
                    opp = "Друг";
                }
            }
            int hours = time / 3600;
            int minutes = time / 60;
            int seconds = time % 60;
            string times = hours.ToString() + ':'.ToString()+minutes.ToString() + ':'.ToString() + seconds.ToString();
            profile.AddMatchToProfileFile(result, opp, steps,times);
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
            while (j < (size - 1) && (board[i, j] == 'E'|| board[i, j] == player) && verticalCount < 5/*если длинный ряд, прерывается*/)
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
            while (j > 0 && (board[i, j] == 'E' || board[i, j] == player) && verticalCount < 5)
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
            while (i < (size - 1) && (board[i, j] == 'E' || board[i, j] == player) && horizontalCount < 5)
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
            while (i > 0 && (board[i, j] == 'E' || board[i, j] == player) && horizontalCount < 5)
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
            if (IsEmptySquares()) 
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
            profile = new Profile("Gamer"); //подумать над тем как сохранять в тот же файл
            this.whiteSteps = 0;
            this.blackSteps = 0;
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
            this.blackSteps = cnt;
        }

        public void SetWhiteSteps(int cnt)
        {
            this.whiteSteps = cnt;
        }

        public void SetSteps(int cnt)
        {
            this.steps = cnt;
        }
        public int GetBlackSteps()
        {
            return this.blackSteps;
        }

        public int GetWhiteSteps()
        {
            return this.whiteSteps;
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
