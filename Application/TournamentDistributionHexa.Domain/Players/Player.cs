namespace TournamentDistributionHexa.Domain.Players;

public record Player
{
    public Player(PlayerId id, string firstname, string lastname, string telephone)
    {
        PlayerId = id;
        Firstname = firstname;
        Lastname = lastname;
        Telephone = telephone;
    }
    public PlayerId PlayerId { get; }
    public string Firstname { get; }
    public string Lastname { get; }
    public string Telephone { get; }
}