using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Entities;

public interface IDotAttributeCollection : IDotEntity
{
    // TODO: teraz niby implementacja jest sama w sobie kolekcją, a tu zwracam tę samą lub inną przez metodę
    DotAttributeCollection GetAttributes(DotSyntaxOptions options);
}