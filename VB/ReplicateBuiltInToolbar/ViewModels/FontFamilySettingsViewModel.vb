Imports System.Collections.Generic
Imports DevExpress.Maui.HtmlEditor
Imports Microsoft.Maui.Controls

Namespace HtmlEditToolbarCustomization

    Public Class FontFamilySettingsViewModel
        Inherits BaseViewModel

        Public Sub New(ByVal owner As HtmlEdit, ByVal closeDelegate As Func(Of Task))
            MyBase.New(owner)
            SelectionRange = owner.SelectionRange
            ApplyCommand = New Command(AddressOf Apply)
            Me.CloseDelegate = closeDelegate
        End Sub

        Public ReadOnly Property FontFamilies As IEnumerable(Of String)
            Get
                Return New String() {"Arial", "Baskerville", "Courier", "Courier New", "Georgia", "Helvetica", "Monaco", "Palatino", "Tahoma", "Times", "Times New Roman", "Verdana", "Comic Sans MS"}
            End Get
        End Property

        Public ReadOnly Property ApplyCommand As Command

        Private ReadOnly Property CloseDelegate As Func(Of Task)

        Public Property FontFamily As String
            Get
                Return GetValue(Of String)()
            End Get

            Set(ByVal value As String)
                SetValue(value, Function(oldValue, newValue)
                    If oldValue IsNot Nothing AndAlso newValue Is Nothing Then
                        FontFamily = oldValue
                        Return
                    End If

                    __ = Owner?.SetFontFamilyAsync(value, SelectionRange)
                End Function)
            End Set
        End Property

        Private Property SelectionRange As HtmlSelectionRange?

        Protected Overrides Sub OnAttachHtmlEdit(ByVal htmlEdit As HtmlEdit)
            FontFamily = htmlEdit.SelectedTextFontFamily
            SelectionRange = htmlEdit.SelectionRange
        End Sub

        Private Async Sub Apply()
            Dim edit As HtmlEdit? = Owner
            Dim range As HtmlSelectionRange? = SelectionRange
            Await CloseDelegate()
            If edit IsNot Nothing Then Await edit.SetFontFamilyAsync(FontFamily, range)
        End Sub
    End Class
End Namespace
