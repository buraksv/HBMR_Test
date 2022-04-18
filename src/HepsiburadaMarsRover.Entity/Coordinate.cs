namespace HepsiburadaMarsRover.Entity;

public class Coordinate
{
    public Coordinate(int x, int y, string d)
    {
        X = x;
        Y = y;

        Enum.TryParse(d, out EnumDirection direction);

        Direction = direction;
    }

    public int X { get; set; }
    public int Y { get; set; }
    public EnumDirection Direction { get; set; }

      
}