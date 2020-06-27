using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public class DotGraphAttributes : DotEntityAttributes, IDotGraphAttributes
    {
        public override void SetFilled(DotColorDefinition value) => BackgroundColor = value;
    }
}