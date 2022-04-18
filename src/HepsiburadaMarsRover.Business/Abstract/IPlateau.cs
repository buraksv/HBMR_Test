using HepsiburadaMarsRover.Entity;

namespace HepsiburadaMarsRover.Business;

public interface IPlateau
{
    Dimension CurrentDimension { get; }
    void DropRover(IRover rover);
    List<IRover> GetRovers();
}