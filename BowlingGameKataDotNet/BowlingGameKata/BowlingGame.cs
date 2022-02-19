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

            _current.Anotate(pinsDown);

            _tries++;
            _frame = _tries / 2;

            if (_current.Completed())
            {
                _current = new Frame();
                _frames.Add(_current);
            }
        }

        public int Score()
        {
            var score = _frames.Sum(f => f.Score);

            var bunuses = IsStrike() ? _frames.ElementAt(1).Score : 0;

            return score + bunuses;
        }

        private void EnsureGameIsNotComplete()
        {
            if (_frame == 10)
                throw new CompletedGame();
        }

        private bool IsStrike() => _frames.First().Score == 10;
    }
}