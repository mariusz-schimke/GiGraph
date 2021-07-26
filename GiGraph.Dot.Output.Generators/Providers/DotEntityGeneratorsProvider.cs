using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Output.Writers;

namespace GiGraph.Dot.Output.Generators.Providers
{
    public class DotEntityGeneratorsProvider : IDotEntityGeneratorsProvider
    {
        protected readonly List<IDotEntityGenerator> _generators = new();

        public virtual TGenerator Get<TGenerator>()
            where TGenerator : IDotEntityGenerator
        {
            if (!TryGet<TGenerator>(out var result))
            {
                throw new NotSupportedException($"No generator compatible with {typeof(TGenerator).FullName} has been registered.");
            }

            return result;
        }

        public virtual bool TryGet<TGenerator>(out TGenerator generator)
            where TGenerator : IDotEntityGenerator
        {
            var generatorType = typeof(TGenerator);
            generator = (TGenerator) _generators.LastOrDefault(t => generatorType.IsAssignableFrom(t.GetType()));

            return generator is { };
        }

        public virtual IDotEntityGenerator<TRequiredWriter> GetForEntity<TRequiredWriter>(IDotEntity entity)
            where TRequiredWriter : IDotEntityWriter
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity must not be null.");
            }

            var lastExactMatch = _generators.LastOrDefault(g => g.Supports<TRequiredWriter>(entity, out var isExactEntityTypeMatch) && isExactEntityTypeMatch);
            var lastCompatibleMatch = _generators.LastOrDefault(g => g.Supports<TRequiredWriter>(entity, out var isExactEntityTypeMatch) && !isExactEntityTypeMatch);

            return (IDotEntityGenerator<TRequiredWriter>) lastExactMatch
             ?? (IDotEntityGenerator<TRequiredWriter>) lastCompatibleMatch
             ?? throw new NotSupportedException($"No compatible generator has been registered for the entity type {entity.GetType().FullName} with the writer type {typeof(TRequiredWriter).FullName}.");
        }

        public virtual DotEntityGeneratorsProvider Register(IDotEntityGenerator generator)
        {
            _generators.Add(generator);
            return this;
        }

        public virtual int Remove(Predicate<IDotEntityGenerator> match)
        {
            return _generators.RemoveAll(match);
        }

        public virtual void Clear()
        {
            _generators.Clear();
        }
    }
}