using HepsiburadaMarsRover.Business;
using HepsiburadaMarsRover.Entity;
using NUnit.Framework;

namespace HepsiburadaMarsRover.Test;

public class RoverTests
{
    private readonly IPlateau _plateau;
    public RoverTests()
    {
        _plateau=new Plateau(5,5); 
    }


    [SetUp]
    public void Setup()
    {

    }

    [Test]
    [TestCase(1,2,"N")]
    public void Rover_RelocationTest(int x,int y,string direction)
    { 
        Rover rover = new ();
        rover.DropToPlateau(_plateau,x,y,direction);

        rover.Relocation(x, y, direction);

        var outputCoordinate = new Coordinate(x, y, direction);

        Assert.True(rover.CurrentCoordinate.X==outputCoordinate.X && rover.CurrentCoordinate.Y==outputCoordinate.Y && rover.CurrentCoordinate.Direction==outputCoordinate.Direction);

    }

    [Test]
    [TestCase(1, 2, "N")]
    public void Rover_TurnRightTest(int x, int y, string direction)
    {
        Rover rover = new();
        rover.DropToPlateau(_plateau,x,y,direction);


        rover.TurnRight();

        Assert.True(rover.CurrentCoordinate.Direction==EnumDirection.E);
    }

    [Test]
    [TestCase(1, 2, "N")]
    public void Rover_TurnLeftTest(int x, int y, string direction)
    {
        Rover rover = new();

        rover.DropToPlateau(_plateau,x,y,direction);

        rover.TurnLeft();

        Assert.True(rover.CurrentCoordinate.Direction == EnumDirection.W);
    }

    [Test]
    [TestCase(1, 2, "N")]
    public void Rover_MoveTest(int x, int y, string direction)
    {

        Rover rover = new();
        rover.DropToPlateau(_plateau,x,y,direction);


        rover.Move();


        Assert.True(rover.CurrentCoordinate.Y==3);
    }

    [Test]
    [TestCase(1, 2, "N")]
    public void Rover_CommandTest(int x, int y, string direction)
    {
        
        Rover rover = new();
        rover.DropToPlateau(_plateau,x,y,direction);

        rover.Command('L');

        Assert.True(rover.CurrentCoordinate.Direction==EnumDirection.W);
    }
    [Test]
    [TestCase(1, 2, "N")]
    public void Rover_ResetTest(int x, int y, string direction)
    {
        Rover rover = new();
        rover.DropToPlateau(_plateau,x,y,direction);


        rover.Reset();
        Assert.True(rover.CurrentCoordinate.X == 0 && rover.CurrentCoordinate.Y == 0 && rover.CurrentCoordinate.Direction == EnumDirection.N);

    }
}