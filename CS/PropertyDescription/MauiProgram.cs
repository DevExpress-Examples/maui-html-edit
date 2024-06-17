using DevExpress.Maui;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace PropertyDescriptionHTMLEdit;

public static class MauiProgram {
    public static MauiApp CreateMauiApp() {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseDevExpressCollectionView()
            .UseDevExpressControls()
            .UseDevExpressHtmlEditor()
            .UseDevExpressEditors()
            .UseDevExpressDataGrid()
            .UseDevExpressCharts()
            .UseDevExpressGauges()
            .UseDevExpressPdf()
            .UseDevExpressScheduler()
            .UseDevExpress(useLocalization: true)            
            .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("roboto-bold.ttf", "Roboto-Bold");
                fonts.AddFont("roboto-regular.ttf", "Roboto");
            });


        return builder.Build();
    }
}
