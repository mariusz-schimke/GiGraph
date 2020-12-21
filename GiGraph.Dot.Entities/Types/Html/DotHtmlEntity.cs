using System;
using System.Collections.Generic;
using GiGraph.Dot.Entities.Types.Strings;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Entities.Types.Html
{
    /// <summary>
    ///     Represents a meaningful HTML entity.
    /// </summary>
    public abstract class DotHtmlEntity
    {
        /// <summary>
        ///     Converts the entity to HTML.
        /// </summary>
        public abstract DotHtml ToHtml();

        /// <summary>
        ///     Creates a collection of entities to represent the specified text as HTML. All line breaks will be replaced with &lt;br /&gt;
        ///     tags.
        /// </summary>
        /// <param name="text">
        ///     The input text.
        /// </param>
        /// <param name="newLine">
        ///     The line break sequences to replace with HTML line break tags (see <see cref="DotNewLine" />).
        /// </param>
        public static DotHtmlEntity[] FromText(string text, params string[] newLine)
        {
            if (text is null)
            {
                return new DotHtmlEntity[0];
            }

            var result = new List<DotHtmlEntity>();
            var lines = text.Split(newLine, StringSplitOptions.None);

            for (var i = 0; i < lines.Length; i++)
            {
                result.Add(new DotHtmlText(lines[i]));

                if (i < lines.Length - 1)
                {
                    result.Add(new DotHtmlLineBreak());
                }
            }

            return result.ToArray();
        }

        /// <summary>
        ///     Creates a collection of entities to represent the specified text as HTML. All line breaks will be replaced with &lt;br /&gt;
        ///     tags.
        /// </summary>
        /// <param name="text">
        ///     The input text.
        /// </param>
        public static DotHtmlEntity[] FromText(string text)
        {
            return FromText(text, DotNewLine.Windows, DotNewLine.Unix);
        }
    }
}