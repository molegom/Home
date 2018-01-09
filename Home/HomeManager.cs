using System;
using System.Collections.Generic;
using System.Linq;
using Home.Models;

namespace Home
{
    class HomeManager
    {
        private int currentMonth = Helper.Month;
        private int currentYear = Helper.Year;
        private int sum = Helper.Sum;
        private int incomeMonth = Helper.IncomeByMonth;
        private bool isCredit = Helper.IsCredit;
        private int currentCount = 1;
        private string outputStatusStr = string.Empty;
        private string prevStatusStr = string.Empty;
        List<FlatModel> flats = new List<FlatModel>();
        public void Process(int countMonth = 300)
        {
            InitiateHome();
            for (int i = 0; i < countMonth; i++)
            {
                outputStatusStr = string.Empty;
                if (currentMonth == 1 && currentYear == 2032)
                {
                    int y = 4;
                }
                int sumFlatMonth = 0;
                var doneFlats = flats.Where(f => f.Status == HomeStatus.Profiting).ToList();
                var waitTenFlats = flats.Where(f => f.Status == HomeStatus.WaitingTenant).ToList();
                var repairFlats = flats.Where(f => f.Status == HomeStatus.Repairing).ToList();
                var buyFlats = flats.Where(f => f.Status == HomeStatus.Buying).ToList();

                doneFlats.Select(d => d.IncomeMonth).ToList().ForEach(d1 => sumFlatMonth += d1);
                incomeMonth = sumFlatMonth + Helper.IncomeByMonth;
                if (i > 0)
                {
                    sum = sum + incomeMonth;
                }

                repairFlats.ForEach(r =>
                {
                    if (sum > 0)
                    {
                        if (r.PriceRepair + Helper.MinStorage <= sum)
                        {
                            sum = sum - r.PriceRepair;
                            r.PriceRepair = 0;
                            r.IsCredit = false;
                            r.Status = HomeStatus.Profiting;
                            outputStatusStr = outputStatusStr + "P(" + r.Id + ")| ";
                            if (buyFlats.Count == 0)
                            {
                                CollectToBuyNewFlat();
                            }
                        }
                    }
                });
                buyFlats.ForEach(b =>
                {
                    if (sum > 0)
                    {
                        if (b.PriceFlat + Helper.MinStorage <= sum)
                        {
                            sum = sum - b.PriceFlat;
                            b.PriceFlat = 0;
                            b.Status = HomeStatus.Repairing;
                            b.IsCredit = false;
                            outputStatusStr = outputStatusStr + "R(" + b.Id + ")| ";
                            if (b.PriceRepair <= 0)
                            {
                                b.PriceRepair = Helper.PriceRepair;
                            }
                        }
                    }
                });

                waitTenFlats.ForEach(w =>
                {
                    w.WaitingMonthTenant--;
                    if (w.WaitingMonthTenant == 0)
                    {
                        outputStatusStr = outputStatusStr + "W(" + w.Id + ")| ";
                        w.Status = HomeStatus.Profiting;
                    }
                });

                if (isCredit)
                {
                    isCredit = flats.Count(f => f.IsCredit) * 2 >= flats.Count;
                }

                BuyNewFlats();

                IncrementMonth();
            }
        }

        private void BuyNewFlats()
        {
            int counts = 0;
            while (sum >= Helper.PriceFlat + Helper.MinStorage)
            {
                flats.Add(new FlatModel()
                {
                    Id = flats.Count + 1,
                    IncomeMonth = Helper.IncByOne,
                    PriceFlat = Helper.PriceFlat,
                    PriceRepair = Helper.PriceRepair
                });
                counts++;
                outputStatusStr = outputStatusStr + "B(" + flats.Last().Id + ")| ";
                sum = sum - Helper.PriceFlat;
            }
            if (counts > 0)
            {
                currentCount = counts;
            }
        }

