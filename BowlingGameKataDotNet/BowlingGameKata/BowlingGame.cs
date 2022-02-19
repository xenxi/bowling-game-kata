namespace BowlingGameKata
{
    public class BowlingGame
    {
        private int _score = 0;
        public int Score()
        {
            return _score;
        }

        public void Roll(int pinsDown)
        {
            _score += pinsDown;
        }
    }
}