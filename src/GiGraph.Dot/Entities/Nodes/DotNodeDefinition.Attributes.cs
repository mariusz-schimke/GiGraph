using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Entities.Nodes.Attributes;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Nodes;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Nodes;

public abstract partial class DotNodeDefinition : IDotNodeRootAttributes
{
    /// <inheritdoc cref="IDotNodeRootAttributes.Font"/>
    public DotFontAttributes Font => Attributes.Implementation.Font;

    /// <inheritdoc cref="IDotNodeRootAttributes.Image"/>
    public DotNodeImageAttributes Image => Attributes.Implementation.Image;

    /// <inheritdoc cref="IDotNodeRootAttributes.Geometry"/>
    public DotNodeGeometryAttributes Geometry => Attributes.Implementation.Geometry;

    /// <inheritdoc cref="IDotNodeRootAttributes.Size"/>
    public DotNodeSizeAttributes Size => Attributes.Implementation.Size;

    /// <inheritdoc cref="IDotNodeRootAttributes.Style"/>
    public DotNodeStyleAttributes Style => Attributes.Implementation.Style;

    /// <inheritdoc cref="IDotNodeRootAttributes.SvgStyleSheet"/>
    public DotSvgStyleSheetAttributes SvgStyleSheet => Attributes.Implementation.SvgStyleSheet;

    /// <inheritdoc cref="IDotNodeRootAttributes.Hyperlink"/>
    public DotHyperlinkAttributes Hyperlink => Attributes.Implementation.Hyperlink;

    /// <inheritdoc cref="IDotNodeRootAttributes.Layout"/>
    public DotNodeLayoutAttributes Layout => Attributes.Implementation.Layout;

    /// <inheritdoc cref="IDotNodeRootAttributes.LabelOptions"/>
    public DotNodeLabelOptionsAttributes LabelOptions => Attributes.Implementation.LabelOptions;

    DotStyles? IDotNodeAttributes.Style
    {
        get => ((IDotNodeAttributes) Attributes.Implementation).Style;
        set => ((IDotNodeAttributes) Attributes.Implementation).Style = value;
    }

    /// <inheritdoc cref="IDotNodeAttributes.Label"/>
    public virtual DotLabel? Label
    {
        get => Attributes.Implementation.Label;
        set => Attributes.Implementation.Label = value;
    }

    /// <inheritdoc cref="IDotNodeAttributes.ExternalLabel"/>
    public virtual DotLabel? ExternalLabel
    {
        get => Attributes.Implementation.ExternalLabel;
        set => Attributes.Implementation.ExternalLabel = value;
    }

    /// <inheritdoc cref="IDotNodeAttributes.Tooltip"/>
    public virtual DotEscapeString? Tooltip
    {
        get => Attributes.Implementation.Tooltip;
        set => Attributes.Implementation.Tooltip = value;
    }

    /// <inheritdoc cref="IDotNodeAttributes.Shape"/>
    public virtual DotNodeShape? Shape
    {
        get => Attributes.Implementation.Shape;
        set => Attributes.Implementation.Shape = value;
    }

    /// <inheritdoc cref="IDotNodeAttributes.Comment"/>
    public virtual string? Comment
    {
        get => Attributes.Implementation.Comment;
        set => Attributes.Implementation.Comment = value;
    }

    /// <inheritdoc cref="IDotNodeAttributes.ObjectId"/>
    public virtual DotEscapeString? ObjectId
    {
        get => Attributes.Implementation.ObjectId;
        set => Attributes.Implementation.ObjectId = value;
    }
}