using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Edges.Enums;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Edges;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Ranks;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public class DotAttributeCollection : SortedList<string, DotAttribute>, IDotAttributeCollection
    {
        public virtual string Annotation { get; set; }

        public virtual T Set<T>(T attribute)
            where T : DotAttribute
        {
            this[attribute.Key] = attribute;
            return attribute;
        }

        public virtual void SetRange(IEnumerable<DotAttribute> attributes)
        {
            foreach (var attribute in attributes)
            {
                Set(attribute);
            }
        }

        public virtual DotStringAttribute Set(string key, string value)
        {
            return Set(new DotStringAttribute(key, value));
        }

        public virtual DotEscapeStringAttribute Set(string key, DotEscapableString value)
        {
            return Set(new DotEscapeStringAttribute(key, value));
        }

        public virtual DotEscapeStringAttribute Set(string key, DotEscapedString value)
        {
            return Set(new DotEscapeStringAttribute(key, value));
        }

        public virtual DotLabelAttribute Set(string key, DotLabelString value)
        {
            return Set(new DotLabelAttribute(key, value));
        }

        public virtual DotLabelAttribute Set(string key, DotLabelHtml value)
        {
            return Set(new DotLabelAttribute(key, value));
        }

        public virtual DotLabelAttribute Set(string key, DotLabelRecord value)
        {
            return Set(new DotLabelAttribute(key, value));
        }

        public virtual DotHorizontalAlignmentAttribute Set(string key, DotHorizontalAlignment value)
        {
            return Set(new DotHorizontalAlignmentAttribute(key, value));
        }

        public virtual DotVerticalLabelAlignmentAttribute Set(string key, DotVerticalLabelAlignment value)
        {
            return Set(new DotVerticalLabelAlignmentAttribute(key, value));
        }

        public virtual DotIntAttribute Set(string key, int value)
        {
            return Set(new DotIntAttribute(key, value));
        }

        public virtual DotDoubleAttribute Set(string key, double value)
        {
            return Set(new DotDoubleAttribute(key, value));
        }

        public virtual DotDoubleListAttribute Set(string key, params double[] value)
        {
            return Set(new DotDoubleListAttribute(key, value));
        }

        public virtual DotDoubleListAttribute Set(string key, IEnumerable<double> value)
        {
            return Set(new DotDoubleListAttribute(key, value));
        }

        public virtual DotBoolAttribute Set(string key, bool value)
        {
            return Set(new DotBoolAttribute(key, value));
        }

        public virtual DotColorAttribute Set(string key, Color value)
        {
            return Set(new DotColorAttribute(key, value));
        }

        public virtual DotColorDefinitionAttribute Set(string key, DotColorDefinition value)
        {
            return Set(new DotColorDefinitionAttribute(key, value));
        }

        public virtual DotNodeShapeAttribute Set(string key, DotNodeShape value)
        {
            return Set(new DotNodeShapeAttribute(key, value));
        }

        public virtual DotEdgeShapeAttribute Set(string key, DotEdgeShape value)
        {
            return Set(new DotEdgeShapeAttribute(key, value));
        }

        public virtual DotNodeFixedSizeAttribute Set(string key, DotNodeSizing value)
        {
            return Set(new DotNodeFixedSizeAttribute(key, value));
        }

        public virtual DotStyleAttribute Set(string key, DotStyle value)
        {
            return Set(new DotStyleAttribute(key, value));
        }

        public virtual DotArrowTypeAttribute Set(string key, DotArrowType value)
        {
            return Set(new DotArrowTypeAttribute(key, value));
        }

        public virtual DotArrowDirectionAttribute Set(string key, DotArrowDirection value)
        {
            return Set(new DotArrowDirectionAttribute(key, value));
        }

        public virtual DotRankAttribute Set(string key, DotRank value)
        {
            return Set(new DotRankAttribute(key, value));
        }

        public virtual DotRankDirectionAttribute Set(string key, DotRankDirection value)
        {
            return Set(new DotRankDirectionAttribute(key, value));
        }

        public virtual DotRankSeparationAttribute Set(string key, DotRankSeparationDefinition value)
        {
            return Set(new DotRankSeparationAttribute(key, value));
        }

        public virtual DotRankSeparationAttribute Set(string key, DotRankSeparation value)
        {
            return Set(new DotRankSeparationAttribute(key, value));
        }

        public virtual DotRankSeparationAttribute Set(string key, DotRankSeparationList value)
        {
            return Set(new DotRankSeparationAttribute(key, value));
        }

        public virtual DotEndpointPortAttribute Set(string key, DotEndpointPort value)
        {
            return Set(new DotEndpointPortAttribute(key, value));
        }

        public virtual DotEndpointPortAttribute Set(string key, DotCompassPoint value)
        {
            return Set(new DotEndpointPortAttribute(key, new DotEndpointPort(value)));
        }

        public virtual T GetAs<T>(string key)
            where T : DotAttribute
        {
            if (TryGetValue(key, out var result))
            {
                return (T) result;
            }

            return null;
        }

        public virtual bool TryGetAs<T>(string key, out T attribute)
            where T : DotAttribute
        {
            if (TryGetValue(key, out var result))
            {
                attribute = result as T;
                return attribute is { };
            }

            attribute = null;
            return false;
        }

        public virtual bool TryGetValueAs<T>(string key, out T value)
        {
            if (TryGetValue(key, out var attribute) && attribute.GetValue() is T attributeValue)
            {
                value = attributeValue;
                return true;
            }

            value = default;
            return false;
        }

        public virtual int RemoveAll(Predicate<DotAttribute> match)
        {
            var result = 0;
            var matches = Values.Where(a => match(a)).ToArray();

            foreach (var attribute in matches)
            {
                result += Remove(attribute.Key) ? 1 : 0;
            }

            return result;
        }

        void IDictionary<string, DotAttribute>.Add(string key, DotAttribute attribute)
        {
            if (key != attribute.Key)
            {
                throw new ArgumentException($"The key specified (\"{key}\") has to match the attribute key (\"{attribute.Key}\").", nameof(key));
            }

            Add(key, attribute);
        }

        protected virtual void AddOrRemove<T>(string key, T attribute)
            where T : DotAttribute
        {
            if (attribute is null)
            {
                Remove(key);
            }
            else
            {
                Set(attribute);
            }
        }

        protected virtual void AddOrRemove<TAttribute, TValue>(string key, TValue value, Func<string, TValue, TAttribute> newAttribute)
            where TAttribute : DotAttribute
        {
            AddOrRemove(key, value is null ? null : newAttribute(key, value));
        }
    }
}