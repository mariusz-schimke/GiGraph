using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public partial class DotGraphSvgStyleSheetAttributes : DotSvgStyleSheetAttributes<IDotGraphSvgStyleSheetAttributes, DotGraphSvgStyleSheetAttributes>, IDotGraphSvgStyleSheetAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphSvgStyleSheetAttributes, IDotGraphSvgStyleSheetAttributes>().BuildLazy();

    public DotGraphSvgStyleSheetAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotGraphSvgStyleSheetAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotGraphSvgStyleSheetAttributes.Url"/>
    [DotAttributeKey(DotAttributeKeys.SvgStyleSheet)]
    public virtual partial string? Url { get; set; }

    /// <summary>
    ///     Sets style sheet attributes.
    /// </summary>
    /// <param name="url">
    ///     The URL or pathname specifying an XML style sheet.
    /// </param>
    /// <param name="class">
    ///     The CSS class to set.
    /// </param>
    public virtual void Set(string? url = null, string? @class = null)
    {
        Url = url;
        Class = @class;
    }
}