namespace BowlingGameKata
{
    public class BowlingGame
    {
        private Frame _current;
        private IList<Frame> _frames;

        public BowlingGame()
        {
            _current = new Frame();
            _frames = new List<Frame> { _current };
        }

        public void Roll(int pinsDown)
        {
            EnsureGameIsNotComplete();

            if (_current.Completed())
            {
                _current = new Frame();
                _frames.Add(_current);
            }

            _current.Anotate(pinsDown);
        }

        public int Score()
        {
            var score = _frames.Sum(f => f.Score);

            var bunuses = 0;
            for (int i = 0; i < _frames.Count - 1; i++)
            {
                var frame = _frames[i];
                var nextFrame = _frames[i + 1];

                if (HasBonus(frame) && i < 9)
                {
                    if (IsFullStrike(frame))
                        bunuses += nextFrame.Score;
                    else
                        bunuses += nextFrame.SpareBonus();
                }
            }
            return score + bunuses;
        }

        private void EnsureGameIsNotComplete()
        {
            if (_frames.Count == 10)
            {
                var lastFrame = _frames[9];
                if (lastFrame.Completed() && !HasBonus(lastFrame))
                    throw new CompletedGame();
            }
            else if (_frames.Count > 10)
                throw new CompletedGame();
        }

        private bool IsFullStrike(Frame frame) => HasBonus(frame) && frame.Tries == 1;

        private bool HasBonus(Frame frame) => frame.Score == 10;
    }
}