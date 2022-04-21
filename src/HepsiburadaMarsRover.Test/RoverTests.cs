using System;
using System.Linq;
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
    [TestCase(1,2,EnumDirection.N)]
    public void Rover_RelocationTest(int x,int y,EnumDirection direction)
    { 
        Rover rover = new ();
        rover.DropToPlateau(_plateau,x,y,direction);

        rover.Relocation(x, y, direction);

        var outputCoordinate = new Coordinate(x, y, direction);

        Assert.True(rover.CurrentCoordinate.X==outputCoordinate.X && rover.CurrentCoordinate.Y==outputCoordinate.Y && rover.CurrentCoordinate.Direction==outputCoordinate.Direction);

    }

    [Test]
    [TestCase(1, 2, EnumDirection.N)]
    public void Rover_TurnRightTest(int x, int y, EnumDirection direction)
    {
        Rover rover = new();
        rover.DropToPlateau(_plateau,x,y,direction);


        rover.TurnRight();

        Assert.True(rover.CurrentCoordinate.Direction==EnumDirection.E);
    }

    [Test]
    [TestCase(1, 2, EnumDirection.N)]
    public void Rover_TurnLeftTest(int x, int y, EnumDirection direction)
    {
        Rover rover = new();

        rover.DropToPlateau(_plateau,x,y,direction);

        rover.TurnLeft();

        Assert.True(rover.CurrentCoordinate.Direction == EnumDirection.W);
    }

    [Test]
    [TestCase(1, 2, EnumDirection.N)]
    public void Rover_MoveTest(int x, int y, EnumDirection direction)
    {

        Rover rover = new();
        rover.DropToPlateau(_plateau,x,y,direction);


        rover.Move();


        Assert.True(rover.CurrentCoordinate.Y==3);
    }

    [Test]
    [TestCase(1, 2,'L', EnumDirection.N)] 
    public void Rover_CommandTest(int x, int y,char command, EnumDirection direction)
    {
        Rover rover = new();
        rover.DropToPlateau(_plateau,x,y,direction); 
        rover.Command(command); 

        Assert.True(rover.CurrentCoordinate.Direction==EnumDirection.W);
    }
    
    [Test]
    [TestCase(1, 2,'O', EnumDirection.N)] 
    public void Rover_CommandExceptionTest(int x, int y,char command, EnumDirection direction)
    {
        Rover rover = new();
        rover.DropToPlateau(_plateau,x,y,direction);  

        Assert.Throws<ArgumentException>(()=>rover.Command(command));
    }
    
    [Test]
    [TestCase(1, 2, EnumDirection.N)]
    public void Rover_ResetTest(int x, int y, EnumDirection direction)
    {
        Rover rover = new();
        rover.DropToPlateau(_plateau,x,y,direction);


        rover.Reset();
        Assert.True(rover.CurrentCoordinate.X == 0 && rover.CurrentCoordinate.Y == 0 && rover.CurrentCoordinate.Direction == EnumDirection.N);
    }
    
    [Test]
    [TestCase(1, 2, EnumDirection.N)]
    public void Rover_ToStringTest(int x, int y, EnumDirection direction)
    {
        Rover rover = new();
        rover.DropToPlateau(_plateau,x,y,direction);


        rover.Reset();
        Assert.True(rover.CurrentCoordinate.X == 0 && rover.CurrentCoordinate.Y == 0 && rover.CurrentCoordinate.Direction == EnumDirection.N);
    }
    
    [Test]
    [TestCase(1, 2, EnumDirection.N)]
    public void Rover_GetPlateauTest(int x, int y, EnumDirection direction)
    {
        Rover rover = new();
        rover.DropToPlateau(_plateau,x,y,direction);
        
        var plateau = rover.GetPlateau();
        
        Assert.True(_plateau==plateau);
    }
 
    
    [Test]
    [TestCase(8, 2, EnumDirection.N)]
    [TestCase(-1, 7, EnumDirection.S)]
    [TestCase(0, -7, EnumDirection.W)]
    public void Rover_DropToPlateauBoundariesControlTest(int x, int y, EnumDirection direction)
    {
        Rover rover = new();  
        Assert.Throws<ArgumentOutOfRangeException>(()=> rover.DropToPlateau(_plateau,x,y,direction));
    }  
    
    
    [Test]
    [TestCase(1, 2, EnumDirection.N)]
    public void Rover_DropToPlateauArgumentExceptionTextTest(int x, int y, EnumDirection direction)
    {
        Rover rover = new(); 
        Assert.Throws<ArgumentNullException>(()=>rover.DropToPlateau(null,1,4,direction));
    }
    
    
    [Test]
    [TestCase(1, 2, EnumDirection.N)]
    public void Rover_DropToPlateauHasExistsPlateauTest(int x, int y, EnumDirection direction)
    {
        Rover rover = new(); 
        rover.DropToPlateau(_plateau,x,y,direction); 

        Assert.True(_plateau.GetRovers().Any(x=>x==rover));
    }
    
    [Test]
    [TestCase(1, 2, EnumDirection.N)]
    public void Rover_DropToPlateauCurrentCoordinateTest(int x, int y, EnumDirection direction)
    {
        Rover rover = new(); 
        rover.DropToPlateau(_plateau,x,y,direction); 

        Assert.True(rover.CurrentCoordinate.X==x && rover.CurrentCoordinate.Y==y && rover.CurrentCoordinate.Direction==direction);
    }
    
 
    
}