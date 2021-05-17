using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    public class GameManager
    {
        private Game game;

        public GameManager(Game game)
        {
            this.game = game;
        }

        public void Start()
        {
            var gameContinues = game.MakeMove();

            var counter = 0;

            while (gameContinues)
            {
                counter++;

                gameContinues = game.MakeMove();
            }
        }
    }
}
