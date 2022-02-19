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
    }
}