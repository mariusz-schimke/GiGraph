using System;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public interface IDotAttributeCollection : IDotEntity, ICollection<DotAttribute>
    {
        void Set(DotAttribute attribute);
        void Set(string key, string value);

        T Get<T>(string key) where T : DotAttribute;
        bool TryGet<T>(string key, out T attribute) where T : DotAttribute;

        bool Remove(string key);
        int RemoveAll(Predicate<DotAttribute> match);
    }
}