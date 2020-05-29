﻿namespace GiGraph.Dot.Entities.Attributes
{
    public abstract class DotCommonAttribute : IDotAttribute, IDotOrderableEntity
    {
        /// <summary>
        /// Gets or sets the key of the attribute.
        /// </summary>
        public string Key { get; set; }

        string IDotOrderableEntity.OrderingKey => Key;

        /// <summary>
        /// Gets the value of the attribute in a format understood by DOT graph renderer.
        /// </summary>
        protected abstract string GetDotEncodedValue();

        protected DotCommonAttribute(string key)
        {
            Key = key;
        }

        string IDotAttribute.GetDotEncodedValue() => GetDotEncodedValue();
    }

    public abstract class DotCommonAttribute<T> : DotCommonAttribute, IDotAttribute
    {
        /// <summary>
        /// Gets or sets the value of the attribute.
        /// </summary>
        public T Value { get; set; }

        public DotCommonAttribute(string key, T value)
            : base(key)
        {
            Value = value;
        }

        /// <summary>
        /// Converts the value to string using the default converter (unless overriden in a descendant class).
        /// </summary>
        public override string ToString()
        {
            return Value?.ToString();
        }

        /// <summary>
        /// Gets the value of the attribute in a format understood by DOT graph renderer.
        /// </summary>
        protected override string GetDotEncodedValue()
        {
            return Value?.ToString() ?? string.Empty;
        }

        public static implicit operator T(DotCommonAttribute<T> attribute)
        {
            return attribute is { } ? attribute.Value : default;
        }
    }
}