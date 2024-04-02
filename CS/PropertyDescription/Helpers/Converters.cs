using System.Globalization;
// using PropertyDescriptionHTMLEdit.Model;

namespace PropertyDescriptionHTMLEdit.Helpers;

public class StatusToColorConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        AppTheme currentTheme = Application.Current.RequestedTheme;
        if (value is null) {
            return null;
        }
        byte status = (byte)value;
        var alpha = (float)parameter;
        Color res;
        if (currentTheme is AppTheme.Light) {
            res = status switch {
                1 => Color.FromArgb("#60BA07"),
                0 => Color.FromArgb("#BF9500"),
                _ => Color.FromArgb("#60BA07")
            };
        } else {
            res = status switch {
                1 => Color.FromArgb("#A0CD73"),
                0 => Color.FromArgb("#BF9500"),
                _ => Color.FromArgb("#A0CD73")
            };
        }

        return res.WithAlpha(alpha);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}