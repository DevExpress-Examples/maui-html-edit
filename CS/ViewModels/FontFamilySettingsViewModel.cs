using System.Collections.Generic;
using DevExpress.Maui.HtmlEditor;
using Microsoft.Maui.Controls;

namespace HtmlEditToolbarCustomization;

public class FontFamilySettingsViewModel : BaseViewModel {
    public FontFamilySettingsViewModel(HtmlEdit owner, Func<Task> closeDelegate) : base(owner) {
        SelectionRange = owner.SelectionRange;
        ApplyCommand = new Command(Apply);
        CloseDelegate = closeDelegate;
    }

    public IEnumerable<string> FontFamilies => new string[] {
        "Arial",
        "Baskerville",
        "Courier",
        "Courier New",
        "Georgia",
        "Helvetica",
        "Monaco",
        "Palatino",
        "Tahoma",
        "Times",
        "Times New Roman",
        "Verdana",
        "Comic Sans MS",
    };

    public Command ApplyCommand { get; }
    Func<Task> CloseDelegate { get; }

    public string FontFamily {
        get => GetValue<string>();
        set => SetValue(value, (oldValue, newValue) => {
            if (oldValue != null && newValue == null) {
#pragma warning disable CA2011 // Avoid infinite recursion
                FontFamily = oldValue;
#pragma warning restore CA2011 // Avoid infinite recursion
                return;
            }
            _ = Owner?.SetFontFamilyAsync(value, SelectionRange);
        });
    }

    HtmlSelectionRange? SelectionRange { get; set; }


    protected override void OnAttachHtmlEdit(HtmlEdit htmlEdit) {
        FontFamily = htmlEdit.SelectedTextFontFamily;
        SelectionRange = htmlEdit.SelectionRange;
    }

    async void Apply() {
        HtmlEdit? edit = Owner;
        HtmlSelectionRange? range = SelectionRange;
        await CloseDelegate();
        if (edit != null)
            await edit.SetFontFamilyAsync(FontFamily, range);
    }
}