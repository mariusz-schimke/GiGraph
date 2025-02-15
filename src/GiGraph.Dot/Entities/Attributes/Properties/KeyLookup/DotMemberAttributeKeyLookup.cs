using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

/// <summary>
///     Provides access to attribute keys assigned to class members.
/// </summary>
public class DotMemberAttributeKeyLookup
{
    protected readonly IDictionary<Module, IDictionary<int, string>> _lookup;
    protected readonly bool _useCommonBaseAsLookupKey;

    protected DotMemberAttributeKeyLookup(IDictionary<Module, IDictionary<int, string>> lookup, bool useCommonBaseAsLookupKey)
    {
        _lookup = lookup;
        _useCommonBaseAsLookupKey = useCommonBaseAsLookupKey;
    }

    /// <summary>
    ///     Creates a new lookup instance.
    /// </summary>
    /// <param name="useCommonBaseAsLookupKey">
    ///     True to use the base definitions of property accessors as their keys in the lookup. This reduces the number of items to map
    ///     when certain properties are overridden in descendant classes. In such case only their common ancestor property is mapped with
    ///     the same attribute key used for all its descendants. Pass false to use the accessor as is (to map every property accessor
    ///     separately to any attribute key).
    /// </param>
    public DotMemberAttributeKeyLookup(bool useCommonBaseAsLookupKey = true)
        : this(new Dictionary<Module, IDictionary<int, string>>(), useCommonBaseAsLookupKey)
    {
    }

    /// <summary>
    ///     Creates a new lookup initialized with content copied from another instance.
    /// </summary>
    /// <param name="source">
    ///     The source lookup to copy the content from.
    /// </param>
    public DotMemberAttributeKeyLookup(DotMemberAttributeKeyLookup source)
        : this(source._useCommonBaseAsLookupKey)
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
    ///     Adds or replaces a key for the specified property.
    /// </summary>
    /// <param name="property">
    ///     The property whose attribute key to set.
    /// </param>
    /// <param name="key">
    ///     The attribute key to assign to the specified property.
    /// </param>
    public virtual void SetPropertyKey(PropertyInfo property, string key)
    {
        SetMemberKey(property, key);
    }

    /// <summary>
    ///     Adds or replaces a key for the specified property accessor.
    /// </summary>
    /// <param name="accessor">
    ///     The property accessor whose attribute key to set.
    /// </param>
    /// <param name="key">
    ///     The attribute key to assign to the specified property accessor.
    /// </param>
    public virtual void SetPropertyAccessorKey(MethodInfo accessor, string key)
    {
        SetMemberKey(GetPropertyAccessorDefinition(accessor), key);
    }

    protected virtual void SetMemberKey(MemberInfo member, string key)
    {
        var module = GetOrAddModule(member.Module);

        // metadata token is a dictionary key, DOT attribute key is a value
        module[member.MetadataToken] = key;
    }

    /// <summary>
    ///     Tries to get an attribute key for the specified property.
    /// </summary>
    /// <param name="property">
    ///     The property whose attribute key to get.
    /// </param>
    /// <param name="key">
    ///     The output attribute key if found.
    /// </param>
    public virtual bool TryGetPropertyKey(PropertyInfo property, out string key) => TryGetMemberKey(property, out key);

    /// <summary>
    ///     Tries to get an attribute key for the specified property accessor.
    /// </summary>
    /// <param name="accessor">
    ///     The property accessor whose attribute key to get.
    /// </param>
    /// <param name="key">
    ///     The output attribute key if found.
    /// </param>
    public virtual bool TryGetPropertyAccessorKey(MethodInfo accessor, out string key) => TryGetMemberKey(GetPropertyAccessorDefinition(accessor), out key);

    protected virtual bool TryGetMemberKey(MemberInfo member, out string? key)
    {
        key = null;
        return _lookup.TryGetValue(member.Module, out var module) &&
            module.TryGetValue(member.MetadataToken, out key);
    }

    /// <summary>
    ///     Gets an attribute key for the specified property.
    /// </summary>
    /// <param name="property">
    ///     The property whose attribute key to get.
    /// </param>
    /// <exception cref="KeyNotFoundException">
    ///     Thrown when the collection does not contain a key for the specified property.
    /// </exception>
    public virtual string GetPropertyKey(PropertyInfo property) =>
        TryGetPropertyKey(property, out var key)
            ? key
            : throw new KeyNotFoundException(
                $"There is no attribute key specified for the '{property.Name}' property of the {property.DeclaringType?.Name} type."
            );

    /// <summary>
    ///     Gets an attribute key for the specified property accessor.
    /// </summary>
    /// <param name="accessor">
    ///     The property accessor whose attribute key to get.
    /// </param>
    /// <exception cref="KeyNotFoundException">
    ///     Thrown when the collection does not contain a key for the specified property accessor.
    /// </exception>
    public virtual string GetPropertyAccessorKey(MethodInfo accessor) =>
        TryGetPropertyAccessorKey(accessor, out var key)
            ? key
            : throw new KeyNotFoundException(
                $"There is no attribute key specified for the '{accessor.Name}' property accessor of the {accessor.DeclaringType?.Name} type."
            );

    protected virtual MethodInfo GetPropertyAccessorDefinition(MethodInfo accessor) =>
        _useCommonBaseAsLookupKey ? accessor.GetRuntimeBaseDefinition()! : accessor;

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
        var result = _lookup.ToDictionary<KeyValuePair<Module, IDictionary<int, string>>, Module, IDictionary<int, string>>(
            item => item.Key,
            item => new ReadOnlyDictionary<int, string>(item.Value)
        );

        return new(
            new ReadOnlyDictionary<Module, IDictionary<int, string>>(result),
            _useCommonBaseAsLookupKey
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