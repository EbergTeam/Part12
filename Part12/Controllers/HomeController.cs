using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Part12.Models; // пространство имен моделей
using Part12.ModelsViews; // пространство имен моделей представлений
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Part12.Controllers
{
    public class HomeController : Controller
    {
        List<Phone> phones;
        List<Company> companies;
        public HomeController()
        {
            Company apple = new Company() { Id = 1, Name = "Apple", Country = "USA" };
            Company xiaomi = new Company() { Id = 2, Name = "Xiaomi", Country = "China" };
            Company google = new Company() { Id = 3, Name = "Google", Country = "USA" };
            companies = new List<Company> { apple, xiaomi, google};

            phones = new List<Phone>()
            {
                new Phone { Id = 1, Name = "IPhone 5", Manufacturer = apple, Price = 3500},
                new Phone { Id = 2, Name = "IPhone 6", Manufacturer = apple, Price = 4500},
                new Phone { Id = 3, Name = "Redmi note 4", Manufacturer = xiaomi, Price = 2000},
                new Phone { Id = 4, Name = "Phone 3", Manufacturer = google, Price = 5000},
            };
        }
        
        public IActionResult Index(int? companyId)
        {
            // формируем список компаний для передачи в представление
            List<CompanyModels> compModels = companies
                .Select(s => new CompanyModels() { Id = s.Id, Name = s.Name })
                .ToList();
            // добавляем на первое место "Все"
            compModels.Insert(0, new CompanyModels() { Id = 0, Name = "Все" });

            IndexViewModel ivm = new() { Phones = phones, Companies = compModels };

            // если передан id компании, фильтруем список
            if (companyId != null && companyId > 0)
                ivm.Phones = phones.Where(w => w.Manufacturer.Id == companyId);

            return View(ivm);
        }
        [HttpGet]
        public IActionResult AddPhone()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPhone(Phone[] phones)
        {
            string result = "";
            foreach (var p in phones)
                result = $"{result}{p.Name} - {p.Price} - {p.Manufacturer?.Name} \n";
            return Content(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
