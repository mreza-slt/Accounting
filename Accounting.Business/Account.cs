using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.DataLayer.Context;
using Accounting.ViewModels.Accounting;

namespace Accounting.Business
{
    public class Account
    {
        public static ReportViewModel ReportFormMain()
        {
            ReportViewModel rp = new ReportViewModel();

            using (Unit_Of_Work db = new Unit_Of_Work())
            {
                DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01);
                DateTime endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 30);

                var recived = db.AccountingRepository.Get(a => a.TypeId == 1 && a.DateTime >= startDate && a.DateTime <= endDate).Select(a => a.Amount).ToList();
                var pay = db.AccountingRepository.Get(a => a.TypeId == 2 && a.DateTime >= startDate && a.DateTime <= endDate).Select(a => a.Amount).ToList();

                rp.Recived = recived.Sum();
                rp.Pay = pay.Sum();
                rp.AccountBalance = (recived.Sum() - pay.Sum());

            }

            return rp;
        }
    }
}
