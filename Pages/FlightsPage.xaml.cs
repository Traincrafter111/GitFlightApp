using GitFlightApp.ViewModels;

namespace GitFlightApp.Pages;

public partial class FlightsPage : ContentPage
{
    private readonly FlightViewModel flightViewModel;

    public FlightsPage(FlightViewModel flightViewModel)
	{
		InitializeComponent();
		BindingContext = flightViewModel;
		this.flightViewModel = flightViewModel;
    }

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		await flightViewModel.LoadFlightsAsync();
	}

    private async void OnAddNewFlightClicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(AddNewFlightPage));
    }

    private async void OnFlightSelected(object sender, SelectionChangedEventArgs e)
    {
		if (flightViewModel.SelectedFlight != null)
		{
			await Shell.Current.GoToAsync($"/{nameof(FlightDetailsPage)}");
        }
    }
}