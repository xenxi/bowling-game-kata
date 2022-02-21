namespace BowlingGameKata
{
    public class Scorer
    {
        private int _score = 0;
        private int _bonus = 0;
        public void Compute(ComposableFrame composableFrame)
        {
            _score += composableFrame.Score;
        }
        public int Score => _score;
    }
}