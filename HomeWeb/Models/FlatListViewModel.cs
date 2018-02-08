using System.Collections.Generic;
using HomeDB;

namespace HomeWeb.Models
{
    public class FlatListViewModel
    {
        public List<Flat> Flats { get; set; }      
        public Dictionary<int, string> ImagesData { get; set; } 
    }
}