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
            double decimalHours = base.Distance / TruckTopSpeed;
            int hours = (int)decimalHours;
            int minutes = (int)Math.Round((decimalHours - hours) * 60);
            return (hours * 60) + minutes;
        }
    }
}
