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
            var budget = Repo.GetAll().First(model => model.YearMonth == startDate.ToString("yyyyMM"));

            return budget.Amount;
        }

        public IBudgetRepo Repo { get; set; }
    }
}
