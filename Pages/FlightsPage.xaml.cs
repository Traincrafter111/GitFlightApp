using GitFlightApp.ViewModels;

namespace GitFlightApp.Pages;

public partial class FlightsPage : ContentPage
{
	public FlightsPage(FlightViewModel flightViewModel)
	{
		InitializeComponent();
		BindingContext = flightViewModel;
    }

    private async void OnAddNewFlightClicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new AddNewFlightPage(this));
    }
}