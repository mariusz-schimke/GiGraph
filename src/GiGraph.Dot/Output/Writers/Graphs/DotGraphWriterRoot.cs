using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Comments;
using GiGraph.Dot.Output.Writers.TokenWriter;

namespace GiGraph.Dot.Output.Writers.Graphs;

public class DotGraphWriterRoot(DotTokenWriter tokenWriter, DotFormattingOptions formattingOptions) : IDotGraphWriterRoot
{
    protected bool _initializeIndentation = true;

    public virtual IDotGraphWriter BeginGraph(bool directed)
    {
        InitializeIndentation();
        return new DotGraphWriter(tokenWriter, new DotEntityWriterConfiguration(directed, formattingOptions));
    }

    public virtual void EndGraph()
    {
    }

    public virtual IDotCommentWriter BeginComment(bool preferBlockComment)
    {
        InitializeIndentation();
        return new DotCommentWriter(tokenWriter, preferBlockComment);
    }

    public virtual void EndComment()
    {
        tokenWriter.NewLine(linger: true, enforceLineBreak: true);
    }

    protected virtual void InitializeIndentation()
    {
        if (_initializeIndentation)
        {
            tokenWriter.Indentation(linger: true);
            _initializeIndentation = false;
        }
    }
}