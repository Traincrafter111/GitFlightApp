using GitFlightApp.ViewModels;

namespace GitFlightApp.Pages;

public partial class AddNewUserPage : ContentPage
{
	public AddNewUserPage(UserViewModel viewModel)
	{
		InitializeComponent(); 
		BindingContext = viewModel;
    }
}