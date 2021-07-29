using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Text;

namespace GiGraph.Dot.Types.Records
{
    /// <summary>
    ///     Represents a field of a record (<see cref="DotRecord" />). It can either be text (<see cref="DotRecordTextField" />), or
    ///     another record (<see cref="DotRecord" />). A record can be used as the label of a
    ///     <see href="http://www.graphviz.org/doc/info/shapes.html#record">
    ///         record-based node
    ///     </see>
    ///     .
    /// </summary>
    public abstract class DotRecordField : IDotComplexType
    {
        string IDotComplexType.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return GetDotEncoded(options, syntaxRules, hasParent: false);
        }

        protected internal abstract string GetDotEncoded(DotSyntaxOptions options, DotSyntaxRules syntaxRules, bool hasParent);

        public static implicit operator DotRecordField(string text)
        {
            return (DotRecordTextField) text;
        }

        public static implicit operator DotRecordField(DotEscapeString text)
        {
            return (DotRecordTextField) text;
        }
    }
}