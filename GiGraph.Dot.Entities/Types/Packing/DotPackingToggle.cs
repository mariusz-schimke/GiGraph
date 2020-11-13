using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Packing
{
    /// <summary>
    ///     Determines whether graph packing is enabled or disabled.
    /// </summary>
    public class DotPackingToggle : DotPackingDefinition
    {
        /// <summary>
        ///     Creates a new instance.
        /// </summary>
        /// <param name="enabled">
        ///     If true, each connected component of the graph is laid out separately, and then the graphs are packed together. If false, the
        ///     entire graph is laid out together.
        /// </param>
        public DotPackingToggle(bool enabled)
        {
            Enabled = enabled;
        }

        /// <summary>
        ///     If true, each connected component of the graph is laid out separately, and then the graphs are packed together. If false, the
        ///     entire graph is laid out together.
        /// </summary>
        public virtual bool Enabled { get; set; }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return Enabled ? "true" : "false";
        }
    }
}