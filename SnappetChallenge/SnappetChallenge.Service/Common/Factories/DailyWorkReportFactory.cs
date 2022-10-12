using SnappetChallenge.Service.Services;

namespace SnappetChallenge.Service.Common.Factories
{
    public static class DailyWorkReportFactory
    {
        public static IDailyWorkReport CreateDailyWorkReport()
        {
            return new DailyWorkReport();
        }
    }
}