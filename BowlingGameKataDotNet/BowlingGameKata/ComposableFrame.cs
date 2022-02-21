namespace BowlingGameKata
{
    public class ComposableFrame : Frame
    {
        private ComposableFrame? _next;

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
        public override void Anotate(int pinsDown)
        {
            if(Completed())
                Next().Anotate(pinsDown);
            else
                base.Anotate(pinsDown);
        }
        public ComposableFrame Next() => _next ??= new ComposableFrame();
    }
}