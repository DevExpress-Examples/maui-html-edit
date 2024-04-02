using System.Collections.ObjectModel;
using DevExpress.Maui.Core;
using PropertyDescriptionHTMLEdit.Models;

namespace PropertyDescriptionHTMLEdit.ViewModels;

public class PropertyDetailFormViewModel : DetailFormViewModel
{

    public Property Property
    {
        get => ((Property)Item);
        set
        {
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
