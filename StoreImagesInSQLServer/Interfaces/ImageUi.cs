using System.Collections.Generic;
using HomeDB;

namespace StoreImagesInSQLServer.Interfaces
{
    public class ImageUi : IImageUi
    {
        private static DbManager db = null;

        public ImageUi()
        {
            if (db == null)
            {
                db = new DbManager();
            }
        }

        List<Image> IImageUi.GetAllImages()
        {            
            return db.GetAllImages();
        }

        public Dictionary<int, string> GetAllImageStatuses()
        {            
            return db.GetAllImageStatuses();
        }

        public int SaveImage(Image image)
        {            
            return db.SaveImage(image);
        }
    }
}
