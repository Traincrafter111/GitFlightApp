using GitFlightApp.Pages;

namespace GitFlightApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(FlightConnectionDetailsPage), typeof(FlightConnectionDetailsPage));
            Routing.RegisterRoute(nameof(AddNewFlightPage), typeof(AddNewFlightPage));
        }
    }
}
