using GiGraph.Dot.Entities;
using GiGraph.Dot.Writers.CommonEntityWriters;
using System;

namespace GiGraph.Dot.Generators.CommonEntityGenerators
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
