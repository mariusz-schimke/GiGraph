using System;
using System.Collections.Generic;

namespace Dotless.Generators
{
    public class EntityGeneratorCollection
    {
        protected IDictionary<Type, IEntityGenerator> _generators { get; } = new Dictionary<Type, IEntityGenerator>();

        public void Clear()
        {
            _generators.Clear();
        }

        public void Add<T>(IEntityGenerator<T> generator)
        {
            _generators.Add(typeof(T), generator);
        }

        public void Replace<T>(IEntityGenerator<T> generator)
        {
            _generators[typeof(T)] = generator;
        }

        public IEntityGenerator GetForType(Type entityType)
        {
            var seek = entityType;

            while (seek is { })
            {
                if (_generators.ContainsKey(entityType))
                {
                    return _generators[seek];
                }

                seek = seek.BaseType;
            }

            throw new NotSupportedException($"No entity generator has been found for type {entityType.FullName} and any of its base types.");
        }
    }
}
