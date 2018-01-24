using System.Web.Mvc;
using HomeWeb.Interfaces;
using HomeWeb.Models;

namespace HomeWeb.Controllers
{
    public class FlatController : Controller
    {
        public ActionResult Index()
        {
            IFlatModelFactory flatModelFactory = new FlatModelFactory();
            FlatListViewModel flatListModel = flatModelFactory.CreateFlatListViewModel();
            return View(flatListModel);
        }

        public ActionResult FlatDetail(int id)
        {
            IFlatModelFactory flatModelFactory = new FlatModelFactory();
            FlatViewModel flatListModel = flatModelFactory.CreateFlatViewModel(id);
            return View("Flat", flatListModel);
        }
    }
}