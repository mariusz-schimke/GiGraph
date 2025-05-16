using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Types.Html.Table;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

public class DotHtmlTableCellAlignmentAttributes : DotHtmlTableTableCellCommonAlignmentAttributes<IDotHtmlTableCellAlignmentAttributes, DotHtmlTableCellAlignmentAttributes, DotHtmlTableCellHorizontalAlignment>, IDotHtmlTableCellAlignmentAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlTableCellAlignmentAttributes, IDotHtmlTableCellAlignmentAttributes>().BuildLazy();

    public DotHtmlTableCellAlignmentAttributes(DotHtmlAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotHtmlTableCellAlignmentAttributes(DotHtmlAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <summary>
    ///     Sets alignment.
    /// </summary>
    /// <param name="alignment">
    ///     The alignment to set.
    /// </param>
    public virtual void Set(DotHtmlTableCellAlignmentOptions alignment)
    {
        base.Set(alignment);
    }
}