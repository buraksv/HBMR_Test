using HepsiburadaMarsRover.Entity;

namespace HepsiburadaMarsRover.Business.Utilities;

public static class Extensions
{
    public static List<Rover> Run(this List<Input> roverList)
    {
        List<Rover> returnList = new();

        foreach (var item in roverList)
        {
            Rover rover = new();

            rover.Relocation(item.Coordinates.X,item.Coordinates.Y,item.Coordinates.Direction);

            foreach (var command in item.Directions)
            {
                rover.Command(command);
            }

            returnList.Add(rover);

        }

        return returnList;
    }

    public static string Run(this Input input,IPlateau plateau)
    {

        Rover rover = new();
        
        rover.DropToPlateau(plateau,input.Coordinates.X,input.Coordinates.Y,input.Coordinates.Direction);
 

        foreach (var command in input.Directions)
        {
            rover.Command(command);
        }

        return $"{rover}"; 
    }
 
}