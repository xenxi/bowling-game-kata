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

        [Test]
        public void scores_a_first_roll()
        {
            var game = new BowlingGame();
            game.Roll(3);

            var score = game.Score();

            score.Should().Be(3);
        }

        [Test]
        public void scores_a_second_roll()
        {
            var game = new BowlingGame();
            game.Roll(3);
            game.Roll(6);

            var score = game.Score();

            score.Should().Be(9);
        }
    }
}