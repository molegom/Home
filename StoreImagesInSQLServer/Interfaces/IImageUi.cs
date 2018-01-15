using System.Collections.Generic;

namespace StoreImagesInSQLServer.Interfaces
{
    public interface IImageUi
    {
        List<HomeDB.Image> GetAllImages();

        int SaveImage(HomeDB.Image image);
    }
}
