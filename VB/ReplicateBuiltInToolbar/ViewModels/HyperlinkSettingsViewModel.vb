Imports DevExpress.Maui.Core
Imports DevExpress.Maui.HtmlEditor
Imports Microsoft.Maui.Controls

Namespace HtmlEditToolbarCustomization

    Public Class HyperlinkSettingViewModel
        Inherits BaseViewModel

        Public Sub New(ByVal owner As HtmlEdit, ByVal closeDelegate As Action)
            MyBase.New(owner)
            ApplyCommand = New Command(AddressOf Apply)
            Me.CloseDelegate = closeDelegate
        End Sub

        Public Property Text As String
            Get
                Return GetValue(Of String)()
            End Get

            Set(ByVal value As String)
                SetValue(value)
            End Set
        End Property

        Public Property Url As String
            Get
                Return GetValue(Of String)()
            End Get

            Set(ByVal value As String)
                SetValue(value)
            End Set
        End Property

        Public ReadOnly Property ApplyCommand As Command

        Private ReadOnly Property CloseDelegate As Action

        Private Property SelectionStart As Integer

        Private Property SelectionLength As Integer

        Private Sub Apply()
            If Owner Is Nothing Then Return
            Dim range As HtmlSelectionRange = New(SelectionStart, SelectionLength)()
            Owner.SelectedTextHyperlink = New HtmlHyperlink(Text, Url, range)
            CloseDelegate?.Invoke()
        End Sub

        Protected Overrides Sub OnAttachHtmlEdit(ByVal htmlEdit As HtmlEdit)
            MyBase.OnAttachHtmlEdit(htmlEdit)
            If htmlEdit.SelectedTextHyperlink IsNot Nothing Then
                Text = htmlEdit.SelectedTextHyperlink.Text
                Url = htmlEdit.SelectedTextHyperlink.Url
                SelectionStart = If(htmlEdit.SelectedTextHyperlink?.Range?.Start, 0)
                SelectionLength = If(htmlEdit.SelectedTextHyperlink?.Range?.Length, 0)
            Else
                Text = htmlEdit.SelectedText
                SelectionStart = htmlEdit.SelectionRange.Start
                SelectionLength = htmlEdit.SelectionRange.Length
            End If
        End Sub
    End Class
End Namespace
