/*
 Helpers/ByteArrayToImageSourceHelper.cs

 Propósito:
 - Convertir un array de bytes (byte[]) que contiene los datos de una imagen
   en un ImageSource usable por controles Image en .NET MAUI.
 - Facilita el binding de campos BLOB de la base de datos directamente a la UI.

 Uso (XAML):

 <ContentPage xmlns:helpers="clr-namespace:GitFlightApp.Helpers">
   <ContentPage.Resources>
     <ResourceDictionary>
       <helpers:ByteArrayToImageSourceHelper x:Key="BytesToImage" />
     </ResourceDictionary>
   </ContentPage.Resources>

   <!-- En el DataTemplate -->
   <Image Source="{Binding profileImage, Converter={StaticResource BytesToImage}}" />
 </ContentPage>

 Notas:
 - Si el valor no es byte[] o es null/empty, el convertidor devuelve null (no se muestra imagen).
 - ConvertBack no está implementado ya que la conversión inversa no es necesaria en la mayoría de escenarios de UI.
*/

using System;
using System.Globalization;
using System.IO;
using Microsoft.Maui.Controls;

namespace GitFlightApp.Helpers
{
    /// <summary>
    /// Convierte un array de bytes (<c>byte[]</c>) que representa una imagen
    /// en un <see cref="ImageSource"/> para ser usado directamente en la UI de MAUI.
    /// </summary>
    /// <remarks>
    /// Ideal para enlazar campos BLOB de la base de datos (por ejemplo, columnas que almacenan
    /// imágenes en formato byte[]) a un control <c>Image</c> en XAML.
    ///</remarks>
    public class ByteArrayToImageSourceHelper : IValueConverter
    {
        /// <summary>
        /// Convierte un <c>byte[]</c> en <see cref="ImageSource"/>.
        /// </summary>
        /// <param name="value">El valor entrante esperado: un <see cref="byte[]"/> con los bytes de la imagen.</param>
        /// <param name="targetType">Tipo objetivo (ignoramos, esperado ImageSource).</param>
        /// <param name="parameter">Parámetro opcional (no usado).</param>
        /// <param name="culture">Cultura (no usado).</param>
        /// <returns>
        /// Un <see cref="ImageSource"/> creado desde un <see cref="MemoryStream"/> con los bytes.
        /// Devuelve <c>null</c> si el valor no es un <c>byte[]</c> válido o está vacío.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is byte[] bytes && bytes.Length > 0)
            {
                return ImageSource.FromStream(() => new MemoryStream(bytes));
            }
            return null;
        }

        /// <summary>
        /// Conversión inversa no implementada.
        /// </summary>
        /// <exception cref="NotImplementedException">Siempre lanzada.</exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
