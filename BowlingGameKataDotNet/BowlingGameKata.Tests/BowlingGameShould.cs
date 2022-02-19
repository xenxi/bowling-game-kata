using FluentAssertions;
using NUnit.Framework;
using System;

namespace BowlingGameKata.Tests
{
    public class BowlingGameShould
    {
        private BowlingGame _game;

        [Test]
        public void have_a_starting_score_of_zero()
        {
            var score = _game.Score();

            score.Should().Be(0);
        }

        [Test]
        public void not_allow_to_play_more_thant_ten_frames()
        {
            GivenAnyCompletedGame();

            Action action = () => _game.Roll(1);

            action.Should().Throw<CompletedGame>();
        }

        [Test]
        public void scores_a_first_roll()
        {
            _game.Roll(3);

            var score = _game.Score();

            score.Should().Be(3);
        }

        [Test]
        public void scores_a_second_roll()
        {
            _game.Roll(3);
            _game.Roll(6);

            var score = _game.Score();

            score.Should().Be(9);
        }

        [SetUp]
        public void SetUp()
        {
            _game = new BowlingGame();
        }

        private void GivenAnyCompletedGame()
        {
            for (int i = 0; i < 10; i++)
            {
                _game.Roll(1);
                _game.Roll(1);
            }
        }
    }
}