using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeHubPortal.Web.Controllers
{
    [Authorize (Roles ="admin")]//asks to auth for all actions 
    public class CatagoryController : Controller
    {
        
        //CatagoryRepository catagoryRepository = new CatagoryRepository();
        private ICatagoryRepository _repository;


        public CatagoryController(ICatagoryRepository repository)
        {
            this._repository = repository;
        }

        //[AllowAnonymous]//this excluds the auth 
        // .../catagory/index
        [ResponseCache(Duration = 60, Location =ResponseCacheLocation.Any)]
        [Authorize]
        public async Task<IActionResult> Index(int? page)
        {
            
            // Fetch the data from model

            //CatagoryRepository catagoryRepository = new CatagoryRepository();

            //var catagories = _repository.GetAll();

            //List<Catagory> catagories = new List<Catagory>()
            //{
            //    new Catagory{Id=111, Name = "Sports", Description="Sports related articles" },
            //    new Catagory{Id=222, Name = "Education", Description="Education related articles" },
            //    new Catagory{Id=333, Name = ".Net", Description=".Net related articles" },
            //    new Catagory{Id=444, Name = "MVC", Description="MVC related articles" },
            //    new Catagory{Id=555, Name = "AI", Description="AI related articles" }
            //};

            // pass the data to view

            //int pageSize = 5;
            //int pageNumber = page ?? 1;

            var categories = _repository.GetAllAsync().Result;//.Result.OrderBy(c => c.Name);

            //var pagedList = categories.ToPagedList(pageNumber, pageSize);

            return View(categories);
        }
        // .../catagory/create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Catagory catagory)
        {
            // collect the data from ui
            // validate
            if (!ModelState.IsValid)
            {
                return View();
            }
            // pass to backend
            await _repository.SaveAsync(catagory);
            // return a view
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);

            TempData["MSG"] = $"Category {id} successfully deleted";


            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            // fetch the all data based on id
            Catagory category = await _repository.GetByIdAsync(id);
            // return edit view
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Catagory catagory)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _repository.EditAsync(catagory);
            TempData["MSG"] = $"Category {catagory.Id} successfully updated";
            return RedirectToAction("Index");
        }
    }
}