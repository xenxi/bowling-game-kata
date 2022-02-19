namespace BowlingGameKata
{
    public class Frame
    {
        public int Score { get; private set; } = 0;
        private int _tries = 0;
        public void Anotate(int pinsDown)
        {
            Score += pinsDown;
            _tries++;
        }

        public bool Finished() => _tries > 1;
    }
}