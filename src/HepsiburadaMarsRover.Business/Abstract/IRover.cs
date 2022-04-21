using HepsiburadaMarsRover.Entity;

namespace HepsiburadaMarsRover.Business;

public interface IRover
{
    void Relocation(int x, int y, EnumDirection direction);
    void TurnLeft();
    void TurnRight();
    void Move();
    void Command(char command);
    void Reset();
    void DropToPlateau(IPlateau plateau,int x=0, int y=0, EnumDirection direction=EnumDirection.N);
    IPlateau GetPlateau(); 
}