using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Properties;
using GiGraph.Dot.Entities.Html.Table.Attributes;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Html.Table;

namespace GiGraph.Dot.Entities.Html.Table
{
    /// <summary>
    ///     A cell of an HTML table row (&lt;td&gt;).
    /// </summary>
    public class DotHtmlTableCell : DotHtmlElement, IDotHtmlTableCellAttributes
    {
        /// <summary>
        ///     Initializes a new table cell instance.
        /// </summary>
        public DotHtmlTableCell()
            : this(new DotHtmlAttributeCollection())
        {
        }

        private DotHtmlTableCell(DotHtmlAttributeCollection attributes)
            : this(new DotHtmlTableCellAttributes(attributes))
        {
        }

        private DotHtmlTableCell(DotHtmlTableCellAttributes attributes)
            : base("td")
        {
            Attributes = new DotHtmlElementRootAttributes<IDotHtmlTableCellAttributes, DotHtmlTableCellAttributes>(attributes);
        }

        /// <summary>
        ///     The attributes of the table.
        /// </summary>
        public new virtual DotHtmlElementRootAttributes<IDotHtmlTableCellAttributes, DotHtmlTableCellAttributes> Attributes { get; }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Id" />
        public virtual DotEscapeString Id
        {
            get => Attributes.Implementation.Id;
            set => Attributes.Implementation.Id = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.PortName" />
        public virtual string PortName
        {
            get => Attributes.Implementation.PortName;
            set => Attributes.Implementation.PortName = value;
        }

        /// <inheritdoc cref="IDotHtmlTableCellAttributes.HorizontalAlignment" />
        public virtual DotHtmlTableCellHorizontalAlignment? HorizontalAlignment
        {
            get => Attributes.Implementation.HorizontalAlignment;
            set => Attributes.Implementation.HorizontalAlignment = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.VerticalAlignment" />
        public virtual DotVerticalAlignment? VerticalAlignment
        {
            get => Attributes.Implementation.VerticalAlignment;
            set => Attributes.Implementation.VerticalAlignment = value;
        }

        /// <inheritdoc cref="IDotHtmlTableCellAttributes.HorizontalLineAlignment" />
        public virtual DotHorizontalAlignment? HorizontalLineAlignment
        {
            get => Attributes.Implementation.HorizontalLineAlignment;
            set => Attributes.Implementation.HorizontalLineAlignment = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.BackgroundColor" />
        public virtual DotColorDefinition BackgroundColor
        {
            get => Attributes.Implementation.BackgroundColor;
            set => Attributes.Implementation.BackgroundColor = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.BorderColor" />
        public virtual DotColor BorderColor
        {
            get => Attributes.Implementation.BorderColor;
            set => Attributes.Implementation.BorderColor = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.BorderWidth" />
        public virtual int? BorderWidth
        {
            get => Attributes.Implementation.BorderWidth;
            set => Attributes.Implementation.BorderWidth = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.CellPadding" />
        public virtual int? CellPadding
        {
            get => Attributes.Implementation.CellPadding;
            set => Attributes.Implementation.CellPadding = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.CellSpacing" />
        public virtual int? CellSpacing
        {
            get => Attributes.Implementation.CellSpacing;
            set => Attributes.Implementation.CellSpacing = value;
        }

        /// <inheritdoc cref="IDotHtmlTableCellAttributes.ColumnSpan" />
        public virtual int? ColumnSpan
        {
            get => Attributes.Implementation.ColumnSpan;
            set => Attributes.Implementation.ColumnSpan = value;
        }

        /// <inheritdoc cref="IDotHtmlTableCellAttributes.RowSpan" />
        public virtual int? RowSpan
        {
            get => Attributes.Implementation.RowSpan;
            set => Attributes.Implementation.RowSpan = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Borders" />
        public virtual DotHtmlTableBorders? Borders
        {
            get => Attributes.Implementation.Borders;
            set => Attributes.Implementation.Borders = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.FixedSize" />
        public virtual bool? FixedSize
        {
            get => Attributes.Implementation.FixedSize;
            set => Attributes.Implementation.FixedSize = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.GradientFillAngle" />
        public virtual int? GradientFillAngle
        {
            get => Attributes.Implementation.GradientFillAngle;
            set => Attributes.Implementation.GradientFillAngle = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Width" />
        public virtual int? Width
        {
            get => Attributes.Implementation.Width;
            set => Attributes.Implementation.Width = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Height" />
        public virtual int? Height
        {
            get => Attributes.Implementation.Height;
            set => Attributes.Implementation.Height = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Href" />
        public virtual DotEscapeString Href
        {
            get => Attributes.Implementation.Href;
            set => Attributes.Implementation.Href = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Target" />
        public virtual DotEscapeString Target
        {
            get => Attributes.Implementation.Target;
            set => Attributes.Implementation.Target = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Title" />
        public virtual DotEscapeString Title
        {
            get => Attributes.Implementation.Title;
            set => Attributes.Implementation.Title = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Tooltip" />
        public virtual DotEscapeString Tooltip
        {
            get => Attributes.Implementation.Tooltip;
            set => Attributes.Implementation.Tooltip = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Style" />
        public virtual DotHtmlTableStyles? Style
        {
            get => Attributes.Implementation.Style;
            set => Attributes.Implementation.Style = value;
        }
    }
}