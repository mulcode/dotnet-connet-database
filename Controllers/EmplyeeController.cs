using Microsoft.AspNetCore.Mvc;
using EmployeeData.Models;
using EmployeeData.DataAccessLayer;

namespace EmployeeData
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IActionResult EmployeeInfo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            EmployeeDataAccess dataAccess = new EmployeeDataAccess();

            dataAccess.Insert(employee);

            return View();
        }

        [HttpGet]
        public IActionResult ShowAllEmployees()
        {
            EmployeeDataAccess dataAccess = new EmployeeDataAccess();
            List<Employee> employees = dataAccess.GetEmployees();

            return View(employees);
        }
        [HttpGet]
        public IActionResult ShowProduct()
        {
            ProductDataAccess dataAccess = new ProductDataAccess();
            List<Product> products = dataAccess.GetProducts();

            return View(products);
        }

    }
}