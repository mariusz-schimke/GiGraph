using GiGraph.Dot.Output.Writers.Attributes;
using GiGraph.Dot.Output.Writers.Clusters;
using GiGraph.Dot.Output.Writers.Edges;
using GiGraph.Dot.Output.Writers.Graphs.Attributes;
using GiGraph.Dot.Output.Writers.Nodes;
using GiGraph.Dot.Output.Writers.Subgraphs;
using GiGraph.Dot.Output.Writers.TokenWriter;

namespace GiGraph.Dot.Output.Writers.Graphs;

public class DotGraphBodyWriter : DotEntityWriter, IDotGraphBodyWriter
{
    public DotGraphBodyWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration)
        : base(tokenWriter, configuration, enforceBlockComment: true)
    {
    }

    public virtual IDotGlobalGraphAttributeStatementWriter BeginGlobalGraphAttributesSection(bool useStatementDelimiter) => new DotGlobalGraphAttributeStatementWriter(_tokenWriter, _configuration, useStatementDelimiter);

    public virtual void EndGlobalGraphAttributesSection()
    {
        EndSection();
    }

    public virtual IDotGlobalEntityAttributesStatementWriter BeginGlobalEntityAttributesSection(bool useStatementDelimiter) => new DotGlobalEntityAttributesStatementWriter(_tokenWriter, _configuration, useStatementDelimiter);

    public virtual void EndGlobalEntityAttributesSection()
    {
        EndSection();
    }

    public virtual IDotNodeStatementWriter BeginNodesSection(bool useStatementDelimiter) => new DotNodeStatementWriter(_tokenWriter, _configuration, useStatementDelimiter);

    public virtual void EndNodesSection()
    {
        EndSection();
    }

    public virtual IDotEdgeStatementWriter BeginEdgesSection(bool useStatementDelimiter) => new DotEdgeStatementWriter(_tokenWriter, _configuration, useStatementDelimiter);

    public virtual void EndEdgesSection()
    {
        EndSection();
    }

    public virtual IDotSubgraphWriterRoot BeginSubgraphsSection() => new DotSubgraphWriterRoot(_tokenWriter, _configuration);

    public virtual void EndSubgraphsSection()
    {
        EndSection();
    }

    public virtual IDotSubgraphWriterRoot BeginClustersSection() => new DotClusterWriterRoot(_tokenWriter, _configuration);

    public virtual void EndClustersSection()
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
            .NewLine(linger: true);
    }
}