using FeedbackModel.Domain.Entities;
using FeedbackModel.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackModel.Web.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly FeedbackRepository _repository;

        public FeedbackController(FeedbackRepository repository)
        {
            _repository = repository;
        }

        // action for index
        public IActionResult Index()
        {
            var feedbacks = _repository.GetAll(); 
            return View(feedbacks);
        }

        //create GET
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Feedback feedback)
        {
            
            Console.WriteLine($"Received Feedback: {feedback.StudentName}, {feedback.Course}, {feedback.Rating}");

            if (ModelState.IsValid)
            {
                _repository.Add(feedback);
                return RedirectToAction(nameof(Index));
            }

            
            Console.WriteLine("Model state is invalid.");
            return View(feedback);
        }


        //edit GET
        public IActionResult Edit(int id)
        {
            var feedback = _repository.GetById(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return View(feedback);
        }

        //POST edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Feedback feedback)
        {
            if (id != feedback.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repository.Update(feedback);
                return RedirectToAction(nameof(Index));
            }
            return View(feedback);
        }

        //delete GET
        public IActionResult Delete(int id)
        {
            var feedback = _repository.GetById(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return View(feedback);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
