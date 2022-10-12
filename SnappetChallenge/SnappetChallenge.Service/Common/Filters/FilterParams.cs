namespace SnappetChallenge.Service.Common.Filters
{
    public class FilterParams : IFilterParams
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}