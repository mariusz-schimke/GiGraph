namespace GiGraph.Dot.Types.Styling
{
    /// <summary>
    ///     The fill styles of an element.
    /// </summary>
    public enum DotFillStyle
    {
        /// <summary>
        ///     No fill.
        /// </summary>
        None = 0,

        /// <inheritdoc cref="DotStyles.Filled" />
        Normal = DotStyles.Filled,

        /// <inheritdoc cref="DotStyles.Striped" />
        Striped = DotStyles.Striped,

        /// <inheritdoc cref="DotStyles.Wedged" />
        Wedged = DotStyles.Wedged,

        /// <inheritdoc cref="DotStyles.Radial" />
        Radial = DotStyles.Radial
    }
}