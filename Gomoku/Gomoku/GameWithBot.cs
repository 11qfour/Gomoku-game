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
                stepI = rand.Next(0, 14);
                stepJ = rand.Next(0, 14);
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

        public List<(int, int)> AlphaBetaPruning()
        {
            List<(int, int)> BotStep = new List<(int, int)> { (stepI, stepJ) };
            return BotStep;

        }

        private List<(int, int)> bestMove(Players players)
        {
            List<(int, int)> BotStep = new List<(int, int)> { (stepI, stepJ) };
            int bestScore = int.MinValue;
            for (int i = 0; i < GetBoard().GetLength(0); i++)
            {
                for (int j = 0; j < GetBoard().GetLength(1); j++)
                {
                    if (GetBoardValue(i, j) == 'E')
                    {
                        SetBoardValue(i, j, players.PlayerMarker);
                        int moveScore = Minimax(0, GetOpponent(players), int.MinValue, int.MaxValue);
                        SetBoardValue(i, j, 'E');
                        if (moveScore > bestScore)
                        {
                            bestScore = moveScore;
                            BotStep.Clear();
                            int row = i;
                            int col = j;
                            BotStep.Add((row, col)); //добавляем координаты оптимального хода
                        }
                    }
                }
            }
            return BotStep;
        }

        private int Minimax(int depth, Players currentPlayer, int alpha, int beta)
        {
            if (IsWinner(currentPlayer)) 
                return 10;
            currentPlayer=GetOpponent(currentPlayer);
            if (IsWinner(currentPlayer)) 
                return 10;
            currentPlayer=GetOpponent(currentPlayer);
            if (IsEmptySquares() || depth == 3) 
                return 0;

            int bestValue = currentPlayer.Player == Player.BotPlayer ? int.MinValue : int.MaxValue;

            for (int i = 0; i <GetBoard().GetLength(0); i++)
            {
                for (int j = 0; j < GetBoard().GetLength(1); j++)
                {
                    if (GetBoardValue(i, j) == 'E')
                    {
                        SetBoardValue(i, j, currentPlayer.PlayerMarker);
                        int moveValue = Minimax(depth + 1, GetOpponent(currentPlayer), alpha, beta);
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
