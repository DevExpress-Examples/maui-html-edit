using System.Collections.ObjectModel;
using DevExpress.Maui.Core;
// using PropertyDescriptionHTMLEdit.DataLayer;
using PropertyDescriptionHTMLEdit.Models;

namespace PropertyDescriptionHTMLEdit.ViewModels;

public class PropertyDetailFormViewModel : DetailFormViewModel
{
    // private PropertyViewModel customersViewModel => (PropertyViewModel)DataControlContext;
    // private CrmContext crmContext => customersViewModel.CrmContext;

    // public Command<bool?> EditCommand { get; }
    public Property Property
    {
        get => ((Property)Item);
        set
        {
            // ((Property)Item).Employee = value;
            // crmContext.SaveChanges();
            OnPropertyChanged(nameof(Property));
        }
    }
    public PropertyDetailFormViewModel(object item, object context = null) : base(item, context)

    {
    }

    public ImageSource Image
    {
        get => ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(Property.Photo)));
    }


}
