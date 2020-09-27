using System.Collections.Generic;
using System.Reflection;

namespace GiGraph.Dot.Entities.Attributes.Collections.KeyLookup
{
    public class DotMemberAttributeKeyLookup
    {
        protected readonly Dictionary<Module, Dictionary<int, string>> _lookup = new Dictionary<Module, Dictionary<int, string>>();

        public DotMemberAttributeKeyLookup()
        {
        }

        public DotMemberAttributeKeyLookup(DotMemberAttributeKeyLookup source)
        {
            foreach (var item in source._lookup)
            {
                _lookup.Add(item.Key, new Dictionary<int, string>(item.Value));
            }
        }

        public virtual void Update(MemberInfo member, string key)
        {
            var module = GetOrAddModule(member.Module);

            // metadata token is a dictionary key, DOT attribute key is a value 
            module[member.MetadataToken] = key;
        }

        public virtual void UpdateFrom(DotMemberAttributeKeyLookup source)
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

        protected virtual Dictionary<int, string> GetOrAddModule(Module module)
        {
            if (!_lookup.TryGetValue(module, out var result))
            {
                // metadata token uniquely identifies a member within a module
                result = _lookup[module] = new Dictionary<int, string>();
            }

            return result;
        }

        public virtual bool TryGetKey(MemberInfo member, out string key)
        {
            key = null;
            return _lookup.TryGetValue(member.Module, out var module) &&
                   module.TryGetValue(member.MetadataToken, out key);
        }
    }
}