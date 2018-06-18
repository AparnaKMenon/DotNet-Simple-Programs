using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class RandomNumberArrayTest
{
    [TestMethod]
    public void generateRandomNum_HighandLowReversed_ReturnsWithinRange()
    {
        int low = 50;
        int high = 0;

        int actual = RandomNumber.generateRandomNum(low, high);
        Assert.IsTrue(!(actual < high || actual > low));
    }

    [TestMethod]
    public void generateRandomNum_PositiveNums_ReturnsPos()
    {
        int low = 10;
        int high = 33;

        int actual = RandomNumber.generateRandomNum(low, high);

        Assert.IsTrue(!(actual < low || actual > high || actual < 0));
    }


    [TestMethod]
    public void generateRandomNum_NegativeNums_ReturnsNeg()
    {
        int low = -110;
        int high = -93;

        int actual = RandomNumber.generateRandomNum(low, high);

        Assert.IsTrue(!(actual < low || actual > high || actual > 0));
    }

    [TestMethod]
    public void generateRandomNum_NegPositiveNums_ReturnsNegOrPos()
    {
        int low = -15;
        int high = 5;

        int actual = RandomNumber.generateRandomNum(low, high);

        Assert.IsTrue(!(actual < low || actual > high));
    }

    [TestMethod]
    public void generateRandomNum_SameNums_ReturnsSameNum()
    {
        int low = 0;
        int high = 0;

        int actual = RandomNumber.generateRandomNum(low, high);

        Assert.IsTrue(actual == high);
    }

    [TestMethod]
    public void generateRandomNum_MinMaxNums_ReturnsWithinRange()
    {
        int low = Int32.MinValue;
        int high = Int32.MaxValue;

        int actual = RandomNumber.generateRandomNum(low, high);

        Assert.IsTrue(!(actual < low || actual > high));
    }

    [TestMethod]
    public void generateRandomNum_MinAnd0_ReturnsNeg()
    {
        int low = Int32.MinValue;
        int high = 0;

        int actual = RandomNumber.generateRandomNum(low, high);

        Assert.IsTrue(!(actual < low || actual > high || actual > 0));
    }

    [TestMethod]
    public void generateRandomNum_VeryLowNums_ReturnsNegWithinRange()
    {
        int low = Int32.MinValue;
        int high = Int32.MinValue + 5;

        int actual = RandomNumber.generateRandomNum(low, high);

        Assert.IsTrue(!(actual < low || actual > high || actual > 0));
    }

    [TestMethod]
    public void generateRandomNum_0AndMax_ReturnsPositive()
    {
        int low = 0;
        int high = Int32.MaxValue;

        int actual = RandomNumber.generateRandomNum(low, high);

        Assert.IsTrue(!(actual < low || actual > high || actual < 0));
    }

    [TestMethod]
    public void generateRandomNum_VeryHighNumbers_ReturnsWithinRange()
    {
        int low = Int32.MaxValue - 5;
        int high = Int32.MaxValue;

        int actual = RandomNumber.generateRandomNum(low, high);

        Assert.IsTrue(!(actual < low || actual > high));
    }
}
