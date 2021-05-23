using System;

namespace BullsAndCows
{
    public class BullsAndCows
    { 
        public int Bulls { get; set; }

        public int Cows { get; set; }

        public BullsAndCows(int bulls, int cows)
        {
            this.Bulls = bulls;
            this.Cows = cows;     
        }
        public bool Equals(BullsAndCows bullsAndCows)
        {
            if (this.Bulls == bullsAndCows.Bulls && this.Cows == bullsAndCows.Cows)
            {
                return true;
            }

            else
            {
                return false;
            }
        }


    }
}
