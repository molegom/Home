using System;
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

        public List<Flats> GetAllFlats()
        {
            return flatEntities.Flats.ToList();
        }

        public List<Image> GetAllImages()
        {
            return flatEntities.Images.ToList();
        }

        public Flats GetFlatById(int id)
        {
            return flatEntities.Flats.FirstOrDefault(k => k.Id == id);
        }

        public Flats GetFlatByName(string name)
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
    }
}