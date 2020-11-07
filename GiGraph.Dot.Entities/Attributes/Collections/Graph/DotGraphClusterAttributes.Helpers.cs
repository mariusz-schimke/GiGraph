using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public partial class DotGraphClusterAttributes
    {
        /// <summary>
        ///     Makes the border and background of clusters invisible.
        /// </summary>
        public virtual DotGraphClusterAttributes SetInvisible()
        {
            Style.Invisible = true;
            return this;
        }

        /// <summary>
        ///     Sets the fill color of clusters.
        /// </summary>
        /// <param name="color">
        ///     The color to use.
        /// </param>
        public virtual DotGraphClusterAttributes SetFilled(DotColor color)
        {
            Style.Filled = true;
            FillColor = color;
            return this;
        }

        /// <summary>
        ///     Sets a gradient fill for clusters.
        /// </summary>
        /// <param name="color">
        ///     The gradient color definition to use.
        /// </param>
        /// <param name="angle">
        ///     The angle of the fill. Note that this attribute is shared with the parent graph (see
        ///     <see cref="DotGraphAttributes.GradientAngle" />), and will overwrite its current value if already set there.
        /// </param>
        /// <param name="radial">
        ///     Determines whether to use a radial-style gradient fill. Note that this attribute is shared with the parent graph (see
        ///     <see cref="DotGraphAttributes.Style" />), and will overwrite its current value if already set there.
        /// </param>
        public virtual DotGraphClusterAttributes SetFilled(DotGradientColor color, int? angle = null, bool radial = false)
        {
            Style.Filled = true;
            Style.Radial = radial;

            FillColor = color;
            _graphGraphAttributes.GradientAngle = angle;

            return this;
        }

        // TODO: dodać zamiast SetFilled() metody SetGradientFill(DotGradientColor color, bool radial, int angle)
        // TODO: oraz SetStriped(DotMultiColor color) -- uwzględnić wagi
        // TODO: oraz SetWedged(DotMultiColor color) -- uwzględnić wagi
        // TODO: oraz SetFilled(DotColorDefinition/DotColor color)
    }
}