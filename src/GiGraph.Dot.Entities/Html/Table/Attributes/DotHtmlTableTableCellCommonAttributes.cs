using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Properties;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Html.Table;

namespace GiGraph.Dot.Entities.Html.Table.Attributes
{
    public abstract class DotHtmlTableTableCellCommonAttributes<TIEntityAttributeProperties> : DotHtmlElementRootAttributes<TIEntityAttributeProperties>, IDotHtmlTableTableCellCommonAttributes
    {
        protected DotHtmlTableTableCellCommonAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        [DotAttributeKey("id")]
        DotEscapeString IDotHtmlTableTableCellCommonAttributes.Id
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey("port")]
        string IDotHtmlTableTableCellCommonAttributes.PortName
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey("valign")]
        DotVerticalAlignment? IDotHtmlTableTableCellCommonAttributes.VerticalAlignment
        {
            get => GetValueAs<DotVerticalAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        [DotAttributeKey("bgcolor")]
        DotColorDefinition IDotHtmlTableTableCellCommonAttributes.BackgroundColor
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey("color")]
        DotColor IDotHtmlTableTableCellCommonAttributes.BorderColor
        {
            get => GetValueAsColor(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey("border")]
        int? IDotHtmlTableTableCellCommonAttributes.BorderWidth
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey("cellpadding")]
        int? IDotHtmlTableTableCellCommonAttributes.CellPadding
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey("cellspacing")]
        int? IDotHtmlTableTableCellCommonAttributes.CellSpacing
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey("sides")]
        DotHtmlTableBorders? IDotHtmlTableTableCellCommonAttributes.Borders
        {
            get => GetValueAs<DotHtmlTableBorders>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        [DotAttributeKey("fixedsize")]
        bool? IDotHtmlTableTableCellCommonAttributes.FixedSize
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey("gradientangle")]
        int? IDotHtmlTableTableCellCommonAttributes.GradientFillAngle
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey("width")]
        int? IDotHtmlTableTableCellCommonAttributes.Width
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey("height")]
        int? IDotHtmlTableTableCellCommonAttributes.Height
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey("href")]
        DotEscapeString IDotHtmlTableTableCellCommonAttributes.Href
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey("target")]
        DotEscapeString IDotHtmlTableTableCellCommonAttributes.Target
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey("title")]
        DotEscapeString IDotHtmlTableTableCellCommonAttributes.Title
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey("tooltip")]
        DotEscapeString IDotHtmlTableTableCellCommonAttributes.Tooltip
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey("style")]
        DotHtmlTableStyles? IDotHtmlTableTableCellCommonAttributes.Style
        {
            get => GetValueAs<DotHtmlTableStyles>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }
    }
}