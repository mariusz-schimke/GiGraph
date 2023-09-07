using GiGraph.Dot.Output.Entities;
using GiGraph.Dot.Output.Writers;

namespace GiGraph.Dot.Output.Generators.Providers;

public interface IDotEntityGeneratorsProvider
{
    TGenerator Get<TGenerator>()
        where TGenerator : IDotEntityGenerator;

    bool TryGet<TGenerator>(out TGenerator generator)
        where TGenerator : IDotEntityGenerator;

    IDotEntityGenerator<TRequiredWriter> GetForEntity<TRequiredWriter>(IDotEntity entity)
        where TRequiredWriter : IDotEntityWriter;
}