using GiGraph.Dot.Output.Writers.AttributeWriters;
using GiGraph.Dot.Output.Writers.CommonEntityWriters;
using GiGraph.Dot.Output.Writers.Contexts;
using GiGraph.Dot.Output.Writers.EdgeWriters;
using GiGraph.Dot.Output.Writers.GlobalAttributesWriters;
using GiGraph.Dot.Output.Writers.NodeWriters;
using GiGraph.Dot.Output.Writers.SubgraphWriters;

namespace GiGraph.Dot.Output.Writers.GraphWriters
{
    public class DotGraphBodyWriter : DotEntityWriter, IDotGraphBodyWriter
    {
        public DotGraphBodyWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context, enforceBlockComment: false)
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

        public virtual IDotGlobalAttributesStatementWriter BeginGlobalAttributesSection(bool useStatementDelimiter)
        {
            return new DotGlobalAttributesStatementWriter(_tokenWriter, _context, useStatementDelimiter);
        }

        public virtual void EndGlobalAttributesSection()
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
               .Indentation(linger: true);
        }
    }
}