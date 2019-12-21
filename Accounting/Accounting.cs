using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Accounting
{
    class Accounting
    {
        
        public decimal QueryBudget(DateTime startDate, DateTime endDate)
        {
            var bugdet = 0m;
            if (startDate.Year == endDate.Year)
            {
                if (startDate.Month == endDate.Month)
                {
                    var days = endDate.Subtract(startDate).Days + 1;
                    return BudgetOfMonth(startDate, days);
                }

                var CurrentDate = new DateTime(startDate.Year, startDate.Month, 1);

                var months = (endDate.Month - startDate.Month) + 1;



                for (var i = 0; i < months; i++)
                {
                    if (i == 0)
                    {
                        bugdet += BudgetOfMonth(startDate,
                            DateTime.DaysInMonth(startDate.Year, startDate.Month) - startDate.Day + 1);


                    }
                    else if (i == months - 1)
                    {
                        bugdet += BudgetOfMonth(endDate, endDate.Day);
                    }
                    else
                    {
                        bugdet += BudgetOfMonth(CurrentDate, DateTime.DaysInMonth(CurrentDate.Year, CurrentDate.Month));
                    }

                    CurrentDate = CurrentDate.AddMonths(1);
                }


            }
            

            return bugdet;
        }

        private decimal BudgetOfMonth(DateTime startDate, int days)
        {
            

            var daysInMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month);

            var budget = Repo.GetAll().First(model => model.YearMonth == startDate.ToString("yyyyMM"));
            return (decimal) budget.Amount / daysInMonth * days;
        }

        public IBudgetRepo Repo { get; set; }
    }
}
