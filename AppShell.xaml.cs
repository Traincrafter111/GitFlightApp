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
            Routing.RegisterRoute(nameof(AddNewFlightConnectionPage), typeof(AddNewFlightConnectionPage));
            Routing.RegisterRoute(nameof(FlightDetailsPage), typeof(FlightDetailsPage));
            Routing.RegisterRoute(nameof(AddNewUserPage), typeof(AddNewUserPage));
            Routing.RegisterRoute(nameof(AddNewPlanePage), typeof(AddNewPlanePage));
        }
    }
}
