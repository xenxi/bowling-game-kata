namespace BowlingGameKata
{
    public class Frame
    {
        private int _first = 0;
        private int _tries = 0;
        public int Score { get; private set; } = 0;
        public int Tries => _tries;

        public void Anotate(int pinsDown)
        {
            if (Completed())
                throw new CompletedFrame();

            Score += pinsDown;

            if (Score > 10)
                throw new InvalidNumberOfPins();

            if (_tries == 0)
                _first = pinsDown;

            _tries++;
        }

        public bool Completed() => _tries > 1 || Score == 10;

        public int SpareBonus() => _first;
    }
}