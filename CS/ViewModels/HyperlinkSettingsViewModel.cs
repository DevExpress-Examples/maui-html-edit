using DevExpress.Maui.Core;
using DevExpress.Maui.HtmlEditor;
using Microsoft.Maui.Controls;

namespace HtmlEditToolbarCustomization;

public class HyperlinkSettingViewModel : BaseViewModel {
    public HyperlinkSettingViewModel(HtmlEdit owner, Action closeDelegate) : base(owner) {
        ApplyCommand = new Command(Apply);
        CloseDelegate = closeDelegate;
    }

    public string Text {
        get => GetValue<string>();
        set => SetValue(value);
    }
    public string Url {
        get => GetValue<string>();
        set => SetValue(value);
    }
    public Command ApplyCommand { get; }
    Action CloseDelegate { get; }
    int SelectionStart { get; set; }
    int SelectionLength { get; set; }

    void Apply() {
        if (Owner == null)
            return;
        HtmlSelectionRange range = new(SelectionStart, SelectionLength);
        Owner.SelectedTextHyperlink = new HtmlHyperlink(Text, Url, range);
        CloseDelegate?.Invoke();
    }

    protected override void OnAttachHtmlEdit(HtmlEdit htmlEdit) {
        base.OnAttachHtmlEdit(htmlEdit);
        if (htmlEdit.SelectedTextHyperlink != null) {
            Text = htmlEdit.SelectedTextHyperlink.Text;
            Url = htmlEdit.SelectedTextHyperlink.Url;
            SelectionStart = htmlEdit.SelectedTextHyperlink?.Range?.Start ?? 0;
            SelectionLength = htmlEdit.SelectedTextHyperlink?.Range?.Length ?? 0;
        } else {
            Text = htmlEdit.SelectedText;
            SelectionStart = htmlEdit.SelectionRange.Start;
            SelectionLength = htmlEdit.SelectionRange.Length;
        }
    }
}