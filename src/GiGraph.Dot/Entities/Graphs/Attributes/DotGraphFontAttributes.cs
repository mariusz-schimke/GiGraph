using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Fonts;
using GiGraph.Dot.Types.Graphs.Font;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public partial class DotGraphFontAttributes : DotFontAttributes<IDotGraphFontAttributes, DotGraphFontAttributes>, IDotGraphFontAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup =
        new DotMemberAttributeKeyLookupBuilder<DotGraphFontAttributes, IDotGraphFontAttributes>().BuildLazy();

    public DotGraphFontAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotGraphFontAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotGraphFontAttributes.Directories"/>
    [DotAttributeKey(DotAttributeKeys.FontPath)]
    public virtual partial string? Directories { get; set; }

    /// <inheritdoc cref="IDotGraphFontAttributes.Convention"/>
    [DotAttributeKey(DotAttributeKeys.FontNames)]
    public virtual partial DotFontConvention? Convention { get; set; }

    /// <summary>
    ///     Sets font attributes.
    /// </summary>
    /// <param name="attributes">
    ///     The attributes to set.
    /// </param>
    public virtual DotGraphFontAttributes Set(DotGraphFont attributes)
    {
        Directories = attributes.Directories;
        Convention = attributes.Convention;
        return base.Set(attributes);
    }
}