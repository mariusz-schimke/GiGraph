using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.LabelAlignment;
using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Graphs;

public partial class DotGraphSection : IDotGraphRootAttributes
{
    // hidden by explicit implementation because they are exposed through the Clusters collection property
    DotGraphClustersAttributes IDotGraphRootAttributes.Clusters => Attributes.Implementation.Clusters;

    /// <inheritdoc cref="IDotGraphRootAttributes.Style"/>
    public DotGraphStyleAttributes Style => Attributes.Implementation.Style;

    /// <inheritdoc cref="IDotGraphRootAttributes.Font"/>
    public DotGraphFontAttributes Font => Attributes.Implementation.Font;

    /// <inheritdoc cref="IDotGraphRootAttributes.SvgStyleSheet"/>
    public DotGraphSvgStyleSheetAttributes SvgStyleSheet => Attributes.Implementation.SvgStyleSheet;

    /// <inheritdoc cref="IDotGraphRootAttributes.Layout"/>
    public DotGraphLayoutAttributes Layout => Attributes.Implementation.Layout;

    /// <inheritdoc cref="IDotGraphRootAttributes.Canvas"/>
    public DotGraphCanvasAttributes Canvas => Attributes.Implementation.Canvas;

    /// <inheritdoc cref="IDotGraphRootAttributes.LabelAlignment"/>
    public DotLabelAlignmentAttributes LabelAlignment => Attributes.Implementation.LabelAlignment;

    /// <inheritdoc cref="IDotGraphRootAttributes.Hyperlink"/>
    public DotHyperlinkAttributes Hyperlink => Attributes.Implementation.Hyperlink;

    DotStyles? IDotGraphAttributes.Style
    {
        get => ((IDotGraphAttributes) Attributes.Implementation).Style;
        set => ((IDotGraphAttributes) Attributes.Implementation).Style = value;
    }

    /// <inheritdoc cref="IDotGraphAttributes.Label"/>
    public virtual DotLabel? Label
    {
        get => Attributes.Implementation.Label;
        set => Attributes.Implementation.Label = value;
    }

    /// <inheritdoc cref="IDotGraphAttributes.DisableLabelJustification"/>
    public virtual bool? DisableLabelJustification
    {
        get => Attributes.Implementation.DisableLabelJustification;
        set => Attributes.Implementation.DisableLabelJustification = value;
    }

    /// <inheritdoc cref="IDotGraphAttributes.Charset"/>
    public virtual string? Charset
    {
        get => Attributes.Implementation.Charset;
        set => Attributes.Implementation.Charset = value;
    }

    /// <inheritdoc cref="IDotGraphAttributes.Comment"/>
    public virtual string? Comment
    {
        get => Attributes.Implementation.Comment;
        set => Attributes.Implementation.Comment = value;
    }

    /// <inheritdoc cref="IDotGraphAttributes.Tooltip"/>
    public virtual DotEscapeString? Tooltip
    {
        get => Attributes.Implementation.Tooltip;
        set => Attributes.Implementation.Tooltip = value;
    }

    /// <inheritdoc cref="IDotGraphAttributes.ImageDirectories"/>
    public virtual string? ImageDirectories
    {
        get => Attributes.Implementation.ImageDirectories;
        set => Attributes.Implementation.ImageDirectories = value;
    }

    /// <inheritdoc cref="IDotGraphAttributes.ObjectId"/>
    public virtual DotEscapeString? ObjectId
    {
        get => Attributes.Implementation.ObjectId;
        set => Attributes.Implementation.ObjectId = value;
    }
}