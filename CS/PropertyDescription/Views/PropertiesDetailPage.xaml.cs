using DevExpress.Maui.Core;

namespace PropertyDescriptionHTMLEdit.Views;

public partial class PropertiesDetailPage : ContentPage
{
    DetailEditFormViewModel ViewModel => (DetailEditFormViewModel)BindingContext;
	public PropertiesDetailPage()
	{
		InitializeComponent();
	}
}