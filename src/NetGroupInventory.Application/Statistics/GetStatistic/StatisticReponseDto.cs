namespace NetGroupInventory.Application.Statistics.GetStatistic
{
    public class StatisticReponseDto
    {
        public IList<UserStatisticDto> UserStatistics { get; set; }

        public IList<LastActiveUser> LastActiveUsers { get; set; }
    }
}
