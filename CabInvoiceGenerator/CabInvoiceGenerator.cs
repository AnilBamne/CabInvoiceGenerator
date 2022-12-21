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
        /// Variables
        /// </summary>
        RideType type;
        public readonly int MINIMUM_FARE;
        public readonly int COST_PER_MIN;
        public readonly int DISTANCE_PER_KM;

        /// <summary>
        /// constructor ,initializing ride types
        /// </summary>
        /// <param name="type"></param>
        public CabInvoiceGenerator(RideType type)
        {
            this.type = type;
            if (this.type == RideType.NORMAL)
            {
                MINIMUM_FARE = 5;
                COST_PER_MIN = 1;
                DISTANCE_PER_KM = 10;
            }
            else
            {
                MINIMUM_FARE = 20;
                COST_PER_MIN = 2;
                DISTANCE_PER_KM = 15;
            }
        }

        /// <summary>
        /// Calculate Total Fare by given parameters
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns> total fare</returns>
        public double CalculateTotalFare(double distance,int time)
        {
            try
            {
                double totalFare = 0;
                if (distance <= 0)
                {
                    throw new CabInvoiceCustomException("Invalid Distance", ExceptionType.INVALID_DISTANCE);
                }
                else if (time <= 0)
                {
                    throw new CabInvoiceCustomException("Invalid Time", ExceptionType.INVALID_TIME);
                }
                totalFare = distance * DISTANCE_PER_KM + time * COST_PER_MIN;
                return Math.Max(totalFare, MINIMUM_FARE);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }
    }
}
