using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.LabelAlignment;
using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Identifiers;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Graphs
{
    public partial class DotGraphSection : IDotGraphRootAttributes
    {
        /// <inheritdoc cref="IDotGraphRootAttributes.Font" />
        public virtual DotGraphFontAttributes Font => Attributes.Attributes.Font;

        /// <inheritdoc cref="IDotGraphRootAttributes.Style" />
        public virtual DotGraphStyleAttributeOptions Style => Attributes.Attributes.Style;

        /// <inheritdoc cref="IDotGraphRootAttributes.SvgStyleSheet" />
        public virtual DotGraphSvgStyleSheetAttributes SvgStyleSheet => Attributes.Attributes.SvgStyleSheet;

        /// <inheritdoc cref="IDotGraphRootAttributes.Layout" />
        public virtual DotGraphLayoutAttributes Layout => Attributes.Attributes.Layout;

        /// <inheritdoc cref="IDotGraphRootAttributes.Canvas" />
        public virtual DotGraphCanvasAttributes Canvas => Attributes.Attributes.Canvas;

        /// <inheritdoc cref="IDotGraphRootAttributes.LabelAlignment" />
        public virtual DotLabelAlignmentAttributes LabelAlignment => Attributes.Attributes.LabelAlignment;

        /// <inheritdoc cref="IDotGraphRootAttributes.Hyperlink" />
        public virtual DotHyperlinkAttributes Hyperlink => Attributes.Attributes.Hyperlink;

        DotStyles? IDotGraphAttributes.Style
        {
            get => ((IDotGraphAttributes) Attributes.Attributes).Style;
            set => ((IDotGraphAttributes) Attributes.Attributes).Style = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.EdgeShape" />
        public virtual DotEdgeShape? EdgeShape
        {
            get => Attributes.Attributes.EdgeShape;
            set => Attributes.Attributes.EdgeShape = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.Label" />
        public virtual DotLabel Label
        {
            get => Attributes.Attributes.Label;
            set => Attributes.Attributes.Label = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.ColorScheme" />
        public virtual string ColorScheme
        {
            get => Attributes.Attributes.ColorScheme;
            set => Attributes.Attributes.ColorScheme = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.Charset" />
        public virtual string Charset
        {
            get => Attributes.Attributes.Charset;
            set => Attributes.Attributes.Charset = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.Comment" />
        public virtual string Comment
        {
            get => Attributes.Attributes.Comment;
            set => Attributes.Attributes.Comment = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.ImageDirectories" />
        public virtual string ImageDirectories
        {
            get => Attributes.Attributes.ImageDirectories;
            set => Attributes.Attributes.ImageDirectories = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.RootNodeId" />
        public virtual DotId RootNodeId
        {
            get => Attributes.Attributes.RootNodeId;
            set => Attributes.Attributes.RootNodeId = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.ObjectId" />
        public virtual DotEscapeString ObjectId
        {
            get => Attributes.Attributes.ObjectId;
            set => Attributes.Attributes.ObjectId = value;
        }
    }
}