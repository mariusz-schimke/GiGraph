using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public partial class DotEdgeAttributes
    {
        /// <summary>
        ///     Applies the specified style options to the <see cref="DotEntityCommonAttributes{TIEntityAttributeProperties}.Style" />
        ///     attribute.
        /// </summary>
        public virtual void SetStyle(DotEdgeStyleOptions options)
        {
            base.SetStyle(options);
        }

        /// <summary>
        ///     Applies the <see cref="DotStyles.Invisible" /> style option to the
        ///     <see cref="DotEntityCommonAttributes{TIEntityAttributeProperties}.Style" /> attribute, making the edge invisible.
        /// </summary>
        public virtual void SetInvisible()
        {
            ApplyStyleOption(DotStyles.Invisible);
        }

        /// <summary>
        ///     Applies the <see cref="DotStyles.Tapered" /> style to the edge. The edge starts with the specified width, and tapers to width
        ///     1, in points.
        /// </summary>
        /// <param name="startWidth">
        ///     The width to start with (applied to the <see cref="Width" /> attribute).
        /// </param>
        public virtual void SetTapered(double startWidth)
        {
            Width = startWidth;
            ApplyStyleOption(DotStyles.Tapered);
        }
    }
}