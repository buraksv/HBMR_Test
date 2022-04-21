using HepsiburadaMarsRover.Business;
using HepsiburadaMarsRover.Business.Utilities;
using HepsiburadaMarsRover.Entity;

if (args.Length > 0 && args[0] == "auto")
{
    int plateauX = 5, plateauY = 5;

    Plateau plateau = new (plateauX,plateauY);


    Console.WriteLine($"{plateauX} {plateauY}");
    Console.WriteLine(" ");
     
    var roverList = new List<Input>
    {
        new("1 2 N","LMLMLMLMM"),
        new("3 3 E","MMRMMRMRRM")
    };


    foreach (var item in roverList)
    {
        Console.WriteLine($"{item.Location}");
        Console.WriteLine($"{item.Directions}");
        Console.WriteLine(" ");
    }


    Console.WriteLine("OUTPUT");
    Console.WriteLine("======================");

    foreach (var item in roverList)
    { 
        Console.WriteLine(item.Run(plateau));
    }



}
else
{
    Console.WriteLine("Mars Yolculuğu Tamamlandı...");
    Thread.Sleep(1000);




    ConsoleKeyInfo cki;

    Plateau plateau = new (5, 5);
    Console.WriteLine($"Plateao Oluşturuldu. Plato Boyutları: {plateau.CurrentDimension.X}x{plateau.CurrentDimension.Y}");
    Thread.Sleep(1000);



    Rover rover = new();
    Console.WriteLine($"Rover Platoya İndirildi...");
    Thread.Sleep(500);
    Console.WriteLine("Roverın Yönünü Değiştirebilmek için Klavyenin \"Sağ\" ve \"Sol\" ok tuşlarını kullanabilirsiniz");
    Thread.Sleep(500);
    Console.WriteLine("Roverı hareket ettirebilmek için \"Yukarı\" ok tuşunu kullabilirsiniz...");
    Thread.Sleep(500);
    Console.WriteLine("Programdan Çıkmak için \"ESC\" tuşunu kullanabilirsiniz");
    Thread.Sleep(500);
    
    rover.DropToPlateau(plateau, 3, 3,EnumDirection.E);
    Console.WriteLine($"Rover Yeni lokasyonuna hareket ettirildi. Güncel Lokasyonu: {rover}");
    Thread.Sleep(500);
    Console.WriteLine("===============Şimdi hareket ettirebilirsiniz================");

    do
    {
        cki = Console.ReadKey();

        switch (cki.Key)
        {
            case ConsoleKey.LeftArrow:
                rover.TurnLeft();
                Console.WriteLine($"Rover Yönü 90 derece Sola döndürüldü. Güncel Lokasyonu: {rover}");
                break;
            case ConsoleKey.RightArrow:
                rover.TurnRight();
                Console.WriteLine($"Rover Yönü 90 derece Sağa döndürüldü. Güncel Lokasyonu: {rover}");

                break;
            case ConsoleKey.UpArrow:
                rover.Move();
                Console.WriteLine($"Rover Hareket Ettirildi. Güncel Lokasyonu: {rover}");

                break;
            default:
                break;
        }

    } while (cki.Key != ConsoleKey.Escape);
}