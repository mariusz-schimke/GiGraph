using System;
using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Types.Records;

public partial class DotRecordBuilder
{
    /// <summary>
    ///     Appends a field to the record being built.
    /// </summary>
    /// <param name="text">
    ///     The text of the field to append.
    /// </param>
    /// <param name="portName">
    ///     The port name, that is a name that can be referred to from an edge endpoint in order to attach the end of the edge to the
    ///     appended field.
    /// </param>
    public virtual DotRecordBuilder AppendField(DotEscapeString? text, string? portName = null)
    {
        _fields.Add(new DotRecordTextField(text, portName));
        return this;
    }

    /// <summary>
    ///     Appends a field to the record being built.
    /// </summary>
    /// <param name="formatText">
    ///     The method delegate to generate formatted text for the field, using the specified text formatter.
    /// </param>
    /// <param name="portName">
    ///     The port name, that is a name that can be referred to from an edge endpoint in order to attach the end of the edge to the
    ///     appended field.
    /// </param>
    public virtual DotRecordBuilder AppendField(Action<DotFormattedTextBuilder> formatText, string? portName = null)
    {
        var formatter = new DotFormattedTextBuilder();
        formatText(formatter);

        return AppendField(formatter.Build(), portName);
    }
}