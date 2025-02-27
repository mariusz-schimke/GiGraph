using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Reflection;

namespace GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

/// <summary>
///     Provides access to attribute keys assigned to class members.
/// </summary>
public class DotMemberAttributeKeyLookup
{
    protected readonly IDictionary<MethodInfo, string> _lookup;

    protected DotMemberAttributeKeyLookup(IDictionary<MethodInfo, string> lookup)
    {
        _lookup = lookup;
    }

    /// <summary>
    ///     Creates a new lookup instance.
    /// </summary>
    public DotMemberAttributeKeyLookup()
        : this(new Dictionary<MethodInfo, string>())
    {
    }

    /// <summary>
    ///     Creates a new lookup initialized with content copied from another instance.
    /// </summary>
    /// <param name="source">
    ///     The source lookup to copy the content from.
    /// </param>
    public DotMemberAttributeKeyLookup(DotMemberAttributeKeyLookup source)
        : this(new Dictionary<MethodInfo, string>(source._lookup))
    {
    }

    /// <summary>
    ///     Returns the total number of mapped member keys.
    /// </summary>
    public virtual int Count => _lookup.Count;

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
        if (_lookup.ContainsKey(accessor))
        {
            throw new ArgumentException(
                $"The attribute key for the '{accessor.Name}' property accessor of the {accessor.DeclaringType?.Name} type is already set."
            );
        }

        _lookup.Add(accessor, key);
    }

    /// <summary>
    ///     Tries to get an attribute key for the specified property accessor.
    /// </summary>
    /// <param name="accessor">
    ///     The property accessor whose attribute key to get.
    /// </param>
    /// <param name="key">
    ///     The output attribute key if found.
    /// </param>
    public virtual bool TryGetPropertyAccessorKey(MethodInfo accessor, [MaybeNullWhen(false)] out string key) =>
        _lookup.TryGetValue(accessor, out key);

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

    /// <summary>
    ///     Creates a read-only copy of the lookup.
    /// </summary>
    /// <remarks>
    ///     The returned lookup is a read-only wrapper around the current instance for efficiency. It does not create a deep copy, so any
    ///     modifications to this instance will be reflected in the sealed lookup.
    /// </remarks>
    [Pure]
    public virtual DotMemberAttributeKeyLookup Seal() => new(new ReadOnlyDictionary<MethodInfo, string>(_lookup));
}