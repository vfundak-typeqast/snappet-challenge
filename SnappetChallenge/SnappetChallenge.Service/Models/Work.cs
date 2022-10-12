﻿namespace SnappetChallenge.Service.Models
{
    public class Work : IWork
    {
        public int SubmittedAnswerId { get; set; }

        public DateTime SubmitDateTime { get; set; }

        public bool Correct { get; set; }

        public int UserId { get; set; }

        public int ExerciseId { get; set; }

        public string Difficulty { get; set; }

        public string Subject { get; set; }

        public string Domain { get; set; }

        public string LearningObjective { get; set; }

        public int Progress { get; set; }
    }
}