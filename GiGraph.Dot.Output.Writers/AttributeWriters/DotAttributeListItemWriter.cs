using GiGraph.Dot.Output.Writers.CommonEntityWriters;
using GiGraph.Dot.Output.Writers.Contexts;

namespace GiGraph.Dot.Output.Writers.AttributeWriters
{
    public class DotAttributeListItemWriter : DotEntityWriter, IDotAttributeListItemWriter
    {
        protected readonly bool _useAttributeSeparator;

        public DotAttributeListItemWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context, bool useAttributeSeparator)
            : base(tokenWriter, context)
        {
            _useAttributeSeparator = useAttributeSeparator;
        }

        public virtual IDotAttributeWriter BeginAttribute()
        {
            return new DotAttributeWriter(_tokenWriter, _context);
        }

        public virtual void EndAttribute()
        {
            if (_useAttributeSeparator)
            {
                _tokenWriter.AttributeSeparator(linger: true);
            }

            _tokenWriter.Space(linger: true);
        }

        public override IDotCommentWriter BeginComment(bool preferBlockComment)
        {
            return new DotCommentWriter(_tokenWriter, preferBlockComment: true);
        }

        public override void EndComment()
        {
            _tokenWriter.Space();
        }
    }
}