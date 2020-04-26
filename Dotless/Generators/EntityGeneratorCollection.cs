using Dotless.Core;
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
            where T : IEntity
        {
            _generators.Add(typeof(T), generator);
        }

        public void Replace<T>(IEntityGenerator<T> generator)
            where T : IEntity
        {
            _generators[typeof(T)] = generator;
        }

        public IEntityGenerator GetForTypeOrForAnyBaseType(IEntity entity)
        {
            return GetForTypeOrForAnyBaseType(entity.GetType());
        }

        public IEntityGenerator GetForTypeOrForAnyBaseType(Type entityType)
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
