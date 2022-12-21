using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CabInvoiceGenerator222Batch.CabInvoiceCustomException;

namespace CabInvoiceGenerator222Batch
{
    public class CabInvoiceGenerator
    {
        /// <summary>
        /// Calculate Total Fare by given parameters
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns> total fare</returns>
        public double CalculateTotalFare(Ride ride)
        {
           // try
            //{
                double totalFare = 0;
                if (ride.distance <= 0)
                {
                    throw new CabInvoiceCustomException("Invalid Distance", ExceptionType.INVALID_DISTANCE);
                }
                else if (ride.time <= 0)
                {
                    throw new CabInvoiceCustomException("Invalid Time", ExceptionType.INVALID_TIME);
                }
                totalFare = ride.distance * ride.DISTANCE_PER_KM + ride.time * ride.COST_PER_MIN;
                return Math.Max(totalFare, ride.MINIMUM_FARE);
            //}
            //catch (Exception )
            //{
            //    return default;
            //}
        }

        public double CalculateTotalFare(Ride[] rides)
        {
            double totalFare = 0;
            foreach(Ride ride in rides)
            {
                totalFare += CalculateTotalFare(ride);
            }
            return totalFare;
        }
    }
}
