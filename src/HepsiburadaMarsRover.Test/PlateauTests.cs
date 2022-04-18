using HepsiburadaMarsRover.Business;
using NUnit.Framework;

namespace HepsiburadaMarsRover.Test;

public class PlateauTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase(5,5)]
    public void Plateau_ResizeTest(int x,int y)
    {
        IPlateau plateau = new Plateau(x,y);
 

        Assert.True(plateau.CurrentDimension.X == y && plateau.CurrentDimension.Y == y);

    }
}