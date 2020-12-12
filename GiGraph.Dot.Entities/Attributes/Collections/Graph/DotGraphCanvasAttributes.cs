using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Attributes.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public class DotGraphCanvasAttributes : DotEntityAttributes<IDotGraphCanvasAttributes>, IDotGraphCanvasAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup GraphCanvasAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphCanvasAttributes, IDotGraphCanvasAttributes>().Build();

        protected DotGraphCanvasAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotGraphCanvasAttributes(DotAttributeCollection attributes)
            : base(attributes, GraphCanvasAttributesKeyLookup)
        {
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.CenterDrawing" />
        [DotAttributeKey(DotAttributeKeys.Center)]
        public virtual bool? CenterDrawing
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.Orientation" />
        [DotAttributeKey(DotAttributeKeys.Orientation)]
        public virtual DotOrientation? Orientation
        {
            get => GetValueAs<DotOrientation>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotOrientation?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotOrientationAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.OrientationAngle" />
        [DotAttributeKey(DotAttributeKeys.Rotate)]
        public virtual int? OrientationAngle
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotIntAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.Landscape" />
        [DotAttributeKey(DotAttributeKeys.Landscape)]
        public virtual bool? Landscape
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        /// <summary>
        ///     Copies canvas properties from the specified instance.
        /// </summary>
        /// <param name="source">
        ///     The instance to copy the properties from.
        /// </param>
        public virtual void CopyFrom(IDotGraphCanvasAttributes source)
        {
            CenterDrawing = source.CenterDrawing;
            Landscape = source.Landscape;
            Orientation = source.Orientation;
            OrientationAngle = source.OrientationAngle;
        }
    }
}