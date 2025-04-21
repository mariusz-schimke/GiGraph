using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.LabelAlignment;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;
using GiGraph.Dot.Entities.Clusters.Attributes;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Clusters;

public partial class DotClusterSection : IDotClusterRootAttributes
{
    /// <inheritdoc cref="IDotClusterRootAttributes.Font"/>
    public DotFontAttributes Font => Attributes.Implementation.Font;

    /// <inheritdoc cref="IDotClusterRootAttributes.Style"/>
    public DotClusterStyleAttributes Style => Attributes.Implementation.Style;

    /// <inheritdoc cref="IDotClusterRootAttributes.LabelAlignment"/>
    public DotLabelAlignmentAttributes LabelAlignment => Attributes.Implementation.LabelAlignment;

    /// <inheritdoc cref="IDotClusterRootAttributes.SvgStyleSheet"/>
    public DotSvgStyleSheetAttributes SvgStyleSheet => Attributes.Implementation.SvgStyleSheet;

    /// <inheritdoc cref="IDotClusterRootAttributes.Hyperlink"/>
    public DotHyperlinkAttributes Hyperlink => Attributes.Implementation.Hyperlink;

    /// <inheritdoc cref="IDotClusterRootAttributes.Layout"/>
    public DotClusterLayoutAttributes Layout => Attributes.Implementation.Layout;

    /// <inheritdoc cref="IDotClusterAttributes.Style"/>
    DotStyles? IDotClusterAttributes.Style
    {
        get => ((IDotClusterAttributes) Attributes.Implementation).Style;
        set => ((IDotClusterAttributes) Attributes.Implementation).Style = value;
    }

    /// <inheritdoc cref="IDotClusterAttributes.Label"/>
    public virtual DotLabel? Label
    {
        get => Attributes.Implementation.Label;
        set => Attributes.Implementation.Label = value;
    }

    /// <inheritdoc cref="IDotClusterAttributes.DisableLabelJustification"/>
    public virtual bool? DisableLabelJustification
    {
        get => Attributes.Implementation.DisableLabelJustification;
        set => Attributes.Implementation.DisableLabelJustification = value;
    }

    /// <inheritdoc cref="IDotClusterAttributes.Tooltip"/>
    public virtual DotEscapeString? Tooltip
    {
        get => Attributes.Implementation.Tooltip;
        set => Attributes.Implementation.Tooltip = value;
    }

    /// <inheritdoc cref="IDotClusterAttributes.Padding"/>
    public virtual DotPoint? Padding
    {
        get => Attributes.Implementation.Padding;
        set => Attributes.Implementation.Padding = value;
    }

    /// <inheritdoc cref="IDotClusterAttributes.ObjectId"/>
    public virtual DotEscapeString? ObjectId
    {
        get => Attributes.Implementation.ObjectId;
        set => Attributes.Implementation.ObjectId = value;
    }

    /// <inheritdoc cref="IDotClusterAttributes.IsCluster"/>
    bool? IDotClusterAttributes.IsCluster
    {
        get => ((IDotClusterAttributes) Attributes.Implementation).IsCluster;
        set => ((IDotClusterAttributes) Attributes.Implementation).IsCluster = value;
    }
}