using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using UI.Models;

namespace UI.Controllers
{
    public class AddController : Controller
    {
        private readonly CarRepository _carRepository;
        private readonly UserRepository _userRepository;
        public AddController(IRepository<Car> carRepository, IRepository<User> userRepository)
        {
            _carRepository = (CarRepository)carRepository;
            _userRepository = (UserRepository)userRepository;
        }
        public IActionResult Add()
        {
            ViewBag.UserId = (int)TempData.Peek("UserId");
            return View(new Car());
        }
        [HttpPost]
        public IActionResult Add(Car car)
        {
            if (ModelState.IsValid)
            {
                _carRepository.Add(car);
                return View("Success");
            }
            else
            {
                ViewBag.Error = true;
                return View(car);
            }
        }
    }
}

