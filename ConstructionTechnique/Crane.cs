using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionFleet;

/// <summary>
/// Кран — строительная техника, которая поднимает грузы.
/// </summary>
public class Crane : ConstructionVehicle, ILiftable
{
    /// <summary>Максимальная грузоподъёмность в тоннах.</summary>
    public int MaxLoad { get; set; }

    /// <summary>Признак тяжёлого крана (грузоподъёмность больше 30 тонн).</summary>
    public bool IsHeavyLifter => MaxLoad > 30;

    /// <summary>
    /// Создаёт кран с указанными параметрами.
    /// </summary>
    public Crane(string vin, string model, int power, int weight, int maxLoad)
        : base(vin, model, power, weight)
    {
        MaxLoad = maxLoad;
    }

    /// <summary>
    /// Создаёт кран только с моделью.
    /// </summary>
    public Crane(string model) : this("N/A", model, 0, 0, 0)
    {
    }

    /// <summary>
    /// Кран выполняет подъём.
    /// </summary>
    public override void Operate()
    {
        Console.WriteLine(Model + " lifts.");
    }

    /// <summary>
    /// Поднимает груз указанного веса.
    /// </summary>
    /// <param name="weight">Вес груза в тоннах.</param>
    public void Lift(int weight)
    {
        Console.WriteLine(Model + " lifted " + weight + " tons.");
    }

    /// <summary>
    /// Возвращает строковое представление крана.
    /// </summary>
    public override string ToString()
    {
        return $"[Crane] {Model}, max load={MaxLoad}, type: {Type}";
    }
}
