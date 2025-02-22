using GiGraph.Dot.Entities.Attributes.Factories;
using GiGraph.Dot.Output.Entities;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Entities.Attributes.Collections;

// TODO: Zastosować OrderedDictionary, ale przez kompozycję, a nie dziedziczenie.
public partial class DotAttributeCollection : SortedList<string, DotAttribute>, IDotEntity, IDotAnnotatable
{
    protected readonly DotAttributeFactory _attributeFactory;

    public DotAttributeCollection()
        : this(DotAttributeFactory.Instance)
    {
    }

    public DotAttributeCollection(DotAttributeCollection source)
        : this(source._attributeFactory, source)
    {
    }

    public DotAttributeCollection(DotAttributeFactory attributeFactory)
    {
        _attributeFactory = attributeFactory;
    }

    public DotAttributeCollection(DotAttributeFactory attributeFactory, IDictionary<string, DotAttribute> source)
        : base(source)
    {
        _attributeFactory = attributeFactory;
    }

    protected internal string? Annotation { get; set; }

    string? IDotAnnotatable.Annotation
    {
        get => Annotation;
        set => Annotation = value;
    }

    /// <summary>
    ///     Removes all attributes matching the specified criteria from the collection.
    /// </summary>
    /// <param name="match">
    ///     The predicate to use for matching attributes.
    /// </param>
    public virtual int RemoveAll(Predicate<DotAttribute> match)
    {
        var matches = this.Where(a => match(a.Value)).ToArray();
        return matches.Sum(attribute => Remove(attribute.Key) ? 1 : 0);
    }

    /// <summary>
    ///     Adds an entry with the given key and value to the list. An <see cref="ArgumentException" /> is thrown if the key is already
    ///     present in the list or when the specified key is different than the key assigned to the attribute.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to add.
    /// </param>
    /// <param name="attribute">
    ///     The attribute to add.
    /// </param>
    public new virtual void Add(string key, DotAttribute attribute)
    {
        if (key != attribute.Key)
        {
            throw new ArgumentException($"The key specified (\"{key}\") has to match the attribute key (\"{attribute.Key}\").", nameof(key));
        }

        base.Add(key, attribute);
    }

    /// <summary>
    ///     Determines whether the collection contains an attribute with the specified key, whose value is null.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute whose value to check.
    /// </param>
    public virtual bool IsNullified(string key) => TryGetValue(key, out var result) && result.GetValue() is null;
}