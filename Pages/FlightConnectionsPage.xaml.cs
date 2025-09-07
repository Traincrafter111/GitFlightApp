using GitFlightApp.Models;

namespace GitFlightApp.Pages;

public partial class FlightConnectionsPage : ContentPage
{
	public FlightConnectionsPage()
	{
		InitializeComponent();
	}

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		if (e.CurrentSelection.FirstOrDefault() is not FlightConnection selectedConnection)
			return;
		

		var navParams = new Dictionary<string, object>()
		{
			{ "SelectedConnection", selectedConnection }  
        };

		await Shell.Current.GoToAsync($"/{nameof(FlightConnectionDetailsPage)}", navParams);

		((CollectionView)sender).SelectedItem = null;
    }

    private async void OnAddNewFlightConnectionClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddNewFlightConnectionPage(this));
    }
}