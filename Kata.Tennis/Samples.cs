using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Tennis
{
    public class TennisGame
    {
        private int player1Score;
        private int player2Score;
        private string player1Name;
        private string player2Name;

        public TennisGame(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            if (player1Score >= 4 && player1Score - player2Score >= 2)
            {
                return $"{player1Name} wins";
            }
            else if (player2Score >= 4 && player2Score - player1Score >= 2)
            {
                return $"{player2Name} wins";
            }
            else if (player1Score >= 3 && player2Score == player1Score)
            {
                return "Deuce";
            }
            else if (player1Score > player2Score && player2Score >= 3)
            {
                return $"Advantage {player1Name}";
            }
            else if (player2Score > player1Score && player1Score >= 3)
            {
                return $"Advantage {player2Name}";
            }
            else if (player1Score == player2Score)
            {
                return $"{GetScoreName(player1Score)} all";
            }
            else
            {
                return $"{GetScoreName(player1Score)}, {GetScoreName(player2Score)}";
            }
        }

        private string GetScoreName(int score)
        {
            return score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => "",
            };
        }

        public void Player1Scored()
        {
            player1Score++;
        }

        public void Player2Scored()
        {
            player2Score++;
        }
    }

}
