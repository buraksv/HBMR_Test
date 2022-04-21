using HepsiburadaMarsRover.Entity;

namespace HepsiburadaMarsRover.Business;

public class Rover : IRover
{
    private IPlateau _plateau; 
    public Coordinate CurrentCoordinate { get; private set; } 
    private void ControlBoundaries(IPlateau plateau, int x, int y, EnumDirection direction)
    {
        var control = x > plateau.CurrentDimension.X || y > plateau.CurrentDimension.Y || x<0 || y<0;
        if (control)
        {
            throw new ArgumentOutOfRangeException($"Rover outside the plateau.  Plateau current dimensions: {_plateau}");
        }
    }
    
    public void Command(char command)
    {
        switch (command)
        {
            case 'M':
                Move();
                break;
            case 'L':
                TurnLeft();
                break;
            case 'R':
                TurnRight(); 
                break;
            default:
                throw new ArgumentException($"Invalid Command"); 
        }
 
    }

    public void Reset()
    {
        CurrentCoordinate = new(0, 0, EnumDirection.N);
    }

    public void DropToPlateau(IPlateau plateau,int x=0, int y=0, EnumDirection direction=EnumDirection.N)
    {
        if (plateau == null) throw new ArgumentNullException(nameof(plateau));
        if (_plateau != null) throw new Exception("The rover already dropped a plateau");

        ControlBoundaries(plateau,x,y,direction);
        _plateau = plateau;
        _plateau.DropRover(this);
        CurrentCoordinate = new(x, y, direction);
    }

    public IPlateau GetPlateau() => _plateau;
 
    public void Move()
    {
        ControlPlateau();
        switch (CurrentCoordinate.Direction)
        {
            case EnumDirection.N:
                CurrentCoordinate.Y++;
                break;
            case EnumDirection.E:
                CurrentCoordinate.X++;
                break;
            case EnumDirection.S:
                CurrentCoordinate.Y--;
                break;
            case EnumDirection.W:
                CurrentCoordinate.X--;
                break;
        }

    }

    public void Relocation(int x, int y, EnumDirection direction)
    {
        ControlPlateau();
        CurrentCoordinate = new ( x,  y, direction); 
    }

    public void TurnLeft()
    {
        ControlPlateau();
        var currentPosition =  CurrentCoordinate.Direction;

        currentPosition--;
        if (currentPosition <  EnumDirection.N)
            currentPosition =  EnumDirection.W;

        CurrentCoordinate.Direction = currentPosition;

    }

    public void TurnRight()
    {
        ControlPlateau();
        var currentPosition = CurrentCoordinate.Direction;

        currentPosition++;
        if (currentPosition >  EnumDirection.W)
            currentPosition =  EnumDirection.N;

        CurrentCoordinate.Direction = currentPosition;

    }

    public override string ToString()
    {
        string returnCoordinates = $"{CurrentCoordinate.X} {CurrentCoordinate.Y} {CurrentCoordinate.Direction}";
  
        return returnCoordinates;
    }
 
    private void ControlPlateau()
    {
        if (_plateau == null) throw new Exception("Rover not dropped any pleteau");

    }
}