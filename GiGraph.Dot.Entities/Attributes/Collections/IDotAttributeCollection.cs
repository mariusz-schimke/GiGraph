using GiGraph.Dot.Entities.Attributes.Enums;
using System;
using System.Collections.Generic;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public interface IDotAttributeCollection : IDotEntity, IDictionary<string, DotCommonAttribute>
    {
        /// <summary>
        /// Adds or replaces the specified attribute in the collection.
        /// </summary>
        /// <param name="attribute">The attribute to include in the collection.</param>
        T Set<T>(T attribute) where T : DotCommonAttribute;

        /// <summary>
        /// Adds or replaces the specified attributes in the collection.
        /// </summary>
        /// <param name="attributes">The attributes to include in the collection.</param>
        void SetRange(IEnumerable<DotCommonAttribute> attributes);

        /// <summary>
        /// Adds or replaces the specified attribute in the collection.
        /// <para>
        ///     When necessary, the value specified will be rendered escaped in the generated graph, so it can be displayed properly when visualized.
        ///     If you want the value to be rendered as is, without any further processing, use the <see cref="SetCustom(string,string)"/> method instead.
        ///     If you are not sure which one to choose, then most probably the current method <see cref="Set(string, string)"/> is the right choice.
        /// </para>
        /// </summary>
        /// <param name="key">The key of the attribute to include in the collection.</param>
        /// <param name="value">The value of the attribute to include in the collection.</param>
        DotStringAttribute Set(string key, string value);

        /// <summary>
        /// Adds or replaces the specified integer value attribute in the collection.
        /// </summary>
        /// <param name="key">The key of the attribute to include in the collection.</param>
        /// <param name="value">The value of the attribute to include in the collection.</param>
        DotIntAttribute Set(string key, int value);

        /// <summary>
        /// Adds or replaces the specified double value attribute in the collection.
        /// </summary>
        /// <param name="key">The key of the attribute to include in the collection.</param>
        /// <param name="value">The value of the attribute to include in the collection.</param>
        DotDoubleAttribute Set(string key, double value);

        /// <summary>
        /// Adds or replaces the specified boolean value attribute in the collection.
        /// </summary>
        /// <param name="key">The key of the attribute to include in the collection.</param>
        /// <param name="value">The value of the attribute to include in the collection.</param>
        DotBoolAttribute Set(string key, bool value);

        /// <summary>
        /// Adds or replaces the specified node shape attribute in the collection.
        /// </summary>
        /// <param name="key">The key of the attribute to include in the collection.</param>
        /// <param name="value">The value of the attribute to include in the collection.</param>
        DotShapeAttribute Set(string key, DotShape value);

        /// <summary>
        /// Adds or replaces the specified element style attribute in the collection.
        /// </summary>
        /// <param name="key">The key of the attribute to include in the collection.</param>
        /// <param name="value">The value of the attribute to include in the collection.</param>
        DotStyleAttribute Set(string key, DotStyle value);

        /// <summary>
        /// Adds or replaces the specified arrow type attribute in the collection.
        /// </summary>
        /// <param name="key">The key of the attribute to include in the collection.</param>
        /// <param name="value">The value of the attribute to include in the collection.</param>
        DotArrowTypeAttribute Set(string key, DotArrowType value);

        /// <summary>
        /// Adds or replaces the specified arrow direction attribute in the collection.
        /// </summary>
        /// <param name="key">The key of the attribute to include in the collection.</param>
        /// <param name="value">The value of the attribute to include in the collection.</param>
        DotArrowDirectionAttribute Set(string key, DotArrowDirection value);

        /// <summary>
        /// Adds or replaces the specified rank constraint attribute in the collection.
        /// </summary>
        /// <param name="key">The key of the attribute to include in the collection.</param>
        /// <param name="value">The value of the attribute to include in the collection.</param>
        DotRankAttribute Set(string key, DotRank value);

        /// <summary>
        /// Adds or replaces the specified graph layout direction attribute in the collection.
        /// </summary>
        /// <param name="key">The key of the attribute to include in the collection.</param>
        /// <param name="value">The value of the attribute to include in the collection.</param>
        DotRankDirectionAttribute Set(string key, DotRankDirection value);

        /// <summary>
        /// Adds or replaces the specified HTML text attribute in the collection.
        /// </summary>
        /// <param name="key">The key of the attribute to include in the collection.</param>
        /// <param name="value">The value of the attribute to include in the collection.</param>
        DotHtmlAttribute SetHtml(string key, string value);

        /// <summary>
        /// Adds or replaces the specified custom attribute in the collection.
        /// <para>
        ///     The value provided will be rendered in the generated DOT script exactly the way it is provided here,
        ///     without any further processing (escaping). Therefore, it has to follow the DOT language syntax rules.
        /// </para>
        /// </summary>
        /// <param name="key">The key of the attribute to include in the collection.</param>
        /// <param name="value">The value of the attribute to include in the collection.</param>
        DotCustomAttribute SetCustom(string key, string value);
        
        /// <summary>
        /// Adds or replaces the specified custom attribute in the collection.
        /// <para>
        /// The value provided will be rendered escaped in the output DOT script by the specified text escaping pipeline.
        /// </para>
        /// </summary>
        /// <param name="key">The key of the attribute to include in the collection.</param>
        /// <param name="value">The value of the attribute to include in the collection.</param>
        /// <param name="valueEscaper">The text escaping pipeline to use for the value when generating a DOT script.</param>
        DotCustomAttribute SetCustom(string key, string value, IDotTextEscaper valueEscaper);

        /// <summary>
        /// Checks if an attribute with the specified key exists in the collection, and returns it as the specified type.
        /// If the attribute is found, but cannot be cast as the specified type, an exception is thrown.
        /// </summary>
        /// <typeparam name="T">The type to return the attribute as.</typeparam>
        /// <param name="key">The key of the attribute to get.</param>
        T GetAs<T>(string key) where T : DotCommonAttribute;

        /// <summary>
        /// Checks if an attribute with the specified key exists in the collection, and returns it as the specified type.
        /// If the attribute is found, but cannot be cast as the specified type, returns false.
        /// </summary>
        /// <typeparam name="T">The type to return the attribute as.</typeparam>
        /// <param name="key">The key of the attribute to get.</param>
        /// <param name="attribute">The attribute if found and valid, or null otherwise.</param>
        bool TryGetAs<T>(string key, out T attribute) where T : DotCommonAttribute;

        /// <summary>
        /// Checks if an attribute with the specified key exists in the collection, and returns its value as the specified type.
        /// If the attribute is found, but its value cannot be cast as the specified type, returns false.
        /// </summary>
        /// <typeparam name="T">The type to return the attribute value as.</typeparam>
        /// <param name="key">The key of the attribute to get.</param>
        /// <param name="value">The value of the attribute if found and valid, or null otherwise.</param>
        bool TryGetValueAs<T>(string key, out T value);

        /// <summary>
        /// Removes all attributes matching the specified criteria from the collection.
        /// </summary>
        /// <param name="match">The predicate to use for matching attributes.</param>
        int RemoveAll(Predicate<DotCommonAttribute> match);
    }
}