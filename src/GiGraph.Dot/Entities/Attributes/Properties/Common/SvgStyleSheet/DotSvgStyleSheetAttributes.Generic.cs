﻿using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;

public abstract partial class DotSvgStyleSheetAttributes<TIEntitySvgStyleSheetAttributes, TEntitySvgStyleSheetAttributes>
    : DotEntityAttributesWithMetadata<TIEntitySvgStyleSheetAttributes, TEntitySvgStyleSheetAttributes>, IDotSvgStyleSheetAttributes
    where TIEntitySvgStyleSheetAttributes : IDotSvgStyleSheetAttributes
    where TEntitySvgStyleSheetAttributes : DotSvgStyleSheetAttributes<TIEntitySvgStyleSheetAttributes, TEntitySvgStyleSheetAttributes>, TIEntitySvgStyleSheetAttributes
{
    protected DotSvgStyleSheetAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotSvgStyleSheetAttributes.Class" />
    [DotAttributeKey(DotAttributeKeys.Class)]
    public virtual partial string? Class { get; set; }
}