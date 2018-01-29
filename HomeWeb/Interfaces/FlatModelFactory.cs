using System.Collections.Generic;
using System.Linq;
using HomeDB;
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
            IDecreaseImage decreaseImage = new DecreaseImage();

            List<Image> images = flatUi.GetAllImages().Where(p => p.FlatId == id).ToList();

            FlatViewModel flatViewModel = new FlatViewModel
            {
                Flat = flatUi.GetFlat(id),
                Images = images,
                ThumbImages = images
            };
            flatViewModel.ThumbImages.ForEach(t=>t.ImageData = decreaseImage.CreateThumbnail(t.ImageData, 3));
            return flatViewModel;
        }
    }
}
