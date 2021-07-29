using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Factories;
using GiGraph.Dot.Entities.Html.Attributes.Properties;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Html.Table;
using GiGraph.Dot.Types.Text;

namespace GiGraph.Dot.Entities.Html.Table.Attributes
{
    public class DotHtmlTableAttributes : DotHtmlElementRootAttributes<IDotHtmlTableAttributes>, IDotHtmlTableAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup HtmlTableAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlTableAttributes, IDotHtmlTableAttributes>().Build();

        protected DotHtmlTableAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotHtmlTableAttributes()
            : this(new DotAttributeCollection(DotHtmlAttributeFactory.Instance), HtmlTableAttributesKeyLookup)
        {
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.Id" />
        [DotAttributeKey("id")]
        DotEscapeString IDotHtmlTableAttributes.Id
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.PortName" />
        [DotAttributeKey("port")]
        string IDotHtmlTableAttributes.PortName
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.HorizontalAlignment" />
        [DotAttributeKey("align")]
        DotHorizontalAlignment? IDotHtmlTableAttributes.HorizontalAlignment
        {
            get => GetValueAs<DotHorizontalAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.VerticalAlignment" />
        [DotAttributeKey("valign")]
        DotVerticalAlignment? IDotHtmlTableAttributes.VerticalAlignment
        {
            get => GetValueAs<DotVerticalAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.BackgroundColor" />
        [DotAttributeKey("bgcolor")]
        DotColorDefinition IDotHtmlTableAttributes.BackgroundColor
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.Color" />
        [DotAttributeKey("color")]
        DotColorDefinition IDotHtmlTableAttributes.Color
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.BorderWidth" />
        [DotAttributeKey("border")]
        int? IDotHtmlTableAttributes.BorderWidth
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.CellBorderWidth" />
        [DotAttributeKey("cellborder")]
        int? IDotHtmlTableAttributes.CellBorderWidth
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.CellPadding" />
        [DotAttributeKey("cellpadding")]
        int? IDotHtmlTableAttributes.CellPadding
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.CellSpacing" />
        [DotAttributeKey("cellspacing")]
        int? IDotHtmlTableAttributes.CellSpacing
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.RowFormatting" />
        [DotAttributeKey("rows")]
        string IDotHtmlTableAttributes.RowFormatting
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.ColumnFormatting" />
        [DotAttributeKey("columns")]
        string IDotHtmlTableAttributes.ColumnFormatting
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.Sides" />
        [DotAttributeKey("sides")]
        DotHtmlTableSides? IDotHtmlTableAttributes.Sides
        {
            get => GetValueAs<DotHtmlTableSides>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.FixedSize" />
        [DotAttributeKey("fixedsize")]
        bool? IDotHtmlTableAttributes.FixedSize
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.GradientFillAngle" />
        [DotAttributeKey("gradientangle")]
        int? IDotHtmlTableAttributes.GradientFillAngle
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.Width" />
        [DotAttributeKey("width")]
        int? IDotHtmlTableAttributes.Width
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.Height" />
        [DotAttributeKey("height")]
        int? IDotHtmlTableAttributes.Height
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.Href" />
        [DotAttributeKey("href")]
        DotEscapeString IDotHtmlTableAttributes.Href
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.Target" />
        [DotAttributeKey("target")]
        DotEscapeString IDotHtmlTableAttributes.Target
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.Title" />
        [DotAttributeKey("title")]
        DotEscapeString IDotHtmlTableAttributes.Title
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.Tooltip" />
        [DotAttributeKey("tooltip")]
        DotEscapeString IDotHtmlTableAttributes.Tooltip
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotHtmlTableAttributes.Style" />
        [DotAttributeKey("style")]
        DotHtmlTableStyles? IDotHtmlTableAttributes.Style
        {
            get => GetValueAs<DotHtmlTableStyles>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }
    }
}