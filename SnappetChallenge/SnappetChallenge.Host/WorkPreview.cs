using SnappetChallenge.Service;
using SnappetChallenge.Service.Common.Factories;
using SnappetChallenge.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.Host
{
    internal class WorkPreview
    {
        public static async Task GetTodayWorkReportAsync()
        {
            IDailyWorkReport dailyWorkReport = DailyWorkReportFactory.CreateDailyWorkReport();

            await dailyWorkReport.GetTodaysWorkListAsync();
        }
    }
}