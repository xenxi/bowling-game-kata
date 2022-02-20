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
        public void not_allow_to_play_more_than_eleven_frames_for_a_game_extended_by_spare()
        {
            for (int i = 0; i < 9; i++)
            {
                _game.Roll(1);
                _game.Roll(1);
            }
            _game.Roll(5);
            _game.Roll(5);
            _game.Roll(4);

            Action action = () => _game.Roll(1);

            action.Should().Throw<CompletedGame>();
        }

        [Test]
        public void not_allow_to_play_more_than_ten_frames()
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

        [Test]
        public void scores_a_spare()
        {
            _game.Roll(3);
            _game.Roll(7);
            _game.Roll(3);

            var score = _game.Score();

            score.Should().Be(16);
        }

        [Test]
        public void scores_a_strike()
        {
            _game.Roll(10);
            _game.Roll(2);
            _game.Roll(2);

            var score = _game.Score();

            score.Should().Be(18);
        }

        [Test]
        public void scores_game_extended_by_spare()
        {
            for (int i = 0; i < 9; i++)
            {
                _game.Roll(1);
                _game.Roll(1);
            }
            _game.Roll(5);
            _game.Roll(5);
            _game.Roll(4);

            var score = _game.Score();

            score.Should().Be(32);
        }
        [Test]
        public void scores_game_extended_by_strike()
        {
            for (int i = 0; i < 9; i++)
            {
                _game.Roll(1);
                _game.Roll(1);
            }
            _game.Roll(10);
            _game.Roll(5);
            _game.Roll(4);

            var score = _game.Score();

            score.Should().Be(37);
        }
        [Test]
        public void scores_multiple_spares()
        {
            _game.Roll(3);
            _game.Roll(7);
            _game.Roll(5);
            _game.Roll(5);
            _game.Roll(4);

            var score = _game.Score();

            score.Should().Be(33);
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