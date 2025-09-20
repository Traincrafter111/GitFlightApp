using GitFlightApp.Models;

namespace GitFlightApp.Pages;

[QueryProperty("SelectedConnection", "SelectedConnection")]
public partial class FlightConnectionDetailsPage : ContentPage
{
	private FlightConnection _selectedConnection;

	public FlightConnection SelectedConnection
	{
		get => _selectedConnection; set
		{
			_selectedConnection = value;

			if (_selectedConnection != null)
			{
				//connectionsCollectionView.ItemsSource = _selectedConnection.Flights;
			}
		}
	}

	public FlightConnectionDetailsPage()
	{
		InitializeComponent();
	}
}