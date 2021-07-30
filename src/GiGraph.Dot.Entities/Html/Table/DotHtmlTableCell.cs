using GiGraph.Dot.Entities.Html.Table.Attributes;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Html.Table;
using GiGraph.Dot.Types.Text;

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
            : this(new DotHtmlTableCellAttributes())
        {
        }

        protected DotHtmlTableCell(DotHtmlTableCellAttributes attributes)
            : base("td", attributes.Collection)
        {
            Attributes = attributes;
        }

        /// <summary>
        ///     The attributes of the table.
        /// </summary>
        public new virtual DotHtmlTableCellAttributes Attributes { get; }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Id" />
        public virtual DotEscapeString Id
        {
            get => ((IDotHtmlTableCellAttributes) Attributes).Id;
            set => ((IDotHtmlTableCellAttributes) Attributes).Id = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.PortName" />
        public virtual string PortName
        {
            get => ((IDotHtmlTableCellAttributes) Attributes).PortName;
            set => ((IDotHtmlTableCellAttributes) Attributes).PortName = value;
        }

        /// <inheritdoc cref="IDotHtmlTableCellAttributes.HorizontalAlignment" />
        public virtual DotHorizontalCellAlignment? HorizontalAlignment
        {
            get => ((IDotHtmlTableCellAttributes) Attributes).HorizontalAlignment;
            set => ((IDotHtmlTableCellAttributes) Attributes).HorizontalAlignment = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.VerticalAlignment" />
        public virtual DotVerticalAlignment? VerticalAlignment
        {
            get => ((IDotHtmlTableCellAttributes) Attributes).VerticalAlignment;
            set => ((IDotHtmlTableCellAttributes) Attributes).VerticalAlignment = value;
        }

        /// <inheritdoc cref="IDotHtmlTableCellAttributes.HorizontalLineAlignment" />
        public virtual DotHorizontalAlignment? HorizontalLineAlignment
        {
            get => ((IDotHtmlTableCellAttributes) Attributes).HorizontalLineAlignment;
            set => ((IDotHtmlTableCellAttributes) Attributes).HorizontalLineAlignment = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.BackgroundColor" />
        public virtual DotColorDefinition BackgroundColor
        {
            get => ((IDotHtmlTableCellAttributes) Attributes).BackgroundColor;
            set => ((IDotHtmlTableCellAttributes) Attributes).BackgroundColor = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Color" />
        public virtual DotColor Color
        {
            get => ((IDotHtmlTableCellAttributes) Attributes).Color;
            set => ((IDotHtmlTableCellAttributes) Attributes).Color = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.BorderWidth" />
        public virtual int? BorderWidth
        {
            get => ((IDotHtmlTableCellAttributes) Attributes).BorderWidth;
            set => ((IDotHtmlTableCellAttributes) Attributes).BorderWidth = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.CellPadding" />
        public virtual int? CellPadding
        {
            get => ((IDotHtmlTableCellAttributes) Attributes).CellPadding;
            set => ((IDotHtmlTableCellAttributes) Attributes).CellPadding = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.CellSpacing" />
        public virtual int? CellSpacing
        {
            get => ((IDotHtmlTableCellAttributes) Attributes).CellSpacing;
            set => ((IDotHtmlTableCellAttributes) Attributes).CellSpacing = value;
        }

        /// <inheritdoc cref="IDotHtmlTableCellAttributes.ColumnSpan" />
        public virtual int? ColumnSpan
        {
            get => ((IDotHtmlTableCellAttributes) Attributes).ColumnSpan;
            set => ((IDotHtmlTableCellAttributes) Attributes).ColumnSpan = value;
        }

        /// <inheritdoc cref="IDotHtmlTableCellAttributes.RowSpan" />
        public virtual int? RowSpan
        {
            get => ((IDotHtmlTableCellAttributes) Attributes).RowSpan;
            set => ((IDotHtmlTableCellAttributes) Attributes).RowSpan = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Sides" />
        public virtual DotHtmlTableSides? Sides
        {
            get => ((IDotHtmlTableCellAttributes) Attributes).Sides;
            set => ((IDotHtmlTableCellAttributes) Attributes).Sides = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.FixedSize" />
        public virtual bool? FixedSize
        {
            get => ((IDotHtmlTableCellAttributes) Attributes).FixedSize;
            set => ((IDotHtmlTableCellAttributes) Attributes).FixedSize = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.GradientFillAngle" />
        public virtual int? GradientFillAngle
        {
            get => ((IDotHtmlTableCellAttributes) Attributes).GradientFillAngle;
            set => ((IDotHtmlTableCellAttributes) Attributes).GradientFillAngle = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Width" />
        public virtual int? Width
        {
            get => ((IDotHtmlTableCellAttributes) Attributes).Width;
            set => ((IDotHtmlTableCellAttributes) Attributes).Width = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Height" />
        public virtual int? Height
        {
            get => ((IDotHtmlTableCellAttributes) Attributes).Height;
            set => ((IDotHtmlTableCellAttributes) Attributes).Height = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Href" />
        public virtual DotEscapeString Href
        {
            get => ((IDotHtmlTableCellAttributes) Attributes).Href;
            set => ((IDotHtmlTableCellAttributes) Attributes).Href = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Target" />
        public virtual DotEscapeString Target
        {
            get => ((IDotHtmlTableCellAttributes) Attributes).Target;
            set => ((IDotHtmlTableCellAttributes) Attributes).Target = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Title" />
        public virtual DotEscapeString Title
        {
            get => ((IDotHtmlTableCellAttributes) Attributes).Title;
            set => ((IDotHtmlTableCellAttributes) Attributes).Title = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Tooltip" />
        public virtual DotEscapeString Tooltip
        {
            get => ((IDotHtmlTableCellAttributes) Attributes).Tooltip;
            set => ((IDotHtmlTableCellAttributes) Attributes).Tooltip = value;
        }

        /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Style" />
        public virtual DotHtmlTableStyles? Style
        {
            get => ((IDotHtmlTableCellAttributes) Attributes).Style;
            set => ((IDotHtmlTableCellAttributes) Attributes).Style = value;
        }
    }
}