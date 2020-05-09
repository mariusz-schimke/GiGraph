using Gigraph.Dot.Entities;
using Gigraph.Dot.Writers;
using System;

namespace Gigraph.Dot.Generators
{
    public interface IDotEntityGenerator
    {
        bool Supports<TWriter>(Type entityType, out bool isExactEntityTypeMatch) where TWriter : IDotEntityWriter;

        void Generate(IDotEntity entity, IDotEntityWriter writer);
    }

    public interface IDotEntityGenerator<TEntity, TWriter> : IDotEntityGenerator
        where TEntity : IDotEntity
        where TWriter : IDotEntityWriter
    {
        void Generate(TEntity entity, TWriter writer);
    }
}
