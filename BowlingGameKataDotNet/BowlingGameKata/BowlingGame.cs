using BowlingGameKata.Exceptions;

namespace BowlingGameKata
{
    public class BowlingGame
    {
        private ComposableFrame _rolls = new ComposableFrame();

        public void Roll(int pinsDown)
        {
            EnsureGameIsNotComplete();

            _rolls.Anotate(pinsDown);
        }

        public int Score()
        {
            var scorer = new Scorer();
            _rolls.Accept(scorer);
            return scorer.Score();
        }

        private void EnsureGameIsNotComplete()
        {
            var _frames = _rolls.AsFrames();
            if (_frames.Count == 10)
            {
                var lastFrame = _frames[9];
                if (lastFrame.Completed() && !lastFrame.HasBonus())
                    throw new CompletedGame();
            }
            else if (_frames.Count == 11)
            {
                var lastFrame = _frames[9];
                if (!lastFrame.IsStrike() || (_frames.Last().Completed() && !_frames.Last().IsStrike()))
                    throw new CompletedGame();
            }
            else if (_frames.Count > 11)
                throw new CompletedGame();
        }
    }
}