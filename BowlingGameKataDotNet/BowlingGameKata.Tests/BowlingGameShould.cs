using FluentAssertions;
using NUnit.Framework;

namespace BowlingGameKata.Tests
{
    public class BowlingGameShould
    {
        private BowlingGame game;

        [Test]
        public void have_a_starting_score_of_zero()
        {
            var score = game.Score();

            score.Should().Be(0);
        }

        [Test]
        public void scores_a_first_roll()
        {
            game.Roll(3);

            var score = game.Score();

            score.Should().Be(3);
        }

        [Test]
        public void scores_a_second_roll()
        {
            game.Roll(3);
            game.Roll(6);

            var score = game.Score();

            score.Should().Be(9);
        }

        [SetUp]
        public void SetUp()
        {
            game = new BowlingGame();
        }
    }
}