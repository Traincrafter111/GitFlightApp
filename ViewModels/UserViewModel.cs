using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GitFlightApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitFlightApp.ViewModels
{
    public partial class UserViewModel : ObservableObject
    {
        private readonly DataContext dataContext;
        [ObservableProperty]
        private string userName;
        [ObservableProperty]
        private byte[]? profileImage;
        [ObservableProperty]
        private ImageSource? profileImageSource;

        public UserViewModel(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [RelayCommand]
        public async Task TakePhoto()
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Error capturing photo: {ex.Message}", "ok");
            }
        }
    }
}
