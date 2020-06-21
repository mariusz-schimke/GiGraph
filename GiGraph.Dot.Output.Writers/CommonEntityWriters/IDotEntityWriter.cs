namespace GiGraph.Dot.Output.Writers.CommonEntityWriters
{
    public interface IDotEntityWriter
    {
        IDotCommentWriter BeginComment(bool preferBlockComment);
        void EndComment();
    }
}