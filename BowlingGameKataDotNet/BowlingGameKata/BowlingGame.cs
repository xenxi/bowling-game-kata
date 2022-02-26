using BowlingGameKata.Exceptions;

namespace BowlingGameKata
{
    public class BowlingGame
    {
        private ComposableFrame _rolls = ComposableFrame.Create();

        public void Roll(int pinsDown)
        {
            //EnsureGameIsNotComplete();

            _rolls.Anotate(pinsDown);
        }

        public int Score()
        {
            var scorer = new Scorer();
            _rolls.Accept(scorer);
            return scorer.Score();
        }

    }
}