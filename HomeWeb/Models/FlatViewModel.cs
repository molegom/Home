using System.Collections.Generic;
using HomeDB;

namespace HomeWeb.Models
{
    public class FlatViewModel
    {
        public Flat Flat { get; set; }
        public List<Image> Images { get; set; }
        public List<Image> ThumbImages { get; set; }
    }
}