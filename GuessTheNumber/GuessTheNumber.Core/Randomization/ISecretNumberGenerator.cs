namespace GuessTheNumber.Core.Randomization;

public interface ISecretNumberGenerator
{
    int Generate(int min, int max);
}