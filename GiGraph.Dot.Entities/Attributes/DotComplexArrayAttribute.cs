using System;
using System.Linq;
using System.Reflection;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     A DOT-encodable value array attribute.
    /// </summary>
    /// <typeparam name="TComplex">
    ///     A complex type that implements the <see cref="IDotEncodable" /> interface.
    /// </typeparam>
    public class DotComplexArrayAttribute<TComplex> : DotAttribute<TComplex[]>
        where TComplex : IDotEncodable
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
        public DotComplexArrayAttribute(string key, TComplex[] value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            var complexType = typeof(TComplex);
            if (complexType.GetCustomAttribute<DotJoinableTypeAttribute>() is not { } attribute)
            {
                throw new ArgumentException($"The {complexType.Name} type is not annotated with a {nameof(DotJoinableTypeAttribute)} attribute.", nameof(Value));
            }

            var encoded = (Value ?? Enumerable.Empty<TComplex>())
               .Select(value => value.GetDotEncodedValue(options, syntaxRules));

            return string.Join(attribute.Separator, encoded);
        }
    }
}