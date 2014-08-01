using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NVexFlowTest
{
    [TestClass]
    public class UnitTestFraction
    {
        Random r = new Random();
        [TestMethod]
        public void TestFractionConstrcutor()
        {
            var rndIntN = r.Next(-int.MaxValue,int.MaxValue);
            var rndIntD = r.Next(-int.MaxValue,int.MaxValue);
            Assert.AreEqual(true,new Fraction() == new Fraction(0,0));
            Assert.AreEqual(true,new Fraction() == new Fraction(rndIntN,int.MinValue));
            Assert.AreEqual(true,new Fraction() == new Fraction(int.MinValue,rndIntD));
            Assert.AreEqual(true,new Fraction(rndIntN,rndIntD) == new Fraction(rndIntN * -1,rndIntD * -1));
        }
        [TestMethod]
        public void TestFractionCompute()
        {
            var rndIntN = r.Next(-int.MaxValue,int.MaxValue);
            var rndIntD = r.Next(-int.MaxValue,int.MaxValue);
            Assert.AreEqual(true,new Fraction(rndIntN,rndIntD) * 2 == new Fraction(rndIntN,rndIntD) + new Fraction(rndIntN,rndIntD));
            Assert.AreEqual(true,new Fraction(rndIntN,rndIntD) * 0 == new Fraction(rndIntN,rndIntD) - new Fraction(rndIntN,rndIntD));
            Assert.AreEqual(true,new Fraction(rndIntN,rndIntD) * -1 == -(new Fraction(rndIntN,rndIntD)));
            Assert.AreEqual(true,new Fraction(rndIntN,rndIntD) / -1 == -(new Fraction(rndIntN,rndIntD)));
        }
    }
}
