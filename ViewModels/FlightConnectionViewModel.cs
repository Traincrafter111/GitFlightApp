using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GitFlightApp.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GitFlightApp.ViewModels
{
    public partial class FlightConnectionViewModel : ObservableObject
    {
        public ObservableCollection<string> Cities { get; } = new ObservableCollection<string>
        {
            "Mexico",
            "France",
            "Germany",
            "United States"
        };
        public ObservableCollection<string> Airlines { get; } = new ObservableCollection<string>
        {
            "Aeromexico",
            "Air France",
            "Lufthansa",
            "American Airlines"
        };

        [ObservableProperty]
        private string _selectedOrigin = string.Empty;

        [ObservableProperty]
        private string _selectedDestination = string.Empty;

        [ObservableProperty]
        private string _connectionID = string.Empty;

        [ObservableProperty]
        private string _airline = string.Empty;

        [ObservableProperty]
        private string _departureCity = string.Empty;

        [ObservableProperty]
        private string _arrivalCity = string.Empty;

        public ICommand CheckCitiesCommand { get; }

        [RelayCommand]
        public async Task AddNewFlightConnection()
        {

            if (string.IsNullOrEmpty(ConnectionID) || string.IsNullOrEmpty(Airline) ||
    string.IsNullOrEmpty(SelectedOrigin) || string.IsNullOrEmpty(SelectedDestination))
            {
                await Shell.Current.DisplayAlert("Error", "Please fill in all fields.", "OK");
                return;
            }


            if (GlobalData.FlightConnections.FirstOrDefault(fc => fc.ConnectionID.Equals(ConnectionID)) != null)
            {
                await Shell.Current.DisplayAlert("Error", "Flight connection with this ID already exists.", "OK");
                return;
            }

       
            if (string.IsNullOrEmpty(SelectedOrigin) || string.IsNullOrEmpty(SelectedDestination))
            {
                await Shell.Current.DisplayAlert("Error", "Please select both cities", "OK");
                return;
            }

   
            if (SelectedOrigin == SelectedDestination)
            {
                await Shell.Current.DisplayAlert("Notice", "Departure City and Destination City cannot be the same.", "OK");
                return; 
            }


            var newFlightConnection = new FlightConnection
            {
                ConnectionID = ConnectionID.Trim(),
                //Airline = Airline.Trim(),
                //DepartureCity = SelectedOrigin.Trim(),
                //ArrivalCity = SelectedDestination.Trim()
            };

            GlobalData.FlightConnections.Add(newFlightConnection);

            await Shell.Current.DisplayAlert("Success", "Flight connection added successfully.", "OK");
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public async Task CancelNewFlightConnection()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}