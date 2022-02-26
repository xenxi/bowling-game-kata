using BowlingGameKata.Exceptions;

namespace BowlingGameKata
{
    public class ComposableFrame : Frame
    {
        private int _index;
        private ComposableFrame? _next;
        private ComposableFrame? _previous;

        private ComposableFrame(ComposableFrame? previous, int index)
        {
            _previous = previous;
            _index = index;
        }

        public static ComposableFrame Create() => new ComposableFrame(null, 1);

        public void Accept(Scorer scorer)
        {
            scorer.Compute(this);
            _next?.Accept(scorer);
        }

        public override void Anotate(int pinsDown)
        {
            EnsureGameIsNotComplete();
            if (Completed())
                Next().Anotate(pinsDown);
            else
                base.Anotate(pinsDown);
        }

        public IList<Frame> AsFrames()
        {
            var aux = this;
            var result = new List<Frame>();
            while (aux != null)
            {
                result.Add(aux);
                aux = aux._next;
            }
            return result;
        }

        public ComposableFrame Next() => _next ??= new ComposableFrame(this, _index + 1);

        private void EnsureGameIsNotComplete()
        {
            if (_index < 10)
                return;

            if (_index == 10)
            {
                if (Completed() && !HasBonus())
                    throw new CompletedGame();
            }
            else if (_index == 11)
            {
                var lastFrame = GetLastFrame()!;

                if (!NotPlayed() && !lastFrame.IsStrike())
                    throw new CompletedGame();
            }
            else if (_index == 12)
            {
                if (!NotPlayed() || !_previous!.HasBonus())
                    throw new CompletedGame();
            }
            else if (_index > 12)
                throw new CompletedGame();
        }

        private ComposableFrame GetLastFrame()
        {
            ComposableFrame? frame = this;
            while (frame != null && frame._index > 10)
                frame = frame._previous;

            return frame ?? this;
        }
    }
}