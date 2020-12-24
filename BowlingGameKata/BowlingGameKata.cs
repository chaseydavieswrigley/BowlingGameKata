using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGameKata
{
    public class Game
    {
        private int[] pinsPerRoll = new int[22];
        private int currentRoll;
        public void Roll(int knockedDownPins)
        {
            pinsPerRoll[currentRoll] = knockedDownPins;
            currentRoll++;
        }

        public int Score()
        {
            int score = 0;
            int roll = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(roll))
                {
                    score += CalcStrikeScore(roll);
                    roll++;
                }
                else if (IsSpare(roll))
                {
                    score += CalcSpareScore(roll);
                    roll += 2;
                }
                else
                {
                    score += pinsPerRoll[roll] + pinsPerRoll[roll + 1];
                    roll += 2;
                }
            }
            return score;
        }


        /***********************************************************************
         * Calculates the score from a Strike
         * 10 + the number of pins knocked down in both throws of the next frame
         ***********************************************************************/
        private int CalcStrikeScore(int roll)
        {
            return 10 + pinsPerRoll[roll + 1] + pinsPerRoll[roll + 2];
        }

        /***********************************************************************
        * Calculates the score from a Spare
        * 10 + the number of pins knocked down in next throw of the next frame
        ***********************************************************************/
        private int CalcSpareScore(int roll)
        {
            return 10 + pinsPerRoll[roll + 2];
        }

        /***********************************************************************
        * Determines if number of pins knocked down in one throw = 10
        ***********************************************************************/
        private bool IsStrike(int roll)
        {
            return pinsPerRoll[roll] == 10;
        }

        /***********************************************************************
       * Determines if combined number of pins knocked down in both throws in a frame = 10 
       ***********************************************************************/
        private bool IsSpare(int roll)
        {
            return pinsPerRoll[roll] + pinsPerRoll[roll + 1] == 10;
        }
    }
}
