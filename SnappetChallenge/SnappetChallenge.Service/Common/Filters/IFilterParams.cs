namespace SnappetChallenge.Service.Common.Filters
{
    public interface IFilterParams
    {
        DateTime? StartDate { get; set; }

        DateTime? EndDate { get; set; }
    }
}