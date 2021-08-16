using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Clusters.Collections
{
    public partial class DotGraphClusterCollection : IDotFillable, IDotStripable
    {
        void IDotFillable.SetFillStyle(DotFillStyle style) => Style.FillStyle = (DotClusterFillStyle) style;
        void IDotFillable.SetFillColor(DotColorDefinition color) => FillColor = color;
        void IDotFillable.SetGradientFillAngle(int? angle) => ((IDotGraphRootAttributes) _graphAttributes).Canvas.GradientFillAngle = angle;
        void IDotStripable.SetStripeColors(DotMultiColor color) => FillColor = color;
    }
}