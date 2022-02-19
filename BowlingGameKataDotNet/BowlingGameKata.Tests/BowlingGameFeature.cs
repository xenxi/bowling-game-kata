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
            game.Roll(9);
            game.Roll(0);
            game.Roll(9);
            game.Roll(0);
            game.Roll(9);
            game.Roll(0);
            game.Roll(9);
            game.Roll(0);
            game.Roll(9);
            game.Roll(0);
            game.Roll(9);
            game.Roll(0);
            game.Roll(9);
            game.Roll(0);
            game.Roll(9);
            game.Roll(0);
            game.Roll(9);
            game.Roll(0);
            game.Roll(9);
            game.Roll(0);

            var score = game.Score();

            score.Should().Be(90);
        }

        [Test]
        public void score_a_game_with_spares()
        {
            var game = new BowlingGame();
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);

            var score = game.Score();

            score.Should().Be(150);
        }
    }
}