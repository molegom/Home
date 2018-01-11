using HomeLibrary.Interfaces;
using HomeWeb.Models;

namespace HomeWeb.Interfaces
{
    class FlatModelFactory: IFlatModelFactory
    {
        private IFlatUi flatUi { get; set; }
        public FlatModelFactory()
        {
            flatUi = new FlatUi();
        }
        public FlatListViewModel CreateFlatsViewModel()
        {
            return new FlatListViewModel
            {
                Flats = flatUi.GetAllFlats(),
                Images =  flatUi.GetAllImages()
            };
        }
    }
}
