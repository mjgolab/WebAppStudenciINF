namespace WebAppStudenciINF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using WebAppStudenciINF.Models;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAppStudenciINF.Models.WebAppStudenciINFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebAppStudenciINF.Models.WebAppStudenciINFContext context)
        {
            //Wype�nienie bazy danych [LocalDB] przyk�adowymi danymi.
            context.Students.AddOrUpdate(x => x.ID,
                new Student()
                {
                    ID = 1,
                    Name = "Marcin",
                    LastName = "Go��biewski",
                    BirthDate = DateTime.Parse("1995-04-26"),
                    SID = "gax29279",
                    Course = "Informatyka",
                    GroupName = "INF_ITO",
                    Specialty = "In�ynieria Test�w Oprogramowania"
                },
                new Student()
                {
                    ID = 2,
                    Name = "Tomasz",
                    LastName = "Kowalski",
                    BirthDate = DateTime.Parse("1994-02-10"),
                    SID = "gaT12389",
                    Course = "Informatyka",
                    GroupName = "INF_BSK",
                    Specialty = "Bezpiecze�stwo Sieci Komputerowych"
                }
                );
        }
    }
}
