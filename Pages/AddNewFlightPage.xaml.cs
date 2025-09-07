namespace GitFlightApp.Pages;
using GitFlightApp.Models;
using GitFlightApp.ViewModels;

public partial class AddNewFlightPage : ContentPage
{
	private readonly FlightsPage _flightsPage;
	public AddNewFlightPage(FlightsPage flightsPage)
    {
        InitializeComponent();
        _flightsPage = flightsPage;
        BindingContext = new FlightViewModel();
    }
}