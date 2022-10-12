using SnappetChallenge.Service.Common.Filters;
using SnappetChallenge.Service.Models;

namespace SnappetChallenge.Service.Services
{
    public interface IWorkService
    {
        Task<IEnumerable<IWork>> FindDataAsync(IFilterParams filter);

        Task<IEnumerable<IWork>> GetTodaysWorkAsync();

        DateTime GetCurrentTime();

        Task<int> GetTotalStudentCountAsync();

        Task<IEnumerable<IWork>> FindLastWeekWorkAsync();
    }
}