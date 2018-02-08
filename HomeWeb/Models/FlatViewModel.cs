using System.Collections.Generic;
using HomeDB;

namespace HomeWeb.Models
{
    public class FlatViewModel
    {
        public Flat Flat { get; set; }
        public List<string> Images { get; set; }
        public List<string> ThumbImages { get; set; }
    }
}