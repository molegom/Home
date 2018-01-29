namespace HomeWeb.Interfaces
{
    interface IDecreaseImage
    {
        byte[] CreateThumbnail(byte[] PassedImage, int LargestSide);
    }
}
