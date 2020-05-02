using Dotless.Core;
using Dotless.DotWriters;

namespace Dotless.Writers
{
    public interface IDotEntityWriter
    {
        void Write(IDotEntity entity, DotStringWriter writer);
    }

    public interface IDotEntityWriter<T> : IDotEntityWriter
        where T : IDotEntity
    {
        void Write(T entity, DotStringWriter writer);
    }
}
