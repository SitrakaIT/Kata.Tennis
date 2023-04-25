using Kata.Tennis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Tennis.Services
{
    public interface IWinningService
    {
        bool CheckGameWinning(Player player);
        bool CheckSetWinning(Player player);
        bool CheckMatchWinning(Player player);
    }

    public class WinningService : IWinningService
    {
        private readonly IScoreService _scoreService;

        public WinningService(IScoreService scoreService)
        {
            this._scoreService = scoreService;
        }

        public bool CheckGameWinning(Player player)
        {
            if (player.Player1Score >= 4 && player.Player1Score - player.Player2Score >= 2)
            {
                Console.WriteLine($"Game {player.Player1Name}");
                return true;
            }
            else if (player.Player2Score >= 4 && player.Player2Score - player.Player1Score >= 2)
            {
                Console.WriteLine($"Game {player.Player2Name}");
                return true;
            }
            else if (player.Player1Score == player.Player2Score && player.Player1Score < 3)
            {
                Console.WriteLine($"{_scoreService.GetScoreName(player.Player2Score)} all");
                return false;
            }
            else if (player.Player1Score >= 3 && player.Player2Score == player.Player1Score)
            {
                Console.WriteLine($"Deuce");
                return false;
            }
            else if (player.Player1Score > player.Player2Score && player.Player2Score >= 3)
            {
                Console.WriteLine($"Advantage {player.Player1Name}");
                return false;
            }
            else if (player.Player2Score > player.Player1Score && player.Player1Score >= 3)
            {
                Console.WriteLine($"Advantage {player.Player2Name}");
                return false;
            }
            else
            {
                Console.WriteLine($"{_scoreService.GetScoreName(player.Player1Score)} {_scoreService.GetScoreName(player.Player2Score)}");
                return false;
            }
        }

        public bool CheckMatchWinning(Player player)
        {
            throw new NotImplementedException();
        }

        public bool CheckSetWinning(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
