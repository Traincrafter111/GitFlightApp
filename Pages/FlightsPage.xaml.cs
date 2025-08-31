namespace GitFlightApp.Pages;

public partial class FlightsPage : ContentPage
{
	public FlightsPage()
	{
		InitializeComponent();
	}

    private async void OnAddNewFlightClicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new AddNewFlightPage(this));
    }
}