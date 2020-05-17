using GiGraph.Dot.Entities.Attributes.Enums;
using System;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// Arrow direction attribute. Assignable to edges only.
    /// To see how each arrow direction is interpreted, please go to <see cref="https://www.graphviz.org/doc/info/attrs.html#k:dirType"/>.
    /// </summary>
    public class DotArrowDirectionAttribute : DotAttribute<DotArrowDirection>
    {
        /// <summary>
        /// Creates a new instance of the attribute.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        public DotArrowDirectionAttribute(string key, DotArrowDirection value)
            : base(key, value)
        {
        }

        protected override string GetDotEncodedValue()
        {
            switch (Value)
            {
                case DotArrowDirection.None:
                    return "none";

                case DotArrowDirection.Forward:
                    return "forward";

                case DotArrowDirection.Backward:
                    return "back";

                case DotArrowDirection.Both:
                    return "both";

                default:
                    throw new ArgumentOutOfRangeException(nameof(IDotAttribute.GetDotEncodedValue), $"The specified arrow direction '{Value}' is not supported.");
            }
        }
    }
}
