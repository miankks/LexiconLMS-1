namespace Lexicon_LMS.Migrations
{
    using Lexicon_LMS.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Lexicon_LMS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Lexicon_LMS.Models.ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            foreach (string roleName in new[] { "Teacher", "Student" })
            {
                if (!context.Roles.Any(r => r.Name == roleName))
                {
                    var role = new IdentityRole { Name = roleName };
                    roleManager.Create(role);
                }

            }


            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var users = new List<ApplicationUser> {
                new ApplicationUser {FirstName = "Oscar", LastName = "Jakobsson", Email = "oscar.jakobsson@lexicon.se", UserName = "oscar.jakobsson@lexicon.se"},
                new ApplicationUser {FirstName = "Adrian", LastName = "Lozano", Email = "adrian.lozano@lexicon.se", UserName = "adrian.lozano@lexicon.se"},
                
            };

            var NewUserList = new List<ApplicationUser>();

            foreach (var u in users)
            {
                userManager.Create(u, "foobar");
                var user = userManager.FindByEmail(u.Email);
                NewUserList.Add(user);
                userManager.AddToRole(user.Id, "Teacher");
            }



            var groups = new List<Group> {
                new Group 
                {
                    GroupId = 1,
                    Name = ".NET utvecklare november 2015",
                    TeacherId = NewUserList[0].Id,
                    //Teacher = "Oscar Jakobsson",
                    Description = "Grunderna i C#. Det �r ett v�lk�nt faktum att l�sare distraheras av l�sbar "+
                    "text p� en sida n�r man skall studera layouten. Po�ngen med Lorem Ipsum �r att det ger ett "+
                    "normalt ordfl�de, till skillnad fr�n \"Text h�r, Text h�r\", och ger intryck av att vara l�sbar "+
                    "text. M�nga publiseringprogram och webbutvecklare anv�nder Lorem Ipsum som test-text, och en "+
                    "s�kning efter \"Lorem Ipsum\" avsl�jar m�nga webbsidor under uteckling. Olika versioner har dykt "+
                    "upp under �ren, ibland av olycksh�ndelse, ibland med flit (mer eller mindre humoristiska).",
                    StartDate = DateTime.ParseExact("2015-11-19", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-03-02", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Group
                { 
                    GroupId = 2,
                    Name = ".NET utvecklare mars 2016",
                    TeacherId = NewUserList[0].Id,
                    //Teacher = "Oscar Jakobsson",
                    Description = "Grundkurs i C#. Lorem Ipsum �r en utfyllnadstext fr�n tryck- och f�rlagsindustrin. "+
                    "Lorem ipsum har varit standard �nda sedan 1500-talet, n�r en ok�nd boks�ttare tog att antal "+
                    "bokst�ver och blandade dem f�r att g�ra ett provexemplar av en bok. Lorem ipsum har inte bara �verlevt "+
                    "fem �rhundraden, utan �ven �verg�ngen till elektronisk typografi utan st�rre f�r�ndringar. Det blev "+
                    "allm�nt k�nt p� 1960-talet i samband med lanseringen av Letraset-ark med avsnitt av Lorem Ipsum, "+
                    "och senare med mjukvaror som Aldus PageMaker.",
                    StartDate = DateTime.ParseExact("2016-03-21", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Group
                { 
                    GroupId = 3,
                    Name = ".NET utvecklare juni 2016",
                    //Teacher = "Oscar Jakobsson",
                    TeacherId = NewUserList[0].Id,
                    Description = "Hello world. Det finns m�nga olika varianter av Lorem Ipsum, men majoriteten "+
                    "av dessa har �ndrats p� n�gotvis. Antingen med inslag av humor, eller med inl�gg av ord "+
                    "som knappast ser trov�rdiga ut. Skall man anv�nda l�nga stycken av Lorem Ipsum b�r man "+
                    "f�rs�kra sig om att det inte g�mmer sig n�got pinsamt mitt i texten. Lorem Ipsum-generatorer "+
                    "p� internet tenderar att repetera Lorem Ipsum-texten styckvis efter behov, n�got som g�r "+
                    "denna sidan till den f�rsta riktiga Lorem Ipsum-generatorn p� internet. Den anv�nder ett "+
                    "ordf�rr�d p� �ver 200 ord, kombinerat med ett antal meningsbyggnadsstrukturer som tillsamman "+
                    "genererar Lorem Ipsum som ser ut som en normal mening. Lorem Ipsum genererad p� denna sidan "+
                    "�r d�rf�r alltid fri fr�n repetitioner, humorinslag, m�rkliga ordformationer osv.",
                StartDate = DateTime.ParseExact("2016-07-17", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-09-23", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Group
                { 
                    GroupId = 4,
                    Name = "Java Del 1",
                    //Teacher = "Adrian Lozano",
                    TeacherId = NewUserList[1].Id,
                    Description = "Grundkurs. Lorem Ipsum �r en utfyllnadstext fr�n tryck- och f�rlagsindustrin. "+
                    "Lorem ipsum har varit standard �nda sedan 1500-talet, n�r en ok�nd boks�ttare tog att antal "+
                    "bokst�ver och blandade dem f�r att g�ra ett provexemplar av en bok. Lorem ipsum har inte bara "+
                    "�verlevt fem �rhundraden, utan �ven �verg�ngen till elektronisk typografi utan st�rre f�r�ndringar. "+
                    "Det blev allm�nt k�nt p� 1960-talet i samband med lanseringen av Letraset-ark med avsnitt av Lorem Ipsum, "+
                    "och senare med mjukvaror som Aldus PageMaker.",
                    StartDate = DateTime.ParseExact("2015-11-04", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-02-17", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Group
                { 
                    GroupId = 5,
                    Name = "Java Del 2",
                    //Teacher = "Adrian Lozano",
                    TeacherId = NewUserList[1].Id,
                    Description = "Objektorienterad programmering. Det finns m�nga olika varianter av Lorem Ipsum, "+
                    "men majoriteten av dessa har �ndrats p� n�gotvis. Antingen med inslag av humor, eller med "+
                    "inl�gg av ord som knappast ser trov�rdiga ut. Skall man anv�nda l�nga stycken av Lorem Ipsum "+
                    "b�r man f�rs�kra sig om att det inte g�mmer sig n�got pinsamt mitt i texten. Lorem Ipsum-generatorer "+
                    "p� internet tenderar att repetera Lorem Ipsum-texten styckvis efter behov, n�got som g�r denna "+
                    "sidan till den f�rsta riktiga Lorem Ipsum-generatorn p� internet. Den anv�nder ett ordf�rr�d p� �ver "+
                    "200 ord, kombinerat med ett antal meningsbyggnadsstrukturer som tillsamman genererar Lorem Ipsum som "+
                    "ser ut som en normal mening. Lorem Ipsum genererad p� denna sidan �r d�rf�r alltid fri fr�n repetitioner, "+
                    "humorinslag, m�rkliga ordformationer osv.",
                    StartDate = DateTime.ParseExact("2016-03-14", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-05-28", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Group
                { 
                    GroupId = 6,
                    Name = "Java Del 3",
                    //Teacher = "Adrian Lozano",
                    TeacherId = NewUserList[1].Id,
                    Description = "Forts�ttningskurs. Lorem Ipsum �r en utfyllnadstext fr�n tryck- och f�rlagsindustrin. "+
                    "Lorem ipsum har varit standard �nda sedan 1500-talet, n�r en ok�nd boks�ttare tog att antal bokst�ver "+
                    "och blandade dem f�r att g�ra ett provexemplar av en bok. Lorem ipsum har inte bara �verlevt fem �rhundraden, "+
                    "utan �ven �verg�ngen till elektronisk typografi utan st�rre f�r�ndringar. Det blev allm�nt k�nt p� 1960-talet "+
                    "i samband med lanseringen av Letraset-ark med avsnitt av Lorem Ipsum, och senare med mjukvaror som Aldus PageMaker.",
                    StartDate = DateTime.ParseExact("2016-06-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-09-09", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                }

              

                //new Group
                //{ 
                //    GroupId = 7,
                //    Name = "Avancerad C Del 1",
                //    //Teacher = "Oscar Jakobsson",
                //    TeacherId = NewUserList[0].Id,
                //    Description = "Moment 1.",
                //    StartDate = DateTime.ParseExact("2015-11-18", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                //    EndDate = DateTime.ParseExact("2016-04-07", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                //},

                //new Group
                //{ 
                //    GroupId = 8,
                //    Name = "Assembler",
                //    //Teacher = "Adrian Lozano",
                //    TeacherId = NewUserList[1].Id,
                //    Description = "Grundkurs.",
                //    StartDate = DateTime.ParseExact("2015-12-13", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                //    EndDate = DateTime.ParseExact("2016-03-08", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                //},

                //new Group
                //{ 
                //    GroupId = 9,
                //    Name = "HTML Grunderna",
                //    //Teacher = "Adrian Lozano",
                //    TeacherId = NewUserList[1].Id,
                //    Description = "Skapa en hemsida.",
                //    StartDate = DateTime.ParseExact("2016-03-13", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                //    EndDate = DateTime.ParseExact("2016-05-28", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                //},

                //new Group
                //{ 
                //    GroupId = 10,
                //    Name = "Avancerad C Del 2",
                //    //Teacher = "Oscar Jakobsson",
                //    TeacherId = NewUserList[0].Id,
                //    Description = "Moment 2.",
                //    StartDate = DateTime.ParseExact("2016-04-08", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                //    EndDate = DateTime.ParseExact("2016-07-07", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                //}

            };

            foreach (var gr in groups)
            {
                context.Groups.AddOrUpdate(g => g.Name, gr);
            }

            //context.SaveChanges();

            context.Courses.AddOrUpdate(
                c => c.Name,
               new Course
               {
                   Name = "C# 2015",
                   GroupId = 1,
                   CourseId = 1,
                   Teacher = "Oscar Jakobsson",
                   Description = "Klasser och objekt.",
                   StartDate = DateTime.ParseExact("2015-11-03", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2015-12-23", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "C# 2015 del2",
                   GroupId = 1,
                   CourseId = 2,
                   Teacher = "Oscar Jakobsson",
                   Description = "Interface.",
                   StartDate = DateTime.ParseExact("2015-12-24", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-01-12", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "Test 2015",
                   GroupId = 1,
                   CourseId = 3,
                   Teacher = "Mattias �stholm",
                   Description = "Vattenfallsmetoden.",
                   StartDate = DateTime.ParseExact("2016-01-13", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-01-17", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "SCRUM 2015",
                   GroupId = 1,
                   CourseId = 4,
                   Teacher = "Mattias �stholm",
                   Description = "SCRUM del 1",
                   StartDate = DateTime.ParseExact("2016-01-18", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-01-21", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "AngularJS 2015",
                   GroupId = 1,
                   CourseId = 5,
                   Teacher = "Oscar Jakobsson",
                   Description = "AngularJS del 1.",
                   StartDate = DateTime.ParseExact("2016-01-22", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-01-24", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "MVC5 2015",
                   GroupId = 1,
                   CourseId = 6,
                   Teacher = "Adrian Lozano",
                   Description = "Modeller.",
                   StartDate = DateTime.ParseExact("2016-01-25", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-02-12", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "LMS Projekt 2015",
                   GroupId = 1,
                   CourseId = 7,
                   Teacher = "Oscar Jakobsson",
                   Description = "Fastst�lla kravspec.",
                   StartDate = DateTime.ParseExact("2016-02-13", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-03-18", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "C# 2016",
                   GroupId = 2,
                   CourseId = 8,
                   Teacher = "Pontus Wittberg",
                   Description = "Klasser och objekt.",
                   StartDate = DateTime.ParseExact("2016-03-21", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-04-20", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "C# 2016 del2",
                   GroupId = 2,
                   CourseId = 9,
                   Teacher = "Adrian Lozano",
                   Description = "Arv.",
                   StartDate = DateTime.ParseExact("2016-04-21", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-04-30", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "C# 2016 del3",
                   GroupId = 2,
                   CourseId = 10,
                   Teacher = "Pontus Wittberg",
                   Description = "Skapa en app.",
                   StartDate = DateTime.ParseExact("2016-05-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-05-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "Test kurs 2016",
                   GroupId = 2,
                   CourseId = 11,
                   Teacher = "Mattias �stholm",
                   Description = "Dokumentation.",
                   StartDate = DateTime.ParseExact("2016-05-16", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-05-19", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "SCRUM 2016",
                   GroupId = 2,
                   CourseId = 12,
                   Teacher = "Adrian Lozano",
                   Description = "SCRUM Grunder.",
                   StartDate = DateTime.ParseExact("2016-05-20", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-05-23", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "AngularJS 2016",
                   GroupId = 2,
                   CourseId = 13,
                   Teacher = "Oscar Jakobsson",
                   Description = "AngularJS Grunder.",
                   StartDate = DateTime.ParseExact("2016-05-24", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-06-02", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "MVC5 2016",
                   GroupId = 2,
                   CourseId = 14,
                   Teacher = "Adrian Lozano",
                   Description = "MVC5 Controller.",
                   StartDate = DateTime.ParseExact("2016-06-03", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-06-10", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

            new Course
               {
                   Name = "LMS Projekt 2016",
                   GroupId = 2,
                   CourseId = 15,
                   Teacher = "Oscar JAkobsson",
                   Description = "Kravspec.",
                   StartDate = DateTime.ParseExact("2016-06-11", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               }
             );

            //"pl�ster" f�r att f� databaskoppling innan vi la till CourseId i Courese seeden.
            // context.SaveChanges();


            var users2 = new List<ApplicationUser> {
                new ApplicationUser { FirstName = "Nina", LastName = "Eriksson", Email = "nina@hemma.se", UserName = "nina@hemma.se", GroupId = 1 },              
                new ApplicationUser { FirstName = "Rickard", LastName = "Nilsson", Email = "rickard@hemma.se", UserName = "rickard@hemma.se", GroupId = 1 },
                new ApplicationUser { FirstName = "Disa", LastName = "Hiltunen", Email = "disa@hemma.se", UserName = "disa@hemma.se", GroupId = 1 },
                new ApplicationUser { FirstName = "Anna", LastName = "Andersson", Email = "anna@hemma.se", UserName = "anna@hemma.se", GroupId = 2 },
                new ApplicationUser { FirstName = "Kalle", LastName = "Karlsson", Email = "kalle@hemma.se", UserName = "kalle@hemma.se", GroupId = 2 },
                new ApplicationUser { FirstName = "Stina", LastName = "Persson", Email = "stina@hemma.se", UserName = "stina@hemma.se", GroupId = 2 }
            };

            foreach (var u in users2)
            {
                userManager.Create(u, "foobar");
                var user = userManager.FindByEmail(u.Email);
                userManager.AddToRole(user.Id, "Student");
            }


            //context.Users.AddOrUpdate(
            //var appUser = new ApplicationUser { FirstName = "Nina", LastName = "Eriksson", Email = "nina@hemma.se", UserName = "nina@hemma.se", GroupId = 1 };
            //userManager.Create(appUser, "foobar");

            //appUser = new ApplicationUser { FirstName = "Rickard", LastName = "Nilsson", Email = "rickard@hemma.se", UserName = "rickard@hemma.se", GroupId = 1 };
            //userManager.Create(appUser, "foobar");

            //appUser = new ApplicationUser { FirstName = "Disa", LastName = "Hiltunen", Email = "disa@hemma.se", UserName = "disa@hemma.se", GroupId = 1 };
            //userManager.Create(appUser, "foobar");

            //appUser = new ApplicationUser { FirstName = "Anna", LastName = "Andersson", Email = "anna@hemma.se", UserName = "anna@hemma.se", GroupId = 2 };
            //userManager.Create(appUser, "foobar");

            //appUser = new ApplicationUser { FirstName = "Kalle", LastName = "Karlsson", Email = "kalle@hemma.se", UserName = "kalle@hemma.se", GroupId = 2 };
            //userManager.Create(appUser, "foobar");

            //appUser = new ApplicationUser { FirstName = "Stina", LastName = "Persson", Email = "stina@hemma.se", UserName = "stina@hemma.se", GroupId = 2 };
            //userManager.Create(appUser, "foobar");

            //appUser = new ApplicationUser { FirstName = "Oscar", LastName = "Jakobsson", Email = "oscar.jakobsson@lexicon.se", UserName = "oscar.jakobsson@lexicon.se", GroupId = 1 };
            //userManager.Create(appUser, "foobar");

            //appUser = new ApplicationUser { FirstName = "Adrian", LastName = "Lozano", Email = "adrian.lozano@lexicon.se", UserName = "adrian.lozano@lexicon.se", GroupId = 2 };
            //userManager.Create(appUser, "foobar");




            //var user = userManager.FindByEmail("nina@hemma.se");
            //userManager.AddToRole(user.Id, "Student");
            //user = userManager.FindByEmail("disa@hemma.se");
            //userManager.AddToRole(user.Id, "Student");
            //user = userManager.FindByEmail("rickard@hemma.se");
            //userManager.AddToRole(user.Id, "Student");
            //user = userManager.FindByEmail("kalle@hemma.se");
            //userManager.AddToRole(user.Id, "Student");
            //user = userManager.FindByEmail("stina@hemma.se");
            //userManager.AddToRole(user.Id, "Student");

            //user = userManager.FindByEmail("oscar.jakobsson@lexicon.se");
            //userManager.AddToRole(user.Id, "Teacher");
            //user = userManager.FindByEmail("adrian.lozano@lexicon.se");
            //userManager.AddToRole(user.Id, "Teacher");



            context.Activities.AddOrUpdate(
                a => a.Name,
                new Activity
                {
                    CourseId = 1,
                    Type = "L�rarledd kurs",
                    Name = "Databaser del 1",
                    Teacher = "Adrian Lozano",
                    Description = "Databaser �r bra att ha",
                    StartDate = DateTime.ParseExact("2015-01-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2015-02-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },


                new Activity
                {
                    CourseId = 1,
                    Type = "Sj�lvstudier",
                    Name = "E-learning C#",
                    Teacher = "Oscar Jakobsson",
                    Description = "E-learning C# �r bra f�r att bla bla bla",
                    StartDate = DateTime.ParseExact("2015-01-18", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2015-01-22", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 1,
                    Type = "Lab",
                    Name = "Code along 1",
                    Teacher = "Pontus Wittberg",
                    Description = "Dungeons of lexicon code along",
                    StartDate = DateTime.ParseExact("2015-02-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2015-02-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },


                new Activity
                {
                    CourseId = 2,
                    Type = "L�rarledd kurs",
                    Name = "C# forts�ttningskurs",
                    Teacher = "Oscar Jakobsson",
                    Description = "I denna kurs kommer vi att l�ra oss mer om C#",
                    StartDate = DateTime.ParseExact("2015-02-18", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2015-02-26", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 2,
                    Type = "L�rarledd kurs",
                    Name = "C# forts�ttningskurs 2015",
                    Teacher = "Oscar Jakobsson",
                    Description = "I denna kurs kommer vi att l�ra oss mer om  C# och bla bla bla bla",
                    StartDate = DateTime.ParseExact("2015-03-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2015-03-05", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                 new Activity
                {
                    CourseId = 2,
                    Type = "Lab",
                    Name = "Code along 2",
                    Teacher = "Pontus Wittberg",
                    Description = "Code along med Pontus",
                    StartDate = DateTime.ParseExact("2015-03-08", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2015-03-12", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 2,
                    Type = "Sj�lvstudier",
                    Name = "Bootstrap",
                    Teacher = "Oscar Jakobsson",
                    Description = "I denna kurs kommer vi att l�ra oss mer om Bootstrap",
                    StartDate = DateTime.ParseExact("2015-03-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2015-03-18", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 3,
                    Type = "L�rarledd kurs",
                    Name = "Test grunder 2015",
                    Teacher = "Mattias �stholm",
                    Description = "I denna kurs g�r vi igenom grunderna till test",
                    StartDate = DateTime.ParseExact("2015-03-20", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2015-03-25", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 3,
                    Type = "Sj�lvstudier",
                    Name = "Test E-learning",
                    Teacher = "Oscar Jakobsson",
                    Description = "Kursen best�r av ett antal e-learning kurser fr�n Plural sight",
                    StartDate = DateTime.ParseExact("2015-03-28", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2015-04-01", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 3,
                    Type = "L�rarledd kurs",
                    Name = "Test med liten dator",
                    Teacher = "Mattias �stholm",
                    Description = "En liten kurs med test",
                    StartDate = DateTime.ParseExact("2015-04-03", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2015-04-05", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 4,
                    Type = "L�rarledd kurs",
                    Name = "Scrum del 1",
                    Teacher = "Oscar Jakobsson",
                    Description = "I denna kurs kommer vi att l�ra oss grunderna i scrum",
                    StartDate = DateTime.ParseExact("2015-04-07", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2015-04-17", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 4,
                    Type = "L�rarledd kurs",
                    Name = "Scrum del 2",
                    Teacher = "Oscar Jakobsson",
                    Description = "I denna kurs kommer vi att l�ra oss grunderna i scrum",
                    StartDate = DateTime.ParseExact("2015-04-19", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2015-04-29", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },


                 new Activity
                 {
                    CourseId = 5,
                    Type = "L�rarledd kurs",
                     Name = "Angular grunder",
                     Teacher = "Adrian Lozano",
                     Description = "Kursen kommer att g� igenom allt m�jligt om Angular",
                     StartDate = DateTime.ParseExact("2015-05-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                     EndDate = DateTime.ParseExact("2015-05-07", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                 },

                 new Activity
                 {
                     CourseId = 5,
                     Type = "L�rarledd kurs",
                    Name = "Angular f�rdjupningskurs",
                    Teacher = "Adrian Lozano",
                    Description = "Kursen kommer att g� igenom allt m�jligt om Angular",
                     StartDate = DateTime.ParseExact("2015-05-09", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                     EndDate = DateTime.ParseExact("2016-05-13", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },


                new Activity
                {
                    CourseId = 6,
                    Type = "L�rarledd kurs",
                    Name = "Mvc grunder",
                    Teacher = "Adrian Lozano",
                    Description = "Kursen kommer att g� igenom grunderna i mvc",
                    StartDate = DateTime.ParseExact("2015-05-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2015-05-23", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },


                new Activity
                {
                    CourseId = 6,
                    Type = "Sj�lvstudier",
                    Name = "E-learning2",
                    Teacher = "Adrian Lozano",
                    Description = "Kursen kommer att best� av e-learning p� pluralsight",
                    StartDate = DateTime.ParseExact("2015-05-25", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2015-05-27", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },


                new Activity
                {
                    CourseId = 6,
                    Type = "Sj�lvstudier",
                    Name = "E-learning C# del2",
                    Teacher = "Oscar Jakobsson",
                    Description = "I denna kurs kommer ni att lyssna p� det e-learning material som finns ang�nde C#",
                    StartDate = DateTime.ParseExact("2015-05-28", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2015-05-30", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },


                new Activity
                {
                    CourseId = 7,
                    Type = "L�rarledd kurs",
                    Name = "LMS",
                    Teacher = "Oscar Jakobsson",
                    Description = "Gupparbete start",
                    StartDate = DateTime.ParseExact("2015-06-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2015-06-05", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },


                 new Activity
                {
                      CourseId = 7,
                    Type = "L�rarledd kurs",
                      Name = "LMS forts�ttning",
                    Teacher = "Oscar Jakobsson",
                      Description = "LMS grupparbete forts�ttning",
                      StartDate = DateTime.ParseExact("2015-06-07", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                      EndDate = DateTime.ParseExact("2015-06-10", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 8,
                    Type = "Sj�lvstudier",
                    Name = "E-learning",
                    Teacher = "Oscar Jakobsson",
                    Description = "Plural sight kurs",
                    StartDate = DateTime.ParseExact("2015-06-11", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2015-06-13", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },


                new Activity
                {
                    CourseId = 8,
                    Type = "L�rarledd kurs",
                    Name = "C#",
                    Teacher = "Oscar Jakobsson",
                    Description = "I denna kur skommer vi g� igenom bla bla bla bla.",
                    StartDate = DateTime.ParseExact("2015-06-14", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2015-06-20", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },


                 new Activity
                 {
                     CourseId = 9,
                     Type = "L�rarledd kurs",
                     Name = "C# f�rdjupningskurs 2016",
                     Teacher = "Oscar Jakobsson",
                     Description = "I denna kurs kommer vi att f�rdjupa oss i C# ",
                     StartDate = DateTime.ParseExact("2016-01-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                     EndDate = DateTime.ParseExact("2016-01-25", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                 new Activity
                {
                    CourseId = 9,
                    Type = "L�rarledd kurs",
                    Name = "C# 2016",
                    Teacher = "Adrian Lozano",
                    Description = "I denna kurs kommer vi att l�ra oss mer om C# ",
                     StartDate = DateTime.ParseExact("2016-02-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                     EndDate = DateTime.ParseExact("2016-02-25", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                 },

                new Activity
                {
                    CourseId = 10,
                    Type = "Sj�lvstudier",
                    Name = "E-learning3 2016",
                    Teacher = "Adrian Lozano",
                    Description = "Kursen kommer att best� av e-learning p� pluralsight",
                    StartDate = DateTime.ParseExact("2016-03-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-03-25", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },


                new Activity
                {
                    CourseId = 10,
                    Type = "L�rarledd kurs",
                    Name = "C# kurs",
                    Teacher = "Oscar Jakobsson",
                    Description = "I denna kurs kommer vi att l�ra oss mer om C# ",
                    StartDate = DateTime.ParseExact("2016-04-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-04-25", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 11,
                    Type = "L�rarledd kurs",
                    Name = "Test kurs del1",
                    Teacher = "Mattias �stholm",
                    Description = "I denna kurs kommer vi att l�ra oss mer om test",
                    StartDate = DateTime.ParseExact("2016-05-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-05-25", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 12,
                    Type = "L�rarledd kurs",
                    Name = "Scrum grundkurs",
                    Teacher = "Oscar Jakobsson",
                    Description = "I denna del av kursen skommer vi g� igenom scrum",
                    StartDate = DateTime.ParseExact("2016-06-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-06-25", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                 new Activity
                {
                    CourseId = 13,
                    Type = "L�rarledd kurs",
                    Name = "Angular JS kurs",
                    Teacher = "Pontus Wittberg",
                    Description = "I denna kurs kommer vi att f�rdjupa oss i Angular JS ",
                    StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                     EndDate = DateTime.ParseExact("2016-07-25", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 14,
                    Type = "Sj�lvstudier",
                    Name = "E-learning MVC",
                    Teacher = "Adrian Lozano",
                    Description = "Kursen kommer att best� av e-learning p� pluralsight",
                    StartDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-09-25", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                 new Activity
                {
                    CourseId = 15,
                    Type = "L�rarledd kurs",
                    Name = "LMS kurs",
                    Teacher = "Pontus Wittberg",
                    Description = "I denna kurs kommer vi att l�ra oss mer om LMS",
                     StartDate = DateTime.ParseExact("2016-10-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                     EndDate = DateTime.ParseExact("2016-11-25", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                }

            );

            //var groups = new List<Group> {
            //    new Group { },
            //    new Group { },
            //    new Group { },
            //};

            //foreach (var g in groups) { 
            //    context.Groups.AddOrUpdate(g => g.Name, groups);
            //}

            //var users = new List<ApplicationUser> {
            //    new ApplicationUser { },
            //    new ApplicationUser { },
            //    new ApplicationUser { },
            //};

            //foreach (var u in users)
            //{
            //    int userIndex = users.IndexOf(u);
            //    userManager.Create(u, "foobar");
            //    userManager.AddToRole(u.Id, userIndex < 5 ? "Teacher" : "Student");
            //}

            //groups[0].UserId = users[2].Id;
            //users[1].GroupId = groups[1].GroupId;
            

        }
    }
}
