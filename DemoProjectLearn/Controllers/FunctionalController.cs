using DemoProjectLearn.LoginAndRegisterModel;
using DemoProjectLearn.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProjectLearn.Controllers
{
    public class FunctionalController : Controller
    {
        private readonly AppDBContext _context;
        public FunctionalController(AppDBContext context)
        {
            _context = context;

        }
        public IActionResult Index(string name)
        {
            ViewBag.msg = "Welcome, " +  (name);
            return View(_context.pizzas);
        }
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel c)
        {
            var customer = _context.customers.Single(x => x.Email == c.UserName);
            if (c.Password == customer.Password)
            {
                return RedirectToAction("Index" ,new {name = customer.CName });
            }
            else
                ViewBag.msg = "Invalid Credentials";

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CName,Email,Mobile_No,Address,Password")] CustomerModel customerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            return View(customerModel);
        }
        public ActionResult PizzaDetails(int id)
        {
            var laptop = _context.pizzas.Single(x => x.Id == id);
            return View(laptop);
        }
        public IActionResult Payment(int id)
        {
            ViewBag.id = id;
            return View();
        }
       
        public async Task<IActionResult> Order(int id)
        {
            PizzaModel pizza = new PizzaModel();
            foreach (var piz in _context.pizzas.ToList())
            {
                if (piz.Id == id)
                {
                    pizza = piz;
                    break;
                }
            }
            CustomerModel c = new CustomerModel();
            return View(pizza);
        }
    }
}
