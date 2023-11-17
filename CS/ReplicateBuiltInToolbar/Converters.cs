using System.Globalization;
using DevExpress.Maui.HtmlEditor;

namespace HtmlEditToolbarCustomization;

public class EnumToBoolConverter : IMarkupExtension, IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if (value is not Enum valueEnum) {
            return false;
        }
        if (parameter is string parameterString) {
            Type enumType = value.GetType();
            Enum enumValue = (Enum)Enum.Parse(enumType, parameterString);
            return Enum.IsDefined(enumType, value) ? enumValue.Equals(value) : valueEnum.HasFlag(enumValue);
        }
        return parameter is Enum parameterEnum ? parameterEnum.Equals(valueEnum) : false;
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        return Binding.DoNothing;
    }
    public object ProvideValue(IServiceProvider serviceProvider) {
        return this;
    }
}

public class ColorToBoolConverter : IMarkupExtension, IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        Color color = (Color)parameter;
        Color valueColor = (Color)value;
        return Object.Equals(color, valueColor);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotSupportedException();
    }

    public object ProvideValue(IServiceProvider serviceProvider) {
        return this;
    }
}

public class IntToBoolConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if (parameter is string parameterString) {
            if (int.TryParse(parameterString, out int intValue)) {
                return Object.Equals(intValue, value);
            }
            return false;
        } else {
            int intValue = (int)parameter;
            int valueInt = (int)value;
            return Object.Equals(intValue, valueInt);
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        return null;
    }

    public object ProvideValue(IServiceProvider serviceProvider) {
        return this;
    }
}

public class LineHeightToBoolConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if (parameter is string parameterString) {
            HtmlLineHeight lineHeight = (HtmlLineHeight)value;
            if (double.TryParse(parameterString, out double intValue)) {
                return Object.Equals(intValue, lineHeight.Value);
            }
            return false;
        } else {
            double parameterValue = (double)parameter;
            HtmlLineHeight lineHeight = (HtmlLineHeight)value;
            return Object.Equals(parameterValue, lineHeight.Value);
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        return null;
    }

    public object ProvideValue(IServiceProvider serviceProvider) {
        return this;
    }
} 