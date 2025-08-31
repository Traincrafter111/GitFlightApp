namespace GitFlightApp.Pages;
using GitFlightApp.Models;

public partial class AddNewFlightPage : ContentPage
{
	private readonly FlightsPage _flightsPage;
	public AddNewFlightPage(FlightsPage flightsPage)
    {
        InitializeComponent();
        _flightsPage = flightsPage;
    }

    private async void OnSave(object sender, EventArgs e)
    {
        string flightNumber = flightNumberEntry.Text.Trim();
        string departureDate = departureDateEntry.Text.Trim();
        string priceText = priceEntry.Text.Trim();

        if (string.IsNullOrEmpty(flightNumber) || string.IsNullOrEmpty(departureDate) || string.IsNullOrEmpty(priceText))
        {
            await DisplayAlert("Error", "Please fill in all fields.", "OK");
            return;
        }

        if (!DateTime.TryParse(departureDate, out DateTime parsedDate))
        {
            await DisplayAlert("Error", "Invalid date format.", "OK");
            return;
        }

        if (!decimal.TryParse(priceText, out decimal parsedPrice))
        {
            await DisplayAlert("Error", "Invalid price format.", "OK");
            return;
        }


        var newFlight = new Flight
        {
            FlightNumber = flightNumber,
            DepartureDate = parsedDate,
            Price = parsedPrice
        };

        GlobalData.Flights.Add(newFlight);

        await Navigation.PopAsync();

    }

    private async void OnCancel(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}