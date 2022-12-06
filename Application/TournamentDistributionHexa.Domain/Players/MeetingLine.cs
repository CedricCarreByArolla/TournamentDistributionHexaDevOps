using System.Diagnostics;
using System.Text;

namespace TournamentDistributionHexa.Domain.Players
{
    [DebuggerDisplay("{DebugText}")]
    public class MeetingLine
    {
        private readonly int[] _meetingsValue;
        public MeetingLine(int playerCount)
        {
            _meetingsValue = new int[playerCount];
        }
        public int GetMeetingsNumber(int player)
        {
            return _meetingsValue[player];
        }
        public void IncrementMeetingsNumber(int player)
        {
            _meetingsValue[player]++;
        }
        public int GetMeetingsMaximumNumber(int currentPlayer, List<int> teamMembers)
        {
            int currentMaximumValue = int.MinValue;
            for (int i = 0; i < _meetingsValue.Count(); i++)
            {
                if (teamMembers.Contains(i))
                {
                    int maximum = _meetingsValue[i];
                    if (currentMaximumValue < maximum && currentPlayer != i)
                    {
                        currentMaximumValue = maximum;
                    }
                }
            }
            return currentMaximumValue;
        }
        private string DebugText
        {
            get
            {
                return MeetingLineToString();
            }
        }
        public override string ToString()
        {
            return MeetingLineToString();
        }
        private string MeetingLineToString()
        {
            StringBuilder result = new StringBuilder();
            for (int j = 0; j < _meetingsValue.Length; j++)
            {
                result.Append($"{j}  [{_meetingsValue[j],2}]  ");
            }
            return result.ToString();
        }
    }
}
