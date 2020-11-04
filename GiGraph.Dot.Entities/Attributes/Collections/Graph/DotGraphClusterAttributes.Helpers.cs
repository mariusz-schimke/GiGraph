namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public partial class DotGraphClusterAttributes
    {
        /// <summary>
        ///     Makes the border and background of clusters invisible.
        /// </summary>
        public virtual void SetInvisible()
        {
            Style.Invisible = true;
        }

        // TODO: dodać zamiast SetFilled() metody SetGradientFill(DotGradientColor color, bool radial, int angle)
        // TODO: oraz SetStriped(DotMultiColor color) -- uwzględnić wagi
        // TODO: oraz SetWedged(DotMultiColor color) -- uwzględnić wagi
        // TODO: oraz SetFilled(DotColorDefinition/DotColor color)
    }
}