using FeedbackModel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FeedbackModel.Domain.Repositories
{
    public class FeedbackRepository
    {
       
        public static List<Feedback> _feedbacks = new List<Feedback>
        {
            new Feedback { Id = 1, StudentName = "Lobo", Course = "Math", Rating = 4, DateSubmitted = DateTime.Now, Feedbacks = "Good" },
            new Feedback { Id = 2, StudentName = "Leonard", Course = "Social Studies", Rating = 4, DateSubmitted = DateTime.Now, Feedbacks = "Great" }
        };
       
        public List<Feedback> GetAll()
        {
            return _feedbacks;
        }

        public Feedback GetById(int id)
        {
            return _feedbacks.FirstOrDefault(f => f.Id == id);
        }

        public void Add(Feedback feedback)
        {
            feedback.Id = _feedbacks.Count > 0 ? _feedbacks.Max(f => f.Id) + 1 : 1;
            feedback.DateSubmitted = DateTime.Now;
            _feedbacks.Add(feedback);

            
            Console.WriteLine("All Feedbacks after add:");
            foreach (var f in _feedbacks)
            {
                Console.WriteLine($"{f.StudentName} - {f.Course}");
            }
        }

        public void Update(Feedback feedback)
        {
            var existingFeedback = _feedbacks.FirstOrDefault(f => f.Id == feedback.Id);
            if (existingFeedback != null)
            {
                existingFeedback.StudentName = feedback.StudentName;
                existingFeedback.Course = feedback.Course;
                existingFeedback.Rating = feedback.Rating;
                existingFeedback.Feedbacks= feedback.Feedbacks;
            }
        }

        
        public void Delete(int id)
        {
            var feedback = _feedbacks.FirstOrDefault(f => f.Id == id);
            if (feedback != null)
            {
                _feedbacks.Remove(feedback);
            }
        }
    }
}
