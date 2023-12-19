Imports Android.App
Imports Android.Runtime

Namespace HtmlEditLoadDataFromDocx

    <Application>
    Public Class MainApplication
        Inherits MauiApplication

        Public Sub New(ByVal handle As IntPtr, ByVal ownership As JniHandleOwnership)
            MyBase.New(handle, ownership)
        End Sub

        Protected Overrides Function CreateMauiApp() As MauiApp
            Return MauiProgram.CreateMauiApp()
        End Function
    End Class
End Namespace
