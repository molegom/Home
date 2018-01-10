using System.Collections.Generic;
using HomeDB;

namespace HomeLibrary.Interfaces
{
    public class FlatUi: IFlatUi
    {
        public List<Flats> GetAllFlats()
        {
            DbManager db = new DbManager();
            return db.GetAllFlats();
        }
    }
}
