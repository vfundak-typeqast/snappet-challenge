using SnappetChallenge.Service.Services;

namespace SnappetChallenge.Service.Common.Factories
{
    public static class WorkServiceFactory
    {
        public static IWorkService CreateWorkService()
        {
            return new WorkService();
        }
    }
}