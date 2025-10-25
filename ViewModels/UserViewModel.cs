using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GitFlightApp.Helpers;
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
               var profileImage = await ImageHelper.CapturePhotoAsync();
               if (profileImage != null)
               {
                    ProfileImage = profileImage;
                    ProfileImageSource = ImageHelper.ToImageSource(ProfileImage);
                    CancellationTokenSource cancellationToken = new();
                    var toast = Toast.Make("Photo uploaded successfully!", ToastDuration.Short, 14);
                    await toast.Show(cancellationToken.Token);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Error capturing photo: {ex.Message}", "ok");
            }
        }

        [RelayCommand]
        public async Task SaveUserAsync()
        {
            if (string.IsNullOrWhiteSpace(UserName))
            {
                await Shell.Current.DisplayAlert("Error", "Username cannot be empty.", "OK");
                return;
            }
            var user = new User
            {
                Username = UserName,
                profileImage = ProfileImage
            };
            await dataContext.Users.AddAsync(user);
            await dataContext.SaveChangesAsync();
            CancellationTokenSource cancellationToken = new();
            var toast = Toast.Make("User saved successfully!", ToastDuration.Short, 14);
            await toast.Show(cancellationToken.Token);
        }
    }
}
