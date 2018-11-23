using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Controllers
{
    public class LogInController : Controller
    {
        private readonly UserRepository _userRepository;
        private readonly CarRepository _carRepository;
        public LogInController(IRepository<User> userRepository,IRepository<Car> carRepository)
        {
            _userRepository = (UserRepository)userRepository;
            _carRepository = (CarRepository)carRepository;
        }
        public IActionResult LogIn()
        {
            return View(new LogInViewModel());
        }

        [HttpPost]
        public IActionResult LogIn(LogInViewModel model)
        {
            if (ModelState.IsValid)
            {
                int userId = -1;
                bool isAdmin = false;
                if (_userRepository.ValidateUser(model.Username, model.Password, out isAdmin, out userId))
                {
                    if (isAdmin)
                    {
                        List<Car> cars = _carRepository.GetItems().ToList();
                        List<AdminPageModel> models = new List<AdminPageModel>();
                        foreach (Car car in cars)
                        {
                            models.Add(new AdminPageModel
                            {
                                Mark = car.Mark,
                                CarModel = car.CarModel,
                                UserID = car.UserID,
                                ProductID = car.ID
                            });
                        }
                        return View("AdminPage",models);
                    }
                    else
                    {
                        TempData["UserId"] = userId;
                        return RedirectToAction("Add", "Add");
                    }
                }
            }
            return View();
        }
    }
}
