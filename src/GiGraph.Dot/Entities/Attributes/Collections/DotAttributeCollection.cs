using GiGraph.Dot.Entities.Attributes.Factories;
using GiGraph.Dot.Output.Entities;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Entities.Attributes.Collections;

// TODO: Zastosować OrderedDictionary, ale przez kompozycję, a nie dziedziczenie.
public partial class DotAttributeCollection : IDotEntity, IDotAnnotatable
{
    protected readonly DotAttributeFactory _attributeFactory;
    protected readonly SortedDictionary<string, DotAttribute> _attributes = new();

    public DotAttributeCollection()
        : this(DotAttributeFactory.Instance)
    {
    }

    public DotAttributeCollection(DotAttributeCollection source)
        : this(source._attributeFactory, source._attributes)
    {
    }

    public DotAttributeCollection(DotAttributeFactory attributeFactory)
    {
        _attributeFactory = attributeFactory;
    }

    public DotAttributeCollection(DotAttributeFactory attributeFactory, IDictionary<string, DotAttribute> source)
        : this(attributeFactory)
    {
        _attributes = new(source);
    }

    protected internal string? Annotation { get; set; }

    /// <summary>
    ///     Gets the number of attributes in the collection.
    /// </summary>
    public int Count => _attributes.Count;

    string? IDotAnnotatable.Annotation
    {
        get => Annotation;
        set => Annotation = value;
    }

    /// <summary>
    ///     Determines whether the collection contains an attribute with the specified key.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to locate.
    /// </param>
    public bool ContainsKey(string key) => _attributes.ContainsKey(key);

    /// <summary>
    ///     Removes an attribute with the specified key from the collection.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to remove.
    /// </param>
    public DotAttribute? Remove(string key) => _attributes.Remove(key, out var result) ? result : null;

    /// <summary>
    ///     Removes all attributes from the collection.
    /// </summary>
    public void Clear()
    {
        _attributes.Clear();
    }

    /// <summary>
    ///     Determines whether the collection contains an attribute with the specified key, whose value is null.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute whose value to check.
    /// </param>
    public virtual bool IsNullified(string key) => Get(key)?.HasValue is false;
}