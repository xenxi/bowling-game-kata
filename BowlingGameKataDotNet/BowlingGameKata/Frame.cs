namespace BowlingGameKata
{
    public class Frame
    {
        private int _tries = 0;
        public int Score { get; private set; } = 0;

        public void Anotate(int pinsDown)
        {
            if (Completed())
                throw new CompletedFrame();

            Score += pinsDown;

            if (Score > 10)
                throw new InvalidNumberOfPins();

            _tries++;
        }

        public bool Completed() => _tries > 1;

        public int SpareBonus()
        {
            return 5;
        }
    }
}