using BowlingGameKata.Exceptions;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace BowlingGameKata.Tests
{
    public class FramesShould
    {
        [Test]
        public void not_allow_to_play_more_than_two_rolls()
        {
            var frame = new Frame();
            frame.Anotate(1);
            frame.Anotate(1);

            Action action = () => frame.Anotate(1);

            action.Should().Throw<CompletedFrame>();
        }

        [Test]
        public void not_allow_to_anonate_more_than_ten_pins()
        {
            var frame = new Frame();
            frame.Anotate(5);

            Action action = () => frame.Anotate(6);

            action.Should().Throw<InvalidNumberOfPins>();
        }

        [Test]
        public void calcule_spare_bonus()
        {
            var frame = new Frame();
            frame.Anotate(5);
            frame.Anotate(2);

            var bonus = frame.SpareBonus();

            bonus.Should().Be(5);
        }

        [Test]
        public void have_a_starting_bonus_of_zero()
        {
            var frame = new Frame();

            var bonus = frame.SpareBonus();

            bonus.Should().Be(0);
        }
    }
}