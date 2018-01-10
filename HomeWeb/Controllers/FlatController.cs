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
            FlatListViewModel flatListModel = flatModelFactory.CreateFlatsViewModel();
            return View(flatListModel);
        }      
    }
}