using System.Collections.ObjectModel;

namespace YAFIT.Common.Extensions
{
    public static class ListExtension
    {

        public static ObservableCollection<T> ToObservableCollection<T>(this IList<T> list)
        {
            ObservableCollection<T> observable = new (list);
            return observable;
        }
    }
}
