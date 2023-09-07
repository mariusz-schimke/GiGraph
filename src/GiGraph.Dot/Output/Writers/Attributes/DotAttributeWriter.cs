using System.Linq;
using GiGraph.Dot.Output.Writers.TokenWriter;

namespace GiGraph.Dot.Output.Writers.Attributes;

public class DotAttributeWriter : DotEntityWriter, IDotAttributeWriter
{
    public DotAttributeWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration)
        : base(tokenWriter, configuration, enforceBlockComment: false)
    {
    }

    public virtual void WriteAttribute(string key, bool quoteKey, string value, bool quoteValue)
    {
        InitializeAttribute(key, quoteKey);
        _tokenWriter.Value(value, quoteValue);
    }

    public virtual void WriteHtmlAttribute(string key, bool quoteKey, string value, bool writeInBrackets)
    {
        InitializeAttribute(key, quoteKey);

        // As HTML strings can contain newline characters, which are used solely for formatting, the language does not allow
        // escaped newlines or concatenation operators to be used within them.
        // https://graphviz.org/doc/info/lang.html
        _tokenWriter.HtmlValue(value, writeInBrackets);
    }

    public virtual void WriteAttribute(string key, bool quoteKey, string[] valueParts, bool quoteValue)
    {
        if (_tokenWriter.Options.SingleLine)
        {
            var value = string.Join(string.Empty, valueParts);
            WriteAttribute(key, quoteKey, value, quoteValue);
            return;
        }

        WriteConcatenatedValueAttribute(key, quoteKey, valueParts, quoteValue);
    }

    protected virtual void WriteConcatenatedValueAttribute(string key, bool quoteKey, string[] valueParts, bool quoteValue)
    {
        quoteValue |= valueParts.Length > 1;
        WriteAttribute(key, quoteKey, valueParts.FirstOrDefault(), quoteValue);

        DotTokenWriter tokenWriter = null;
        foreach (var valuePart in valueParts.Skip(1))
        {
            tokenWriter ??= _tokenWriter.NextIndentationLevel();
            tokenWriter.Space()
               .StringConcatenationOperator()
               .NewLine()
               .Value(valuePart, quoteValue);
        }
    }

    protected virtual void InitializeAttribute(string key, bool quoteKey)
    {
        _tokenWriter.Identifier(key, quoteKey)
           .Space()
           .ValueAssignmentOperator()
           .Space();
    }
}