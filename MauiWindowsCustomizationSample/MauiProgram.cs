using Microsoft.Maui.LifecycleEvents;
using Microsoft.Maui.Platform;
#if WINDOWS
using Microsoft.UI.Windowing;
#endif

namespace MauiWindowsCustomizationSample;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureLifecycleEvents(lifecycle =>
			{
#if WINDOWS
				lifecycle.AddWindows(w =>
				{
					w.OnWindowCreated(a =>
					{
						var appWindow = a.GetAppWindow();

						// Works, but in fullscreen customization is lost. I guess that's expected?
						//appWindow.SetPresenter(AppWindowPresenterKind.FullScreen);

						if (AppWindowTitleBar.IsCustomizationSupported())
						{
							appWindow.Title = "Default titlebar with custom color customization";
							appWindow.TitleBar.ForegroundColor = Colors.White.ToWindowsColor();
							appWindow.TitleBar.BackgroundColor = Colors.DarkOrange.ToWindowsColor();
							appWindow.TitleBar.InactiveBackgroundColor = Colors.Blue.ToWindowsColor();
							appWindow.TitleBar.InactiveForegroundColor = Colors.White.ToWindowsColor();

							appWindow.TitleBar.ButtonBackgroundColor = Colors.DarkOrange.ToWindowsColor();
							appWindow.TitleBar.ButtonForegroundColor = Colors.White.ToWindowsColor();
							appWindow.TitleBar.ButtonInactiveBackgroundColor = Colors.Blue.ToWindowsColor();
							appWindow.TitleBar.ButtonInactiveForegroundColor = Colors.White.ToWindowsColor();
							appWindow.TitleBar.ButtonHoverBackgroundColor = Colors.Green.ToWindowsColor();
							appWindow.TitleBar.ButtonHoverForegroundColor = Colors.White.ToWindowsColor();
							appWindow.TitleBar.ButtonPressedBackgroundColor = Colors.DarkOrange.ToWindowsColor();
							appWindow.TitleBar.ButtonPressedForegroundColor = Colors.White.ToWindowsColor();
						}
						
						// Doesn't work
						a.ExtendsContentIntoTitleBar = true;
					});
				});
#endif
			})
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		return builder.Build();
	}
}
