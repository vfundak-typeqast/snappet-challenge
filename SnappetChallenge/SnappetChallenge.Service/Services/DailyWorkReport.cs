using SnappetChallenge.Service.Common.Factories;
using SnappetChallenge.Service.Models;
using SnappetChallenge.Service.Services;

namespace SnappetChallenge.Service
{
    public class DailyWorkReport : IDailyWorkReport
    {
        public DailyWorkReport()
        {
            _workService ??= WorkServiceFactory.CreateWorkService();
        }

        private readonly IWorkService _workService;

        public async Task GetTodaysWorkListAsync()
        {
            var currentDate = _workService.GetCurrentTime();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"------------------Daily Report for {currentDate.Date:dddd, dd MMMM yyyy}------------------");

            var items = await _workService.GetTodaysWorkAsync();
            var lastWeekWork = await _workService.FindLastWeekWorkAsync();
            await SetBasicInfoAsync(items);

            var groupedItemsPerSubject = items.GroupBy(x => x.Subject);

            foreach (var subject in groupedItemsPerSubject)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("\tSubject: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(subject.Key);
                var groupedByLearningObjectiveItems = subject.GroupBy(p => p.LearningObjective);

                foreach (var item in groupedByLearningObjectiveItems)
                {
                    var lastWeekItems = lastWeekWork.Where(p => string.Equals(subject.Key, p.Subject) && string.Equals(item.Key, p.LearningObjective) && p.Progress != 0).ToList();

                    var lastWeekProgressAverage = lastWeekItems.Sum(p => p.Progress) / lastWeekItems.Count;
                    var todayProgressAverage = item.Sum(p => p.Progress) / item.Where(p => p.Progress != 0).ToList().Count;

                    var averageProgress = (todayProgressAverage + lastWeekProgressAverage) / 2;

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\t\tLearning objective: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(item.Key);

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\t\tAverage progress based on last 7 days and Today: ");
                    Console.ForegroundColor = averageProgress < 0 ? ConsoleColor.Red : averageProgress > 0 ? ConsoleColor.Green : ConsoleColor.White;
                    Console.WriteLine($"{averageProgress}");
                }
            }

            Console.ReadLine();
        }

        private async Task SetBasicInfoAsync(IEnumerable<IWork> items)
        {
            int studentCount = await _workService.GetTotalStudentCountAsync();
            var currentStudents = items.DistinctBy(p => p.UserId);
            var currentStudentCount = currentStudents.Count();

            var progressStudentsOrder = currentStudents.OrderBy(p => p.Progress);
            var maxProgressStudent = progressStudentsOrder.Last();
            var minProgressStudent = progressStudentsOrder.First();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nMissing students: \t");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{studentCount - currentStudentCount}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nExceptional Progress:");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"\t Max: {maxProgressStudent.Progress}");
            Console.Write($"\t UserId: {maxProgressStudent.UserId}");
            Console.WriteLine($"\t Learning objective: {maxProgressStudent.LearningObjective}");

            Console.Write($"\t Min: {minProgressStudent.Progress}");
            Console.Write($"\t UserId: {minProgressStudent.UserId}");
            Console.WriteLine($"\t Learning objective: {minProgressStudent.LearningObjective}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nList of subjects:");
        }
    }
}