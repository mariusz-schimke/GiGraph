using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;
using GiGraph.Dot.Entities.Edges.Attributes;
using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Edges;

public abstract partial class DotEdgeDefinition : IDotEdgeRootAttributes
{
    // hidden by explicit implementation because they are exposed through separate properties of descendant classes
    DotEdgeHeadAttributes IDotEdgeRootAttributes.Head => Attributes.Implementation.Head;
    DotEdgeTailAttributes IDotEdgeRootAttributes.Tail => Attributes.Implementation.Tail;


    /// <inheritdoc cref="IDotEdgeRootAttributes.Font"/>
    public DotFontAttributes Font => Attributes.Implementation.Font;

    /// <inheritdoc cref="IDotEdgeRootAttributes.EndpointLabels"/>
    public DotEdgeEndpointLabelsAttributes EndpointLabels => Attributes.Implementation.EndpointLabels;

    /// <inheritdoc cref="IDotEdgeRootAttributes.EdgeHyperlink"/>
    public DotEdgeHyperlinkAttributes EdgeHyperlink => Attributes.Implementation.EdgeHyperlink;

    /// <inheritdoc cref="IDotEdgeRootAttributes.LabelHyperlink"/>
    public DotEdgeLabelHyperlinkAttributes LabelHyperlink => Attributes.Implementation.LabelHyperlink;

    /// <inheritdoc cref="IDotEdgeRootAttributes.Style"/>
    public DotEdgeStyleAttributes Style => Attributes.Implementation.Style;

    /// <inheritdoc cref="IDotEdgeRootAttributes.SvgStyleSheet"/>
    public DotSvgStyleSheetAttributes SvgStyleSheet => Attributes.Implementation.SvgStyleSheet;

    /// <inheritdoc cref="IDotEdgeRootAttributes.Hyperlink"/>
    public DotHyperlinkAttributes Hyperlink => Attributes.Implementation.Hyperlink;

    DotStyles? IDotEdgeAttributes.Style
    {
        get => ((IDotEdgeAttributes) Attributes.Implementation).Style;
        set => ((IDotEdgeAttributes) Attributes.Implementation).Style = value;
    }

    /// <inheritdoc cref="IDotEdgeAttributes.Label"/>
    public virtual DotLabel? Label
    {
        get => Attributes.Implementation.Label;
        set => Attributes.Implementation.Label = value;
    }

    /// <inheritdoc cref="IDotEdgeAttributes.ExternalLabel"/>
    public virtual DotLabel? ExternalLabel
    {
        get => Attributes.Implementation.ExternalLabel;
        set => Attributes.Implementation.ExternalLabel = value;
    }

    /// <inheritdoc cref="IDotEdgeAttributes.EnableLabelFloating"/>
    public virtual bool? EnableLabelFloating
    {
        get => Attributes.Implementation.EnableLabelFloating;
        set => Attributes.Implementation.EnableLabelFloating = value;
    }

    /// <inheritdoc cref="IDotEdgeAttributes.DisableLabelJustification"/>
    public virtual bool? DisableLabelJustification
    {
        get => Attributes.Implementation.DisableLabelJustification;
        set => Attributes.Implementation.DisableLabelJustification = value;
    }

    /// <inheritdoc cref="IDotEdgeAttributes.MinLength"/>
    public virtual int? MinLength
    {
        get => Attributes.Implementation.MinLength;
        set => Attributes.Implementation.MinLength = value;
    }

    /// <inheritdoc cref="IDotEdgeAttributes.Length"/>
    public virtual double? Length
    {
        get => Attributes.Implementation.Length;
        set => Attributes.Implementation.Length = value;
    }

    /// <inheritdoc cref="IDotEdgeAttributes.Weight"/>
    public virtual double? Weight
    {
        get => Attributes.Implementation.Weight;
        set => Attributes.Implementation.Weight = value;
    }

    /// <inheritdoc cref="IDotEdgeAttributes.Tooltip"/>
    public virtual DotEscapeString? Tooltip
    {
        get => Attributes.Implementation.Tooltip;
        set => Attributes.Implementation.Tooltip = value;
    }

    public virtual double? ArrowheadScaleFactor
    {
        get => Attributes.Implementation.ArrowheadScaleFactor;
        set => Attributes.Implementation.ArrowheadScaleFactor = value;
    }

    /// <inheritdoc cref="IDotEdgeAttributes.Directions"/>
    public virtual DotEdgeDirections? Directions
    {
        get => Attributes.Implementation.Directions;
        set => Attributes.Implementation.Directions = value;
    }

    /// <inheritdoc cref="IDotEdgeAttributes.DrawLabelConnector"/>
    public virtual bool? DrawLabelConnector
    {
        get => Attributes.Implementation.DrawLabelConnector;
        set => Attributes.Implementation.DrawLabelConnector = value;
    }

    /// <inheritdoc cref="IDotEdgeAttributes.Constrain"/>
    public virtual bool? Constrain
    {
        get => Attributes.Implementation.Constrain;
        set => Attributes.Implementation.Constrain = value;
    }

    /// <inheritdoc cref="IDotEdgeAttributes.Comment"/>
    public virtual string? Comment
    {
        get => Attributes.Implementation.Comment;
        set => Attributes.Implementation.Comment = value;
    }

    /// <inheritdoc cref="IDotEdgeAttributes.ObjectId"/>
    public virtual DotEscapeString? ObjectId
    {
        get => Attributes.Implementation.ObjectId;
        set => Attributes.Implementation.ObjectId = value;
    }
}