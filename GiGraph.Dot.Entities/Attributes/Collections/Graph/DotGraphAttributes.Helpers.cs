using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public partial class DotGraphAttributes
    {
        /// <summary>
        ///     Applies the specified graph style options to the <see cref="DotEntityCommonAttributes{TIEntityAttributeProperties}.Style" />
        ///     attribute.
        /// </summary>
        public virtual void SetStyle(DotGraphStyleOptions options)
        {
            base.SetStyle(options);
        }

        /// <summary>
        ///     Applies the specified clusters style options to the
        ///     <see cref="DotEntityCommonAttributes{TIEntityAttributeProperties}.Style" /> attribute.
        /// </summary>
        public virtual void SetClustersStyle(DotClusterStyleOptions options)
        {
            base.SetStyle(options);
        }

        /// <summary>
        ///     Applies the <see cref="DotStyles.Invisible" /> style option to the
        ///     <see cref="DotEntityCommonAttributes{TIEntityAttributeProperties}.Style" /> attribute, making the border and background of
        ///     clusters invisible.
        /// </summary>
        public virtual void SetClustersInvisible()
        {
            ApplyStyleOption(DotStyles.Invisible);
        }

        // TODO: rozważyć, czy te metody Set...() nie powinny być extension methods podobnie jak ToPolygon i inne (z weryfikacją poprawności rodzaju przekazanej listy kolorów)
        // TODO: dodać zamiast SetFilled() metody SetGradientFill(DotGradientColor color, bool radial)
        // TODO: oraz SetStriped(DotMultiColor color) -- uwzględnić wagi
        // TODO: oraz SetWedged(DotMultiColor color) -- uwzględnić wagi
        // TODO: oraz SetFilled(DotColorDefinition/DotColor color)
    }
}