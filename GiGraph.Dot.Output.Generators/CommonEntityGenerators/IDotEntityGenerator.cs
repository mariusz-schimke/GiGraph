using GiGraph.Dot.Entities;
using GiGraph.Dot.Output.Writers.CommonEntityWriters;
using System;

namespace GiGraph.Dot.Output.Generators.CommonEntityGenerators
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
