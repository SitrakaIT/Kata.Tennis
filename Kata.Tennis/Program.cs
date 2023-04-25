using Kata.Tennis.Models;
using Kata.Tennis.Services;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddTransient<IMatchService, MatchService>();
        services.AddTransient<IScoreService, ScoreService>();
        services.AddTransient<IWinningService, WinningService>();

        var provider = services.BuildServiceProvider();
        var matchService = provider.GetService<IMatchService>();
        Player player = new Player();
        matchService.StartMatch(player);
        
    }
}
