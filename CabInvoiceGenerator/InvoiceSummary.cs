using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator222Batch
{
    public class InvoiceSummary
    {
        public double totalFare;
        public int numOfRides;
        public double averageFare;
        public InvoiceSummary(double totalFare,int numOfRides)
        {
            this.totalFare = totalFare;
            this.numOfRides = numOfRides;
            averageFare= totalFare/numOfRides;
        }

        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }
            if(!(obj is InvoiceSummary))
            {
                return false;
            }
            InvoiceSummary inputedObject= (InvoiceSummary)obj;
            return this.numOfRides==inputedObject.numOfRides && this.averageFare==inputedObject.averageFare && this.averageFare == inputedObject.averageFare;
        }

        public override int GetHashCode()
        {
            return this.numOfRides.GetHashCode() ^ this.totalFare.GetHashCode() ^ this.averageFare.GetHashCode();
        }
    }
}
