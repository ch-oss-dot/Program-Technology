using System;

namespace GuessTheNumber.Core.Randomization;

public class RandomSecretNumberGenerator : ISecretNumberGenerator
{
    private readonly Random _random = new();
    public int Generate(int min, int max) => _random.Next(min, max + 1);
}