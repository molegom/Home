using System;

namespace HomeWeb.Helpers
{
    static class ImageHelper
    {
        public static string ToImage(this byte[] data)
        {
            return string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(data));
        }
    }
}