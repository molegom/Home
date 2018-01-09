using System;

namespace HomeLibrary
{
    public static class Helper
    {
        public static int Month = DateTime.Now.Month - 1;
        public static int Year = DateTime.Now.Year;
        public const int StartIncomeByMonth = 3000;
        public static int IncomeByMonth = StartIncomeByMonth;
        public const int IncByOne = 500;
        public const int CountFlat = 1;
        public const int Sum = 1100;
        public const bool IsCredit = true;
        public static bool IsHome;
        public const int MinStorage = 2000;
        public const int PriceFlat = 25000;
        public const int PriceRepair = 12000;
        public const int PriceCredit = 15000;

        public static string GetFormat(this int s, int l)
        {
            string sStr = s.ToString();
            while (sStr.Length < l)
            {
                sStr = " " + sStr;
            }
            return sStr;
        }
    }
}
