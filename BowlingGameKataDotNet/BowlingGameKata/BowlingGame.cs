namespace BowlingGameKata
{
    public class BowlingGame
    {
        private Frame _current;
        private Frame _first;
        private int _frame = 0;
        private Frame _second;
        private int _tries = 0;

        public BowlingGame()
        {
            _first = new Frame();
            _second = new Frame();
            _current = _first;

            _frame = 0;
            _tries = 0;
        }

        public void Roll(int pinsDown)
        {
            EnsureGameIsNotComplete();

            _current.Anotate(pinsDown);

            _tries++;
            _frame = _tries / 2;

            if (_current.Finished())
                _current = _second;
        }

        public int Score()
        {
            var score = _first.Score + _second.Score;
            var bunuses = IsStrike() ? _second.Score : 0;

            return score + bunuses;
        }

        private void EnsureGameIsNotComplete()
        {
            if (_frame == 10)
                throw new CompletedGame();
        }

        private bool IsStrike() => _first.Score == 10;
    }
}