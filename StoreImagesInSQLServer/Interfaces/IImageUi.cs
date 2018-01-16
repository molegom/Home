using System.Collections.Generic;

namespace StoreImagesInSQLServer.Interfaces
{
    public interface IImageUi
    {
        List<HomeDB.Image> GetAllImages();
        Dictionary<int, string> GetAllImageStatuses();

        int SaveImage(HomeDB.Image image);
    }
}
