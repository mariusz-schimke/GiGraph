using GiGraph.Dot.Output.Writers.Attributes;
using GiGraph.Dot.Output.Writers.Attributes.Graph;
using GiGraph.Dot.Output.Writers.Edges;
using GiGraph.Dot.Output.Writers.Nodes;
using GiGraph.Dot.Output.Writers.Subgraphs;

namespace GiGraph.Dot.Output.Writers.Graphs
{
    public class DotGraphBodyWriter : DotEntityWriter, IDotGraphBodyWriter
    {
        public DotGraphBodyWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration)
            : base(tokenWriter, configuration, enforceBlockComment: true)
        {
        }

        public virtual IDotGlobalGraphAttributeStatementWriter BeginGlobalGraphAttributesSection(bool useStatementDelimiter)
        {
            return new DotGlobalGraphAttributeStatementWriter(_tokenWriter, _configuration, useStatementDelimiter);
        }

        public virtual void EndGlobalGraphAttributesSection()
        {
            EndSection();
        }

        public virtual IDotGlobalEntityAttributesStatementWriter BeginGlobalEntityAttributesSection(bool useStatementDelimiter)
        {
            return new DotGlobalEntityAttributesStatementWriter(_tokenWriter, _configuration, useStatementDelimiter);
        }

        public virtual void EndGlobalEntityAttributesSection()
        {
            EndSection();
        }

        public virtual IDotNodeStatementWriter BeginNodesSection(bool useStatementDelimiter)
        {
            return new DotNodeStatementWriter(_tokenWriter, _configuration, useStatementDelimiter);
        }

        public virtual void EndNodesSection()
        {
            EndSection();
        }

        public virtual IDotEdgeStatementWriter BeginEdgesSection(bool useStatementDelimiter)
        {
            return new DotEdgeStatementWriter(_tokenWriter, _configuration, useStatementDelimiter);
        }

        public virtual void EndEdgesSection()
        {
            EndSection();
        }

        public virtual IDotSubgraphWriterRoot BeginSubgraphsSection()
        {
            return new DotSubgraphWriterRoot(_tokenWriter, _configuration);
        }

        public virtual void EndSubgraphsSection()
        {
            EndSection();
        }

        public override void EndComment()
        {
            EmptyLine();
        }

        protected virtual void EndSection()
        {
            _tokenWriter.ClearLingerBuffer()
               .LineBreak(linger: true)
               .Indentation(linger: true);
        }
    }
}