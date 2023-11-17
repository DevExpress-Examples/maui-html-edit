using DevExpress.Maui.Core;
using DevExpress.Maui.HtmlEditor;
using Microsoft.Maui.Controls;

namespace HtmlEditToolbarCustomization;

public class EmbedImageSettingsViewModel : BaseViewModel {
    public EmbedImageSettingsViewModel(HtmlEdit owner, Action closeDelegate) : base(owner) {
        CloseDelegate = closeDelegate;
    }

    public Command ShowImagePickerCommand => new Command(ShowImagePicker);
    public Command ShowPhotoPickerCommand => new Command(ShowPhotoPicker);
    Action CloseDelegate { get; }

    async void ShowPhotoPicker(object obj) {
        if (Owner == null)
            return;
        FileResult result = await MediaPicker.CapturePhotoAsync();
        if (result == null)
            return;
        await Owner.InsertImageAsync(ImageSource.FromFile(result.FullPath), new HtmlSize(100, HtmlSizeUnit.Percent), new HtmlSize(100, HtmlSizeUnit.Percent));
        CloseDelegate?.Invoke();
    }
    async void ShowImagePicker(object obj) {
        if (Owner == null)
            return;
        FileResult result = await MediaPicker.PickPhotoAsync();
        if (result == null)
            return;
        await Owner.InsertImageAsync(ImageSource.FromFile(result.FullPath), new HtmlSize(100, HtmlSizeUnit.Percent), new HtmlSize(100, HtmlSizeUnit.Percent));
        CloseDelegate?.Invoke();
    }
}