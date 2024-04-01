# DevExpress .NET MAUI HTML Edit - Edit HTML in DataGridView CRUD Views

This scenario uses the [HTML Edit Control](https://docs.devexpress.com/MAUI/404635) to show and edit HTML markup of the selected DataGridView item.

<img src="images/property-description-overview@2x.png?v=23.2" width="50%"/>

## Implementation Details

* In this scenario, the HTML Edit control is displayed in the [DataGridView](https://docs.devexpress.com/MAUI/403255/data-grid/data-grid)'s Detail and Edit [CRUD forms](https://docs.devexpress.com/MAUI/404456/data-grid/crud/customize-detail-forms). You can use the [DetailFormTemplate](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataGrid.DataGridView.DetailFormTemplate) and [DetailEditFormTemplate](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataGrid.DataGridView.DetailEditFormTemplate) properties to define the page that is used to view and edit the selected DataGridView's item.
* Set the [HtmlEdit.IsReadOnly](https://docs.devexpress.com/MAUI/404635/html-edit/html-edit#html-edit-availability) to true to disable editing.
* Use the [HtmlEdit.GetHtmlAsync](https://docs.devexpress.com/MAUI/404637/html-edit/load-and-obtain-markup#retrieve-the-displayed-content) method to obtain the HTML Edit content. After that, you can save it to a property on the [OnNavigatingFrom](https://learn.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.page.onnavigatingfrom?view=winrt-22621) event.

## Files to Review

- [PropertiesDetailPage.xaml](Views/PropertiesDetailPage.xaml)
- [PropertyDescriptionEditView.xaml](Views/PropertyDescriptionEditView.xaml.xaml)
- [PropertyDescriptionEditView.xaml.cs](Views/PropertyDescriptionEditView.xaml.cs)

## Documentation

- [HTML Edit Overview](https://docs.devexpress.com/MAUI/404635?v=23.2)
- [HTML Edit - Load and Retrieve Content](https://docs.devexpress.com/MAUI/404637/html-edit/load-and-obtain-markup?v=23.2)
- [Featured Scenarios](https://docs.devexpress.com/MAUI/404291/scenarios)

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
