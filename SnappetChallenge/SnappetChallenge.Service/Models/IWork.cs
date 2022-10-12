namespace SnappetChallenge.Service.Models
{
    public interface IWork
    {
        int SubmittedAnswerId { get; set; }

        DateTime SubmitDateTime { get; set; }

        bool Correct { get; set; }

        int UserId { get; set; }

        int ExerciseId { get; set; }

        string Difficulty { get; set; }

        string Subject { get; set; }

        string Domain { get; set; }

        string LearningObjective { get; set; }

        int Progress { get; set; }
    }
}