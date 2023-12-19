#If ANDROID
using Microsoft.Maui.Platform;
using PView = Android.Views.View;
#End If
Namespace HtmlEditToolbarCustomization

    Public Module InputHelper

        Public Sub HideKeyboardOnAndroid()
#If ANDROID
        Page? element = Application.Current?.MainPage;
        PView? v = (PView?)element?.Handler?.PlatformView;
        v?.Context?.HideKeyboard(v);
#End If
        End Sub
    End Module
End Namespace
