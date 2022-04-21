using System;
using HepsiburadaMarsRover.Business;
using HepsiburadaMarsRover.Business.Utilities;
using HepsiburadaMarsRover.Entity;
using NUnit.Framework;

namespace HepsiburadaMarsRover.Test;

public class UtilityTest
{
    [SetUp]
    public void Setup()
    {
    }

     
    [Test]
    [TestCase(5,5, "3 3 E", "MMRMMRMRRM", "5 1 E")]
    [TestCase(5,5, "1 2 N", "LMLMLMLMM", "1 3 N")]
    public void Rover_RunTest(int plateauDimensionX,int plateauDimensionY, string location,string directions,string output)
    {
        IPlateau plateau = new Plateau(plateauDimensionX, plateauDimensionY);  
        Input input = new (location,directions);
       
        Assert.True(input.Run(plateau)== output);
    } 
    
}