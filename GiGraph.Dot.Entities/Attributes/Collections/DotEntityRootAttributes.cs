using System.Linq;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Attributes;

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
        public virtual ILookup<string, string> GetKeyMapping()
        {
            // TODO: write a unit test to ensure that no key has more than one property assigned (apart from graph style and graph clusters style)

            var properties = GetPathsOfEntityAttributeProperties();

            return properties
               .Select(path =>
                {
                    var actual = path.Last();
                    return new
                    {
                        actual.Property.GetCustomAttribute<DotAttributeKeyAttribute>().Key,
                        Path = string.Join(".", path.Select(item => item.Property.Name))
                    };
                })
               .ToLookup(
                    key => key.Key,
                    value => value.Path
                );
        }
    }
}