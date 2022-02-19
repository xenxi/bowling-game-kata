using FluentAssertions;
using NUnit.Framework;

namespace BowlingGameKata.Tests
{
    public class BowlingGameFeature
    {
        [Test]
        public void score_a_game_without_any_bonus()
        {
            var game = new BowlingGame();

            var score = game.Score();

            score.Should().Be(90);
        }
    }
}