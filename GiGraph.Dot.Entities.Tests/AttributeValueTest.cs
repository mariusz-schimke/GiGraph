using System;
using System.Linq;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Edges.Enums;
using GiGraph.Dot.Entities.Types.Arrows;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Packing;
using GiGraph.Dot.Output.Options;
using Xunit;

namespace GiGraph.Dot.Entities.Tests
{
    public class AttributeValueTest
    {
        private readonly DotGenerationOptions _generationOptions = new DotGenerationOptions();
        private readonly DotSyntaxRules _syntaxRules = new DotSyntaxRules();

        [Theory]
        [InlineData(typeof(DotAlignment))]
        [InlineData(typeof(DotArrowDirection))]
        [InlineData(typeof(DotArrowheadShape))]
        [InlineData(typeof(DotAspectRatio))]
        [InlineData(typeof(DotClusterMode))]
        [InlineData(typeof(DotEdgeOrderingMode))]
        [InlineData(typeof(DotEdgeShape))]
        [InlineData(typeof(DotHorizontalAlignment))]
        [InlineData(typeof(DotNodeShape))]
        [InlineData(typeof(DotNodeSizing))]
        [InlineData(typeof(DotPackingGranularity))]
        [InlineData(typeof(DotRank))]
        [InlineData(typeof(DotRankDirection))]
        [InlineData(typeof(DotStyle))]
        [InlineData(typeof(DotVerticalAlignment))]
        [InlineData(typeof(DotArrayPackingOption))]
        [InlineData(typeof(DotCompassPoint))]
        [InlineData(typeof(DotArrowheadParts))]
        public void all_enum_properties_have_a_non_empty_attribute_value_assigned(Type enumType)
        {
            foreach (var value in Enum.GetValues(enumType))
            {
                var enumMember = enumType.GetMember(value.ToString()).First();

                var attribute = enumMember?.GetCustomAttribute<DotAttributeValueAttribute>();
                Assert.NotNull(attribute);
                Assert.NotEmpty(attribute.Value);
            }
        }
    }
}