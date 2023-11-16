using DevExpress.Maui.Controls;
using DevExpress.Maui.HtmlEditor;

namespace HtmlEditToolbarCustomization;

public partial class MainPage : ContentPage {

    public MainPage() {
        InitializeComponent();
    }

    TextFormatView? TextFormatView { get; set; }
    EmbedImageSettingsView AddImageView {get; set; }
    FontFamilySettingsView FontFamilyView { get; set; }

    async void OnButtonClicked(object sender, EventArgs e) {
        while (true) {
            if (this.toolbar.SelectedPageName == null) {
                this.toolbar.SelectedPageName = "TextSettings";
            } else {
                this.toolbar.SelectedPageName = null;
            }
            await Task.Delay(1000);
        }
    }

    void OnShowFontFamilySettingsClicked(object sender, EventArgs e) {
        FontFamilySettingsViewModel vm = new (this.edit, NavigateToEditPage);
        FontFamilyView = FontFamilyView ?? new FontFamilySettingsView();
        FontFamilyView.BindingContext = vm;
        ContentPage page = new() { Content = FontFamilyView, Title = HtmlEditLocalizer.GetString(HtmlEditStringId.SelectFontFamily) };
        page.ToolbarItems.Add(new ToolbarItem() { IconImageSource="dxre_check", Command = vm.ApplyCommand});
        Navigation.PushAsync(page).ContinueWith(t => 
            InputHelper.HideKeyboardOnAndroid()
        );
    }

    void OnShowEmbedImageSettingsClicked(object sender, EventArgs e) {
        EmbedImageSettingsViewModel vm = new (this.edit, () => this.root.IsOpened = false);
        AddImageView = AddImageView ?? new EmbedImageSettingsView();
        AddImageView.BindingContext = vm;
        this.root.KeyboardAreaContent = AddImageView;
        this.root.IsOpened = true;        
    }

    void OnShowEmbedHyperlinkSettingsClicked(object sender, EventArgs e) {
        HyperlinkSettingViewModel vm = new (this.edit, () => Navigation.PopAsync());
        HyperlinkSettingsView view = new() {
            BindingContext = vm
        };
        ContentPage page = new() { Content = view, Title = HtmlEditLocalizer.GetString(HtmlEditStringId.InsertHyperlink_Title) };
        page.ToolbarItems.Add(new ToolbarItem() { IconImageSource="dxre_check", Command = vm.ApplyCommand});
        Navigation.PushAsync(page);
    }

    void OnShowTextSettingsClicked(object sender, EventArgs e) {
        this.edit.AllowUserInput = false;
        this.toolbar.SelectedPageName = "TextSettings";
        TextFormatView = TextFormatView ?? new TextFormatView();
        this.root.KeyboardAreaContent = TextFormatView;
        TextFormatView.BindingContext = new TextFormatViewModel(this.edit);
        this.root.IsOpened = true;
    }

    async Task NavigateToEditPage() {
        await Navigation.PopAsync();
        this.edit.Focus();
        await Task.Delay(1000);
    }

    void OnSafeKeyboardAreaViewClosed(object sender, EventArgs e) {
        this.toolbar.SelectedPageName = null;
        ClearKeyboardArea();
    }

    async void OnResetToolbarClicked(object sender, EventArgs e) {
        this.edit.AllowUserInput = true;
        this.edit.Focus();
        this.toolbar.SelectedPageName = null;
        if (this.root.KeyboardAreaContent != null) {
            await this.root.CloseAsync();
            ClearKeyboardArea();
        }
    }
    void ClearKeyboardArea() {
        if (this.root.KeyboardAreaContent == null)
            return;
        if (this.root.KeyboardAreaContent is View view) {
            if (view.BindingContext is IHtmlOwner htmlOwner)
                htmlOwner.Owner = null;
            view.BindingContext = null;
        }
        this.root.KeyboardAreaContent = null;
        this.edit.Focus();
    }
}