using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Nodes.Attributes;

namespace GiGraph.Dot.Entities.Nodes;

/// <summary>
///     Represents a graph node.
/// </summary>
public class DotNode : DotNodeDefinition
{
    /// <summary>
    ///     The unique identifier of the node.
    /// </summary>
    /// <param name="id">
    ///     The unique identifier of the node.
    /// </param>
    public DotNode(string id)
        : this(id, new DotAttributeCollection())
    {
    }

    protected DotNode(string id, DotAttributeCollection attributes)
        : this(id, new DotNodeRootAttributes(attributes))
    {
    }

    protected DotNode(string id, DotNodeRootAttributes attributes)
        : base(attributes)
    {
        // todo: why isn't it thrown in the Id setter too?
        Id = id ?? throw new ArgumentNullException(nameof(id), "Node identifier must not be null.");
    }

    /// <summary>
    ///     Gets or sets the unique identifier of the node.
    /// </summary>
    // todo: should the ID be settable?
    public virtual string Id { get; set; }

    protected override string GetOrderingKey() => Id;
}