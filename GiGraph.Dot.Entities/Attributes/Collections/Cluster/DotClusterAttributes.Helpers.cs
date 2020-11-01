using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections.Cluster
{
    public partial class DotClusterAttributes
    {
        /// <summary>
        ///     Applies the specified style options to the <see cref="DotEntityCommonAttributes{TIEntityAttributeProperties}.Style" />
        ///     attribute.
        /// </summary>
        public virtual void SetStyle(DotClusterStyleOptions options)
        {
            base.SetStyle(options);
        }

        /// <summary>
        ///     Applies the <see cref="DotStyles.Invisible" /> style option to the
        ///     <see cref="DotEntityCommonAttributes{TIEntityAttributeProperties}.Style" /> attribute, making the border and background of
        ///     the cluster invisible.
        /// </summary>
        public virtual void SetInvisible()
        {
            ApplyStyleOption(DotStyles.Invisible);
        }
    }
}