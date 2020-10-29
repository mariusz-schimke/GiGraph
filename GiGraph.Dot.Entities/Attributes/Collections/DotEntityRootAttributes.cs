using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract class DotEntityRootAttributes<TIEntityAttributeProperties> : DotEntityAttributes<TIEntityAttributeProperties>, IDotAnnotatable
    {
        protected DotEntityRootAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        /// <summary>
        ///     Gets the underlying collection of attributes applied to the element.
        /// </summary>
        public virtual DotAttributeCollection Collection => _attributes;

        public virtual string Annotation
        {
            get => _attributes.Annotation;
            set => _attributes.Annotation = value;
        }

        /// <summary>
        ///     Gets a dictionary where the key is a DOT attribute, and the value is a path to a property that exposes it.
        /// </summary>
        public virtual Dictionary<string, string> GetAttributeKeyMapping()
        {
            var properties = GetPathsOfEntityAttributeProperties();

            return properties
               .Select(path =>
                {
                    var actual = path.Last();
                    return new
                    {
                        Key = actual.EntityAttributes.GetAttributeKey(actual.Property),
                        Path = string.Join(".", path.Select(item => item.Property.Name))
                    };
                })
               .ToDictionary(
                    key => key.Key,
                    value => value.Path
                );
        }
    }
}