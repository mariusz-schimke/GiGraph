using Dotless.Core;
using Dotless.DotWriters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dotless.EntityGenerators
{
    // TODO: wyodrębnić interfejs
    public class DotEntityGeneratorsProvider
    {
        protected List<IDotEntityGenerator> _generators { get; } = new List<IDotEntityGenerator>();

        public void Register(IDotEntityGenerator generator)
        {
            _generators.Add(generator);
        }

        public int Remove(Predicate<IDotEntityGenerator> match)
        {
            return _generators.RemoveAll(match);
        }

        public void Clear()
        {
            _generators.Clear();
        }

        public IDotEntityGenerator GetForEntity<TRequiredWriter>(IDotEntity entity)
            where TRequiredWriter : IDotWriter
        {
            return GetForEntity<TRequiredWriter>(entity.GetType());
        }

        public IDotEntityGenerator GetForEntity<TRequiredWriter>(Type entityType)
            where TRequiredWriter : IDotWriter
        {
            var searchedEntityType = entityType;

            do
            {
                if (_generators.FirstOrDefault(g => g.Supports<TRequiredWriter>(searchedEntityType, exactEntityTypeMatching: true)) is { } result)
                {
                    return result;
                }

                searchedEntityType = searchedEntityType.BaseType;

            } while (searchedEntityType is { });

            throw new NotSupportedException($"No generator has been registered for the entity type {entityType.FullName} nor for any of its base types, with the supported writer type {typeof(TRequiredWriter).FullName}.");
        }
    }
}
