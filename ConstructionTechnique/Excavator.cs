using System;
using System.Collections.Generic;
using System.Text;
using ConstructionTechnique;

namespace ConstructionTechnique;

/// <summary>
/// Экскаватор — строительная техника, которая копает.
/// </summary>
public class Excavator : ConstructionVehicle
{
    /// <summary>Объём ковша в кубометрах.</summary>
    public int BucketVolume { get; set; }

    /// <summary>Признак большого ковша (больше 2 кубометров).</summary>
    public bool IsBigBucket => BucketVolume > 2;

    /// <summary>
    /// Создаёт экскаватор с указанными параметрами.
    /// </summary>
    public Excavator(string vin, string model, int power, int weight, int bucketVolume)
        : base(vin, model, power, weight)
    {
        BucketVolume = bucketVolume;
    }

    /// <summary>
    /// Создаёт экскаватор только с моделью.
    /// </summary>
    public Excavator(string model) : this("нет данных", model, 0, 0, 0)
    {
    }

    /// <summary>
    /// Экскаватор копает.
    /// </summary>
    public override void Operate()
    {
        Console.WriteLine(Model + " digs.");
    }

    /// <summary>
    /// Возвращает строковое представление экскаватора.
    /// </summary>
    public override string ToString()
    {
        return $"[Excavator] {Model}, power={EnginePower}, weight={Weight}, type: {Type}";
    }
}