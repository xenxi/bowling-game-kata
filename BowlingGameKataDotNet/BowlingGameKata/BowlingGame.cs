﻿namespace BowlingGameKata
{
    public class BowlingGame
    {
        private ComposableFrame _current;

        public BowlingGame()
        {
            _current = new ComposableFrame();
        }

        public void Roll(int pinsDown)
        {
            EnsureGameIsNotComplete();

            _current.Anotate(pinsDown);
        }

        public int Score() => CalculeScore() + CalculeBonus();

        private int CalculeBonus()
        {
            var _frames = _current.AsFrames();
            var bunuses = 0;
            for (int i = 0; i < _frames.Count - 1; i++)
            {
                var frame = _frames[i];
                var nextFrame = _frames[i + 1];

                if (frame.HasBonus() && i < 9)
                {
                    if (frame.IsStrike())
                    {
                        bunuses += nextFrame.Score;
                        if (nextFrame.IsStrike())
                        {
                            var next = i + 2 < _frames.Count ? _frames[i + 2] : null;
                            bunuses += next?.SpareBonus() ?? 0;
                        }
                    }
                    else
                        bunuses += nextFrame.SpareBonus();
                }
            }

            return bunuses;
        }

        private int CalculeScore()
        {
            var frames = _current.AsFrames();
            return frames.Sum(f => f.Score);
        }

        private void EnsureGameIsNotComplete()
        {
            var _frames = _current.AsFrames();
            if (_frames.Count == 10)
            {
                var lastFrame = _frames[9];
                if (lastFrame.Completed() && !lastFrame.HasBonus())
                    throw new CompletedGame();
            }
            else if (_frames.Count == 11)
            {
                var lastFrame = _frames[9];
                if (!lastFrame.IsStrike() || (_frames.Last().Completed() && !_frames.Last().IsStrike()))
                    throw new CompletedGame();
            }
            else if (_frames.Count > 11)
                throw new CompletedGame();
        }
    }
}