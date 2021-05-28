using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Vacancy.Models
{
    public class VacancyApplContext : DbContext
    {
        public DbSet<VacancyList> VacancyLists { get; set; }
        public VacancyApplContext(DbContextOptions<VacancyApplContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
