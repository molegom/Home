using System.Collections.Generic;
using HomeDB;

namespace HomeLibrary.Interfaces
{
    public class FlatUi: IFlatUi
    {
        public List<Flat> GetAllFlats()
        {
            DbManager db = new DbManager();
            return db.GetAllFlats();
        }

        public List<Image> GetAllImages()
        {
            DbManager db = new DbManager();
            return db.GetAllImages();
        }
    }
}
