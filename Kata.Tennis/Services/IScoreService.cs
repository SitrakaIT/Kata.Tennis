using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Tennis.Services
{
    public interface IScoreService
    {
        int Score(int playerScorer);
        string GetScoreName(int score);
    }

    public class ScoreService : IScoreService
    {
        public string GetScoreName(int score)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
            
        }

        public int Score(int playerScorer) => ++playerScorer;
    }
}
