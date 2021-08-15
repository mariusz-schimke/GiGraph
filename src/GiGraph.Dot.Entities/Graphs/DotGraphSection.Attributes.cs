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
    public partial class DotGraphSection : IDotGraphAttributesRoot
    {
        /// <inheritdoc cref="IDotGraphAttributesRoot.Font" />
        public virtual DotGraphFontAttributes Font => ((IDotGraphAttributesRoot) Attributes).Font;

        /// <inheritdoc cref="IDotGraphAttributesRoot.Style" />
        public virtual DotGraphStyleAttributes Style => ((IDotGraphAttributesRoot) Attributes).Style;

        /// <inheritdoc cref="IDotGraphAttributesRoot.SvgStyleSheet" />
        public virtual DotGraphSvgSvgStyleSheetAttributes SvgStyleSheet => ((IDotGraphAttributesRoot) Attributes).SvgStyleSheet;

        /// <inheritdoc cref="IDotGraphAttributesRoot.Layout" />
        public virtual DotGraphLayoutAttributes Layout => ((IDotGraphAttributesRoot) Attributes).Layout;

        /// <inheritdoc cref="IDotGraphAttributesRoot.Canvas" />
        public virtual DotGraphCanvasAttributes Canvas => ((IDotGraphAttributesRoot) Attributes).Canvas;

        /// <inheritdoc cref="IDotGraphAttributesRoot.LabelAlignment" />
        public virtual DotLabelAlignmentAttributes LabelAlignment => ((IDotGraphAttributesRoot) Attributes).LabelAlignment;

        /// <inheritdoc cref="IDotGraphAttributesRoot.SvgStyleSheet" />
        public virtual DotHyperlinkAttributes Hyperlink => ((IDotGraphAttributesRoot) Attributes).Hyperlink;

        DotStyles? IDotGraphAttributes.Style
        {
            get => ((IDotGraphAttributes) Attributes).Style;
            set => ((IDotGraphAttributes) Attributes).Style = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.EdgeShape" />
        public virtual DotEdgeShape? EdgeShape
        {
            get => ((IDotGraphAttributes) Attributes).EdgeShape;
            set => ((IDotGraphAttributes) Attributes).EdgeShape = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.Label" />
        public virtual DotLabel Label
        {
            get => ((IDotGraphAttributes) Attributes).Label;
            set => ((IDotGraphAttributes) Attributes).Label = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.ColorScheme" />
        public virtual string ColorScheme
        {
            get => ((IDotGraphAttributes) Attributes).ColorScheme;
            set => ((IDotGraphAttributes) Attributes).ColorScheme = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.Charset" />
        public virtual string Charset
        {
            get => ((IDotGraphAttributes) Attributes).Charset;
            set => ((IDotGraphAttributes) Attributes).Charset = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.Comment" />
        public virtual string Comment
        {
            get => ((IDotGraphAttributes) Attributes).Comment;
            set => ((IDotGraphAttributes) Attributes).Comment = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.ImageDirectories" />
        public virtual string ImageDirectories
        {
            get => ((IDotGraphAttributes) Attributes).ImageDirectories;
            set => ((IDotGraphAttributes) Attributes).ImageDirectories = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.RootNodeId" />
        public virtual DotId RootNodeId
        {
            get => ((IDotGraphAttributes) Attributes).RootNodeId;
            set => ((IDotGraphAttributes) Attributes).RootNodeId = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.ObjectId" />
        public virtual DotEscapeString ObjectId
        {
            get => ((IDotGraphAttributes) Attributes).ObjectId;
            set => ((IDotGraphAttributes) Attributes).ObjectId = value;
        }
    }
}