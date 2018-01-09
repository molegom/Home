namespace Home.Models
{
    public enum HomeStatus
    {
        Buying = 0,
        Repairing = 1,
        WaitingTenant = 2,
        Profiting = 3
    }
    public class FlatModel
    {
        public int Id { get; set; }
        public HomeStatus Status { get; set; }
        public bool IsCredit { get; set; }
        public int PriceFlat { get; set; }
        public int PriceRepair { get; set; }
        public int IncomeMonth { get; set; }
        public int WaitingMonthTenant { get; set; }
        public FlatModel(int id = 0, HomeStatus status = HomeStatus.Buying, bool isCredit = false, int priceFlat = 25000, int priceRepair = 12000, int incomeMonth = 450)
        {
            Id = id;
            Status = status;
            IsCredit = isCredit;
            PriceFlat = priceFlat;
            PriceRepair = priceRepair;
            IncomeMonth = incomeMonth;
            WaitingMonthTenant = 1;
        }
    }
}