namespace TournamentDistributionHexa.Application.Models.Requests;

public record GetScoreResponse
{
    public GetScoreResponse(GetMatchResponse match, GetPlayerResponse player,GetGameResponse game, int points)
    {
        Match = match;
        Player = player;
        Points = points;
        Game = game;
    }
    public int Points { get; init; }
    public GetMatchResponse Match { get; init; }
    public GetPlayerResponse Player { get; init; }
    public GetGameResponse Game { get; init; }
}