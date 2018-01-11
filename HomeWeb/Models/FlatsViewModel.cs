using System.Collections.Generic;
using HomeDB;

namespace HomeWeb.Models
{
    public class FlatListViewModel
    {
        public List<Flats> Flats { get; set; }
        public List<Image> Images { get; set; }
    }
}