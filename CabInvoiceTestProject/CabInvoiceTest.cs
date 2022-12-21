using CabInvoiceGenerator222Batch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CabInvoiceTestProject
{
    [TestClass]
    public class CabInvoiceTest
    {
        [TestMethod]
        [DataRow(5,2,RideType.NORMAL,52)]     //expected =>10*5+2*1=52 
        public void When_GivenDistanceAndTime_Then_ReturnTotalFare(double distance,int time,RideType type,double expectedFare)
        {
            //arrange
            CabInvoiceGenerator invoiceGenerator = new CabInvoiceGenerator(type);
            //Act
            double actualFare=invoiceGenerator.CalculateTotalFare(distance,time);
            //Assert
            Assert.AreEqual(actualFare, expectedFare);
        }
    }
}
