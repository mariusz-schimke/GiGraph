using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.Cluster;
using GiGraph.Dot.Entities.Attributes.Collections.Common;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public partial class DotGraphClusterAttributes : DotEntityMappableAttributes<IDotGraphClusterAttributes>, IDotGraphClusterAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup GraphClusterAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphClusterAttributes, IDotGraphClusterAttributes>().Build();
        protected readonly DotGraphAttributes _graphGraphAttributes;

        protected DotGraphClusterAttributes(
            DotGraphAttributes graphAttributes,
            DotMemberAttributeKeyLookup attributeKeyLookup,
            DotClusterStyleAttributes styleAttributes
        )
            : base(graphAttributes.Collection, attributeKeyLookup)
        {
            _graphGraphAttributes = graphAttributes;
            Style = styleAttributes;
        }

        public DotGraphClusterAttributes(DotGraphAttributes graphAttributes)
            : this(
                graphAttributes,
                GraphClusterAttributesKeyLookup,
                new DotClusterStyleAttributes(graphAttributes.Collection)
            )
        {
        }

        /// <summary>
        ///     Style options. Note that the options are shared with those of the graph.
        /// </summary>
        public virtual DotClusterStyleAttributes Style { get; }

        /// <inheritdoc cref="IDotGraphClusterCommonAttributes.Color" />
        [DotAttributeKey(DotAttributeKeys.Color)]
        public virtual DotColorDefinition Color
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        /// <inheritdoc cref="IDotGraphClusterCommonAttributes.BorderWidth" />
        [DotAttributeKey(DotAttributeKeys.PenWidth)]
        public virtual double? BorderWidth
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemoveBorderWidth(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotGraphClusterCommonAttributes.BorderColor" />
        [DotAttributeKey(DotAttributeKeys.PenColor)]
        public virtual DotColor BorderColor
        {
            get => GetValueAsColor(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        /// <inheritdoc cref="IDotGraphClusterCommonAttributes.FillColor" />
        [DotAttributeKey(DotAttributeKeys.FillColor)]
        public virtual DotColorDefinition FillColor
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        /// <inheritdoc cref="IDotGraphClusterAttributes.AllowEdgeClipping" />
        [DotAttributeKey(DotAttributeKeys.Compound)]
        public virtual bool? AllowEdgeClipping
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphClusterAttributes.VisualizationMode" />
        [DotAttributeKey(DotAttributeKeys.ClusterRank)]
        public virtual DotClusterVisualizationMode? VisualizationMode
        {
            get => GetValueAs<DotClusterVisualizationMode>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotClusterVisualizationModeAttribute(k, v.Value));
        }
    }
}