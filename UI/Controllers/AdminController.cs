using DAL;
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
    public class AdminController : Controller
    {
        private readonly UserRepository _userRepository;
        private readonly CarRepository _carRepository;
        public AdminController(IRepository<User> userRepository, IRepository<Car> carRepository)
        {
            _userRepository = (UserRepository)userRepository;
            _carRepository = (CarRepository)carRepository;
        }
        public IActionResult ProductDetails(int userId, int productId)
        {
            ProductDetails productDetails = _carRepository.GetProductsDetailedList(productId, userId);

            return View(productDetails);
        }
    }
}