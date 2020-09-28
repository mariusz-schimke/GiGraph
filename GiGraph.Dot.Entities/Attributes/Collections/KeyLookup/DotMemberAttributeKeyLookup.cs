using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace GiGraph.Dot.Entities.Attributes.Collections.KeyLookup
{
    public class DotMemberAttributeKeyLookup
    {
        protected readonly IDictionary<Module, IDictionary<int, string>> _lookup;

        protected DotMemberAttributeKeyLookup(IDictionary<Module, IDictionary<int, string>> lookup)
        {
            _lookup = lookup;
        }

        public DotMemberAttributeKeyLookup()
            : this(new Dictionary<Module, IDictionary<int, string>>())
        {
        }

        public DotMemberAttributeKeyLookup(DotMemberAttributeKeyLookup source)
            : this()
        {
            foreach (var item in source._lookup)
            {
                _lookup.Add(item.Key, new Dictionary<int, string>(item.Value));
            }
        }

        public virtual int Count => _lookup.Sum(module => module.Value.Count);

        public virtual void Set(MemberInfo member, string key)
        {
            var module = GetOrAddModule(member.Module);

            // metadata token is a dictionary key, DOT attribute key is a value 
            module[member.MetadataToken] = key;
        }

        public virtual bool TryGetKey(MemberInfo member, out string key)
        {
            key = null;
            return _lookup.TryGetValue(member.Module, out var module) &&
                   module.TryGetValue(member.MetadataToken, out key);
        }

        public virtual void MergeFrom(DotMemberAttributeKeyLookup source)
        {
            foreach (var sourceModule in source._lookup)
            {
                var module = GetOrAddModule(sourceModule.Key);

                foreach (var sourceItem in sourceModule.Value)
                {
                    // metadata token is a key, DOT attribute key is a value 
                    module[sourceItem.Key] = sourceItem.Value;
                }
            }
        }

        public virtual DotMemberAttributeKeyLookup ToReadOnly()
        {
            var result = new Dictionary<Module, IDictionary<int, string>>();
            foreach (var item in _lookup)
            {
                result.Add(item.Key, new ReadOnlyDictionary<int, string>(item.Value));
            }

            return new DotMemberAttributeKeyLookup(
                new ReadOnlyDictionary<Module, IDictionary<int, string>>(result)
            );
        }

        protected virtual IDictionary<int, string> GetOrAddModule(Module module)
        {
            if (!_lookup.TryGetValue(module, out var result))
            {
                // metadata token uniquely identifies a member within a module
                return _lookup[module] = new Dictionary<int, string>();
            }

            return result;
        }

        public static DotMemberAttributeKeyLookup Merge(DotMemberAttributeKeyLookup source, DotMemberAttributeKeyLookup other)
        {
            var clone = new DotMemberAttributeKeyLookup(source);
            clone.MergeFrom(other);
            return clone;
        }
    }
}