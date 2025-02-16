using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using GiGraph.Dot.Output.Entities;
using GiGraph.Dot.Output.Writers;

namespace GiGraph.Dot.Output.Generators.Providers;

public class DotEntityGeneratorsProvider : IDotEntityGeneratorsProvider
{
    protected readonly List<IDotEntityGenerator> _generators = [];

    public virtual TGenerator Get<TGenerator>()
        where TGenerator : IDotEntityGenerator
    {
        if (!TryGet<TGenerator>(out var result))
        {
            throw new NotSupportedException($"No generator compatible with {typeof(TGenerator).FullName} has been registered.");
        }

        return result;
    }

    public virtual bool TryGet<TGenerator>([MaybeNullWhen(false)] out TGenerator generator)
        where TGenerator : IDotEntityGenerator
    {
        var generatorType = typeof(TGenerator);
        generator = (TGenerator?) _generators.FirstOrDefault(t => generatorType.IsInstanceOfType(t));

        return generator is not null;
    }

    public virtual IDotEntityGenerator<TRequiredWriter> GetForEntity<TRequiredWriter>(IDotEntity entity)
        where TRequiredWriter : IDotEntityWriter
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity), "Entity must not be null.");
        }

        IDotEntityGenerator? firstCompatibleMatch = null;

        foreach (var generator in _generators)
        {
            var supports = generator.Supports<TRequiredWriter>(entity, out var isExactEntityTypeMatch);

            if (supports && isExactEntityTypeMatch)
            {
                return (IDotEntityGenerator<TRequiredWriter>) generator;
            }

            firstCompatibleMatch ??= supports ? generator : null;
        }

        return (IDotEntityGenerator<TRequiredWriter>?) firstCompatibleMatch
         ?? throw new NotSupportedException($"No compatible generator has been registered for the entity type {entity.GetType().FullName} with the writer type {typeof(TRequiredWriter).FullName}.");
    }

    public virtual DotEntityGeneratorsProvider Register(IDotEntityGenerator generator)
    {
        // the last registered generator overrides a previously added one when they are both
        // compatible for a given element type that is later searched for
        _generators.Insert(0, generator);
        return this;
    }

    public virtual int Remove(Predicate<IDotEntityGenerator> match) => _generators.RemoveAll(match);

    public virtual void Clear()
    {
        _generators.Clear();
    }
}