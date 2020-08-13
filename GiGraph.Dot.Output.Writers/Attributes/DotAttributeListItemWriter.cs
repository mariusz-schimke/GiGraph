namespace GiGraph.Dot.Output.Writers.Attributes
{
    public class DotAttributeListItemWriter : DotEntityWriter, IDotAttributeListItemWriter
    {
        protected readonly bool _useAttributeSeparator;

        public DotAttributeListItemWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context, bool useAttributeSeparator)
            : base(tokenWriter, context, enforceBlockComment: true)
        {
            _useAttributeSeparator = useAttributeSeparator;
        }

        public virtual IDotAttributeWriter BeginAttribute()
        {
            return new DotAttributeWriter(_tokenWriter, _context, enforceBlockComment: true);
        }

        public virtual void EndAttribute()
        {
            if (_useAttributeSeparator)
            {
                _tokenWriter.AttributeSeparator(linger: true);
            }

            _tokenWriter.Space(linger: true);
        }

        public override void EndComment()
        {
            _tokenWriter.Space();
        }
    }
}