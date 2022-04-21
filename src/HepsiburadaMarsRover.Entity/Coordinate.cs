namespace HepsiburadaMarsRover.Entity;

public class Coordinate
{
    public Coordinate(int x, int y, EnumDirection direction)
    {
        X = x;
        Y = y; 
        
        Direction = direction;
    }

    public int X { get; set; }
    public int Y { get; set; }
    public EnumDirection Direction { get; set; }

      
}