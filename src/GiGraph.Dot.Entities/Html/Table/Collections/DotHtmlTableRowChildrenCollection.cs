using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Html.Font;
using GiGraph.Dot.Entities.Html.Image;
using GiGraph.Dot.Entities.Html.Text;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Fonts;
using GiGraph.Dot.Types.Images;

namespace GiGraph.Dot.Entities.Html.Table.Collections
{
    // TODO: dodać komentarze sugerujące, jakie elementy można dodać gdzie

    public class DotHtmlTableRowChildrenCollection : DotHtmlEntityCollection
    {
        /// <summary>
        ///     Adds a cell to the current row.
        /// </summary>
        /// <param name="init">
        ///     A cell initializer delegate.
        /// </param>
        public virtual DotHtmlTableCell AddCell(Action<DotHtmlTableCell> init = null)
        {
            return Add(new DotHtmlTableCell(), init);
        }

        /// <summary>
        ///     Adds a cell with an image to the current row.
        /// </summary>
        /// <param name="source">
        ///     The image file to be displayed in the cell.
        /// </param>
        /// <param name="scaling">
        ///     Specifies how the image will use any extra space available in its cell.
        /// </param>
        /// <param name="init">
        ///     A cell initializer delegate.
        /// </param>
        public virtual DotHtmlTableCell AddImageCell(string source, DotImageScaling? scaling = null, Action<DotHtmlTableCell> init = null)
        {
            return Add(
                new DotHtmlTableCell { Children = { new DotHtmlImage(source, scaling) } },
                init
            );
        }

        /// <summary>
        ///     Adds a text cell to the current row.
        /// </summary>
        /// <param name="text">
        ///     The text to initialize the cell with.
        /// </param>
        /// <param name="init">
        ///     A cell initializer delegate.
        /// </param>
        public virtual DotHtmlTableCell AddCell(string text, Action<DotHtmlTableCell> init = null)
        {
            return Add(
                new DotHtmlTableCell { Children = { new DotHtmlText(text) } },
                init
            );
        }

        /// <summary>
        ///     Adds a text cell to the current row.
        /// </summary>
        /// <param name="text">
        ///     The text to initialize the cell with.
        /// </param>
        /// <param name="fontStyle">
        ///     The font style to apply to the text.
        /// </param>
        /// <param name="name">
        ///     The name of the font to use.
        /// </param>
        /// <param name="size">
        ///     The size to apply to the font.
        /// </param>
        /// <param name="color">
        ///     The color to apply to the text.
        /// </param>
        /// <param name="init">
        ///     A cell initializer delegate.
        /// </param>
        public virtual DotHtmlTableCell AddCell(string text, DotFontStyles fontStyle, string name = null, double? size = null, DotColor color = null, Action<DotHtmlTableCell> init = null)
        {
            return Add(
                new DotHtmlTableCell { Children = { DotHtmlFont.StyleText(text, name, size, color, fontStyle) } },
                init
            );
        }

        /// <summary>
        ///     Adds a text cell to the current row.
        /// </summary>
        /// <param name="text">
        ///     The text to initialize the cell with.
        /// </param>
        /// <param name="font">
        ///     The font and style to apply to the text.
        /// </param>
        /// <param name="init">
        ///     A cell initializer delegate.
        /// </param>
        public virtual DotHtmlTableCell AddCell(string text, DotStyledFont font, Action<DotHtmlTableCell> init = null)
        {
            return Add(
                new DotHtmlTableCell { Children = { DotHtmlFont.StyleText(text, font) } },
                init
            );
        }

        /// <summary>
        ///     Adds the specified text cells to the current row.
        /// </summary>
        /// <param name="cells">
        ///     The text for the cells to add.
        /// </param>
        public virtual DotHtmlTableCell[] AddCells(params string[] cells)
        {
            return AddCells((IEnumerable<string>) cells);
        }

        /// <summary>
        ///     Adds the specified text cells to the current row.
        /// </summary>
        /// <param name="cells">
        ///     The text for the cells to add.
        /// </param>
        /// <param name="init">
        ///     A cell initializer delegate.
        /// </param>
        public virtual DotHtmlTableCell[] AddCells(IEnumerable<string> cells, Action<DotHtmlTableCell, int> init = null)
        {
            return cells.Select((item, index) =>
                {
                    var cell = new DotHtmlTableCell { Children = { new DotHtmlText(item) } };
                    init?.Invoke(cell, index);
                    return base.Add(cell);
                })
               .ToArray();
        }

        /// <summary>
        ///     Adds the specified text cells to the current row.
        /// </summary>
        /// <param name="cells">
        ///     The text for the cells to add.
        /// </param>
        /// <param name="fontStyle">
        ///     The font style to apply to the text.
        /// </param>
        /// <param name="name">
        ///     The name of the font to use.
        /// </param>
        /// <param name="size">
        ///     The size to apply to the font.
        /// </param>
        /// <param name="color">
        ///     The color to apply to the text.
        /// </param>
        /// <param name="init">
        ///     A cell initializer delegate.
        /// </param>
        public virtual DotHtmlTableCell[] AddCells(IEnumerable<string> cells, DotFontStyles fontStyle, string name = null, double? size = null, DotColor color = null, Action<DotHtmlTableCell, int> init = null)
        {
            return cells.Select((item, index) =>
                {
                    var cell = new DotHtmlTableCell { Children = { DotHtmlFont.StyleText(item, name, size, color, fontStyle) } };
                    init?.Invoke(cell, index);
                    return base.Add(cell);
                })
               .ToArray();
        }

        /// <summary>
        ///     Adds the specified text cells to the current row.
        /// </summary>
        /// <param name="cells">
        ///     The text for the cells to add.
        /// </param>
        /// <param name="font">
        ///     The font and style to apply to the text.
        /// </param>
        /// <param name="init">
        ///     A cell initializer delegate.
        /// </param>
        public virtual DotHtmlTableCell[] AddCells(IEnumerable<string> cells, DotStyledFont font, Action<DotHtmlTableCell, int> init = null)
        {
            return cells.Select((item, index) =>
                {
                    var cell = new DotHtmlTableCell { Children = { DotHtmlFont.StyleText(item, font) } };
                    init?.Invoke(cell, index);
                    return base.Add(cell);
                })
               .ToArray();
        }
    }
}