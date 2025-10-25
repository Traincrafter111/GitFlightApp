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
    public partial class PlaneViewModel : ObservableObject
    {
        [ObservableProperty]
        private string model = string.Empty;
        [ObservableProperty]
        private string manufacturer = string.Empty;
        [ObservableProperty]
        private string? imagePath;
        private readonly DataContext dataContext;

        public PlaneViewModel(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [RelayCommand]
        public async Task SelectImageAsync()
        {
            var result = await MediaPicker.PickPhotoAsync();
            if (result == null) return;
            string? localPath = await ImageHelper.SaveImageLocalAsync(result);
            if (localPath == null) return;
            ImagePath = localPath;
        }

        [RelayCommand]
        public async Task SavePlaneAsync()
        {
            if(string.IsNullOrWhiteSpace(Model) || string.IsNullOrWhiteSpace(Manufacturer))
            {
                await Shell.Current.DisplayAlert("Error", "Model and Manufacturer cannot be empty.", "OK");
                return;
            }
            var plane = new Plane
            {
                Model = Model,
                Manufacturer = Manufacturer,
                ImagePath = ImagePath
            };
            await dataContext.Planes.AddAsync(plane);
            await dataContext.SaveChangesAsync();
            CancellationTokenSource cancellationToken = new();
            var toast = Toast.Make("User saved successfully!", ToastDuration.Short, 14);
            await toast.Show(cancellationToken.Token);
        }
    }
}
