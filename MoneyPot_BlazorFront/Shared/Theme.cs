namespace MoneyPot_BlazorFront.Shared
{
    public class Theme
    {
        private static WhiteTheme? _whiteTheme;
        private static WhiteTheme WhiteTheme
        {
            get
            {
                if (_whiteTheme == null) _whiteTheme = new WhiteTheme();
                return _whiteTheme;
            }
        }
        public enum Mode
        {
            White,
            Dark,
        }

        public static IThemeInfo GetTheme(Mode mode)
        {
            switch(mode)
            {
                case Mode.White: return Theme.WhiteTheme;
            }

            throw new NotImplementedException();
        }
    }

    public interface IThemeInfo
    {
        string MainColor { get; }
        string MinorColor { get; }
        string BackgroundPrimaryColor { get; }
        string BackgroundSecondaryColor { get; }
        string BorderColor { get; }
    }

    public class WhiteTheme : IThemeInfo
    {
        public string MainColor => "green-600";

        public string MinorColor => "amber-400";

        public string BackgroundPrimaryColor => "white";

        public string BorderColor => "slate-200";

        public string BackgroundSecondaryColor => "gray-50";
    }

    //public class DarkTheme : IThemeInfo
    //{

    //}
}
