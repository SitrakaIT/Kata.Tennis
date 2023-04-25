using Kata.Tennis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Tennis.Services
{
    public interface IMatchService
    {
        void StartMatch(Player player);
    }

    public class MatchService : IMatchService
    {
        private readonly IWinningService _winningService;
        private readonly IScoreService _scoreService;

        public MatchService(IWinningService winningService, IScoreService scoreService)
        {
            _winningService = winningService;
            _scoreService = scoreService;
        }

        public void StartMatch(Player player)
        {
            Console.WriteLine("Player 1 name ? ");
            player.Player1Name = Console.ReadLine();
            Console.WriteLine("Player 2 name ? ");
            player.Player2Name = Console.ReadLine();

            while (!_winningService.CheckGameWinning(player))
            {
                Console.WriteLine("Who scores ?");
                
                StartScore(player);
            }
        }

        private void StartScore(Player player)
        {
            string scorer = Console.ReadLine();
            if (scorer.Equals("A"))
            {
                player.Player1Score = _scoreService.Score(player.Player1Score);
            }
            else if (scorer.Equals("B"))
            {
                player.Player2Score = _scoreService.Score(player.Player2Score);
            }
            else
            {
                Console.WriteLine("INVALID data. Please retry!");
                StartScore(player);
            }
        }
    }
}
