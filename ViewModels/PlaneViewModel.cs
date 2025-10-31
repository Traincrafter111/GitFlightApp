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
    public partial class PlaneViewModel : ObservableObject
    {
        [ObservableProperty]
        private string model = string.Empty;
        [ObservableProperty]
        private string manufacturer = string.Empty;
        [ObservableProperty]
        private string? imagePath;
        private readonly PlaneRepository planeRepository;

        public ObservableCollection<Plane> Planes { get; } = new();

        public PlaneViewModel(PlaneRepository planeRepository)
        {
            this.planeRepository = planeRepository;
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
            if (string.IsNullOrWhiteSpace(Model) || string.IsNullOrWhiteSpace(Manufacturer))
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
            await planeRepository.AddPlaneAsync(plane);
            await ToastHelper.ShowAsync("Plane saved successfully!");
            await Shell.Current.GoToAsync("..");
        }

        public async Task LoadPlaneAsync()
        {
            Planes.Clear();
            var planesFromDB = await planeRepository.GetAllPlanesAsync();
            foreach (var plane in planesFromDB)
            {
                Planes.Add(plane);
            }
        }
    }
}
