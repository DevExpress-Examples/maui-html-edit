using DevExpress.Maui.HtmlEditor;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;

namespace HtmlEditLoadDataFromDocx;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        StartDocxLoading();
    }
    async void StartDocxLoading()
    {
        using (var wordProcessor = new RichEditDocumentServer())
        {
            wordProcessor.LoadDocument(FileSystem.Current.OpenAppPackageFileAsync("mail.docx").Result);
            await htmlEdit.SetHtmlSourceAsync(wordProcessor.HtmlText);
        }
    }
}