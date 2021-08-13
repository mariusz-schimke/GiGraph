using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Html
{
    /// <summary>
    ///     Contains ready HTML text to be rendered as is, without further processing.
    /// </summary>
    public class DotHtml : DotHtmlEntity
    {
        // TODO: dodać osobną klasę z kodami HTML: https://www.rapidtables.com/web/html/html-codes.html
        // a może to mógłby być enum, gdzie wartość to kod znaku, a atrybut określałby wartość tekstową html?
        // Wtedy konwersja do HTML-a mogłaby bazować na opcjach globalnych (np. HEX/DEC/Kod jeśli kod dostępny)

        protected readonly string _html;

        /// <summary>
        ///     Initializes a new instance with the specified HTML.
        /// </summary>
        /// <param name="html">
        ///     The HTML to initialize the instance with.
        /// </param>
        public DotHtml(string html)
        {
            _html = html;
        }

        protected internal override string ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => _html;
    }
}