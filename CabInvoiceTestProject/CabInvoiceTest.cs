using CabInvoiceGenerator222Batch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CabInvoiceTestProject
{
    [TestClass]
    public class CabInvoiceTest
    {
        //step-1 positive scenario
        [TestMethod]
        //[DataRow(5,2,RideType.NORMAL,52)]     //expected =>10*5+2*1=52 
        public void When_GivenDistanceAndTime_Then_ReturnTotalFare()
        {
            //arrange
            Ride ride = new Ride(4, 2, RideType.NORMAL);
            CabInvoiceGenerator invoiceGenerator = new CabInvoiceGenerator();
            //Act
            double actualFare=invoiceGenerator.CalculateTotalFare(ride);
            //Assert
            Assert.AreEqual(actualFare, 42);
        }

        //step-1 Negative scenario
        [TestMethod]
        //[DataRow(5,2,RideType.NORMAL,52)]     //expected =>10*5+2*1=52 
        public void When_GivenWrongDistanceAndTime_Then_ReturnTotalFare()
        {
            //arrange
            Ride ride = new Ride(-4, 2, RideType.NORMAL);
            CabInvoiceGenerator invoiceGenerator = new CabInvoiceGenerator();
            //Act
            //double actualFare = invoiceGenerator.CalculateTotalFare(ride);
            var actual = Assert.ThrowsException<CabInvoiceCustomException>(() => invoiceGenerator.CalculateTotalFare(ride));
            //Assert
            // Assert.AreEqual(actual.exceptionType, CabInvoiceCustomException.ExceptionType.INVALID_DISTANCE);
            Assert.AreEqual(actual.Message, "Invalid Distance");
        }


        ////step-2 multiple rides
        //[TestMethod]
        ////[DataRow(5,2,RideType.NORMAL,52)]     //expected =>10*5+2*1=52 
        //public void When_MultipleRides_Then_ReturnTotalFare()
        //{
        //    //arrange
        //    Ride[] ride = new Ride[]
        //    {
        //        new Ride(4, 2, RideType.NORMAL),    //fare=42
        //        new Ride(6, 3, RideType.NORMAL),    //fare=63   total=105
        //    };
        //    CabInvoiceGenerator invoiceGenerator = new CabInvoiceGenerator();
        //    //Act
        //    double actualFare = invoiceGenerator.CalculateTotalFare(ride);
        //    //Assert
        //    Assert.AreEqual(actualFare, 105);
        //}

        //step-3 for multiple rides ,calculate total fare,avg fare
        [TestMethod]
        //[DataRow(5,2,RideType.NORMAL,52)]     //expected =>10*5+2*1=52 
        public void When_MultipleRides_Then_ReturnTotalFare()
        {
            //arrange
            Ride[] rides = new Ride[]
            {
                new Ride(4, 2, RideType.NORMAL),    //fare=42
                new Ride(6, 3, RideType.NORMAL),    //fare=63   total=105
            };
            CabInvoiceGenerator invoiceGenerator = new CabInvoiceGenerator();
            InvoiceSummary expected = new InvoiceSummary(105, rides.Length);
            //Act
            InvoiceSummary actual = invoiceGenerator.CalculateTotalFare(rides);
            //Assert
            Assert.AreEqual(actual, expected);
        }
    }
}
