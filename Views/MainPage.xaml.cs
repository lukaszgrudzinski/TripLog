using TripLog.Models;
using TripLog.Services;
using TripLog.ViewModels;

namespace TripLog;

public partial class MainPage : ContentPage
{
	private MainViewModel? ViewModel => BindingContext as MainViewModel;

	public MainPage(MainViewModel vm)
	{
		InitializeComponent();

		//viewModel.Init();

		BindingContext = vm;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

		ViewModel?.Init();
    }
}