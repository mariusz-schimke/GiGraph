using Gigraph.Dot.Entities;
using Gigraph.Dot.Writers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gigraph.Dot.Generators
{
    // TODO: wyodrębnić interfejs
    public class DotEntityGeneratorsProvider
    {
        protected readonly List<IDotEntityGenerator> _generators = new List<IDotEntityGenerator>();

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

        public virtual TGenerator Get<TGenerator>()
            where TGenerator : IDotEntityGenerator
        {
            if (!TryGet<TGenerator>(out var result))
            {
                throw new KeyNotFoundException($"No generator compatible with {typeof(TGenerator).FullName} has been registered.");
            }

            return result;
        }

        public virtual bool TryGet<TGenerator>(out TGenerator generator)
            where TGenerator : IDotEntityGenerator
        {
            var generatorType = typeof(TGenerator);
            generator = (TGenerator)_generators.LastOrDefault(t => generatorType.IsAssignableFrom(t.GetType()));

            return generator is { };
        }

        public virtual IDotEntityGenerator GetForEntity<TRequiredWriter>(IDotEntity entity)
            where TRequiredWriter : IDotEntityWriter
        {
            return GetForEntity<TRequiredWriter>(entity.GetType());
        }

        public virtual IDotEntityGenerator GetForEntity<TRequiredWriter>(Type entityType)
            where TRequiredWriter : IDotEntityWriter
        {
            var lastExactMatch = _generators.LastOrDefault(g => g.Supports<TRequiredWriter>(entityType, out var isExactEntityTypeMatch) && isExactEntityTypeMatch);
            var lastCompatibleMatch = _generators.LastOrDefault(g => g.Supports<TRequiredWriter>(entityType, out var isExactEntityTypeMatch) && !isExactEntityTypeMatch);

            return lastExactMatch
                ?? lastCompatibleMatch
                ?? throw new NotSupportedException($"No compatible generator has been registered for the entity type {entityType.FullName} with the writer type {typeof(TRequiredWriter).FullName}.");
        }
    }
}
