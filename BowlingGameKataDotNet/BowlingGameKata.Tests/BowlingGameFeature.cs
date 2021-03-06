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
            game.Roll(5);
            game.Roll(5);

            var score = game.Score();

            score.Should().Be(150);
        }

        [Test]
        public void score_a_perfect_game()
        {
            var game = new BowlingGame();
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);

            var score = game.Score();

            score.Should().Be(300);
        }

        [Test]
        public void score_a_normal_game()
        {
            var game = new BowlingGame();
            game.Roll(10);
            game.Roll(7);
            game.Roll(3);
            game.Roll(9);
            game.Roll(0);
            game.Roll(10);
            game.Roll(0);
            game.Roll(8);
            game.Roll(8);
            game.Roll(2);
            game.Roll(0);
            game.Roll(6);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(8);
            game.Roll(1);

            var score = game.Score();

            score.Should().Be(167);
        }
    }
}