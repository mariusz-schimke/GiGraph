using Dotless.Core;
using Dotless.DotWriters;
using System;

namespace Dotless.EntityGenerators
{
    public interface IDotEntityGenerator
    {
        bool Supports<TWriter>(Type entityType, out bool isExactEntityTypeMatch) where TWriter : IDotWriter;

        void Write(IDotEntity entity, IDotWriter writer);
    }

    public interface IDotEntityGenerator<TEntity, TWriter> : IDotEntityGenerator
        where TEntity : IDotEntity
        where TWriter : IDotWriter
    {
        void Write(TEntity entity, TWriter writer);
    }
}
