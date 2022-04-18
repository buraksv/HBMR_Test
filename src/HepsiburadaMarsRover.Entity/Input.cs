namespace HepsiburadaMarsRover.Entity;

public class Input
{
    public Input(string location, string directions)
    {
        Location = location;
        Directions = directions;

        string[] roverCoordinates = Location.Split(' ');

        int.TryParse(roverCoordinates[0], out var roverCoordinateX);
        int.TryParse(roverCoordinates[1], out var roverCoordinateY);
        string roverCoordinateDirection = roverCoordinates[2];

        Coordinates=new(roverCoordinateX,roverCoordinateY,roverCoordinateDirection);
    }
         
    public string Location { get; }
    public string Directions { get; }
    public Coordinate Coordinates { get;  }
}