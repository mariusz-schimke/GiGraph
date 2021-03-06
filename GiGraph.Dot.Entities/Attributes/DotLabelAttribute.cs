﻿using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     A label attribute. The value can be a string (<see cref="DotTextLabel" />), an HTML string (<see cref="DotHtmlLabel" />), or
    ///     a record (<see cref="DotRecordLabel" />).
    /// </summary>
    public class DotLabelAttribute : DotAttribute<DotLabel>
    {
        /// <summary>
        ///     Creates a new instance of a string attribute.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute.
        /// </param>
        public DotLabelAttribute(string key, DotLabel value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return Value?.GetDotEncodedString(options, syntaxRules);
        }
    }
}