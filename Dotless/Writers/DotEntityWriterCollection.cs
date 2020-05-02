using Dotless.Core;
using System;
using System.Collections.Generic;

namespace Dotless.Writers
{
    // TODO: wyodrębnić interfejs
    public class DotEntityWriterCollection
    {
        protected IDictionary<Type, IDotEntityWriter> _generators { get; } = new Dictionary<Type, IDotEntityWriter>();

        public void Clear()
        {
            _generators.Clear();
        }

        public void Add<T>(IDotEntityWriter<T> generator)
            where T : IDotEntity
        {
            _generators.Add(typeof(T), generator);
        }

        public void Replace<T>(IDotEntityWriter<T> generator)
            where T : IDotEntity
        {
            _generators[typeof(T)] = generator;
        }

        public IDotEntityWriter GetForTypeOrForAnyBaseType(IDotEntity entity)
        {
            return GetForTypeOrForAnyBaseType(entity.GetType());
        }

        public IDotEntityWriter GetForTypeOrForAnyBaseType(Type entityType)
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
