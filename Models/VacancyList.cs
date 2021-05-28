using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vacancy.Models
{
    public class VacancyList
    {
        public int id { get; set; }
        public string name { get; set; } // Заголовок
        public int salary { get; set; } // Оклад
        public string organization { get; set; } // Организация
        public string contact_person { get; set; } // Контактное лицо
        public string phone_number { get; set; } // Телефон
       // public string empl_type_id { get; set; } // тип занятости
        public string empl_type { get; set; } // Тип занятости
        public string description { get; set; } // Описание вакансии
    }
}
