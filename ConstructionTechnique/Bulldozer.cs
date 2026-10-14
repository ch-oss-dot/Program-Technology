using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionTechnique;

/// <summary>
/// Бульдозер — строительная техника, которая разравнивает и поднимает грунт.
/// </summary>
public class Bulldozer : ConstructionVehicle, ILiftable
{
    /// <summary>Ширина отвала в метрах.</summary>
    public int BladeWidth { get; set; }

    /// <summary>Признак широкого отвала (шире 3 метров).</summary>
    public bool IsWide => BladeWidth > 3;

    /// <summary>
    /// Создаёт бульдозер с указанными параметрами.
    /// </summary>
    public Bulldozer(string vin, string model, int power, int weight, int bladeWidth)
        : base(vin, model, power, weight)
    {
        BladeWidth = bladeWidth;
    }

    /// <summary>
    /// Создаёт бульдозер только с моделью.
    /// </summary>
    public Bulldozer(string model) : this("N/A", model, 0, 0, 0)
    {
    }

    /// <summary>
    /// Бульдозер выполняет работу.
    /// </summary>
    public override void Operate()
    {
        Console.WriteLine(Model + " pushes the ground.");
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
    /// Возвращает строковое представление бульдозера.
    /// </summary>
    public override string ToString()
    {
        return $"[Bulldozer] {Model}, blade width={BladeWidth}, type: {Type}";
    }
}