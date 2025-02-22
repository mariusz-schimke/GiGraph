namespace GiGraph.Dot.Entities.Graphs.Collections;

public class DotGraphSectionCollection<TSection> : List<TSection>
    where TSection : DotCommonGraphSection, new()
{
    /// <summary>
    ///     Adds the specified graph section to the collection and optionally initializes its content.
    /// </summary>
    /// <param name="section">
    ///     The section to add.
    /// </param>
    /// <param name="init">
    ///     An optional section initializer delegate.
    /// </param>
    public virtual TSection Add(TSection section, Action<TSection>? init)
    {
        init?.Invoke(section);
        Add(section);
        return section;
    }

    /// <summary>
    ///     Adds a graph section to the collection and optionally initializes its content.
    /// </summary>
    /// <param name="init">
    ///     An optional section initializer delegate.
    /// </param>
    public virtual TSection Add(Action<TSection>? init = null) => Add(new(), init);
}