using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Clusters
{
    public partial class DotCluster : IDotStylable, IDotFillable, IDotStripable
    {
        void IDotFillable.SetFillColor(DotColorDefinition color) => FillColor = color;
        void IDotFillable.SetGradientFillAngle(int? angle) => GradientFillAngle = angle;
        void IDotStripable.SetStripeColors(DotMultiColor color) => FillColor = color;
        void IDotStylable.SetStyle(DotStyles style) => Attributes.Set(a => a.Style, style);
    }
}