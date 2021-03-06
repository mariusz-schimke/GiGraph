﻿using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Types.Double;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     A double array attribute.
    /// </summary>
    public class DotDoubleArrayAttribute : DotAttribute<double[]>
    {
        /// <summary>
        ///     Creates a new instance of the attribute.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute.
        /// </param>
        public DotDoubleArrayAttribute(string key, double[] value)
            : base(key, value)
        {
        }

        /// <summary>
        ///     Creates a new instance of the attribute.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute.
        /// </param>
        public DotDoubleArrayAttribute(string key, IEnumerable<double> value)
            : base(key, value?.ToArray())
        {
        }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return Value is { } ? DotDoubleListEncoder.Convert(Value, syntaxRules) : null;
        }
    }
}