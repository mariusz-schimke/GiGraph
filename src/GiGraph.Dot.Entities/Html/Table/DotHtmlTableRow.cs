using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Factories;
using GiGraph.Dot.Entities.Html.Font;
using GiGraph.Dot.Entities.Html.Image;
using GiGraph.Dot.Entities.Html.Rule;
using GiGraph.Dot.Entities.Html.Text;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Fonts;
using GiGraph.Dot.Types.Images;

namespace GiGraph.Dot.Entities.Html.Table
{
    /// <summary>
    ///     An HTML table row (&lt;tr&gt;).
    /// </summary>
    public class DotHtmlTableRow : DotHtmlElement
    {
        /// <summary>
        ///     Initializes a new table row instance.
        /// </summary>
        public DotHtmlTableRow()
            : this(new DotAttributeCollection(DotHtmlAttributeFactory.Instance))
        {
        }

        protected DotHtmlTableRow(DotAttributeCollection attributes)
            : base("tr", attributes)
        {
        }

        /// <summary>
        ///     Adds a vertical rule to separate two neighboring cells.
        /// </summary>
        public virtual DotHtmlVerticalRule AddVerticalRule()
        {
            return Content.Add(new DotHtmlVerticalRule(), init: null);
        }

        /// <summary>
        ///     Adds a cell to the current row.
        /// </summary>
        /// <param name="init">
        ///     A cell initializer delegate.
        /// </param>
        public virtual DotHtmlTableCell AddCell(Action<DotHtmlTableCell> init = null)
        {
            return Content.Add(new DotHtmlTableCell(), init);
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
            return Content.Add(
                new DotHtmlTableCell { Content = { new DotHtmlImage(source, scaling) } },
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
            return Content.Add(
                new DotHtmlTableCell { Content = { new DotHtmlText(text) } },
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
        /// <param name="fontName">
        ///     The name of the font to use.
        /// </param>
        /// <param name="fontSize">
        ///     The size to apply to the font.
        /// </param>
        /// <param name="fontColor">
        ///     The color to apply to the text.
        /// </param>
        /// <param name="init">
        ///     A cell initializer delegate.
        /// </param>
        public virtual DotHtmlTableCell AddCell(string text, DotFontStyles fontStyle, string fontName = null, double? fontSize = null, DotColor fontColor = null, Action<DotHtmlTableCell> init = null)
        {
            return Content.Add(
                new DotHtmlTableCell { Content = { DotHtmlFont.SetFont(text, fontName, fontSize, fontColor, fontStyle) } },
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
            return Content.Add(
                new DotHtmlTableCell { Content = { DotHtmlFont.SetFont(text, font) } },
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
                    var cell = new DotHtmlTableCell { Content = { new DotHtmlText(item) } };
                    init?.Invoke(cell, index);
                    return Content.Add(cell);
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
        /// <param name="fontName">
        ///     The name of the font to use.
        /// </param>
        /// <param name="fontSize">
        ///     The size to apply to the font.
        /// </param>
        /// <param name="fontColor">
        ///     The color to apply to the text.
        /// </param>
        /// <param name="init">
        ///     A cell initializer delegate.
        /// </param>
        public virtual DotHtmlTableCell[] AddCells(IEnumerable<string> cells, DotFontStyles fontStyle, string fontName = null, double? fontSize = null, DotColor fontColor = null, Action<DotHtmlTableCell, int> init = null)
        {
            return cells.Select((item, index) =>
                {
                    var cell = new DotHtmlTableCell { Content = { DotHtmlFont.SetFont(item, fontName, fontSize, fontColor, fontStyle) } };
                    init?.Invoke(cell, index);
                    return Content.Add(cell);
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
                    var cell = new DotHtmlTableCell { Content = { DotHtmlFont.SetFont(item, font) } };
                    init?.Invoke(cell, index);
                    return Content.Add(cell);
                })
               .ToArray();
        }
    }
}