using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    public enum Player { None, BotPlayer, Human };
    public class Players
    {
        public Player Player;
        public char PlayerMarker; //сторона игрока

        public int PlayerID;

        public Players(Player players, char playerMarker, int playerID)
        {
            this.Player = players;
            this.PlayerMarker = playerMarker;
            this.PlayerID = playerID;
        }

       /* public char GetPlayerMarker()
        {
            return this.PlayerMarker;
        }

        public int GetPlayerID()
        {
            return this.PlayerID;
        }

        public Player GetPlayer()
        {
            return this.Player;
        }*/
    }
}
