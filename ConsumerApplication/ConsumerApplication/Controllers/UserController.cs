using ConsumerApplication.Models;
using ConsumerApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService service)
        {
            _userService = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserDTO userDTO)
        {
            try
            {
                UserDTO user = _userService.Register(userDTO);
                if(user!=null)
                {
                    TempData["token"] = user.jwtToken;
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {

                return View();
            }
            ViewBag.Error = "Not Registered";
            return View();
        }

        public ActionResult Login(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserDTO userDTO)
        {
            try
            {
                UserDTO user = _userService.Login(userDTO);
                if (user != null)
                {
                    TempData["token"] = user.jwtToken;
                    return RedirectToAction("GetAll", "Employee");
                }
            }
            catch
            {
                return View();
            }
            ViewBag.Error = "Invalid Username or Password";
            return View();
        }
    }
}
