Imports DevExpress.Maui.Core
Imports DevExpress.Maui.HtmlEditor
Imports Microsoft.Maui.Controls

Namespace HtmlEditToolbarCustomization

    Public Class EmbedImageSettingsViewModel
        Inherits BaseViewModel

        Public Sub New(ByVal owner As HtmlEdit, ByVal closeDelegate As Action)
            MyBase.New(owner)
            Me.CloseDelegate = closeDelegate
        End Sub

        Public ReadOnly Property ShowImagePickerCommand As Command
            Get
                Return New Command(AddressOf ShowImagePicker)
            End Get
        End Property

        Public ReadOnly Property ShowPhotoPickerCommand As Command
            Get
                Return New Command(AddressOf ShowPhotoPicker)
            End Get
        End Property

        Private ReadOnly Property CloseDelegate As Action

        Private Async Sub ShowPhotoPicker(ByVal obj As Object)
            If Owner Is Nothing Then Return
            Dim result As FileResult = Await MediaPicker.CapturePhotoAsync()
            If result Is Nothing Then Return
            Await Owner.InsertImageAsync(ImageSource.FromFile(result.FullPath), New HtmlSize(100, HtmlSizeUnit.Percent), New HtmlSize(100, HtmlSizeUnit.Percent))
            CloseDelegate?.Invoke()
        End Sub

        Private Async Sub ShowImagePicker(ByVal obj As Object)
            If Owner Is Nothing Then Return
            Dim result As FileResult = Await MediaPicker.PickPhotoAsync()
            If result Is Nothing Then Return
            Await Owner.InsertImageAsync(ImageSource.FromFile(result.FullPath), New HtmlSize(100, HtmlSizeUnit.Percent), New HtmlSize(100, HtmlSizeUnit.Percent))
            CloseDelegate?.Invoke()
        End Sub
    End Class
End Namespace
