namespace Dotless.DotWriters
{
    public interface IDotGraphWriterFactory : IDotEntityWriter
    {
        IDotGraphWriter Create(bool directed);
    }
}
