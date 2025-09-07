using GitFlightApp.ViewModels;

namespace GitFlightApp.Pages;

public partial class AddNewFlightConnectionPage : ContentPage
{
	private readonly FlightConnectionsPage _flightConnectionsPage;
    public AddNewFlightConnectionPage(FlightConnectionsPage flightConnectionsPage)
	{
		InitializeComponent();
        _flightConnectionsPage = flightConnectionsPage;
        BindingContext = new FlightConnectionViewModel();
    }

}