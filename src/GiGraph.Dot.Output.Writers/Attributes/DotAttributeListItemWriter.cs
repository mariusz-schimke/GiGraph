namespace GiGraph.Dot.Output.Writers.Attributes
{
    public class DotAttributeListItemWriter : DotEntityWriter, IDotAttributeListItemWriter
    {
        protected readonly bool _useAttributeSeparator;

        public DotAttributeListItemWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration, bool useAttributeSeparator)
            : base(tokenWriter, configuration, enforceBlockComment: true)
        {
            _useAttributeSeparator = useAttributeSeparator;
        }

        public virtual IDotAttributeWriter BeginAttribute()
        {
            return new DotAttributeWriter(_tokenWriter, _configuration);
        }

        public virtual void EndAttribute()
        {
            if (_useAttributeSeparator)
            {
                _tokenWriter.AttributeSeparator(linger: true);
            }

            _tokenWriter.NewLine(linger: true);
        }

        public override void EndComment()
        {
            EmptyLine();
        }
    }
}