using SnappetChallenge.Service.Common;
using SnappetChallenge.Service.Common.Factories;
using SnappetChallenge.Service.Common.Filters;
using SnappetChallenge.Service.Models;

namespace SnappetChallenge.Service.Services
{
    public class WorkService : IWorkService
    {
        private const string _filePath = "SnappetChallenge.Service.Data.work.json";

        private readonly DateTime _currentDate = DateTime.Parse("2015-03-24 11:30:00");

        public async Task<IEnumerable<IWork>> FindDataAsync(IFilterParams filter)
        {
            var items = await JsonDataExtractor.LoadJsonData<Work>(_filePath);
            return OnFilterData(filter, items);
        }

        public async Task<int> GetTotalStudentCountAsync()
        {
            return (await FindDataAsync(null)).DistinctBy(p => p.UserId).Count();
        }

        public DateTime GetCurrentTime()
        {
            return _currentDate;
        }

        public Task<IEnumerable<IWork>> FindLastWeekWorkAsync()
        {
            var filter = FilterParamsFactory.CreateFilterParam();
            var currentDate = GetCurrentTime();
            filter.EndDate = currentDate;
            filter.StartDate = currentDate.AddDays(-6);
            return FindDataAsync(filter);
        }

        public async Task<IEnumerable<IWork>> GetTodaysWorkAsync()
        {
            var filter = FilterParamsFactory.CreateFilterParam();
            filter.StartDate = _currentDate.Date;
            filter.EndDate = _currentDate;
            var result = await FindDataAsync(filter);
            return result;
        }

        protected IEnumerable<IWork> OnFilterData(IFilterParams filter, IEnumerable<IWork> items)
        {
            if (filter is not null)
            {
                if (filter.StartDate.HasValue)
                {
                    items = items.Where(p => DateTime.Compare(p.SubmitDateTime, filter.StartDate.Value) >= 0).ToList();
                }

                if (filter.EndDate.HasValue)
                {
                    items = items.Where(p => DateTime.Compare(p.SubmitDateTime, filter.EndDate.Value) <= 0).ToList();
                }
            }

            return items;
        }
    }
}