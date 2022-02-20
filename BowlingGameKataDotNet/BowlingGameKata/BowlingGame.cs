namespace BowlingGameKata
{
    public class BowlingGame
    {
        private Frame _current;
        private int _frame = 0;
        private IList<Frame> _frames;
        private int _tries = 0;

        public BowlingGame()
        {
            _current = new Frame();
            _frames = new List<Frame> { _current };

            _frame = 0;
            _tries = 0;
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

            _tries++;
            _frame = _tries / 2;
        }

        public int Score()
        {
            var score = _frames.Sum(f => f.Score);

            var bunuses = 0;
            for (int i = 0; i < _frames.Count - 1; i++)
            {
                var frame = _frames[i];
                var nextFrame = _frames[i + 1];

                if (IsStrike(frame) && i < 9)
                    bunuses += nextFrame.SpareBonus();
            }
            return score + bunuses;
        }

        private void EnsureGameIsNotComplete()
        {
            if (_frames.Count > 9)
            {
                var lastFrame = _frames[9];
                if (lastFrame.Completed() && !IsStrike(lastFrame))
                    throw new CompletedGame();
            }
        }

        private bool IsStrike(Frame frame) => frame.Score == 10;
    }
}