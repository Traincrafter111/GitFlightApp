using GitFlightApp.ViewModels;

namespace GitFlightApp.Pages;

public partial class FlightDetailsPage : ContentPage
{
    private readonly FlightViewModel flightViewModel;

    public FlightDetailsPage(FlightViewModel flightViewModel)
	{
		InitializeComponent();
		BindingContext = flightViewModel;
		this.flightViewModel = flightViewModel;
    }

    protected override bool OnBackButtonPressed()
    {

        flightViewModel.IsEnabled = false;
        MainOptions.IsVisible = true;
        EditOptions.IsVisible = false;
        flightViewModel.SelectedFlight = null;

        return base.OnBackButtonPressed();
    }

    private void onClickedEdit(object sender, EventArgs e)
    {
        flightViewModel.IsEnabled = true;

        MainOptions.IsVisible = false;
        EditOptions.IsVisible = true;


    }

    private void onClickedCancel(object sender, EventArgs e)
    {
        flightViewModel.IsEnabled = false;

        MainOptions.IsVisible = true;
        EditOptions.IsVisible = false;
    }
}