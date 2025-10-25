using GitFlightApp.ViewModels;

namespace GitFlightApp.Pages;

public partial class AddNewPlanePage : ContentPage
{
	public AddNewPlanePage(PlaneViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

    }
}