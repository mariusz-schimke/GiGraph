namespace Gigraph.Dot.Writers.GraphWriters
{
    public interface IDotGraphWriterFactory : IDotEntityWriter
    {
        IDotGraphWriter Create(bool directed);
    }
}
