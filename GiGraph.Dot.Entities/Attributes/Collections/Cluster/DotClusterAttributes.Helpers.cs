namespace GiGraph.Dot.Entities.Attributes.Collections.Cluster
{
    public partial class DotClusterAttributes
    {
        /// <summary>
        ///     Makes the border and background of the cluster invisible.
        /// </summary>
        public virtual void SetInvisible()
        {
            Style.Invisible = true;
        }
    }
}