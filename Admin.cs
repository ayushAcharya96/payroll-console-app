﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject
{
    class Admin : Staff
    {
        private const float overtimeRate = 15.5f;
        private const float adminHourlyRate = 30;

        public float Overtime { get; private set; }

        public Admin(string name) : base (name, adminHourlyRate) { }

        public override void CalculatePay()
        {
            base.CalculatePay();
            if (HoursWorked > 160)
            {
                Overtime = overtimeRate * (HoursWorked - 160);
                TotalPay += Overtime;
            }
        }

        public override string ToString()
        {
            return base.ToString() + ",\nOvertime : " + Overtime;
        }
    }
}
