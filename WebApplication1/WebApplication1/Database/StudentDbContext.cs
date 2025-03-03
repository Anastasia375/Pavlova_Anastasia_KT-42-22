using Microsoft.EntityFrameworkCore;
using Pavlova_Anastasia_KT_42_22.Controllers;
using Pavlova_Anastasia_KT_42_22.Database.Configurations;
using Pavlova_Anastasia_KT_42_22.Models;

namespace Pavlova_Anastasia_KT_42_22
{
    public class StudentDbcontext : DbContext
    {
        //Добавляем таблицы
        DbSet<Student> Students { get; set; }
        DbSet<Group> Groups { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Добавляем конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
        }
        public StudentDbcontext(DbContextOptions<StudentDbcontext> options)
        {
           
        }
    }
}
