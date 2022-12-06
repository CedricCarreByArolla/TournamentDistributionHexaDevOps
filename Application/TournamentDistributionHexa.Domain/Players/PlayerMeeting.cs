namespace TournamentDistributionHexa.Domain.Players
{
    public class PlayerMeeting
    {
        private readonly MeetingLine[] _meetingLines;
        public PlayerMeeting(int playerCount)
        {
            _meetingLines = new MeetingLine[playerCount];
            for (int i = 0; i < playerCount; i++)
            {
                _meetingLines[i] = new MeetingLine(playerCount);
            }
        }
        public int GetMeetingsNumber(int playerA, int playerB)
        {
            return _meetingLines[playerA].GetMeetingsNumber(playerB);
        }
        public void IncrementMeetingsNumber(int playerA, int playerB)
        {
            _meetingLines[playerA].IncrementMeetingsNumber(playerB);
        }
        public int GetMeetingsMaximumNumber(int playerA, List<int> teamMembers)
        {
            return _meetingLines[playerA].GetMeetingsMaximumNumber(playerA, teamMembers);
        }
    }
}
