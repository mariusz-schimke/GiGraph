using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

public class DotHtmlTableAlignmentAttributes : DotHtmlTableTableCellCommonAlignmentAttributes<IDotHtmlTableAlignmentAttributes, DotHtmlTableAlignmentAttributes, DotHorizontalAlignment>, IDotHtmlTableAlignmentAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlTableAlignmentAttributes, IDotHtmlTableAlignmentAttributes>().BuildLazy();

    public DotHtmlTableAlignmentAttributes(DotHtmlAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotHtmlTableAlignmentAttributes(DotHtmlAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <summary>
    ///     Sets alignment.
    /// </summary>
    /// <param name="alignment">
    ///     The alignment to set.
    /// </param>
    public virtual DotHtmlTableAlignmentAttributes Set(DotAlignmentOptions alignment) => base.Set(alignment);
}