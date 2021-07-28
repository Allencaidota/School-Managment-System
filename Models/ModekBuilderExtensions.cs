using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagmen.Models
{
    public static class ModekBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "Allen",
                    ClassName = ClassNameEnum.FirstGrade,
                    Email = "allenaciadota@gmail.com"
                },
                new Student
                {
                    Id = 2,
                    Name = "JoJo",
                    ClassName = ClassNameEnum.ThridGrade,
                    Email = "Lichyuki@gmail.com"
                }
                );
        }
    }
}
