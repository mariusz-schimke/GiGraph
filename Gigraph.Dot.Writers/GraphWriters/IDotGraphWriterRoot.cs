namespace Gigraph.Dot.Writers.GraphWriters
{
    public interface IDotGraphWriterRoot : IDotEntityWriter
    {
        IDotGraphWriter BeginGraph(bool directed);
    }
}
