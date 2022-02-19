namespace BowlingGameKata
{
    public class BowlingGame
    {
        private int _frame = 0;
        private int _score = 0;
        private int _tries = 0;

        public void Roll(int pinsDown)
        {
            if (_frame == 10)
                throw new CompletedGame();

            _score += pinsDown;

            _tries++;
            _frame = _tries / 2;
        }

        public int Score()
        {
            return _score;
        }
    }
}