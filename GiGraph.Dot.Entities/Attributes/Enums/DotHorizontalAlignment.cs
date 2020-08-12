using GiGraph.Dot.Entities.Types.Attributes;

namespace GiGraph.Dot.Entities.Attributes.Enums
{
    /// <summary>
    ///     The justification options for labels.
    /// </summary>
    public enum DotHorizontalAlignment
    {
        [DotAttributeValue("l")]
        Left,
        
        [DotAttributeValue("c")]
        Center,
        
        [DotAttributeValue("r")]
        Right
    }
}