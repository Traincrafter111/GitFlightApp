/*
 Helpers/ToastHelper.cs

 Propósito:
 - Encapsula la creación y muestra de toasts usando CommunityToolkit.Maui.Alerts.Toast.
 - Centraliza la lógica de cancelación y proporciona overloads de conveniencia.

 Uso (ejemplos):

 // Llamada simple (valores por defecto: Short, fontSize 14)
 await ToastHelper.ShowAsync("Operación completada");

 // Especificando duración y tamaño de fuente
 await ToastHelper.ShowAsync("Guardado", ToastDuration.Long, 16);

 // Con CancellationToken externo (puedes cancelar desde otra rutina)
 using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(2));
 await ToastHelper.ShowAsync("Mensaje temporal", ToastDuration.Short, 14, cts.Token);

 Notas:
 - Requiere CommunityToolkit.Maui (ya está referenciado en el proyecto).
 - El método principal aceptará un CancellationToken opcional; si no se provee, se crea
   internamente un CancellationTokenSource y se usa su token para mostrar el toast.
 - Esta clase está pensada para evitar duplicación de código en ViewModels y Pages.
*/

using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace GitFlightApp.Helpers
{
    /// <summary>
    /// Helper estático para mostrar toasts en la aplicación usando CommunityToolkit.Maui.
    /// Permite configurar el mensaje, la duración, el tamaño de fuente y opcionalmente
    /// pasar un CancellationToken para poder cancelar la visualización desde fuera.
    /// </summary>
    public static class ToastHelper
    {
        /// <summary>
        /// Muestra un toast con el mensaje y opciones especificadas.
        /// </summary>
        /// <param name="message">Texto a mostrar en el toast.</param>
        /// <param name="duration">Duración del toast (Short o Long). Por defecto: Short.</param>
        /// <param name="fontSize">Tamaño de la fuente del mensaje. Por defecto: 14.</param>
        /// <param name="cancellationToken">Token opcional para cancelar la visualización. Si no se provee, se crea uno interno.</param>
        /// <returns>Task que completa cuando el toast ha terminado de mostrarse o es cancelado.</returns>
        public static async Task ShowAsync(string message, ToastDuration duration = ToastDuration.Short, int fontSize = 14, CancellationToken cancellationToken = default)
        {
            var toast = Toast.Make(message, duration, fontSize);

            if (cancellationToken == default)
            {
                using var cts = new CancellationTokenSource();
                await toast.Show(cts.Token);
            }
            else
            {
                await toast.Show(cancellationToken);
            }
        }

        /// <summary>
        /// Sobrecarga de conveniencia que muestra un toast con valores por defecto.
        /// </summary>
        public static Task ShowAsync(string message) => ShowAsync(message, ToastDuration.Short, 14, default);

        /// <summary>
        /// Sobrecarga que permite especificar solo el tamaño de la fuente.
        /// </summary>
        public static Task ShowAsync(string message, int fontSize) => ShowAsync(message, ToastDuration.Short, fontSize, default);

        /// <summary>
        /// Sobrecarga que permite especificar solo la duración.
        /// </summary>
        public static Task ShowAsync(string message, ToastDuration duration) => ShowAsync(message, duration, 14, default);
    }
}
