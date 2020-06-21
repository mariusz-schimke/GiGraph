namespace GiGraph.Dot.Output.Writers.CommonEntityWriters
{
    public interface IDotEntityWriter
    {
        IDotCommentWriter BeginComment(string comment, bool preferBlockComment);
        void EndComment();
    }
}