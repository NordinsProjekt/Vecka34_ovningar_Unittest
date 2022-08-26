using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using F03;

namespace Unittest
{
    [TestClass]
    public class Test_F03
    {
        [TestMethod]
        [TestCategory("Uppgift 5: Order printer cartridges")]
        [DataRow(4,-1)]
        [DataRow(5,0)]
        [DataRow(6,0)]
        [DataRow(99,0)]
        [DataRow(100,20)]
        [DataRow(101,20)]
        public void CheckIfOrderWillGetADiscount_ShouldReturnExcpectedResult(int amount, int expected)
        {
            var o = new OrderCartridge();
            int result = o.HowMuchDiscountWillThisAmountGiveMe(amount);
            Assert.AreEqual(result,expected);
        }
        [TestMethod]
        [TestCategory("Uppgift 6: Check age [1-99 is Valid] ")]
        [DataRow(0,false)]
        [DataRow(1, true)]
        [DataRow(2, true)]
        [DataRow(99,true)]
        [DataRow(100,false)]
        [DataRow(101,false)]
        public void CheckIfPersonsAgeIsValid__ShouldReturnExcpectedResult(int age, bool expected)
        {
            var a = new Age();
            bool result = a.CheckIfAgeIsValid(age);
            Assert.AreEqual(result,expected);
        }

        [TestMethod]
        [TestCategory("Uppgift 7: Year of birth [1900-2011 is Valid] ")]
        [DataRow(1899, false)]
        [DataRow(1900, true)]
        [DataRow(1901, true)]
        [DataRow(2010, true)]
        [DataRow(2011, true)]
        [DataRow(2012, false)]
        [DataRow(9999, false)]
        public void CheckIfYearOfBirthIsValid__ShouldReturnExcpectedResult(int year, bool expected)
        {
            var a = new Age();
            bool result = a.CheckIfYearOfBirth(year);
            Assert.AreEqual(result, expected);
        }
    }
}
