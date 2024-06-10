using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryGames
{
    public class GamePlatform
    {
        public GamePlatform(int gameID, int platformID)
        {
            GameID = gameID;
            PlatformID = platformID;
        }

        public int GameID { get;}

        public int PlatformID { get; }
    }
}
