using GiGraph.Dot.Writers.AttributeWriters;
using GiGraph.Dot.Writers.CommonEntityWriters;
using GiGraph.Dot.Writers.Contexts;
using GiGraph.Dot.Writers.EdgeWriters;
using GiGraph.Dot.Writers.EntityDefaultsWriter;
using GiGraph.Dot.Writers.NodeWriters;
using GiGraph.Dot.Writers.SubgraphWriters;

namespace GiGraph.Dot.Writers.GraphWriters
{
    public class DotGraphBodyWriter : DotEntityWriter, IDotGraphBodyWriter
    {
        public DotGraphBodyWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context)
        {
        }

        public virtual IDotAttributeStatementWriter BeginAttributesSection(bool useStatementDelimiter)
        {
            return new DotAttributeStatementWriter(_tokenWriter, _context, useStatementDelimiter);
        }

        public virtual void EndAttributesSection()
        {
            EndSection();
        }

        public virtual IDotEntityDefaultsStatementWriter BeginDefaultsSection(bool useStatementDelimiter)
        {
            return new DotEntityDefaultsStatementWriter(_tokenWriter, _context, useStatementDelimiter);
        }

        public virtual void EndDefaultsSection()
        {
            EndSection();
        }

        public virtual IDotNodeStatementWriter BeginNodesSection(bool useStatementDelimiter)
        {
            return new DotNodeStatementWriter(_tokenWriter, _context, useStatementDelimiter);
        }

        public virtual void EndNodesSection()
        {
            EndSection();
        }

        public virtual IDotEdgeStatementWriter BeginEdgesSection(bool useStatementDelimiter)
        {
            return new DotEdgeStatementWriter(_tokenWriter, _context, useStatementDelimiter);
        }

        public virtual void EndEdgesSection()
        {
            EndSection();
        }

        public virtual IDotSubgraphWriterRoot BeginSubgraphsSection()
        {
            return new DotSubgraphWriterRoot(_tokenWriter, _context);
        }

        public virtual void EndSubgraphsSection()
        {
            EndSection();
        }

        protected virtual void EndSection()
        {
            _tokenWriter.ClearLingerBuffer()
                        .LineBreak(linger: true)
                        .Indentation(_context.Level, linger: true);
        }
    }
}
