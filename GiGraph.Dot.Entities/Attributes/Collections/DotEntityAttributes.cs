using GiGraph.Dot.Entities.Attributes.Enums;
using System.Drawing;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    // TODO: check if properties are virtual
    public class DotEntityAttributes : DotAttributeCollection,
        IDotGraphAttributes,
        IDotSubgraphAttributes,
        IDotClusterAttributes,
        IDotNodeAttributes,
        IDotEdgeAttributes
    {
        /// <summary>
        /// Gets or sets the color of the element.
        /// </summary>
        public virtual Color? Color
        {
            get => TryGetValueAs<Color>("color", out var result) ? result : (Color?)null;
            set => AddOrRemove("color", value, v => new DotColorAttribute("color", v.Value));
        }

        /// <summary>
        /// Gets or sets the background color of the element.
        /// </summary>
        public virtual Color? BackgroundColor
        {
            get => TryGetValueAs<Color>("bgcolor", out var result) ? result : (Color?)null;
            set => AddOrRemove("bgcolor", value, v => new DotColorAttribute("bgcolor", v.Value));
        }

        public virtual DotShape? Shape
        {
            get => TryGetValueAs<DotShape>("shape", out var result) ? result : (DotShape?)null;
            set => AddOrRemove("shape", value, v => new DotShapeAttribute("shape", v.Value));
        }

        /// <summary>
        /// Gets or sets the label to display on the element.
        /// </summary>
        public virtual string Label
        {
            get => TryGetAs<DotStringAttribute>("label", out var result) ? result.Value : null;
            set => AddOrRemove("label", value, v => new DotStringAttribute("label", v));
        }

        /// <summary>
        /// Gets or sets the label in HTML format to display on the element.
        /// <para>
        ///     <see cref="Label"/> and <see cref="LabelHtml"/> are actually the same attribute in a different format,
        ///     so when one is set, the other is replaced.
        /// </para>
        /// </summary>
        public virtual string LabelHtml
        {
            get => TryGetAs<DotHtmlAttribute>("label", out var result) ? result.Value : null;
            set => AddOrRemove("label", value, v => new DotHtmlAttribute("label", v));
        }

        public virtual double? ArrowSize
        {
            get => TryGetAs<DotDoubleAttribute>("arrowsize", out var result) ? result.Value : (double?)null;
            set => AddOrRemove("arrowsize", value, v => new DotDoubleAttribute("arrowsize", v.Value));
        }

        public virtual DotArrowType? ArrowHead
        {
            get => TryGetAs<DotArrowTypeAttribute>("arrowhead", out var result) ? result.Value : (DotArrowType?)null;
            set => AddOrRemove("arrowhead", value, v => new DotArrowTypeAttribute("arrowhead", v.Value));
        }

        public virtual DotArrowType? ArrowTail
        {
            get => TryGetAs<DotArrowTypeAttribute>("arrowtail", out var result) ? result.Value : (DotArrowType?)null;
            set => AddOrRemove("arrowtail", value, v => new DotArrowTypeAttribute("arrowtail", v.Value));
        }
        public virtual DotArrowDirection? ArrowDirection
        {
            get => TryGetAs<DotArrowDirectionAttribute>("dir", out var result) ? result.Value : (DotArrowDirection?)null;
            set => AddOrRemove("dir", value, v => new DotArrowDirectionAttribute("dir", v.Value));
        }
    }
}
