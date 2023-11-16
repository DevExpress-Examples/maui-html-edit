#if ANDROID
using Microsoft.Maui.Platform;
using PView = Android.Views.View;
#endif

namespace HtmlEditToolbarCustomization;

public static class InputHelper {
    public static void HideKeyboardOnAndroid() {
#if ANDROID
        Page? element = Application.Current?.MainPage;
        PView? v = (PView?)element?.Handler?.PlatformView;
        v?.Context?.HideKeyboard(v);
#endif
    }

}