﻿namespace BowlingGameKata
{
    public class Scorer
    {
        private int _bonus = 0;
        private int _score = 0;
        private List<int> _spareBonifiedVisits = new List<int>();
        private List<int> _strikeBonifiedVisits = new List<int>();
        private int _visits = 0;

        public void Compute(Frame frame)
        {
            ComputeScore(frame);
            ComputeStrike(frame);
            ComputeSpare(frame);

            _visits++;
        }

        public int Score() => _score + _bonus;

        private void ActiveSpareBonusForNext() => _spareBonifiedVisits.Add(_visits + 1);

        private void ComputeScore(Frame frame) => _score += Scoreable() ? frame.Score : 0;

        private void ComputeSpare(Frame frame)
        {
            _bonus += IsSpareBonusActive() ? frame.SpareBonus() : 0;
            if (frame.IsSpare()) ActiveSpareBonusForNext();
        }
        private void ComputeStrike(Frame frame)
        {
            var activeBonus = IsStrikeBonusActive();
            _bonus += activeBonus ? frame.Score : 0;
            if (frame.IsStrike())
            {
                _strikeBonifiedVisits.Add(_visits + 1);

                if (activeBonus && Scoreable()) ActiveSpareBonusForNext();
            }
        }

        private bool IsSpareBonusActive() => _spareBonifiedVisits.Contains(_visits);

        private bool IsStrikeBonusActive() => _strikeBonifiedVisits.Contains(_visits);

        private bool Scoreable() => _visits < 10;
    }
}