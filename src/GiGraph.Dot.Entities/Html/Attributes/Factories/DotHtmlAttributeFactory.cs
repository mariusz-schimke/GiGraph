using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Entities.Attributes.Factories;

namespace GiGraph.Dot.Entities.Html.Attributes.Factories
{
    /// <summary>
    ///     HTML element attributes factory.
    /// </summary>
    public class DotHtmlAttributeFactory : DotAttributeFactory
    {
        /// <summary>
        ///     A static factory instance.
        /// </summary>
        public new static DotHtmlAttributeFactory Instance { get; } = new();

        /// <inheritdoc />
        public override DotBoolAttribute CreateBool(string key, bool value)
        {
            return new DotHtmlBoolAttribute(key, value);
        }

        /// <inheritdoc />
        public override DotStringAttribute CreateString(string key, string value)
        {
            return new DotHtmlStringAttribute(key, value);
        }

        /// <inheritdoc />
        public override DotEscapeStringAttribute CreateEscapeString<TEscapeString>(string key, TEscapeString value)
        {
            return new DotHtmlEscapeStringAttribute(key, value);
        }

        /// <inheritdoc />
        public override DotEnumAttribute<TEnum> CreateEnum<TEnum>(string key, TEnum value)
        {
            return new DotHtmlEnumAttribute<TEnum>(key, value);
        }
    }
}