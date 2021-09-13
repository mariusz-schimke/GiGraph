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
        private DotGraphRootAttributes GraphAttributes => (DotGraphRootAttributes) _attributes;

        /// <inheritdoc cref="IDotGraphRootAttributes.Font" />
        public virtual DotGraphFontAttributes Font => GraphAttributes.Font;

        /// <inheritdoc cref="IDotGraphRootAttributes.Style" />
        public virtual DotGraphStyleAttributeOptions Style => GraphAttributes.Style;

        /// <inheritdoc cref="IDotGraphRootAttributes.SvgStyleSheet" />
        public virtual DotGraphSvgStyleSheetAttributes SvgStyleSheet => GraphAttributes.SvgStyleSheet;

        /// <inheritdoc cref="IDotGraphRootAttributes.Layout" />
        public virtual DotGraphLayoutAttributes Layout => GraphAttributes.Layout;

        /// <inheritdoc cref="IDotGraphRootAttributes.Canvas" />
        public virtual DotGraphCanvasAttributes Canvas => GraphAttributes.Canvas;

        /// <inheritdoc cref="IDotGraphRootAttributes.LabelAlignment" />
        public virtual DotLabelAlignmentAttributes LabelAlignment => GraphAttributes.LabelAlignment;

        /// <inheritdoc cref="IDotGraphRootAttributes.Hyperlink" />
        public virtual DotHyperlinkAttributes Hyperlink => GraphAttributes.Hyperlink;

        DotStyles? IDotGraphAttributes.Style
        {
            get => ((IDotGraphAttributes) GraphAttributes).Style;
            set => ((IDotGraphAttributes) GraphAttributes).Style = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.EdgeShape" />
        public virtual DotEdgeShape? EdgeShape
        {
            get => GraphAttributes.EdgeShape;
            set => GraphAttributes.EdgeShape = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.Label" />
        public virtual DotLabel Label
        {
            get => GraphAttributes.Label;
            set => GraphAttributes.Label = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.ColorScheme" />
        public virtual string ColorScheme
        {
            get => GraphAttributes.ColorScheme;
            set => GraphAttributes.ColorScheme = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.Charset" />
        public virtual string Charset
        {
            get => GraphAttributes.Charset;
            set => GraphAttributes.Charset = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.Comment" />
        public virtual string Comment
        {
            get => GraphAttributes.Comment;
            set => GraphAttributes.Comment = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.ImageDirectories" />
        public virtual string ImageDirectories
        {
            get => GraphAttributes.ImageDirectories;
            set => GraphAttributes.ImageDirectories = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.RootNodeId" />
        public virtual DotId RootNodeId
        {
            get => GraphAttributes.RootNodeId;
            set => GraphAttributes.RootNodeId = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.ObjectId" />
        public virtual DotEscapeString ObjectId
        {
            get => GraphAttributes.ObjectId;
            set => GraphAttributes.ObjectId = value;
        }
    }
}