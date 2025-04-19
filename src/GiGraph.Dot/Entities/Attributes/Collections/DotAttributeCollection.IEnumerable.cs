using System.Collections;
using System.Diagnostics.Contracts;

namespace GiGraph.Dot.Entities.Attributes.Collections;

public partial class DotAttributeCollection : IEnumerable<DotAttribute>
{
    [Pure]
    public IEnumerator<DotAttribute> GetEnumerator() => _attributes.Values.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<DotAttribute>) this).GetEnumerator();
}