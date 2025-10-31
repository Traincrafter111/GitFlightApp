using GitFlightApp.ViewModels;

namespace GitFlightApp.Pages;

public partial class PlanesPage : ContentPage
{
    private readonly PlaneViewModel planeViewModel;

    public PlanesPage(PlaneViewModel planeViewModel)
    {
         InitializeComponent();
         BindingContext = planeViewModel;
         this.planeViewModel = planeViewModel;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await planeViewModel.LoadPlaneAsync();
    }

    private async void OnAddNewPlaneClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddNewPlanePage));
    }
}