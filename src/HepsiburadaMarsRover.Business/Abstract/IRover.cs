using HepsiburadaMarsRover.Entity;

namespace HepsiburadaMarsRover.Business;

public interface IRover
{
    void Relocation(int x, int y, string direction);
    void TurnLeft();
    void TurnRight();
    void Move();
    void Command(char command);
    void Reset();
    void DropToPlateau(IPlateau plateau,int x=0, int y=0, string direction="N");
    IPlateau GetPlateau(); 
}