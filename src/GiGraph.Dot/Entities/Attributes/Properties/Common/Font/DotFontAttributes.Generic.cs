using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.Font;

public abstract partial class DotFontAttributes<TIEntityFontAttributes, TEntityFontAttributes>(
    DotAttributeCollection attributes,
    Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup
)
    : DotEntityAttributesWithMetadata<TIEntityFontAttributes, TEntityFontAttributes>(attributes, attributeKeyLookup), IDotFontAttributes, IDotHasFontAttributes
    where TIEntityFontAttributes : IDotFontAttributes
    where TEntityFontAttributes : DotFontAttributes<TIEntityFontAttributes, TEntityFontAttributes>, TIEntityFontAttributes
{
    /// <inheritdoc cref="IDotFontAttributes.Name"/>
    [DotAttributeKey(DotAttributeKeys.FontName)]
    public virtual partial string? Name { get; set; }

    /// <inheritdoc cref="IDotFontAttributes.Size"/>
    [DotAttributeKey(DotAttributeKeys.FontSize)]
    public virtual partial double? Size { get; set; }

    /// <inheritdoc cref="IDotFontAttributes.Color"/>
    [DotAttributeKey(DotAttributeKeys.FontColor)]
    public virtual partial DotColor? Color { get; set; }

    /// <summary>
    ///     Sets font attributes.
    /// </summary>
    /// <param name="attributes">
    ///     The attributes to set.
    /// </param>
    public virtual TEntityFontAttributes Set(DotFont attributes) => (TEntityFontAttributes) this.Set(attributes.Name, attributes.Size, attributes.Color);
}