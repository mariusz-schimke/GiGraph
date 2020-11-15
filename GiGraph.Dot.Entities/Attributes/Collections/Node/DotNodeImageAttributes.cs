using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Metadata;
using GiGraph.Dot.Entities.Types.Images;

namespace GiGraph.Dot.Entities.Attributes.Collections.Node
{
    public class DotNodeImageAttributes : DotEntityAttributes<IDotNodeImageAttributes>, IDotNodeImageAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup NodeImageAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotNodeImageAttributes, IDotNodeImageAttributes>().Build();

        protected DotNodeImageAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotNodeImageAttributes(DotAttributeCollection attributes)
            : base(attributes, NodeImageAttributesKeyLookup)
        {
        }

        /// <inheritdoc cref="IDotNodeImageAttributes.Path" />
        [DotAttributeKey(DotAttributeKeys.Image)]
        public virtual string Path
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        /// <inheritdoc cref="IDotNodeImageAttributes.Alignment" />
        [DotAttributeKey(DotAttributeKeys.ImagePos)]
        public virtual DotAlignment? Alignment
        {
            get => GetValueAs<DotAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotAlignment?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotAlignmentAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotNodeImageAttributes.Scaling" />
        [DotAttributeKey(DotAttributeKeys.ImageScale)]
        public virtual DotImageScaling? Scaling
        {
            get => GetValueAs<DotImageScaling>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotImageScaling?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotImageScalingAttribute(k, v.Value));
        }

        /// <summary>
        ///     Specifies image attributes.
        /// </summary>
        /// <param name="path">
        ///     The path to an image.
        /// </param>
        /// <param name="alignment">
        ///     The alignment of the image.
        /// </param>
        /// <param name="scaling">
        ///     The scaling option to apply to the image.
        /// </param>
        public virtual void Set(string path, DotAlignment? alignment = null, DotImageScaling? scaling = null)
        {
            Path = path;
            Alignment = alignment;
            Scaling = scaling;
        }

        /// <summary>
        ///     Specifies image attributes.
        /// </summary>
        /// <param name="attributes">
        ///     The image attributes to set.
        /// </param>
        public virtual void Set(DotImage attributes)
        {
            Set(attributes.Path, attributes.Alignment, attributes.Scaling);
        }

        /// <summary>
        ///     Copies image properties from the specified instance.
        /// </summary>
        /// <param name="source">
        ///     The instance to copy the properties from.
        /// </param>
        public virtual void CopyFrom(IDotNodeImageAttributes source)
        {
            Set(source.Path, source.Alignment, source.Scaling);
        }
    }
}