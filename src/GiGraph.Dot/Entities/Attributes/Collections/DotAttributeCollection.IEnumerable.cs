using System.Collections;

namespace GiGraph.Dot.Entities.Attributes.Collections;

public partial class DotAttributeCollection : IEnumerable<DotAttribute>
{
    public IEnumerator<DotAttribute> GetEnumerator() => _attributes.Values.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<DotAttribute>) this).GetEnumerator();
}