using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vacancy.Models;

namespace Vacancy.Controllers
{
    public class HomeController : Controller
    {
        private VacancyApplContext db;
        public HomeController(VacancyApplContext context)
        {
            db = context;

            // добавим начальные данные для тестирования
            if (db.VacancyLists.Count() == 0)
            {
                VacancyList vac1 = new VacancyList { name = "Фельдшер", salary = 100000, organization = "ООО Сервисная Медицинская Компания", contact_person = "ООО Сервисная Медицинская Компания", phone_number = "8894455", empl_type = "Полная занятость", description = "Проведение предрейсовых и послерейсовых медосмотров водителей, оказание первой доврачебной помощи, контроль санитарного состояния на объектах. Ведение журналов, составление отчетов. Бракераж в столовых."  };
                VacancyList vac2 = new VacancyList { name = "Администратор медицинского центра", salary = 65000, organization = "ООО Ульфар", contact_person = "ООО Ульфар", phone_number = "856555", empl_type = "Полная занятость", description = "В связи с открытием в Уфе нового Медицинского центра открыт набор на вакансию: Начинающий косметолог." } ;
                VacancyList vac3 = new VacancyList { name = "Фармацевт-провизор", salary = 35000, organization = "ООО Триумф Арт", contact_person = "ООО Триумф Арт", phone_number = "2244545", empl_type = "Полная занятость", description = "работа в дружном, профессиональном коллективе" } ;
                db.VacancyLists.AddRange(vac1, vac2, vac3);
                db.SaveChanges();
            }
        }

       /* public async Task<IActionResult> Index()
        {
            return View(await db.VacancyLists.ToListAsync());
        }
        */
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(VacancyList vacancyList)
        {
            db.VacancyLists.Add(vacancyList);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                VacancyList VacancyList = await db.VacancyLists.FirstOrDefaultAsync(p => p.id == id);
                if (VacancyList != null)
                    return View(VacancyList);
            }
            return NotFound();
        }

        public async Task<IActionResult> Index(string search_text)
        {
            var vacans = from v in db.VacancyLists
                        // where ((v.name==search_text) | (v.organization == search_text) | (v.empl_type == search_text))                    
                         select v;
            if (!string.IsNullOrEmpty(search_text))
            {
                vacans = vacans.Where(x => (x.name.Contains(search_text))| (x.organization.Contains(search_text)) | (x.empl_type.Contains(search_text)));
            }

            return View(await vacans.ToListAsync());
        }

    }
}
