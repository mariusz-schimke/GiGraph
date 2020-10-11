﻿using System;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    public abstract class DotAttribute : IDotEntity, IDotAnnotatable, IDotEncodable, IDotOrderable
    {
        protected DotAttribute(string key)
        {
            Key = key ?? throw new ArgumentNullException(nameof(key), "Attribute key cannot be null.");
        }

        /// <summary>
        ///     Gets the key of the attribute.
        /// </summary>
        public string Key { get; }

        public virtual string Annotation { get; set; }

        string IDotEncodable.GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return GetDotEncodedValue(options, syntaxRules);
        }

        string IDotOrderable.OrderingKey => Key;

        /// <summary>
        ///     Gets the value of the attribute.
        /// </summary>
        public abstract object GetValue();

        /// <summary>
        ///     Gets the value of the attribute in a format understood by DOT graph renderer.
        /// </summary>
        /// <param name="options">
        ///     The DOT generation options to use.
        /// </param>
        /// <param name="syntaxRules">
        ///     The DOT syntax rules to use.
        /// </param>
        protected internal abstract string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules);
    }
}