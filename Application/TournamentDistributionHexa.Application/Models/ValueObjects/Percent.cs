namespace TournamentDistributionHexa.Application.Models.ValueObjects;

public class Percent
{
    public Percent(double value)
    {
        if(value < 0 || value > 100)
        {
            throw new ArgumentException("Value must be between 0 and 100.");
        }
        Value = value;
    }

    public double Value { get; }
}
