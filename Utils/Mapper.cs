using System;
using System.Collections.ObjectModel;

namespace charity_management_system.Utils
{
    public class Mapper
    {
        public static ObservableCollection<V> toViewModel<U, V>(ObservableCollection<U> models, Func<U, V> constructor)
        {
            ObservableCollection<V> viewModels = new ObservableCollection<V>();
            
            foreach(var model in models)
            {
                viewModels.Add(constructor(model));
            }

            return viewModels;
        }
    }
}
