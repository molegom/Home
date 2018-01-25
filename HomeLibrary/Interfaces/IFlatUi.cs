using System;
using System.Collections.Generic;
using HomeDB;

namespace HomeLibrary.Interfaces
{
    public interface IFlatUi
    {
        Flat GetFlat(int id);
        List<Flat> GetAllFlats();
        List<Image> GetAllImages();
        List<Image> GetAllPreviewImages();
    }
}
