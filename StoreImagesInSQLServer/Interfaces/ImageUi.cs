using System;
using System.Collections.Generic;
using HomeDB;

namespace StoreImagesInSQLServer.Interfaces
{
    public class ImageUi : IImageUi
    {
        List<Image> IImageUi.GetAllImages()
        {
            DbManager db = new DbManager();
            return db.GetAllImages();
        }
    }
}
