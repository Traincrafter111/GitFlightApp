using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GitFlightApp.Helpers;
using GitFlightApp.Models;
using GitFlightApp.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitFlightApp.ViewModels
{
    public partial class UserViewModel : ObservableObject
    {
        private readonly UserRepository userRepository;
        [ObservableProperty]
        private string userName;
        [ObservableProperty]
        private byte[]? profileImage;
        [ObservableProperty]
        private ImageSource? profileImageSource;

        

        public ObservableCollection<User> Users { get; } = new();
        public UserViewModel(UserRepository userRepository)
        {
            this.userRepository = userRepository;
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
                    await ToastHelper.ShowAsync("Photo uploaded successfully!");
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

            await userRepository.AddUserAsync(user);

            await ToastHelper.ShowAsync("User saved successfully!");
            await Shell.Current.GoToAsync("..");
        }

        public async Task LoadUserAsync()
        {
            Users.Clear();
            var usersFromDB = await userRepository.GetAllUsersAsync();
            foreach (var user in usersFromDB)
            {
                Users.Add(user);
            }
        }


    }
}
