using GiGraph.Dot.Output.Writers.TokenWriter;

namespace GiGraph.Dot.Output.Writers.Graphs;

public class DotGraphWriter : DotGraphBlockWriter, IDotGraphWriter
{
    public DotGraphWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration)
        : base(tokenWriter, configuration)
    {
    }

    public virtual void WriteGraphDeclaration(string? id, bool strict, bool quoteId)
    {
        if (strict)
        {
            _tokenWriter.Keyword("strict")
                .Space();
        }

        _tokenWriter.Keyword(_configuration.IsDirectedGraph ? "digraph" : "graph");

        if (!string.IsNullOrEmpty(id))
        {
            _tokenWriter.Space()
                .Identifier(id!, quoteId);
        }

        _tokenWriter.NewLine();
    }
}