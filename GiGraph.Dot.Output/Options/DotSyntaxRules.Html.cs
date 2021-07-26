using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Output.Converters;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Output.Options
{
    public partial class DotSyntaxRules
    {
        public class HtmlRules
        {
            /// <summary>
            ///     A text escaper to use for HTML attribute values of the string type.
            /// </summary>
            public virtual IDotTextEscaper AttributeStringValueEscaper { get; set; } = DotTextEscapingPipeline.ForHtmlAttributeStringValue();

            /// <summary>
            ///     A text escaper to use for HTML attribute values of the escape string type.
            /// </summary>
            public virtual IDotTextEscaper AttributeEscapeStringValueEscaper { get; set; } = DotTextEscapingPipeline.ForHtmlAttributeEscapeStringValue();

            /// <summary>
            ///     A text escaper to use for textual content of HTML elements.
            /// </summary>
            public virtual IDotTextEscaper ElementTextContentEscaper { get; set; } = DotTextEscapingPipeline.ForHtmlElementTextContent();

            /// <summary>
            ///     A list of converters to use in order to convert an object value of an attribute to string, depending on the underlying type.
            ///     If there are two converters valid for a given type, the first one is used.
            /// </summary>
            public virtual List<IDotValueConverter> AttributeValueConverters { get; protected set; } = new()
            {
                new DotHtmlAttributeStringValueConverter(),
                new DotHtmlAttributeDoubleValueConverter(),
                new DotHtmlAttributeIntValueConverter(),
                new DotHtmlAttributeBoolValueConverter(),
                new DotHtmlAttributeEnumValueConverter(),
                new DotHtmlAttributeDotEscapableValueConverter(),
                new DotHtmlAttributeDotEncodableValueConverter()
            };

            /// <summary>
            ///     Gets an appropriate HTML attribute value converter for the specified value. Throws an exception of none is available.
            /// </summary>
            /// <param name="type">
            ///     The type to find a converter for.
            /// </param>
            /// <exception cref="ArgumentException">
            ///     Thrown when no matching converter is found.
            /// </exception>
            public virtual IDotValueConverter GetAttributeValueConverterForType(Type type)
            {
                return AttributeValueConverters.FirstOrDefault(converter => converter.CanConvert(type))
                    ?? throw new ArgumentException($"No HTML attribute value converter has been specified for the '{type}' type.", nameof(type));
            }

            /// <summary>
            ///     Gets an appropriate HTML attribute value converter for the specified value. Throws an exception of none is available.
            /// </summary>
            /// <param name="value">
            ///     The value to find a converter for.
            /// </param>
            /// <exception cref="ArgumentException">
            ///     Thrown when no matching converter is found.
            /// </exception>
            public virtual IDotValueConverter GetAttributeValueConverterForValue(object value)
            {
                return GetAttributeValueConverterForType(value.GetType());
            }
        }
    }
}