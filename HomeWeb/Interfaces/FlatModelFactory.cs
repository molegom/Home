using HomeLibrary.Interfaces;
using HomeWeb.Models;

namespace HomeWeb.Interfaces
{
    class FlatModelFactory : IFlatModelFactory
    {
        private IFlatUi flatUi { get; set; }
        public FlatModelFactory()
        {
            flatUi = new FlatUi();
        }
        public FlatListViewModel CreateFlatListViewModel()
        {
            FlatListViewModel flatListViewModel = new FlatListViewModel
            {
                Flats = flatUi.GetAllFlats(),
                Images = flatUi.GetAllPreviewImages()
            };
            return flatListViewModel;
        }

        public FlatViewModel CreateFlatViewModel(int id)
        {
            FlatViewModel flatViewModel = new FlatViewModel()
            {
                Flat = flatUi.GetFlat(id)
            };
            return flatViewModel;
        }
    }
}
