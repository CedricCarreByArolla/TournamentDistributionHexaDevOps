namespace TournamentDistributionHexa.Application.Configuration
{
    public class InvalidCommandException : Exception
    {
        public string? Details { get; }
        public InvalidCommandException(string message, string? details = null) : base(message)
        {
            this.Details = details;
        }
    }
}
