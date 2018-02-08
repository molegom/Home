using System;
using System.Collections.Generic;
using System.Linq;
using HomeDB;
using HomeLibrary.Interfaces;
using HomeWeb.Helpers;
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
                ImagesData = flatUi.GetAllPreviewImages().ToDictionary(k => k.FlatId, v => v.ImageData.ToImage())
            };
            return flatListViewModel;
        }

        public FlatViewModel CreateFlatViewModel(int id)
        {
            IDecreaseImage decreaseImage = new DecreaseImage();

            //List<Image> imagesList = flatUi.GetAllImages().Where(p => p.FlatId == id).ToList();
            var images =
                flatUi.GetAllImages()
                    .Where(i => i.FlatId == id && i.ImageStatus.Id == 2);                                
            FlatViewModel flatViewModel = new FlatViewModel
            {
                Flat = flatUi.GetFlat(id),
                Images = images.Select(i=>i.ImageData.ToImage()).ToList(),
                ThumbImages = images.Select(i => decreaseImage.CreateThumbnail(i.ImageData, 50).ToImage()).ToList()
            };            
            return flatViewModel;
        }
    }
}
