using Microsoft.Maui.Controls;

namespace HTMLtoMD;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
