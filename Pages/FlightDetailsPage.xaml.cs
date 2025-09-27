using GitFlightApp.ViewModels;

namespace GitFlightApp.Pages;

public partial class FlightDetailsPage : ContentPage
{
	public FlightDetailsPage(FlightViewModel flightViewModel)
	{
		InitializeComponent();
		BindingContext = flightViewModel;
    }
}