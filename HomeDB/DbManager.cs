using System.Collections.Generic;
using System.Linq;

namespace HomeDB
{
    public class DbManager
    {
        private static FlatEntities flatEntities { get; set; }
        public DbManager()
        {
            if (flatEntities == null)
            {
                flatEntities = new FlatEntities();
            }
        }

        public List<Key> GetAllKeys()
        {
            return flatEntities.Keys.ToList();
        }

        public List<Flat> GetAllFlats()
        {
            return flatEntities.Flats.ToList();
        }

        public List<Image> GetAllImages()
        {
            return flatEntities.Images.ToList();
        }

        public List<Image> GetAllPreviewImages()
        {
            return flatEntities.Images.Where(p => p.ImageStatus.Id == 1).ToList();
        }

        public Flat GetFlatById(int id)
        {
            return flatEntities.Flats.FirstOrDefault(k => k.Id == id);
        }

        public Flat GetFlatByName(string name)
        {
            return flatEntities.Flats.FirstOrDefault(k => k.Name == name);
        }

        public int SaveImage(Image image)
        {
            int result;
            try
            {
                flatEntities.Images.Add(image);
                result = flatEntities.SaveChanges();
            }
            catch
            {
                result = 0;
            }
            return result;
        }

        public Dictionary<int, string> GetAllImageStatuses()
        {
            return flatEntities.ImageStatuses.ToDictionary(key => key.Id, val => val.Name);
        }
    }
}