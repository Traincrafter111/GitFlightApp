namespace GitFlightApp.Pages;
using GitFlightApp.Models;
using GitFlightApp.ViewModels;

public partial class AddNewFlightPage : ContentPage
{
	public AddNewFlightPage(FlightViewModel flightViewModel)
    {
        InitializeComponent();
        BindingContext = flightViewModel;
    }
}