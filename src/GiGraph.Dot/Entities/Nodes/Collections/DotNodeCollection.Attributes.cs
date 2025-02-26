using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Entities.Nodes.Attributes;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Nodes;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Nodes.Collections;

public partial class DotNodeCollection : IDotNodeRootAttributes
{
    /// <inheritdoc cref="IDotNodeRootAttributes.Font" />
    public DotFontAttributes Font => Attributes.Implementation.Font;

    /// <inheritdoc cref="IDotNodeRootAttributes.Image" />
    public DotNodeImageAttributes Image => Attributes.Implementation.Image;

    /// <inheritdoc cref="IDotNodeRootAttributes.Geometry" />
    public DotNodeGeometryAttributes Geometry => Attributes.Implementation.Geometry;

    /// <inheritdoc cref="IDotNodeRootAttributes.Size" />
    public DotNodeSizeAttributes Size => Attributes.Implementation.Size;

    /// <inheritdoc cref="IDotNodeRootAttributes.Style" />
    public DotNodeStyleAttributeOptions Style => Attributes.Implementation.Style;

    /// <inheritdoc cref="IDotNodeRootAttributes.SvgStyleSheet" />
    public DotSvgStyleSheetAttributes SvgStyleSheet => Attributes.Implementation.SvgStyleSheet;

    /// <inheritdoc cref="IDotNodeRootAttributes.Hyperlink" />
    public DotHyperlinkAttributes Hyperlink => Attributes.Implementation.Hyperlink;

    DotStyles? IDotNodeAttributes.Style
    {
        get => ((IDotNodeAttributes) Attributes.Implementation).Style;
        set => ((IDotNodeAttributes) Attributes.Implementation).Style = value;
    }

    /// <inheritdoc cref="IDotNodeAttributes.Label" />
    public virtual DotLabel? Label
    {
        get => Attributes.Implementation.Label;
        set => Attributes.Implementation.Label = value;
    }

    /// <inheritdoc cref="IDotNodeAttributes.ExternalLabel" />
    public virtual DotLabel? ExternalLabel
    {
        get => Attributes.Implementation.ExternalLabel;
        set => Attributes.Implementation.ExternalLabel = value;
    }

    /// <inheritdoc cref="IDotNodeAttributes.LabelAlignment" />
    public virtual DotVerticalAlignment? LabelAlignment
    {
        get => Attributes.Implementation.LabelAlignment;
        set => Attributes.Implementation.LabelAlignment = value;
    }

    /// <inheritdoc cref="IDotNodeAttributes.Tooltip" />
    public virtual DotEscapeString? Tooltip
    {
        get => Attributes.Implementation.Tooltip;
        set => Attributes.Implementation.Tooltip = value;
    }

    /// <inheritdoc cref="IDotNodeAttributes.Color" />
    public virtual DotColorDefinition? Color
    {
        get => Attributes.Implementation.Color;
        set => Attributes.Implementation.Color = value;
    }

    /// <inheritdoc cref="IDotNodeAttributes.FillColor" />
    public virtual DotColorDefinition? FillColor
    {
        get => Attributes.Implementation.FillColor;
        set => Attributes.Implementation.FillColor = value;
    }

    /// <inheritdoc cref="IDotNodeAttributes.ColorScheme" />
    public virtual string? ColorScheme
    {
        get => Attributes.Implementation.ColorScheme;
        set => Attributes.Implementation.ColorScheme = value;
    }

    /// <inheritdoc cref="IDotNodeAttributes.GradientFillAngle" />
    public virtual int? GradientFillAngle
    {
        get => Attributes.Implementation.GradientFillAngle;
        set => Attributes.Implementation.GradientFillAngle = value;
    }

    /// <inheritdoc cref="IDotNodeAttributes.BorderWidth" />
    public virtual double? BorderWidth
    {
        get => Attributes.Implementation.BorderWidth;
        set => Attributes.Implementation.BorderWidth = value;
    }

    /// <inheritdoc cref="IDotNodeAttributes.Shape" />
    public virtual DotNodeShape? Shape
    {
        get => Attributes.Implementation.Shape;
        set => Attributes.Implementation.Shape = value;
    }

    /// <inheritdoc cref="IDotNodeAttributes.Padding" />
    public virtual DotPoint? Padding
    {
        get => Attributes.Implementation.Padding;
        set => Attributes.Implementation.Padding = value;
    }

    /// <inheritdoc cref="IDotNodeAttributes.Comment" />
    public virtual string? Comment
    {
        get => Attributes.Implementation.Comment;
        set => Attributes.Implementation.Comment = value;
    }

    /// <inheritdoc cref="IDotNodeAttributes.EdgeOrderingMode" />
    public virtual DotEdgeOrderingMode? EdgeOrderingMode
    {
        get => Attributes.Implementation.EdgeOrderingMode;
        set => Attributes.Implementation.EdgeOrderingMode = value;
    }

    /// <inheritdoc cref="IDotNodeAttributes.GroupName" />
    public virtual string? GroupName
    {
        get => Attributes.Implementation.GroupName;
        set => Attributes.Implementation.GroupName = value;
    }

    /// <inheritdoc cref="IDotNodeAttributes.SortIndex" />
    public virtual int? SortIndex
    {
        get => Attributes.Implementation.SortIndex;
        set => Attributes.Implementation.SortIndex = value;
    }

    /// <inheritdoc cref="IDotNodeAttributes.IsRoot" />
    public virtual bool? IsRoot
    {
        get => Attributes.Implementation.IsRoot;
        set => Attributes.Implementation.IsRoot = value;
    }

    /// <inheritdoc cref="IDotNodeAttributes.ObjectId" />
    public virtual DotEscapeString? ObjectId
    {
        get => Attributes.Implementation.ObjectId;
        set => Attributes.Implementation.ObjectId = value;
    }
}