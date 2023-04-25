using Kata.Tennis.Models;
using Kata.Tennis.Services;
using Kata.Tennis.Tests.Mocks;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Tennis.Tests
{
    public class WinningServiceTest
    {
        private ScoreServiceMock _scoreServiceMock;

        private IWinningService _winningService;
        private Player _player;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            _scoreServiceMock = new ScoreServiceMock();
            services.AddTransient(x => _scoreServiceMock.Object);
            services.AddTransient<IWinningService, WinningService>();

            var service = services.BuildServiceProvider();
            _winningService = service.GetRequiredService<IWinningService>();

            Player player = new Player();
            _player = player;
        }

        [TestCase(1, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(3, 3)]
        [TestCase(5, 5)]
        [TestCase(8, 7)]
        public void TestScoresOne_True(int player1, int player2)
        {
            _player.Player1Score = player1;
            _player.Player2Score = player2;

            bool winning = _winningService.CheckGameWinning(_player);

            Assert.False(winning);

        }

        [TestCase(4, 2)]
        [TestCase(8, 6)]
        public void TestScoresOne_False(int player1, int player2)
        {
            _player.Player1Score = player1;
            _player.Player2Score = player2;

            bool winning = _winningService.CheckGameWinning(_player);

            Assert.IsTrue(winning);

        }
    }
}
