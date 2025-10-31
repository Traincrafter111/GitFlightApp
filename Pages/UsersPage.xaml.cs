using GitFlightApp.ViewModels;

namespace GitFlightApp.Pages;

public partial class UsersPage : ContentPage
{
    private readonly UserViewModel userViewModel;

    public UsersPage(UserViewModel userViewModel)
    {
        InitializeComponent();
        BindingContext = userViewModel;
        this.userViewModel = userViewModel;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await userViewModel.LoadUserAsync();
    }

    private async void OnAddNewUserClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddNewUserPage));
    }
}