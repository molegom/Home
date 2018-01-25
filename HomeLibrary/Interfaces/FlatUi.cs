using System.Collections.Generic;
using HomeDB;

namespace HomeLibrary.Interfaces
{
    public class FlatUi : IFlatUi
    {
        private static DbManager db { get; set; }

        public FlatUi()
        {
            if (db == null)
            {
                db = new DbManager();
            }
        }
        public Flat GetFlat(int id)
        {
            return db.GetFlatById(id);
        }

        public List<Flat> GetAllFlats()
        {
            return db.GetAllFlats();
        }

        public List<Image> GetAllImages()
        {
            return db.GetAllImages();
        }

        public List<Image> GetAllPreviewImages()
        {
            return db.GetAllPreviewImages();
        }
    }
}
