using System;
using GiGraph.Dot.Entities.Html.Font;

namespace GiGraph.Dot.Entities.Html.Builder
{
    public partial class DotHtmlBuilder
    {
        /// <summary>
        ///     Initializes and appends a bold element.
        /// </summary>
        /// <param name="init">
        ///     An element initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendBold(Action<DotHtmlBold> init)
        {
            return Append(new DotHtmlBold(), init);
        }

        /// <summary>
        ///     Initializes and appends an italic element.
        /// </summary>
        /// <param name="init">
        ///     An element initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendItalic(Action<DotHtmlItalic> init)
        {
            return Append(new DotHtmlItalic(), init);
        }

        /// <summary>
        ///     Initializes and appends an underline element.
        /// </summary>
        /// <param name="init">
        ///     An element initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendUnderline(Action<DotHtmlUnderline> init)
        {
            return Append(new DotHtmlUnderline(), init);
        }

        /// <summary>
        ///     Initializes and appends an overline element.
        /// </summary>
        /// <param name="init">
        ///     An element initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendOverline(Action<DotHtmlOverline> init)
        {
            return Append(new DotHtmlOverline(), init);
        }

        /// <summary>
        ///     Initializes and appends an subscript element.
        /// </summary>
        /// <param name="init">
        ///     An element initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendSubscript(Action<DotHtmlSubscript> init)
        {
            return Append(new DotHtmlSubscript(), init);
        }

        /// <summary>
        ///     Initializes and appends an superscript element.
        /// </summary>
        /// <param name="init">
        ///     An element initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendSuperscript(Action<DotHtmlSuperscript> init)
        {
            return Append(new DotHtmlSuperscript(), init);
        }

        /// <summary>
        ///     Initializes and appends an strikethrough element.
        /// </summary>
        /// <param name="init">
        ///     An element initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendStrikethrough(Action<DotHtmlStrikethrough> init)
        {
            return Append(new DotHtmlStrikethrough(), init);
        }
    }
}