Imports DevExpress.Maui.Core
Imports DevExpress.Maui.HtmlEditor
Imports Microsoft.Maui.Controls

Namespace HtmlEditToolbarCustomization

    Public MustInherit Class BaseViewModel
        Inherits BindableBase
        Implements IHtmlOwner

        Protected Sub New(ByVal owner As HtmlEdit)
            Me.Owner = owner
        End Sub

        Public Property Owner As HtmlEdit? Implements IHtmlOwner.Owner
            Get
                Return GetValue(Of HtmlEdit)()
            End Get

            Set(ByVal value As HtmlEdit?)
                SetValue(value, Function(ov, nv)
                    If ov IsNot Nothing Then OnDetachHtmlEdit(ov)
                    If nv IsNot Nothing Then OnAttachHtmlEdit(nv)
                End Function)
            End Set
        End Property

        Protected Overridable Sub OnAttachHtmlEdit(ByVal htmlEdit As HtmlEdit)
        End Sub

        Protected Overridable Sub OnDetachHtmlEdit(ByVal htmlEdit As HtmlEdit)
        End Sub
    End Class
End Namespace
