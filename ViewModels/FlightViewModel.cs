using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GitFlightApp.Models;
using GitFlightApp.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GitFlightApp.ViewModels
{
    //public class FlightViewModel : INotifyPropertyChanged
    //{
    //    public event PropertyChangedEventHandler? PropertyChanged;

    //    private string _flightNumber = string.Empty;
    //    private string _price = string.Empty;
    //    private DateTime _departureDate = DateTime.Now;

    //    public string FlightNumber
    //    {
    //        get => _flightNumber;
    //        set
    //        {
    //            if (_flightNumber != value)
    //            {
    //                _flightNumber = value;
    //                OnPropertyChanged(nameof(FlightNumber));
    //            }
    //        }
    //    }

    //    public string Price
    //    {
    //        get => _price;
    //        set
    //        {
    //            if (_price != value)
    //            {
    //                _price = value;
    //                OnPropertyChanged(nameof(Price));
    //            }
    //        }
    //    }

    //    public DateTime DepartureDate
    //    {
    //        get => _departureDate;
    //        set
    //        {
    //            if (_departureDate != value)
    //            {
    //                _departureDate = value;
    //                OnPropertyChanged(nameof(DepartureDate));
    //            }
    //        }
    //    }

    //    public ICommand AddNewFlightCommand { get; }
    //    public FlightViewModel()
    //    {
    //        AddNewFlightCommand = new Command(OnAddNewFlight);
    //    }

    //    private async void OnAddNewFlight()
    //    {

    //        if (string.IsNullOrEmpty(FlightNumber) || Price == null)
    //        {
    //            await Shell.Current.DisplayAlert("Error", "Please fill in all fields.", "OK");
    //            return;
    //        }

    //        if (GlobalData.Flights.FirstOrDefault(f => f.FlightNumber.Equals(FlightNumber)) != null)
    //        {
    //            await Shell.Current.DisplayAlert("Error", "Flight with this number already exists.", "OK");
    //            return;
    //        }

    //        var newFlight = new Flight
    //        {
    //            FlightNumber = FlightNumber.Trim(),
    //            DepartureDate = DepartureDate,
    //            Price = decimal.Parse(Price)
    //        };

    //        GlobalData.Flights.Add(newFlight);

    //        await Shell.Current.DisplayAlert("Success", "Flight added successfully.", "OK");
    //        await Shell.Current.GoToAsync("..");
    //    }

    //    protected void OnPropertyChanged(string propertyName) =>
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //}

    public partial class FlightViewModel : ObservableObject
    {
        public FlightViewModel(FlightRepository flightRepository)
        {
            this.flightRepository = flightRepository;
        }
        public ObservableCollection<Flight> Flights { get; set; } = [];
        [ObservableProperty]
        private string _flightNumber = string.Empty;

        [ObservableProperty]
        private string _price = string.Empty;

        [ObservableProperty]
        private Flight? _selectedFlight;

        [ObservableProperty]
        private bool _isEnabled = false;

        public async Task LoadFlightsAsync()
        {
            Flights.Clear();
            var flightsFromDB = await flightRepository.GetAllFlightsAsync();
            foreach (var flight in flightsFromDB)
            {
                Flights.Add(flight);
            }
        }

        [ObservableProperty]
        private DateTime _departureDate = DateTime.Now;
        private readonly FlightRepository flightRepository;

        [RelayCommand]
        public async Task AddNewFlight()
        {
            if (string.IsNullOrEmpty(FlightNumber) || Price == null)
            {
                await Shell.Current.DisplayAlert("Error", "Please fill in all fields.", "OK");
                return;
            }

            if (await flightRepository.GetFlightByIdAsync(FlightNumber) != null)
            {
                await Shell.Current.DisplayAlert("Error", "Flight with this number already exists.", "OK");
                return;
            }

            var newFlight = new Flight
            {
                FlightNumber = FlightNumber.Trim(),
                DepartureDate = DepartureDate,
                Price = decimal.Parse(Price)
            };

            await flightRepository.AddFlightAsync(newFlight);

            await Shell.Current.DisplayAlert("Success", "Flight added successfully.", "OK");
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public async Task CancelNewFlight()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public async Task DeleteFlight()
        {
           await flightRepository.DeleteFlightAsync(SelectedFlight.FlightNumber);
        }

        [RelayCommand]
        public async Task UpdateFlight()
        {
            if (SelectedFlight == null)
            {
                await Shell.Current.DisplayAlert("Error", "No flight selected.", "OK");
                return;
            }
            if (SelectedFlight.Price <= 0)
            {
                await Shell.Current.DisplayAlert("Error", "Please fill in all fields.", "OK");
                return;
            }
            await flightRepository.UpdateFlightAsync(SelectedFlight);
            await Shell.Current.DisplayAlert("Success", "Flight updated successfully.", "OK");
            IsEnabled = false;
        }
    }
}
