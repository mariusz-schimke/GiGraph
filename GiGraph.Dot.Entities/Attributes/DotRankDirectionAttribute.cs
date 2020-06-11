﻿using GiGraph.Dot.Entities.Attributes.Enums;
using System;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// Graph layout direction attribute. Assignable to graphs only.
    /// </summary>
    public class DotRankDirectionAttribute : DotAttribute<DotRankDirection>
    {
        /// <summary>
        /// Creates a new instance of the attribute.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        public DotRankDirectionAttribute(string key, DotRankDirection value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options)
        {
            switch (Value)
            {
                case DotRankDirection.TopToBottom:
                    return "TB";

                case DotRankDirection.LeftToRight:
                    return "LR";

                case DotRankDirection.BottomToTop:
                    return "BT";

                case DotRankDirection.RightToLeft:
                    return "RL";

                default:
                    throw new ArgumentOutOfRangeException(nameof(Value), $"The specified graph layout direction '{Value}' is not supported.");
            }
        }
    }
}
