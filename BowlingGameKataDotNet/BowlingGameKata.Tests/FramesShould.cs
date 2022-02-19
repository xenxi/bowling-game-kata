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
    }
}