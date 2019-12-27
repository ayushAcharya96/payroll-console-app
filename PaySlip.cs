using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace CSProject
{
    class PaySlip
    {
        private int month;
        private int year;

        enum MonthsOfYear
        {
            JAN = 1, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC
        }

        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }

        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;
            
            foreach (Staff s in myStaff)
            {
                path = s.NameOfStaff + ".txt";
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("PAYSLIP FOR {0} {1}", (MonthsOfYear)month, year);
                    sw.WriteLine("Name of Staff : {0}", s.NameOfStaff);
                    sw.WriteLine("Hours Worked : {0}", s.HoursWorked);
                    sw.WriteLine("");
                    sw.WriteLine("Basic Pay : {0:C}", s.BasicPay);
                    if (s.GetType() == typeof(Manager))
                        sw.WriteLine("Allowance : {0:C}", ((Manager)s).Allowance);
                    else
                        sw.WriteLine("Overtime : {0:C}", ((Admin)s).Overtime);
                    sw.WriteLine("");
                    sw.WriteLine("=======================================");
                    sw.WriteLine("Total Pay : {0:C}", s.TotalPay);
                    sw.WriteLine("=======================================");
                    sw.WriteLine("");
                    sw.Close();
                }

            }
        }

        public void GenerateSummary(List<Staff> staffs)
        {
            var result =
                from staff in staffs
                where staff.HoursWorked < 10
                orderby staff.NameOfStaff ascending
                select new { staff.NameOfStaff, staff.HoursWorked };

            string path = "summary.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Staff with less than 10 working hours");
                sw.WriteLine("");
                foreach(var staff in result)
                {
                    sw.WriteLine("Name of Staff : {0}, Hours Worked : {1}", staff.NameOfStaff, staff.HoursWorked);
                }
                sw.Close();
            }
        }

        public override string ToString()
        {
            return "Month : " + month + ", Year : " + year;
        }
    }
}
