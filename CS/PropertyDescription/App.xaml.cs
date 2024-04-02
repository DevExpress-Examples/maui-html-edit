using DevExpress.Maui.Core;

namespace PropertyDescriptionHTMLEdit;

public partial class App : Application {
    public App() {
        InitializeComponent();

        MainPage = new AppShell();
        ThemeManager.ApplyThemeToSystemBars = true;
    }
}