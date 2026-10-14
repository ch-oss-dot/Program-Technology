using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionTechnique;

/// <summary>
/// Интерфейс для техники, которая умеет поднимать грузы
/// </summary>
public interface ILiftable
{
    void Lift(int weight);
}
