using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Entities;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Attributes;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public class DotNodeAttributeCollection : DotEntityAttributeCollection<IDotNodeAttributes>, IDotNodeAttributeCollection
    {
        [DotAttributeKey("shape")]
        public virtual DotNodeShape? Shape
        {
            get => TryGetValueAs<DotNodeShape>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotNodeShape?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotNodeShapeAttribute(k, v.Value));
        }

        [DotAttributeKey("sides")]
        public virtual int? Sides
        {
            get => TryGetValueAs<int>(MethodBase.GetCurrentMethod(), out var result) ? result : (int?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0
                ? throw new ArgumentOutOfRangeException(nameof(Sides), v.Value, "The number of sides must be greater than or equal to 0.")
                : new DotIntAttribute(k, v.Value));
        }

        [DotAttributeKey("regular")]
        public virtual bool? Regular
        {
            get => TryGetValueAs<bool>(MethodBase.GetCurrentMethod(), out var result) ? result : (bool?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        [DotAttributeKey("skew")]
        public virtual double? Skew
        {
            get => TryGetValueAs<double>(MethodBase.GetCurrentMethod(), out var result) ? result : (double?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey("distortion")]
        public virtual double? Distortion
        {
            get => TryGetValueAs<double>(MethodBase.GetCurrentMethod(), out var result) ? result : (double?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey("orientation")]
        public virtual double? Orientation
        {
            get => TryGetValueAs<double>(MethodBase.GetCurrentMethod(), out var result) ? result : (double?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey("width")]
        public virtual double? Width
        {
            get => TryGetValueAs<double>(MethodBase.GetCurrentMethod(), out var result) ? result : (double?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0
                ? throw new ArgumentOutOfRangeException(nameof(Width), v.Value, "The width must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey("height")]
        public virtual double? Height
        {
            get => TryGetValueAs<double>(MethodBase.GetCurrentMethod(), out var result) ? result : (double?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0
                ? throw new ArgumentOutOfRangeException(nameof(Height), v.Value, "The height must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey("fixedsize")]
        public virtual DotNodeSizing? Sizing
        {
            get => TryGetValueAs<DotNodeSizing>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotNodeSizing?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotNodeFixedSizeAttribute(k, v.Value));
        }

        [DotAttributeKey("image")]
        public virtual string ImagePath
        {
            get => TryGetValueAs<string>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        [DotAttributeKey("group")]
        public virtual string GroupName
        {
            get => TryGetValueAs<string>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        [DotAttributeKey("imagepos")]
        public virtual DotAlignment? ImageAlignment
        {
            get => TryGetValueAs<DotAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotAlignment?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotAlignmentAttribute(k, v.Value));
        }
    }
}