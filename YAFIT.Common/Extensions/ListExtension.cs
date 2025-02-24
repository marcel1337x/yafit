using System.Collections.ObjectModel;

namespace YAFIT.Common.Extensions
{
    /// <summary>
    /// Eine Klasse mit Erweiterungsmethoden für List<?>
    /// </summary>
    public static class ListExtension
    {

        /// <summary>
        /// Eine Methode, die eine Liste in eine ObservableCollection konvertiert
        /// </summary>
        /// <typeparam name="T">Generischer Datentyp</typeparam>
        /// <param name="list">Liste</param>
        /// <returns>Gibt eine ObservableCollection zurück</returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this IList<T> list)
        {
            ObservableCollection<T> observable = new (list);
            return observable;
        }
    }
}
