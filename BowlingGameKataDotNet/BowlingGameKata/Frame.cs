namespace BowlingGameKata
{
    public class Frame
    {
        private int _tries = 0;
        public int Score { get; private set; } = 0;
        public void Anotate(int pinsDown)
        {
            if (Finished())
                throw new CompletedFrame();

            Score += pinsDown;
            _tries++;
        }

        public bool Finished() => _tries > 1;
    }
}