using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract partial class DotEntityAttributes
    {
        public virtual void SetFilled(Color color) => SetFilled((DotColorDefinition) color);
        public virtual void SetFilled(DotColorList colorList) => SetFilled((DotColorDefinition) colorList);

        public virtual void SetFilled(DotColorDefinition value)
        {
            Style = Style.GetValueOrDefault(DotStyle.Filled) | DotStyle.Filled;
            FillColor = value;
        }
    }
}