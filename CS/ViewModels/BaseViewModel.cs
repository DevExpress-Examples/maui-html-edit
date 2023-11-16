using DevExpress.Maui.Core;
using DevExpress.Maui.HtmlEditor;
using Microsoft.Maui.Controls;

namespace HtmlEditToolbarCustomization;

public abstract class BaseViewModel : BindableBase, IHtmlOwner {
    protected BaseViewModel(HtmlEdit owner) {
        Owner = owner;
    }

    public HtmlEdit? Owner {
        get => GetValue<HtmlEdit>();
        set => SetValue(value, (ov, nv) => {
            if (ov != null)
                OnDetachHtmlEdit(ov);
            if (nv != null)
                OnAttachHtmlEdit(nv);
        });
    }

    protected virtual void OnAttachHtmlEdit(HtmlEdit htmlEdit) {
    }

    protected virtual void OnDetachHtmlEdit(HtmlEdit htmlEdit) {
    }
}