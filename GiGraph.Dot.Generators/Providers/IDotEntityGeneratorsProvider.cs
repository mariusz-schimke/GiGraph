using GiGraph.Dot.Entities;
using GiGraph.Dot.Generators.CommonEntityGenerators;
using GiGraph.Dot.Writers.CommonEntityWriters;
using System;

namespace GiGraph.Dot.Generators.Providers
{
    public interface IDotEntityGeneratorsProvider
    {
        TGenerator Get<TGenerator>() where TGenerator : IDotEntityGenerator;
        bool TryGet<TGenerator>(out TGenerator generator) where TGenerator : IDotEntityGenerator;

        IDotEntityGenerator GetForEntity<TRequiredWriter>(IDotEntity entity) where TRequiredWriter : IDotEntityWriter;
        IDotEntityGenerator GetForEntity<TRequiredWriter>(Type entityType) where TRequiredWriter : IDotEntityWriter;
    }
}