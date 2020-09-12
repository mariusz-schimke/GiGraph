namespace GiGraph.Dot.Entities.Types.Colors
{
    /// <summary>
    ///     Provides a list of supported color schemes.
    /// </summary>
    public static class DotColorSchemes
    {
        /// <summary>
        ///     Uses the default color scheme for the associated color if a color scheme attribute has been set for the current element.
        /// </summary>
        public static string Default => "/";

        /// <summary>
        ///     The X11 color scheme (<see href="http://www.graphviz.org/doc/info/colors.html#x11" />).
        /// </summary>
        public static string X11 => "x11";

        /// <summary>
        ///     The SVG color scheme (<see href="http://www.graphviz.org/doc/info/colors.html#svg" />).
        /// </summary>
        public static string Svg => "svg";

        /// <summary>
        ///     The Brewer color schemes (<see href="http://www.graphviz.org/doc/info/colors.html#brewer" />).
        /// </summary>
        public static DotBrewerColorSchemes Brewer { get; } = new DotBrewerColorSchemes();

        /// <summary>
        ///     Provides a list of supported Brewer color schemes (<see href="http://www.graphviz.org/doc/info/colors.html#brewer" />).
        /// </summary>
        public class DotBrewerColorSchemes
        {
            public string Accent3 => "accent3";
            public string Accent4 => "accent4";
            public string Accent5 => "accent5";
            public string Accent6 => "accent6";
            public string Accent7 => "accent7";
            public string Accent8 => "accent8";

            public string Blues3 => "blues3";
            public string Blues4 => "blues4";
            public string Blues5 => "blues5";
            public string Blues6 => "blues6";
            public string Blues7 => "blues7";
            public string Blues8 => "blues8";
            public string Blues9 => "blues9";

            public string BrBg3 => "brbg3";
            public string BrBg4 => "brbg4";
            public string BrBg5 => "brbg5";
            public string BrBg6 => "brbg6";
            public string BrBg7 => "brbg7";
            public string BrBg8 => "brbg8";
            public string BrBg9 => "brbg9";
            public string BrBg10 => "brbg10";
            public string BrBg11 => "brbg11";

            public string BuGn3 => "bugn3";
            public string BuGn4 => "bugn4";
            public string BuGn5 => "bugn5";
            public string BuGn6 => "bugn6";
            public string BuGn7 => "bugn7";
            public string BuGn8 => "bugn8";
            public string BuGn9 => "bugn9";

            public string BuPu3 => "bupu3";
            public string BuPu4 => "bupu4";
            public string BuPu5 => "bupu5";
            public string BuPu6 => "bupu6";
            public string BuPu7 => "bupu7";
            public string BuPu8 => "bupu8";
            public string BuPu9 => "bupu9";

            public string Dark23 => "dark23";
            public string Dark24 => "dark24";
            public string Dark25 => "dark25";
            public string Dark26 => "dark26";
            public string Dark27 => "dark27";
            public string Dark28 => "dark28";

            public string GnBu3 => "gnbu3";
            public string GnBu4 => "gnbu4";
            public string GnBu5 => "gnbu5";
            public string GnBu6 => "gnbu6";
            public string GnBu7 => "gnbu7";
            public string GnBu8 => "gnbu8";
            public string GnBu9 => "gnbu9";

            public string Greens3 => "greens3";
            public string Greens4 => "greens4";
            public string Greens5 => "greens5";
            public string Greens6 => "greens6";
            public string Greens7 => "greens7";
            public string Greens8 => "greens8";
            public string Greens9 => "greens9";

            public string Greys3 => "greys3";
            public string Greys4 => "greys4";
            public string Greys5 => "greys5";
            public string Greys6 => "greys6";
            public string Greys7 => "greys7";
            public string Greys8 => "greys8";
            public string Greys9 => "greys9";

            public string Oranges3 => "oranges3";
            public string Oranges4 => "oranges4";
            public string Oranges5 => "oranges5";
            public string Oranges6 => "oranges6";
            public string Oranges7 => "oranges7";
            public string Oranges8 => "oranges8";
            public string Oranges9 => "oranges9";

            public string OrRd3 => "orrd3";
            public string OrRd4 => "orrd4";
            public string OrRd5 => "orrd5";
            public string OrRd6 => "orrd6";
            public string OrRd7 => "orrd7";
            public string OrRd8 => "orrd8";
            public string OrRd9 => "orrd9";

            public string Paired3 => "paired3";
            public string Paired4 => "paired4";
            public string Paired5 => "paired5";
            public string Paired6 => "paired6";
            public string Paired7 => "paired7";
            public string Paired8 => "paired8";
            public string Paired9 => "paired9";
            public string Paired10 => "paired10";
            public string Paired11 => "paired11";
            public string Paired12 => "paired12";

            public string Pastel13 => "pastel13";
            public string Pastel14 => "pastel14";
            public string Pastel15 => "pastel15";
            public string Pastel16 => "pastel16";
            public string Pastel17 => "pastel17";
            public string Pastel18 => "pastel18";
            public string Pastel19 => "pastel19";
            public string Pastel23 => "pastel23";
            public string Pastel24 => "pastel24";
            public string Pastel25 => "pastel25";
            public string Pastel26 => "pastel26";
            public string Pastel27 => "pastel27";
            public string Pastel28 => "pastel28";

            public string PiYg3 => "piyg3";
            public string PiYg4 => "piyg4";
            public string PiYg5 => "piyg5";
            public string PiYg6 => "piyg6";
            public string PiYg7 => "piyg7";
            public string PiYg8 => "piyg8";
            public string PiYg9 => "piyg9";
            public string PiYg10 => "piyg10";
            public string PiYg11 => "piyg11";

            public string PrGn3 => "prgn3";
            public string PrGn4 => "prgn4";
            public string PrGn5 => "prgn5";
            public string PrGn6 => "prgn6";
            public string PrGn7 => "prgn7";
            public string PrGn8 => "prgn8";
            public string PrGn9 => "prgn9";
            public string PrGn10 => "prgn10";
            public string PrGn11 => "prgn11";

            public string PuBu3 => "pubu3";
            public string PuBu4 => "pubu4";
            public string PuBu5 => "pubu5";
            public string PuBu6 => "pubu6";
            public string PuBu7 => "pubu7";
            public string PuBu8 => "pubu8";
            public string PuBu9 => "pubu9";

            public string PuBuGn3 => "pubugn3";
            public string PuBuGn4 => "pubugn4";
            public string PuBuGn5 => "pubugn5";
            public string PuBuGn6 => "pubugn6";
            public string PuBuGn7 => "pubugn7";
            public string PuBuGn8 => "pubugn8";
            public string PuBuGn9 => "pubugn9";

            public string PuOr3 => "puor3";
            public string PuOr4 => "puor4";
            public string PuOr5 => "puor5";
            public string PuOr6 => "puor6";
            public string PuOr7 => "puor7";
            public string PuOr8 => "puor8";
            public string PuOr9 => "puor9";
            public string PuOr10 => "puor10";
            public string PuOr11 => "puor11";

            public string PuRd3 => "purd3";
            public string PuRd4 => "purd4";
            public string PuRd5 => "purd5";
            public string PuRd6 => "purd6";
            public string PuRd7 => "purd7";
            public string PuRd8 => "purd8";
            public string PuRd9 => "purd9";

            public string Purples3 => "purples3";
            public string Purples4 => "purples4";
            public string Purples5 => "purples5";
            public string Purples6 => "purples6";
            public string Purples7 => "purples7";
            public string Purples8 => "purples8";
            public string Purples9 => "purples9";

            public string RdBu3 => "rdbu3";
            public string RdBu4 => "rdbu4";
            public string RdBu5 => "rdbu5";
            public string RdBu6 => "rdbu6";
            public string RdBu7 => "rdbu7";
            public string RdBu8 => "rdbu8";
            public string RdBu9 => "rdbu9";
            public string RdBu10 => "rdbu10";
            public string RdBu11 => "rdbu11";

            public string RdGy3 => "rdgy3";
            public string RdGy4 => "rdgy4";
            public string RdGy5 => "rdgy5";
            public string RdGy6 => "rdgy6";
            public string RdGy7 => "rdgy7";
            public string RdGy8 => "rdgy8";
            public string RdGy9 => "rdgy9";
            public string RdGy10 => "rdgy10";
            public string RdGy11 => "rdgy11";

            public string RdPu3 => "rdpu3";
            public string RdPu4 => "rdpu4";
            public string RdPu5 => "rdpu5";
            public string RdPu6 => "rdpu6";
            public string RdPu7 => "rdpu7";
            public string RdPu8 => "rdpu8";
            public string RdPu9 => "rdpu9";

            public string RdYlBu3 => "rdylbu3";
            public string RdYlBu4 => "rdylbu4";
            public string RdYlBu5 => "rdylbu5";
            public string RdYlBu6 => "rdylbu6";
            public string RdYlBu7 => "rdylbu7";
            public string RdYlBu8 => "rdylbu8";
            public string RdYlBu9 => "rdylbu9";
            public string RdYlBu10 => "rdylbu10";
            public string RdYlBu11 => "rdylbu11";

            public string RdYlGn3 => "rdylgn3";
            public string RdYlGn4 => "rdylgn4";
            public string RdYlGn5 => "rdylgn5";
            public string RdYlGn6 => "rdylgn6";
            public string RdYlGn7 => "rdylgn7";
            public string RdYlGn8 => "rdylgn8";
            public string RdYlGn9 => "rdylgn9";
            public string RdYlGn10 => "rdylgn10";
            public string RdYlGn11 => "rdylgn11";

            public string Reds3 => "reds3";
            public string Reds4 => "reds4";
            public string Reds5 => "reds5";
            public string Reds6 => "reds6";
            public string Reds7 => "reds7";
            public string Reds8 => "reds8";
            public string Reds9 => "reds9";

            public string Set13 => "set13";
            public string Set14 => "set14";
            public string Set15 => "set15";
            public string Set16 => "set16";
            public string Set17 => "set17";
            public string Set18 => "set18";
            public string Set19 => "set19";

            public string Set23 => "set23";
            public string Set24 => "set24";
            public string Set25 => "set25";
            public string Set26 => "set26";
            public string Set27 => "set27";
            public string Set28 => "set28";

            public string Set33 => "set33";
            public string Set34 => "set34";
            public string Set35 => "set35";
            public string Set36 => "set36";
            public string Set37 => "set37";
            public string Set38 => "set38";
            public string Set39 => "set39";

            public string Set310 => "set310";
            public string Set311 => "set311";
            public string Set312 => "set312";

            public string Spectral3 => "spectral3";
            public string Spectral4 => "spectral4";
            public string Spectral5 => "spectral5";
            public string Spectral6 => "spectral6";
            public string Spectral7 => "spectral7";
            public string Spectral8 => "spectral8";
            public string Spectral9 => "spectral9";
            public string Spectral10 => "spectral10";
            public string Spectral11 => "spectral11";

            public string YlGn3 => "ylgn3";
            public string YlGn4 => "ylgn4";
            public string YlGn5 => "ylgn5";
            public string YlGn6 => "ylgn6";
            public string YlGn7 => "ylgn7";
            public string YlGn8 => "ylgn8";
            public string YlGn9 => "ylgn9";

            public string YlGnBu3 => "ylgnbu3";
            public string YlGnBu4 => "ylgnbu4";
            public string YlGnBu5 => "ylgnbu5";
            public string YlGnBu6 => "ylgnbu6";
            public string YlGnBu7 => "ylgnbu7";
            public string YlGnBu8 => "ylgnbu8";
            public string YlGnBu9 => "ylgnbu9";

            public string YlOrBr3 => "ylorbr3";
            public string YlOrBr4 => "ylorbr4";
            public string YlOrBr5 => "ylorbr5";
            public string YlOrBr6 => "ylorbr6";
            public string YlOrBr7 => "ylorbr7";
            public string YlOrBr8 => "ylorbr8";
            public string YlOrBr9 => "ylorbr9";

            public string YlOrRd3 => "ylorrd3";
            public string YlOrRd4 => "ylorrd4";
            public string YlOrRd5 => "ylorrd5";
            public string YlOrRd6 => "ylorrd6";
            public string YlOrRd7 => "ylorrd7";
            public string YlOrRd8 => "ylorrd8";
            public string YlOrRd9 => "ylorrd9";
        }
    }
}