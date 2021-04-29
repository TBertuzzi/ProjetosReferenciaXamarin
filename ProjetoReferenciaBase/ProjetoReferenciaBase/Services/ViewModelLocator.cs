using System;
using System.Collections.Generic;

namespace ProjetoReferenciaBase.Services
{
    public class ViewModelLocator
    {
        public Dictionary<Type, Type> Mappings;

        static Lazy<ViewModelLocator> LazyViewModel = new Lazy<ViewModelLocator>(() => new ViewModelLocator());
        public static ViewModelLocator Current => LazyViewModel.Value;

        public ViewModelLocator()
        {

            Mappings = new Dictionary<Type, Type>();
        }

    }
}
