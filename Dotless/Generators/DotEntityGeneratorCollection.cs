using Dotless.Core;
using System;
using System.Collections.Generic;

namespace Dotless.Generators
{
    public class DotEntityGeneratorCollection
    {
        protected IDictionary<Type, IDotEntityGenerator> _generators { get; } = new Dictionary<Type, IDotEntityGenerator>();

        public void Clear()
        {
            _generators.Clear();
        }

        public void Add<T>(IDotEntityGenerator<T> generator)
            where T : IDotEntity
        {
            _generators.Add(typeof(T), generator);
        }

        public void Replace<T>(IDotEntityGenerator<T> generator)
            where T : IDotEntity
        {
            _generators[typeof(T)] = generator;
        }

        public IDotEntityGenerator GetForTypeOrForAnyBaseType(IDotEntity entity)
        {
            return GetForTypeOrForAnyBaseType(entity.GetType());
        }

        public IDotEntityGenerator GetForTypeOrForAnyBaseType(Type entityType)
        {
            var seek = entityType;

            do
            {
                if (_generators.ContainsKey(seek))
                {
                    return _generators[seek];
                }

                seek = seek.BaseType;
            } while (seek is { });

            throw new NotSupportedException($"No entity generator has been found for the type {entityType.FullName} and any of its base types.");
        }
    }
}
