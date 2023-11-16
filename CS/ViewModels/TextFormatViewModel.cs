using System.ComponentModel;
using DevExpress.Maui.Core;
using DevExpress.Maui.HtmlEditor;
using FontSize = DevExpress.Maui.HtmlEditor.HtmlFontSize;

namespace HtmlEditToolbarCustomization;

public class TextFormatViewModel : BindableBase, IHtmlOwner {
    static Color[] PredefinedDefaultColors { get; } = new Color[] {
            Color.FromRgb(0xff, 0xff, 0xff),
            Color.FromRgb(0x00, 0x00, 0x00),
            Color.FromRgb(0x61, 0x61, 0x61),
            Color.FromRgb(0xC6, 0x28, 0x28),
            Color.FromRgb(0x6A, 0x1B, 0x9A),
            Color.FromRgb(0x15, 0x65, 0xC0),
            Color.FromRgb(0x17, 0xC8, 0xB3),
            Color.FromRgb(0x2E, 0x7D, 0x32),
            Color.FromRgb(0xF9, 0xA8, 0x25),
            Color.FromRgb(0x4E, 0x34, 0x2E),
        };
    static List<ColorTarget> PredefinedColorTargets { get; } = new List<ColorTarget>() {
        new ColorTarget() { DisplayName = HtmlEditLocalizer.GetString(HtmlEditStringId.TextSettings_FontColor), ColorTargetType = ColorTargetType.Foreground },
        new ColorTarget() { DisplayName = HtmlEditLocalizer.GetString(HtmlEditStringId.TextSettings_BackgroundColor), ColorTargetType = ColorTargetType.Background }
    };

    public TextFormatViewModel(HtmlEdit owner) {
        SelectedColorTarget = ColorTargets[0];
        Owner = owner;
        SetColorCommand = new Command<Color>(SetColor);
        SetFontSizeCommand = new Command<string>(SetFontSize);
    }

    public Color[] DefaultColors => PredefinedDefaultColors;
    public List<ColorTarget> ColorTargets => PredefinedColorTargets;
    public HtmlEdit? Owner {
        get => GetValue<HtmlEdit>();
        set => SetValue(value, (ov, nv) => {
            if (ov != null)
                OnDetachHtmlEdit(ov);
            if (nv != null)
                OnAttachHtmlEdit(nv);
        });
    }

    public int? FontSize {
        get => GetValue<int?>();
        set => SetValue(value, () => {
            if (Owner is not null)
                Owner.SelectedTextFontSize = value == null ? HtmlFontSize.Empty : new HtmlFontSize(value ?? 8, HtmlSizeUnit.Points);
        });
    }

    public Color Color {
        get => GetValue<Color>();
        set => SetValue(value, () => SetColor(value));
    }

    public ColorTarget SelectedColorTarget {
        get => GetValue<ColorTarget>();
        set => SetValue(value, () => {
            UpdateColor();
        });
    }

    public Command SetColorCommand { get; }
    public Command SetFontSizeCommand { get; }

    void OnAttachHtmlEdit(HtmlEdit htmlEdit) {
        htmlEdit.PropertyChanged += OnHtmlEditPropertyChanged;
        if (!htmlEdit.SelectedTextFontSize.IsEmpty && htmlEdit.SelectedTextFontSize.Unit == HtmlSizeUnit.Points)
            FontSize = (int)htmlEdit.SelectedTextFontSize.Value;
        UpdateColor();
    }

    void OnDetachHtmlEdit(HtmlEdit htmlEdit) {
        htmlEdit.PropertyChanged -= OnHtmlEditPropertyChanged;
    }

    void UpdateColor() {
        if (Owner == null || SelectedColorTarget == null)
            return;
        Color = SelectedColorTarget.ColorTargetType == ColorTargetType.Background ? Owner.SelectedTextBackground : Owner.SelectedTextForeground;
    }

    void SetColor(Color color) {
        Color = color;
        if (Owner is null || SelectedColorTarget == null)
            return;
        if (SelectedColorTarget.ColorTargetType == ColorTargetType.Background) {
            Owner.SelectedTextBackground = color;
        } else {
            Owner.SelectedTextForeground = color;
        }
    }

    void SetFontSize(string fontSize) {
        FontSize = int.Parse(fontSize);
    }

    void OnHtmlEditPropertyChanged(object? sender, PropertyChangedEventArgs? e) {
        if (Owner is null)
            return;
        if (e?.PropertyName == nameof(HtmlEdit.SelectedTextFontSize)) {
            if (Owner != null && !Owner.SelectedTextFontSize.IsEmpty && Owner.SelectedTextFontSize.Unit == HtmlSizeUnit.Points)
                FontSize = (int)(Owner?.SelectedTextFontSize.Value ?? 8);
        }
    }

    public class ColorTarget {
        public string? DisplayName { get; set; }
        public ColorTargetType ColorTargetType { get; set; }
    }
    public enum ColorTargetType {
        Background,
        Foreground
    }
}

public interface IHtmlOwner {
    HtmlEdit? Owner { get; set; }
}