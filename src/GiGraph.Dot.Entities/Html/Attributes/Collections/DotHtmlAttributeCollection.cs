using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Factories;

namespace GiGraph.Dot.Entities.Html.Attributes.Collections
{
    // TODO: sprawdzić, czy można by zastąpić w kontekście HTML bazową kolekcję DotAttributeCollection (na wszelki wypadek, żeby nie doszło do pomyłki ze względu na factory)
    public class DotHtmlAttributeCollection : DotAttributeCollection
    {
        public DotHtmlAttributeCollection(DotHtmlAttributeFactory attributeFactory)
            : base(attributeFactory)
        {
        }

        public DotHtmlAttributeCollection()
            : base(DotHtmlAttributeFactory.Instance)
        {
        }
    }
}