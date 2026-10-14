namespace ConstructionTechnique;

internal class Program
{
    static void Main()
    {
        List<ConstructionVehicle> fleet = new List<ConstructionVehicle>();//полиморфизм

        fleet.Add(new Excavator("VIN001", "CAT 320", 150, 20, 2));
        fleet.Add(new Crane("VIN002", "Liebherr", 200, 50, 50));
        fleet.Add(new Bulldozer("VIN003", "Komatsu D65", 180, 25, 4));

        foreach (ConstructionVehicle vehicle in fleet)//полиморфный цикл
        {
            Console.WriteLine(vehicle.ToString());
            Console.WriteLine("  power per ton: " + vehicle.PowerPerTon);
            vehicle.Operate();

            if (vehicle is ILiftable liftable)//проверка реализации
            {
                liftable.Lift(30);
            }
            else
            {
                Console.WriteLine(vehicle.Model + " cannot lift.");
            }

            Console.WriteLine("----------------------------------------");
        }
    }
}
