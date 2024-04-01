using DevExpress.Maui.Core;
using PropertyDescriptionHTMLEdit.ViewModels;
using PropertyDescriptionHTMLEdit.Models;

namespace PropertyDescriptionHTMLEdit.Views;

public partial class PropertyDescriptionEditView : ContentPage
{
    private DetailEditFormViewModel viewModel => (DetailEditFormViewModel)BindingContext;
    private Property PropertyItem => viewModel.Item as Property;

    public PropertyDescriptionEditView()
    {
        InitializeComponent();
    }
    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
		
        _ = SaveData();
        base.OnNavigatedFrom(args);
    }

    async public Task SaveData()
    {
        string text = await htmledit.GetHtmlAsync();
        PropertyItem.Features = text;
		await Navigation.PopAsync();
    }

}