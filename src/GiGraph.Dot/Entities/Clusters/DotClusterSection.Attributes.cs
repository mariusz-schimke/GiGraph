using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.Common.GraphCluster;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;
using GiGraph.Dot.Entities.Clusters.Attributes;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Entities.Clusters;

public partial class DotClusterSection : IDotClusterRootAttributes
{
    /// <inheritdoc cref="IDotClusterRootAttributes.Font"/>
    public DotFontAttributes Font => Attributes.Implementation.Font;

    /// <inheritdoc cref="IDotClusterRootAttributes.Style"/>
    public DotClusterStyleAttributes Style => Attributes.Implementation.Style;

    /// <inheritdoc cref="IDotClusterRootAttributes.LabelOptions"/>
    public DotGraphClusterLabelOptionsAttributes LabelOptions => Attributes.Implementation.LabelOptions;

    /// <inheritdoc cref="IDotClusterRootAttributes.SvgStyleSheet"/>
    public DotSvgStyleSheetAttributes SvgStyleSheet => Attributes.Implementation.SvgStyleSheet;

    /// <inheritdoc cref="IDotClusterRootAttributes.Hyperlink"/>
    public DotHyperlinkAttributes Hyperlink => Attributes.Implementation.Hyperlink;

    /// <inheritdoc cref="IDotClusterRootAttributes.Layout"/>
    public DotClusterLayoutAttributes Layout => Attributes.Implementation.Layout;

    /// <inheritdoc cref="IDotClusterAttributes.Label"/>
    public virtual DotLabel? Label
    {
        get => Attributes.Implementation.Label;
        set => Attributes.Implementation.Label = value;
    }

    /// <inheritdoc cref="IDotClusterAttributes.Tooltip"/>
    public virtual DotEscapeString? Tooltip
    {
        get => Attributes.Implementation.Tooltip;
        set => Attributes.Implementation.Tooltip = value;
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