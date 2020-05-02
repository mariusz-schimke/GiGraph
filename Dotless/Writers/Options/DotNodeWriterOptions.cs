namespace Dotless.Writers.Options
{
    public class DotNodeWriterOptions
    {
        /// <summary>
        /// When set, node identifier will always be quoted, even if that is not required.
        /// </summary>
        public bool PreferQuotedId { get; set; } = true;
    }
}
