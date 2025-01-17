using DevExpress.Maui.Core;

namespace PropertyDescriptionHTMLEdit;

public partial class App : Application {
    public App() {
        InitializeComponent();
        ThemeManager.ApplyThemeToSystemBars = true;
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        return new Window(new AppShell());
    }
}