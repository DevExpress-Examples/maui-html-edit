using DevExpress.Maui.Core;
using PropertyDescriptionHTMLEdit.ViewModels;

namespace PropertyDescriptionHTMLEdit.Views;

public partial class PropertiesPage : ContentPage
{
    private PropertyViewModel viewModel;

    public PropertiesPage()
    {
        InitializeComponent();
        viewModel = new PropertyViewModel();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.LoadDataAsync();
    }
    private void OnCreateDetailFormViewModel(object sender, CreateDetailFormViewModelEventArgs e)
    {
        if (e.DetailFormType == DetailFormType.View)
        {
            e.Result = new PropertyDetailFormViewModel(e.Item);
        }
    }
}