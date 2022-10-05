using System;
using System.Collections.Generic;
using System.Text;

namespace ShippingCompany
{
    public class TruckDelivery : Delivery
    {
        public const double TruckTopSpeed = 60.0;
        public override int GetDuration()
        {
            double decimalHours = (double)base.Distance / TruckTopSpeed;
            return ConvertHoursToMinutes(decimalHours);
        }
    }
}
