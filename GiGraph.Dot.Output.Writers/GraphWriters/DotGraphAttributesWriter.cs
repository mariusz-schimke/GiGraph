using GiGraph.Dot.Output.Writers.CommonEntityWriters;
using GiGraph.Dot.Output.Writers.Contexts;

namespace GiGraph.Dot.Output.Writers.GraphWriters
{
    public class DotGraphAttributesWriter : DotEntityWithAttributeListWriter, IDotGraphAttributesWriter
    {
        public DotGraphAttributesWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context)
        {
        }

        public virtual void WriteGraphKeyword()
        {
            _tokenWriter.Keyword("graph")
                        .Space();
        }
    }
}