Imports Microsoft.Extensions.Logging
Imports DevExpress.Maui

Namespace HtmlEditLoadDataFromDocx

    Public Module MauiProgram

        Public Function CreateMauiApp() As MauiApp
            Dim builder = MauiApp.CreateBuilder()
            builder.UseMauiApp(Of App)().UseDevExpress().ConfigureFonts(Function(fonts)
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular")
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold")
            End Function)
#If DEBUG
            builder.Logging.AddDebug()
#End If
            Return builder.Build()
        End Function
    End Module
End Namespace
