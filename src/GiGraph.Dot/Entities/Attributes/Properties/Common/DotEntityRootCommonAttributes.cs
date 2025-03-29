using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common;

/// <summary>
///     Common attributes of the root graph, clusters, nodes, and edges.
/// </summary>
/// <remarks>
///     When adding new properties, override them in all descendant classes to set adequate XML documentation comments.
/// </remarks>
public abstract partial class DotEntityRootCommonAttributes<TIEntityAttributeProperties, TEntityAttributeProperties> : DotEntityAttributesWithMetadata<TIEntityAttributeProperties, TEntityAttributeProperties>
    where TEntityAttributeProperties : DotEntityAttributesWithMetadata<TIEntityAttributeProperties, TEntityAttributeProperties>, TIEntityAttributeProperties
{
    protected DotEntityRootCommonAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup, DotHyperlinkAttributes hyperlinkAttributes)
        : base(attributes, attributeKeyLookup)
    {
        Hyperlink = hyperlinkAttributes;
    }

    public DotHyperlinkAttributes Hyperlink { get; }

    [DotAttributeKey(DotAttributeKeys.Label)]
    public virtual partial DotLabel? Label { get; set; }

    // todo: remove
    [DotAttributeKey(DotAttributeKeys.ColorScheme)]
    public virtual partial string? ColorScheme { get; set; }

    [DotAttributeKey(DotAttributeKeys.Id)]
    public virtual partial DotEscapeString? ObjectId { get; set; }
}