        private void CollectToBuyNewFlat()
        {
            if (sum < Helper.PriceFlat + Helper.MinStorage)
            {
                currentCount = 1;
                incomeMonth = incomeMonth + flats.Last().IncomeMonth;
                var currentFlat = new FlatModel()
                {
                    Id = flats.Count + 1,
                    Status = HomeStatus.Buying,
                    PriceRepair = Helper.PriceRepair,
                    PriceFlat = Helper.PriceFlat,
                    IncomeMonth = Helper.IncByOne
                };
                outputStatusStr = outputStatusStr + "B(" + currentFlat.Id + ")| ";
                flats.Add(currentFlat);
            }
            else
            {
                currentCount = (sum - Helper.MinStorage) / Helper.PriceFlat;
                for (int i = 0; i < currentCount; i++)
                {
                    var currentFlat = new FlatModel()
                    {
                        Id = flats.Count + 1,
                        Status = HomeStatus.Repairing,
                        PriceRepair = Helper.PriceRepair,
                        PriceFlat = 0,
                        IncomeMonth = Helper.IncByOne
                    };
                    sum = sum - Helper.PriceRepair;
                    outputStatusStr = outputStatusStr + "BR(" + currentFlat.Id + ")| ";
                    flats.Add(currentFlat);
                }
            }
        }

        public void IncrementMonth()
        {
            if (!string.IsNullOrWhiteSpace(outputStatusStr))
            {
                prevStatusStr = outputStatusStr;
            }
            else
            {
                outputStatusStr = prevStatusStr;
            }
            Console.WriteLine("{0}, sum:{1}, income:{2}, count:{3}, {4}", AddOneMonth(),
                sum.GetFormat(6), incomeMonth.GetFormat(5),
                flats.Count(f => f.Status != HomeStatus.Buying).GetFormat(2), isCredit ? "Credit" : outputStatusStr.TrimEnd(' ').TrimEnd('|')
                /*string.Join(", ", flats.Skip(flats.Count - currentCount).Select(f => f.Status))*/ /*? "Home" : "Repair"*/);
        }

        private void InitiateHome()
        {
            HomeStatus StatusCurrent;
            bool IsCreditCurrent = false;
            int PriceFlatCurrent = 0;
            int PriceRepairCurrent = 0;

            if (currentYear == 2018 && currentMonth <= 5)
            {
                StatusCurrent = HomeStatus.Buying;
                IsCreditCurrent = true;
                sum = sum + Helper.IncomeByMonth * (currentMonth + 1);
                PriceRepairCurrent = 18000;
                PriceFlatCurrent = 15000;
                if (currentMonth == 6)
                {
                    sum = sum - PriceFlatCurrent;
                    PriceFlatCurrent = 0;
                }
            }
            else if (currentYear == 2018 && currentMonth <= 11)
            {
                StatusCurrent = HomeStatus.Repairing;
                PriceFlatCurrent = 0;
                PriceRepairCurrent = 18000 - (currentMonth - 5) * Helper.IncomeByMonth;
                sum = sum + Helper.IncomeByMonth * (currentMonth + 1) - Helper.PriceCredit;
            }
            else
            {
                StatusCurrent = HomeStatus.Profiting;
                sum = sum + Helper.IncomeByMonth * (currentMonth - 1) - Helper.PriceCredit - Helper.PriceRepair;
            }
            FlatModel firstHome = new FlatModel(1, StatusCurrent, IsCreditCurrent, PriceFlatCurrent, PriceRepairCurrent, 200);
            flats.Add(firstHome);
        }

        private string AddOneMonth()
        {
            currentMonth++;
            if (currentMonth > 12)
            {
                currentMonth = 1;
                currentYear++;
                Console.WriteLine("================================={0}==================================", currentYear);
            }

            return string.Format("month: {0}, year: {1}", currentMonth > 9 ? currentMonth.ToString() : " " + currentMonth, currentYear);
        }
    }
}
