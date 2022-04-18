using HepsiburadaMarsRover.Entity;

namespace HepsiburadaMarsRover.Business;
 
public class Plateau : IPlateau
{

    private readonly List<IRover> _rovers=new();
    public Plateau(int x,int y)
    {
        CurrentDimension = new (x, y);
    }

    public Dimension CurrentDimension { get; } 

    public override string ToString() => $"{CurrentDimension.X}x{CurrentDimension.Y}";

    public void DropRover(IRover rover)
    {
        _rovers.Add(rover); 
    }

    public List<IRover>  GetRovers() => _rovers;
}