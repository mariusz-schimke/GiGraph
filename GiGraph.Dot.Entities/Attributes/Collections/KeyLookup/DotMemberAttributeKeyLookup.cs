using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace GiGraph.Dot.Entities.Attributes.Collections.KeyLookup
{
    /// <summary>
    ///     Provides access to attribute keys assigned to class members.
    /// </summary>
    public class DotMemberAttributeKeyLookup
    {
        protected readonly IDictionary<Module, IDictionary<int, string>> _lookup;

        protected DotMemberAttributeKeyLookup(IDictionary<Module, IDictionary<int, string>> lookup)
        {
            _lookup = lookup;
        }

        /// <summary>
        ///     Creates a new lookup instance.
        /// </summary>
        public DotMemberAttributeKeyLookup()
            : this(new Dictionary<Module, IDictionary<int, string>>())
        {
        }

        /// <summary>
        ///     Creates a new lookup initialized with content copied from another instance.
        /// </summary>
        public DotMemberAttributeKeyLookup(DotMemberAttributeKeyLookup source)
            : this()
        {
            foreach (var item in source._lookup)
            {
                _lookup.Add(item.Key, new Dictionary<int, string>(item.Value));
            }
        }

        /// <summary>
        ///     Returns the total number of mapped member keys.
        /// </summary>
        public virtual int Count => _lookup.Sum(module => module.Value.Count);

        /// <summary>
        ///     Adds or replaces a key for the specified member.
        /// </summary>
        /// <param name="member">
        ///     The member whose attribute key to set.
        /// </param>
        /// <param name="key">
        ///     The attribute key to assign to the specified member.
        /// </param>
        public virtual void Set(MemberInfo member, string key)
        {
            var module = GetOrAddModule(member.Module);

            // metadata token is a dictionary key, DOT attribute key is a value 
            module[member.MetadataToken] = key;
        }

        /// <summary>
        ///     Tries to get an attribute key for the specified member.
        /// </summary>
        /// <param name="member">
        ///     The member whose attribute key to get.
        /// </param>
        /// <param name="key">
        ///     The output attribute key if found.
        /// </param>
        public virtual bool TryGetKey(MemberInfo member, out string key)
        {
            key = null;
            return _lookup.TryGetValue(member.Module, out var module) &&
                   module.TryGetValue(member.MetadataToken, out key);
        }

        /// <summary>
        ///     Gets an attribute key for the specified member.
        /// </summary>
        /// <param name="member">
        ///     The member whose attribute key to get.
        /// </param>
        /// <exception cref="KeyNotFoundException">
        ///     Thrown when the collection does not contain a key for the specified member.
        /// </exception>
        public virtual string GetKey(MemberInfo member)
        {
            return TryGetKey(member, out var key)
                ? key
                : throw new KeyNotFoundException(
                    $"The attribute key lookup collection does not contain a key for the '{member}' member of the {member.DeclaringType} type."
                );
        }

        /// <summary>
        ///     Adds and updates (overwrites) the content of the current instance with the content of the specified instance.
        /// </summary>
        /// <param name="source">
        ///     The source lookup whose content to copy.
        /// </param>
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

        /// <summary>
        ///     Returns a copy of the current instance as a read only lookup.
        /// </summary>
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

        /// <summary>
        ///     Merges two lookup instances.
        /// </summary>
        /// <param name="base">
        ///     The initial instance to use as a base lookup.
        /// </param>
        /// <param name="source">
        ///     The source lookup whose content to copy to the base instance. Overwrites all matching items of the base instance.
        /// </param>
        public static DotMemberAttributeKeyLookup Merge(DotMemberAttributeKeyLookup @base, DotMemberAttributeKeyLookup source)
        {
            var clone = new DotMemberAttributeKeyLookup(@base);
            clone.MergeFrom(source);
            return clone;
        }
    }
}