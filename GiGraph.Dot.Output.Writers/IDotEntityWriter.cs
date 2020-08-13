using GiGraph.Dot.Output.Writers.Comments;

namespace GiGraph.Dot.Output.Writers
{
    public interface IDotEntityWriter
    {
        IDotCommentWriter BeginComment(bool preferBlockComment);
        void EndComment();
    }
}