using TripLog.Models;
using TripLog.Services;
using TripLog.ViewModels;

namespace TripLog;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		MainViewModel viewModel = new(DependencyService.Get<INavigationService>());

		viewModel.Init();

		BindingContext = viewModel;
	}
}