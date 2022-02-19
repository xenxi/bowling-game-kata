using FluentAssertions;
using NUnit.Framework;

namespace BowlingGameKata.Tests
{
    public class BowlingGameShould
    {
        [Test]
        public void have_a_starting_score_of_zero()
        {
            var game = new BowlingGame();

            var score = game.Score();

            score.Should().Be(0);
        }

    }
}