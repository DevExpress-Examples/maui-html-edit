Imports DevExpress.Maui.HtmlEditor
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native

Namespace HtmlEditLoadDataFromDocx

    Public Partial Class MainPage
        Inherits ContentPage

        Public Sub New()
            InitializeComponent()
            StartDocxLoading()
        End Sub

        Private Async Sub StartDocxLoading()
            Using wordProcessor = New RichEditDocumentServer()
                wordProcessor.LoadDocument(FileSystem.Current.OpenAppPackageFileAsync("mail.docx").Result)
                Await htmlEdit.SetHtmlSourceAsync(wordProcessor.HtmlText)
            End Using
        End Sub
    End Class
End Namespace
