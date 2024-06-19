using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace HTMLtoMD;

public partial class MainPage : ContentPage
{
    private static string DefaultMdText => """
    # Title

    This is a paragraph with **bold text** and *italic text*.

    - First item
    - Second item

    [Link](https://devexpress.com)
    """;
    public MainPage()
    {
        InitializeComponent();
        html.Focus();
        html.HtmlSource = new MarkedNet.Marked().Parse(DefaultMdText);
        mdEditor.Text = DefaultMdText;
    }

    private void SwitchToHtml(object s, EventArgs e)
    {
        var mdText = mdEditor.Text;
        var htmlText = new MarkedNet.Marked().Parse(mdText);
        ShowHtmlEdit(htmlText);
    }
    private async void SwitchToMd(object s, EventArgs e)
    {
        var htmlText = await html.GetHtmlAsync();
        var mdText = new ReverseMarkdown.Converter().Convert(htmlText);
        await ShowMdEditor(mdText);
    }

    private async Task ShowMdEditor(string text)
    {
        toolbar.SelectedPageName = "mdPage";
        mdEditor.IsVisible = true;
        html.IsVisible = false;
        await Task.Delay(100);
        mdEditor.Focus();
        mdEditor.Text = text;
    }
    private void ShowHtmlEdit(string htmlText)
    {
        html.IsVisible = true;
        mdEditor.IsVisible = false;
        toolbar.SelectedPageName = "htmlPage";
        html.Focus();
        html.HtmlSource = htmlText;
    }
}
