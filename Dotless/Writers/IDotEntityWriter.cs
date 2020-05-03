using Dotless.Core;
using Dotless.DotWriters;

namespace Dotless.Writers
{
    public interface IDotEntityWriter
    {
        bool Write(IDotEntity entity, DotStringWriter writer);
    }

    public interface IDotEntityWriter<T> : IDotEntityWriter
        where T : IDotEntity
    {
        bool Write(T entity, DotStringWriter writer);
    }
}
