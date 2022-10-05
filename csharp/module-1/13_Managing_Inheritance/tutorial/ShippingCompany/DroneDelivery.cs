using System;
using System.Collections.Generic;
using System.Text;

namespace ShippingCompany
{
    public class DroneDelivery : Delivery
    {
        public const double DroneTopSpeed = 100.0;

        public override int GetDuration()
        {
            double topSpeedWithWeight = DroneTopSpeed / Shipment.Weight;
            double decimalHours = base.Distance / topSpeedWithWeight;
            return ConvertHoursToMinutes(decimalHours);
        }
    }
}
