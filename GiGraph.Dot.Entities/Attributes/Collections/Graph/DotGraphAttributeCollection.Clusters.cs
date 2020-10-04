using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Attributes;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public partial class DotGraphAttributeCollection : IDotGraphClusterAttributes
    {
        public virtual IDotGraphClusterAttributes Clusters => this;

        [DotAttributeKey("compound")]
        bool? IDotGraphClusterAttributes.AllowEdgeClipping
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        [DotAttributeKey("clusterrank")]
        DotClusterVisualizationMode? IDotGraphClusterAttributes.VisualizationMode
        {
            get => GetValueAs<DotClusterVisualizationMode>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotClusterVisualizationMode?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotClusterVisualizationModeAttribute(k, v.Value));
        }
    }
}