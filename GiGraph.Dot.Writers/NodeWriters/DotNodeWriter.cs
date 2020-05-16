using GiGraph.Dot.Writers.CommonEntityWriters;
using GiGraph.Dot.Writers.Contexts;

namespace GiGraph.Dot.Writers.NodeWriters
{
    public class DotNodeWriter : DotEntityWithAttributeListWriter, IDotNodeWriter
    {
        public DotNodeWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context)
        {
        }

        public virtual void WriteNodeIdentifier(string id, bool quote)
        {
            _tokenWriter.Identifier(id, quote)
                        .Space(linger: true);
        }
    }
}
