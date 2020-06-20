using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Records
{
    /// <summary>
    /// Represents a field of a record (<see cref="DotRecord"/>). It can either be text (<see cref="DotRecordTextField"/>),
    /// or another record (<see cref="DotRecord"/>).
    /// A record can be used as the label of a record-based node (<see href="http://www.graphviz.org/doc/info/shapes.html#record"/>). 
    /// </summary>
    public abstract class DotRecordField : IDotEncodableValue
    {
        protected internal abstract string GetDotEncoded(DotGenerationOptions options, DotSyntaxRules syntaxRules, bool hasParent);
        string IDotEncodableValue.GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules) => GetDotEncoded(options, syntaxRules, hasParent: false);

        public static implicit operator DotRecordField(string text)
        {
            return (DotRecordTextField) text;
        }

        public static implicit operator DotRecordField(DotRecordField[] fields)
        {
            return (DotRecord) fields;
        }

        public static implicit operator DotRecordField(string[] fields)
        {
            return (DotRecord) fields;
        }
    }
}