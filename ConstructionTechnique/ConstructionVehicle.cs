using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionFleet;

/// <summary>
/// Базовая строительная техника.
/// </summary>
public abstract class ConstructionVehicle
{
    private string _vin;//Приватное поле

    /// <summary>Модель техники.</summary>
    public string Model { get; set; }//автосвойство

    /// <summary>Мощность двигателя.</summary>
    public int EnginePower { get; set; }

    /// <summary>Вес техники.</summary>
    public int Weight { get; set; }

    /// <summary>Тип техники.</summary>
    public VehicleType Type { get; set; } = VehicleType.Excavator;//Свойство-перечисление

    /// <summary>
    /// Мощность на тонну веса.
    /// </summary>
    public double PowerPerTon => Weight > 0 ? (double)EnginePower / Weight : 0;//Вычисляемое

    /// <summary>
    /// Создаёт строительную технику с указанными параметрами.
    /// </summary>
    public ConstructionVehicle(string vin, string model, int power, int weight)//Конструкторы
    {
        _vin = vin;
        Model = model;
        EnginePower = power;
        Weight = weight;
    }

    /// <summary>
    /// Создаёт технику только с моделью, остальные параметры — по умолчанию.
    /// </summary>
    public ConstructionVehicle(string model) : this("N/A", model, 0, 0)
    {
    }

    /// <summary>
    /// Выполняет работу, специфичную для каждого типа техники.
    /// </summary>
    public abstract void Operate();//Абстрактный метод
}