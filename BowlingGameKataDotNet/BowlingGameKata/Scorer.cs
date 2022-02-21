namespace BowlingGameKata
{
    public class Scorer
    {
        private const int MAX_SCOREABLE_FRAME = 10;
        private int _bonus = 0;
        private List<int> _nodesWithSpareBonusActive = new List<int>();
        private List<int> _nodesWithStrikeBonusActive = new List<int>();
        private int _score = 0;
        private int _visits = 0;
        public int Bonus => _bonus;

        public int Score() => _score + _bonus;

        public void Compute(Frame frame)
        {
            _score += Scoreable() ? frame.Score : 0;

            ComputeStrike(frame);
            ComputeSpare(frame);

            _visits++;
        }

        private void ComputeSpare(Frame frame)
        {
            _bonus += IsSpareBonusActive() ? frame.SpareBonus() : 0;
            if (frame.IsSpare())
                _nodesWithSpareBonusActive.Add(_visits + 1);
        }

        private void ComputeStrike(Frame frame)
        {
            var activeBonus = IsStrikeBonusActive();
            _bonus += activeBonus ? frame.Score : 0;
            if (frame.IsStrike())
            {
                _nodesWithStrikeBonusActive.Add(_visits + 1);

                if (activeBonus && Scoreable()) _nodesWithSpareBonusActive.Add(_visits + 1);
            }
        }

        private bool IsSpareBonusActive() => _nodesWithSpareBonusActive.Contains(_visits);

        private bool IsStrikeBonusActive() => _nodesWithStrikeBonusActive.Contains(_visits);

        private bool Scoreable() => _visits < MAX_SCOREABLE_FRAME;
    }
}