namespace Gigraph.Dot.Writers
{
    public interface IDotGraphWriterFactory : IDotEntityWriter
    {
        IDotGraphWriter Create(bool directed);
    }
}
