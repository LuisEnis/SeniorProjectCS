using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeniorProjectCS.Models;
using SeniorProjectCS.ViewModels;

namespace SeniorProjectCS.Controllers
{
    public class EmployeeController : Controller
    {
        private StoreContext _context;

        public EmployeeController()
        {
            _context = new StoreContext();
        }
        public ActionResult RegisterNewEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterNewEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
                return View("RegisterNewEmployee", employee);

            if (_context.Employees.Where(e => e.Username == employee.Username).Any())
            {
                ModelState.AddModelError("Email", "A user with this username already exists.");
                return View("RegisterNewEmployee", employee);
            }

            if (_context.Employees.Where(e => e.Email == employee.Email).Any())
            {
                ModelState.AddModelError("Email", "A user with this email already exists.");
                return View("RegisterNewEmployee", employee);
            }

            _context.Employees.Add(employee);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var employee = _context.Employees.SingleOrDefault(e => e.Id == id);

            if (employee == null)
                return HttpNotFound();

            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginFormViewModel employee)
        {
            if (!ModelState.IsValid)
                return View("Login", employee);

            var loggedInEmployee = _context.Employees.Where(e => e.Username == employee.Username && e.Password == employee.Password).FirstOrDefault();

            if (loggedInEmployee == null)
            {
                ModelState.AddModelError("Password", "Incorect data provided.");
                return View("Login", employee);
            }
            else
            {
                Session["Username"] = loggedInEmployee.Username;
                Session["Role"] = loggedInEmployee.Role;
                return RedirectToAction("index", "Product");
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();

            base.Dispose(disposing);
        }
    }
}