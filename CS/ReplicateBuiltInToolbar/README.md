# DevExpress .NET MAUI HTML Edit - Replicate a Built-In Toolbar

The DevExpress **HTML Edit** control for .NET MAUI includes a built-in [DXToolbar Control](https://docs.devexpress.com/MAUI/404604/dialogs-menu-and-navigation/toolbar/toolbar-overview?v=23.2). This example replicates the **HTML Edit**'s built-in toolbar in XAML and uses a [SafeKeyboardAreaView](https://docs.devexpress.com/MAUI/DevExpress.Maui.Core.SafeKeyboardAreaView?v=23.2&) container. This class helps you achieve the following:
* Decreases the height of the HTML Edit when you open the device keyboard and keep the toolbar visible. In other words, avoids an overlap between the keyboard and the toolbar.
* Displays custom content in the keyboard area to add more space for UI elements.

![DevExpress .NET MAUI HTML Edit - Custom Panel in the Keyboard Area](https://docs.devexpress.com/MAUI/images/core/safekeyboardareaview.png?v=23.2)

## Files to Review

- [MainPage.xaml](MainPage.xaml)
- [MainPage.xaml.cs](MainPage.xaml.cs)
- [EmbedImageSettingsView.xaml](Views/EmbedImageSettingsView.xaml)
- [EmbedImageSettingsViewModel.cs](ViewModels/EmbedImageSettingsViewModel.cs)
- [FontFamilySettingsView.xaml](Views/FontFamilySettingsView.xaml)
- [FontFamilySettingsViewModel.cs](ViewModels/FontFamilySettingsViewModel.cs)
- [HyperlinkSettingsView.xaml](Views/HyperlinkSettingsView.xaml)
- [HyperlinkSettingsViewModel.cs](ViewModels/HyperlinkSettingsViewModel.cs)
- [TextFormatView.xaml](Views/TextFormatView.xaml)
- [TextFormatViewModel.cs](ViewModels/TextFormatViewModel.cs)

## Documentation

- [SafeKeyboardAreaView](https://docs.devexpress.com/MAUI/DevExpress.Maui.Core.SafeKeyboardAreaView?v=23.2)
- [DXToolbar Control](https://docs.devexpress.com/MAUI/404604/dialogs-menu-and-navigation/toolbar/toolbar-overview?v=23.2)
- [HTML Edit - Create a Custom Toolbar](https://docs.devexpress.com/MAUI/404639/html-edit/toolbar?v=23.2)

## More Examples

* [DevExpress .NET MAUI Demo Center](https://github.com/DevExpress-Examples/maui-demo-app)
* [Stocks App](https://github.com/DevExpress-Examples/maui-stocks-mini)
* [Data Grid](https://github.com/DevExpress-Examples/maui-data-grid-get-started)
* [Data Form](https://github.com/DevExpress-Examples/maui-data-form-get-started)
* [Data Editors](https://github.com/DevExpress-Examples/maui-editors-get-started)
* [Charts](https://github.com/DevExpress-Examples/maui-charts)
* [Scheduler](https://github.com/DevExpress-Examples/maui-scheduler-get-started)
* [Tab Page](https://github.com/DevExpress-Examples/maui-tab-page-get-started)
* [Tab View](https://github.com/DevExpress-Examples/maui-tab-view-get-started)
* [Drawer Page](https://github.com/DevExpress-Examples/maui-drawer-page-get-started)
* [Drawer View](https://github.com/DevExpress-Examples/maui-drawer-view-get-started)
* [Collection View](https://github.com/DevExpress-Examples/maui-collection-view-get-started)
* [Popup](https://github.com/DevExpress-Examples/maui-popup-get-started)
