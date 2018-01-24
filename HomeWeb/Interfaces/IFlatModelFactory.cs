using HomeWeb.Models;

namespace HomeWeb.Interfaces
{
    interface IFlatModelFactory
    {
        FlatListViewModel CreateFlatListViewModel();
        FlatViewModel CreateFlatViewModel(int id);
    }
}
