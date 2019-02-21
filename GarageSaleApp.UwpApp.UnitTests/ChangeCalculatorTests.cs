
using System;
using GarageSaleApp.UwpApp.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GarageSaleApp.UwpApp.UnitTests
{
    [TestClass]
    public class ChangeCalculatorTests
    {
        [TestMethod]
        public void CalculatesTheChangeDue()
        {
            var changeCalc = new ChangeCalculator();
            changeCalc.Activate(63.42m);

            changeCalc.PushDigit("7");
            changeCalc.PushDigit("0");

            changeCalc.CalculateChange();

            Assert.AreEqual(6.58m, changeCalc.ChangeDue);
            Assert.IsTrue(changeCalc.ShowTheChangeDue);
        }
    }
}
