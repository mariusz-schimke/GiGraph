using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Accessors;
using GiGraph.Dot.Entities.Nodes.Attributes;
using GiGraph.Dot.Output.Entities;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Entities.Nodes.Collections;

public partial class DotNodeCollection : List<DotNodeDefinition>, IDotEntity, IDotAnnotatable
{
    public DotNodeCollection()
        : this(new DotAttributeCollection())
    {
    }

    protected DotNodeCollection(DotAttributeCollection attributes)
        : this(new DotNodeRootAttributes(attributes))
    {
    }

    protected DotNodeCollection(DotNodeRootAttributes attributes)
    {
        Attributes = new DotEntityRootAttributesAccessor<IDotNodeAttributes, DotNodeRootAttributes>(attributes);
    }

    /// <summary>
    ///     Provides access to the global attributes applied to nodes.
    /// </summary>
    public DotEntityRootAttributesAccessor<IDotNodeAttributes, DotNodeRootAttributes> Attributes { get; }

    /// <inheritdoc cref="IDotAnnotatable.Annotation" />
    public virtual string? Annotation { get; set; }

    /// <summary>
    ///     Adds a node to the collection and initializes its attributes.
    /// </summary>
    /// <typeparam name="T">
    ///     The type of node to add.
    /// </typeparam>
    /// <param name="node">
    ///     The node to add.
    /// </param>
    /// <param name="init">
    ///     An optional node initializer delegate.
    /// </param>
    public virtual T Add<T>(T node, Action<T>? init)
        where T : DotNodeDefinition
    {
        Add(node);
        init?.Invoke(node);
        return node;
    }

    /// <summary>
    ///     Adds a node with the specified identifier to the collection, and returns it.
    /// </summary>
    /// <param name="id">
    ///     The identifier of the node to add.
    /// </param>
    /// <param name="init">
    ///     An optional initializer delegate to call for the created node.
    /// </param>
    public virtual DotNode Add(string id, Action<DotNode>? init = null) => Add(new DotNode(id), init);

    /// <summary>
    ///     Adds a group of nodes with the specified identifiers to the collection.
    /// </summary>
    /// <param name="ids">
    ///     The identifiers of the nodes to add.
    /// </param>
    public virtual DotNodeGroup AddGroup(params string[] ids) => AddGroup(ids, init: null);

    /// <summary>
    ///     Adds a group of nodes with the specified identifiers to the collection.
    /// </summary>
    /// <param name="init">
    ///     An optional initializer delegate to call for the created group.
    /// </param>
    /// <param name="ids">
    ///     The identifiers of the nodes to add.
    /// </param>
    public virtual DotNodeGroup AddGroup(Action<DotNodeGroup>? init, params string[] ids) => AddGroup(ids, init);

    /// <summary>
    ///     Adds a group of nodes with the specified identifiers to the collection.
    /// </summary>
    /// <param name="ids">
    ///     The identifiers of the nodes to add.
    /// </param>
    /// <param name="init">
    ///     An optional initializer delegate to call for the created group.
    /// </param>
    public virtual DotNodeGroup AddGroup(IEnumerable<string> ids, Action<DotNodeGroup>? init = null) => Add(new DotNodeGroup(ids), init);

    /// <summary>
    ///     Adds nodes with the specified identifiers to the collection, and returns them.
    /// </summary>
    /// <param name="ids">
    ///     The identifiers of the nodes to add.
    /// </param>
    public virtual DotNode[] AddRange(params string[] ids) => AddRange(ids, init: null);

    /// <summary>
    ///     Adds nodes with the specified identifiers to the collection, and returns them.
    /// </summary>
    /// <param name="ids">
    ///     The identifiers of the nodes to add.
    /// </param>
    /// <param name="init">
    ///     An optional initializer delegate to call for each created node.
    /// </param>
    public virtual DotNode[] AddRange(Action<DotNode>? init, params string[] ids) => AddRange(ids, init);

    /// <summary>
    ///     Adds nodes with the specified identifiers to the collection, and returns them.
    /// </summary>
    /// <param name="ids">
    ///     The identifiers of the nodes to add.
    /// </param>
    /// <param name="init">
    ///     An optional initializer delegate to call for each created node.
    /// </param>
    public virtual DotNode[] AddRange(IEnumerable<string> ids, Action<DotNode>? init = null)
    {
        return ids.Select
            (
                id =>
                {
                    var node = Add(id);
                    init?.Invoke(node);
                    return node;
                }
            )
            .ToArray();
    }
}