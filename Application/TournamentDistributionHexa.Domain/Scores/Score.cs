namespace TournamentDistributionHexa.Domain.Scores;

public class Score
{
    public Score()
    {

    }
    public Score(ScoreId scoreId, int points)
    {
        ScoreId = scoreId;
        Points = points;
    }
    public ScoreId ScoreId { get; }
    public int Points { get; set; }

}
