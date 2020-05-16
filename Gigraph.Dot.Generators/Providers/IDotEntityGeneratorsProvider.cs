using Gigraph.Dot.Entities;
using Gigraph.Dot.Generators.CommonEntityGenerators;
using Gigraph.Dot.Writers.CommonEntityWriters;
using System;

namespace Gigraph.Dot.Generators.Providers
{
    public interface IDotEntityGeneratorsProvider
    {
        TGenerator Get<TGenerator>() where TGenerator : IDotEntityGenerator;
        bool TryGet<TGenerator>(out TGenerator generator) where TGenerator : IDotEntityGenerator;

        IDotEntityGenerator GetForEntity<TRequiredWriter>(IDotEntity entity) where TRequiredWriter : IDotEntityWriter;
        IDotEntityGenerator GetForEntity<TRequiredWriter>(Type entityType) where TRequiredWriter : IDotEntityWriter;
    }
}