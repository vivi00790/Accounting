using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting
{
    class Accounting
    {
        
        public decimal QueryBudget(DateTime startDate, DateTime endDate)
        {
            if (startDate.Year == endDate.Year)
            {
                if (startDate.Month  == endDate.Month)
                {
                    var days = endDate.Subtract(startDate).Days+1;

                    var daysInMonth = DateTime.DaysInMonth(startDate.Year,startDate.Month);

                    var budget = Repo.GetAll().First(model => model.YearMonth == startDate.ToString("yyyyMM"));
                    return  (decimal)budget.Amount / daysInMonth * days;
                }
            }

            return 0;
        }

        public IBudgetRepo Repo { get; set; }
    }
}
