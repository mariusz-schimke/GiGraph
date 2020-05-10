using Gigraph.Dot.Writers.AttributeWriters;
using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers
{
    public abstract class DotEntityWithAttributeListWriter : DotEntityWriter
    {
        public DotEntityWithAttributeListWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context)
        {
        }

        public virtual IDotAttributeCollectionWriter BeginAttributeList(bool useAttributeSeparator)
        {
            _tokenWriter.AttributeListStart(linger: true)
                   .Space(linger: true);

            return new DotAttributeListWriter(_tokenWriter, _context.NextLevel(), useAttributeSeparator);
        }

        public virtual void EndAttributeList(int attributeCount)
        {
            _tokenWriter.ClearLingerBuffer();

            if (attributeCount > 0)
            {
                _tokenWriter.Space()
                       .AttributeListEnd();
            }
        }
    }
}
