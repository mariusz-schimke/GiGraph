namespace GiGraph.Dot.Entities.Tests.Attributes
{
    // TODO: napisać testy jednostkowe weryfikujące, czy właściwości posiadające te same klucze posiadają te same nazwy w różnych interfejsach

    public class DotTwinAttributeGroupsCoherenceTest : DotAttributeTestBase
    {
        // [Theory]
        // [InlineData(typeof(IDotEdgeHeadAttributes), typeof(IDotEdgeTailAttributes))]
        // public void interfaces_contain_equivalent_members(Type interface1, Type interface2)
        // {
        //     var interface1Props = interface1.GetProperties(AttributePropertyFlags);
        //     var interface2Props = interface2.GetProperties(AttributePropertyFlags);
        //
        //     Assert.Equal(interface1Props.Length, interface2Props.Length);
        //
        //     foreach (var interface1Prop in interface1Props)
        //     {
        //         Assert.Contains(interface2Props, x =>
        //             interface1Prop.Name.Equals(x.Name) &&
        //             interface1Prop.PropertyType == x.PropertyType &&
        //             !(interface1Prop.GetMethod is {} ^ x.GetMethod is {}) &&
        //             !(interface1Prop.SetMethod is {} ^ x.SetMethod is {})
        //         );
        //     }
        // }
    }
}