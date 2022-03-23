using Microsoft.Maui.Platform;
#if WINDOWS
using Microsoft.UI.Windowing;
#endif

namespace MauiWindowsCustomizationSample;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();

#if WINDOWS
		CounterLabel.Text = $"Current ExtendsContentIntoTitleBar value: {((MauiWinUIWindow)App.Current.Windows[0].Handler.PlatformView).ExtendsContentIntoTitleBar}";
#endif
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
#if WINDOWS
		var extends = ((MauiWinUIWindow)App.Current.Windows[0].Handler.PlatformView).ExtendsContentIntoTitleBar;
		((MauiWinUIWindow)App.Current.Windows[0].Handler.PlatformView).ExtendsContentIntoTitleBar = !extends;

		CounterLabel.Text = $"Current ExtendsContentIntoTitleBar value: {((MauiWinUIWindow)App.Current.Windows[0].Handler.PlatformView).ExtendsContentIntoTitleBar}";
#endif
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
#if WINDOWS
		var isFullscreen = ((MauiWinUIWindow)App.Current.Windows[0].Handler.PlatformView).GetAppWindow().Presenter.Kind == AppWindowPresenterKind.FullScreen;
		((MauiWinUIWindow)App.Current.Windows[0].Handler.PlatformView).GetAppWindow().SetPresenter(isFullscreen ? AppWindowPresenterKind.Default : AppWindowPresenterKind.FullScreen);
#endif
	}
}

