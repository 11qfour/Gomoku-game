﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class AIBotPlayer : Game //наследуем от Game все методы
    {
        private char GameLevel; //уровень игры компьютера
        private int TimeLimit=int.MaxValue; //ограничение по времени
        private bool IsTimeLimit; //есть ограничение по времени или нет

        public AIBotPlayer(char level, int limit, bool isTimeLimit)
        {
            this.GameLevel = level;
            this.IsTimeLimit = isTimeLimit;
            if (isTimeLimit)
                this.TimeLimit = limit;
        }

        public void RandomSelection()
        {
            
        }
        public void Minimax()
        {
            
        }

        public void AlphaBetaPruning()
        {

        }

        public void MonteCarloTreeSearch()
        {

        }
    }
}