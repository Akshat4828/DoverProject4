using DemoProjectLearn.LoginAndRegisterModel;
using DemoProjectLearn.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProjectLearn.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(LoginModel admin)
        {
            if(admin.UserName=="Admin" && admin.Password == "Admin")
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.msg = "Invalid Credientials";
            }

            return View();
        }
       


    }
}
