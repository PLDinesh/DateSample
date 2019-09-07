using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //start date
            //end date
            // ignore month ends

            List<DateTime> dtList = new List<DateTime>();

            for (DateTime i = new DateTime(2001, 1, 1); i <= DateTime.Now; i = i.AddDays(1))
            {
                if (!IsMonthEndDate(i))
                    dtList.Add(i);
            }

            int MaxThreads = 10;

            var options = new ParallelOptions() { MaxDegreeOfParallelism = MaxThreads };

            Parallel.ForEach(dtList, options, i =>
            {
                //obj.SavePersistentXIRR(i, i, "1", "XIRR");
                //obj.SavePersistentXIRR(i, i, "2", "XIRR");
                //obj.SavePersistentXIRR(i, i, "3", "XIRR");
            });

        }

        private static bool IsMonthEndDate(DateTime i)
        {
            return (i.Month != i.AddDays(1).Month) ? true : false;
        }
    }
}
