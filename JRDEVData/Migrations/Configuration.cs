namespace JRDEVData.Migrations
{
    using JRDEVDataModels;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JRDEVData.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(JRDEVData.ApplicationDbContext context)
        {
            var RoleStore = new RoleStore<IdentityRole>(context);
            var RoleManager = new RoleManager<IdentityRole>(RoleStore);

            if (!RoleManager.RoleExists("SiteAdmin"))
            {
                var role = new IdentityRole();
                role.Name = "SiteAdmin";
                RoleManager.Create(role);
            }
            if (!RoleManager.RoleExists("CompanyAdmin"))
            {
                var role = new IdentityRole();
                role.Name = "CompanyAdmin";
                RoleManager.Create(role);
            }
            if (!RoleManager.RoleExists("CompanyUser"))
            {
                var role = new IdentityRole();
                role.Name = "CompanyUser";
                RoleManager.Create(role);
            }
            if (!RoleManager.RoleExists("TalentUser"))
            {
                var role = new IdentityRole();
                role.Name = "TalentUser";
                RoleManager.Create(role);
            }
            context.SaveChanges();

            var UserStore = new UserStore<User>(context);
            var UserManager = new UserManager<User>(UserStore);
            User user1;
            User user2;
            User user3;
            User user4;
            User user5;

            if (context.Users.Any(u => u.UserName == "System"))
            {
                user1 = context.Users.FirstOrDefault(u => u.UserName == "System");
            }
            else
            {
                user1 = new User()
                {
                    UserName = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    FirstName = "System",
                    LastName = "Admin"
                };
                UserManager.Create(user1, "123456");
                UserManager.AddToRole(user1.Id, "SiteAdmin");
            }

            if (context.Users.Any(u => u.UserName == "TheBoy"))
            {
                user2 = context.Users.FirstOrDefault(u => u.UserName == "TheBoy");
            }
            else
            {
                user2 = new User()
                {
                    UserName = "TheBoy",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    FirstName = "Nick",
                    LastName = "Brittain"
                };
                UserManager.Create(user2, "123456");
                UserManager.AddToRole(user2.Id, "CompanyUser");
            }

            if (context.Users.Any(u => u.UserName == "TheMan"))
            {
                user3 = context.Users.FirstOrDefault(u => u.UserName == "TheMan");
            }
            else
            {
                user3 = new User()
                {
                    UserName = "TheMan",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    FirstName = "John",
                    LastName = "Doe"
                };
                UserManager.Create(user3, "123456");
                UserManager.AddToRole(user3.Id, "CompanyAdmin");
            }

            if (context.Users.Any(u => u.UserName == "Jobless"))
            {
                user4 = context.Users.FirstOrDefault(u => u.UserName == "Jobless");
            }
            else
            {
                user4 = new User()
                {
                    UserName = "Jobless",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    FirstName = "Steve",
                    LastName = "Jobs"
                };
                UserManager.Create(user4, "123456");
                UserManager.AddToRole(user4.Id, "TalentUser");
            }

            if (context.Users.Any(u => u.UserName == "TestCo"))
            {
                user5 = context.Users.FirstOrDefault(u => u.UserName == "Testco");
            }
            else
            {
                user5 = new User()
                {
                    UserName = "TestCo",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    FirstName = "James",
                    LastName = "Bond"
                };

                UserManager.Create(user5, "123456");
                UserManager.AddToRole(user5.Id, "CompanyAdmin");
            }
            

            context.SaveChanges();

            try
            {
                context.TalentProfiles.AddOrUpdate(
               p => p.TalentProfileId,
               new TalentProfile
               {
                   TalentProfileId = 1,
                   CurrentlyLooking = true,
                   DateCreated = DateTime.Now,
                   DateUpdated = DateTime.Now,
                   DesiredSalary = 60000,
                   IsLookingForJob = true,
                   UserId = user4.Id,
                   UserCreatedId = user4.Id,
                   UserUpdatedId = user4.Id,
                   WillRelocate = true


               });

                context.Resumes.AddOrUpdate(
                    p => p.ResumeId,
                    new Resume
                    {
                        ResumeId = 1,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        Education = "Coder Camps",
                        Heading = "Junior .Net Developer",
                        Summary = "Attended a 9 Week Intensive Program where I learned the .Net Technologies",
                        OtherInfo = "Skills: AngularJS, Entity Framework, Visual Studio, and C#",
                        UserId = user4.Id,
                        UserCreatedId = user2.Id,
                        UserUpdatedId = user2.Id,
                        WorkExperience = "Coder For Rent",

                    },
                    
                     new Resume
                    {
                        ResumeId = 2,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        Education = "University Of Houston",
                        Heading = "Sr PHP Developer",
                        Summary = "Bachelors Degree in Computer Science graduated top 10% of class",
                        OtherInfo = "Skills: AngularJS, Entity Framework, Visual Studio, and C#, IOS, Android, Xamrin",
                        UserId = user4.Id,
                        UserCreatedId = user3.Id,
                        UserUpdatedId = user3.Id,
                        WorkExperience = "Jr. Developer HP, Mobile Application Jr. Developer at FunGamesForMe Co.",

                    },
                
                 new Resume
                    {
                        ResumeId = 3,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        Education = "UCLA",
                        Heading = "Senior Application Developer",
                        Summary = "9 years of experience in applications development, testing, troubleshooting, and implementation Strong knowledge of technical specifications, workflow development, risk management, and QA In-depth background analyzing business requirements and recommending appropriate technologies.",
                        OtherInfo = "Skills: Visual Basic, C, C++, C#, VB.NET, .NET, MS SQL, VBA Scripting, HTML, XML, ASP.NET, Java, J2EE, JavaScript, Java Server Pages (JSP), CSS, MS Visual Studio",
                        UserId = user4.Id,
                        UserCreatedId = user5.Id,
                        UserUpdatedId = user5.Id,
                        WorkExperience = "DEF Inc, HJK Inc, ABC Co",

                    },
                
                 new Resume
                    {
                        ResumeId = 4,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        Education = "MIT",
                        Heading = "Junior C# Developer",
                        Summary = "A conscientious, fast learner offering the ability to assess an organization’s needs and create a complementary, robust web presence. Experienced in all 5 stages of the web development process including: information gathering, planning, design, development, testing and delivery and maintenance. Proficient with a wide array of scripting languages and multimedia web tools.",
                        OtherInfo = "Skills: JavaScript, CSS, HTML, XHTML, Java, .Net and Python. Some knowledge of MySQL Adobe Suite: Adobe CS5.5 Web Premium: Dreamweaver, Flash Catalyst, Flash Professional, Flash Builder, Photoshop, Illustrator, Acrobat X Pro, Fireworks, Contribute, Bridge, Device Central and Media Encoder",
                        UserId = user4.Id,
                        UserCreatedId = user4.Id,
                        UserUpdatedId = user4.Id,
                        WorkExperience = "AnyTown Food Bank, AnyTown Baseball League",

                    },
                
                 new Resume
                    {
                        ResumeId = 5,
                        DateCreated = DateTime.Now,

                        DateUpdated = DateTime.Now,
                        Education = "University Of Texas ",
                        Heading = "Cloud System Administrator",
                        Summary = " Technical Lead/Solution Architect specialising in leading bespoke .Net development teams within corporate environments. He is able to ensure that the project is delivered according to requirements and makes use of the best architectural components in a practical manner – balancing architectural correctness, leading edge and the ability of the implementation team to deliver.",
                        OtherInfo = "Skills: AngularJS, Entity Framework, Visual Studio, Winforms, WS, WCF, REST, SOAP, SQL SERVER and C#",
                        UserId = user4.Id,
                        UserCreatedId = user5.Id,
                        UserUpdatedId = user5.Id,
                        WorkExperience = "Sanlam, Shoprite, Solution Dynamix, Vodacom ",

                    });

                context.Companies.AddOrUpdate(
                    p => p.CompanyId,
                    new Company
                    {
                        CompanyId = 1,
                        City = "Pearland",
                        CompanyName = "Coder For Rent",
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        EmailAddress = "coderforrent@coderforrent.com",
                        PhoneNumber = "1234567",
                        State = "Texas",
                        StreetAddress = "123 Broadway St",
                        ZipCode = "77583",
                        CompanyAdmin = user3,
                        CostPerClick = 0.10m,
                        Description = "Active Development Shop",
                        IsVerified = true,
                        IsVisible = true,
                        JobPostingBudget = 100,
                        Logo = "https://pbs.twimg.com/profile_images/378800000139847457/71de3a478d6b7d85b173f7d3e71adf89.png",
                        UserCreatedId = user3.Id,
                        UserUpdatedId = user3.Id,
                        CompanyAdminId = user3.Id

                    });

                context.Companies.AddOrUpdate(
                    p => p.CompanyId,
                    new Company
                    {
                        CompanyId = 5,
                        City = "Menlo Park",
                        CompanyName = "Google",
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        EmailAddress = "Jobs@google.com",
                        PhoneNumber = "1800-GOO-GLER",
                        State = "California",
                        StreetAddress = "1600 Amphitheatre Parkway",
                        ZipCode = "94043",
                        CompanyAdmin = user5,
                        CostPerClick = 0.10m,
                        Description = "Google is an American multinational corporation specializing in Internet-related services and products.",
                        IsVerified = true,
                        IsVisible = true,
                        JobPostingBudget = 10000,
                        Logo = "http://assets.nydailynews.com/polopoly_fs/1.1012082!/img/httpImage/image.jpg_gen/derivatives/article_1200/google26n-2-web.jpg",
                        UserCreatedId = user5.Id,
                        UserUpdatedId = user5.Id,
                        CompanyAdminId = user5.Id

                    });

                context.Companies.AddOrUpdate(
                   p => p.CompanyId,
                   new Company
                   {
                       CompanyId = 2,
                       City = "Houston",
                       CompanyName = "Dancers For Rent",
                       DateCreated = DateTime.Now,
                       DateUpdated = DateTime.Now,
                       EmailAddress = "Dances@coderforrent.com",
                       PhoneNumber = "1234567",
                       State = "Texas",
                       StreetAddress = "333 Bay St",
                       ZipCode = "77583",
                       CompanyAdmin = user5,
                       CostPerClick = 0.10m,
                       Description = "Dance Troupe Enterprise",
                       IsVerified = true,
                       IsVisible = true,
                       JobPostingBudget = 100,
                       Logo = "https://pbs.twimg.com/profile_images/378800000139847457/71de3a478d6b7d85b173f7d3e71adf89.png",
                       UserCreatedId = user5.Id,
                       UserUpdatedId = user5.Id,
                       CompanyAdminId = user5.Id

                   });



                context.Companies.AddOrUpdate(
                   p => p.CompanyId,
                   new Company
                   {
                       CompanyId = 3,
                       City = "Seattle",
                       CompanyName = "Amazon",
                       DateCreated = DateTime.Now,
                       DateUpdated = DateTime.Now,
                       EmailAddress = "Careers@Amazon.com",
                       PhoneNumber = "1-800-AMAZONS",
                       State = "Washington",
                       StreetAddress = " 1200 12th Ave. South, Ste. 1200",
                       ZipCode = "98144",
                       CompanyAdmin = user5,
                       CostPerClick = 0.10m,
                       Description = "Amazon.com, Inc. is an American international electronic commerce company with headquarters in Seattle, Washington, United States. It is the world's largest online retailer.",
                       IsVerified = true,
                       IsVisible = true,
                       JobPostingBudget = 100,
                       Logo = "https://pbs.twimg.com/profile_images/378800000139847457/71de3a478d6b7d85b173f7d3e71adf89.png",
                       UserCreatedId = user5.Id,
                       UserUpdatedId = user5.Id,
                       CompanyAdminId = user5.Id

                   }); context.Companies.AddOrUpdate(
                    p => p.CompanyId,
                    new Company
                    {
                        CompanyId = 4,
                        City = "Cupertino",
                        CompanyName = "Apple Inc",
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        EmailAddress = "Jobs@Apple.com",
                        PhoneNumber = "1800-APPLECO",
                        State = "California",
                        StreetAddress = "1 Infinite Loop",
                        ZipCode = "95014",
                        CompanyAdmin = user5,
                        CostPerClick = 0.10m,
                        Description = "Electronics Creator of iPad, iPod, iPhone, iMac etc...",
                        IsVerified = true,
                        IsVisible = true,
                        JobPostingBudget = 100,
                        Logo = "https://pbs.twimg.com/profile_images/378800000139847457/71de3a478d6b7d85b173f7d3e71adf89.png",
                        UserCreatedId = user5.Id,
                        UserUpdatedId = user5.Id,
                        CompanyAdminId = user5.Id

                    });

                context.SaveChanges();

                //Set a Company ID on the Company user and admins
                var theMan = UserManager.FindByName("TheMan");
                var testCo = UserManager.FindByName("TestCo");
                var theBoy = UserManager.FindByName("TheBoy");

                theMan.CompanyId = 1;
                testCo.CompanyId = 1;
                theBoy.CompanyId = 1;                              

                context.Jobs.AddOrUpdate(
                  p => p.JobTitle,
                  new Job
                  {
                      JobId = 1,
                      City = "Houston",
                      DateCreated = DateTime.Now,
                      DateUpdated = DateTime.Now,
                      Description = "Technology Specialist in SQL Administration",
                      EmailAddress = "George@WatsonPrograms.com",
                      JobBudget = 1000.99,
                      JobTitle = ".Net Jr. Developer",
                      PhoneNumber = "7135555423",
                      SalaryMin = 100000,
                      SalaryMax = 500000,
                      StartDate = DateTime.Now.AddDays(200),
                      EndDate = DateTime.Now.AddDays(500),
                      State = "Texas",
                      StreetAddress = "123 Awesome Lane",
                      YearsExperience = 2,
                      ZipCode = "77057",
                      UserId = user3.Id,
                      CompanyId = 1,
                      UserCreatedId = user3.Id,
                      UserUpdatedId = user3.Id,

                  },
                  new Job
                  {
                      JobId = 2,
                      City = "Dallas",
                      DateCreated = DateTime.Now,
                      DateUpdated = DateTime.Now,
                      Description = "Cloud Computing Specialist with 5 years experience in related field",
                      EmailAddress = "Deric@FunGamesCo.com",
                      JobBudget = 1000.99,
                      JobTitle = "Cloud Architect",
                      PhoneNumber = "8175556522",
                      SalaryMin = 100000,
                      SalaryMax = 500000,
                      StartDate = DateTime.Now.AddDays(200),
                      EndDate = DateTime.Now.AddDays(500),
                      State = "Texas",
                      StreetAddress = "666 DarkDriven Lane",
                      YearsExperience = 2,
                      ZipCode = "87450",
                      UserId = user3.Id,
                      CompanyId = 1,
                      UserCreatedId = user3.Id,
                      UserUpdatedId = user3.Id,

                  },
                  new Job
                  {
                      JobId = 3,
                      City = "Austin",
                      DateCreated = DateTime.Now,
                      DateUpdated = DateTime.Now,
                      Description = "C# Developer with 3yrs experience at a Jr. to Mid Level knowledge of C# and .Net platforms",
                      EmailAddress = "Joe@AwesomeCompany.com",
                      JobBudget = 1000.99,
                      JobTitle = "Programmer Jr to Mid Level",
                      PhoneNumber = "5125558952",
                      SalaryMin = 100000,
                      SalaryMax = 500000,
                      StartDate = DateTime.Now.AddDays(200),
                      EndDate = DateTime.Now.AddDays(500),
                      State = "Texas",
                      StreetAddress = "187 Valley Rd ",
                      YearsExperience = 2,
                      ZipCode = "83255",
                      UserId = user3.Id,
                      CompanyId = 1,
                      UserCreatedId = user3.Id,
                      UserUpdatedId = user3.Id,

                  },
                  new Job
                  {
                      JobId = 4,
                      City = "San Antonio",
                      DateCreated = DateTime.Now,
                      DateUpdated = DateTime.Now,
                      Description = "Technology Evangelist looking for a opportunity to help promote products offerred by our company",
                      EmailAddress = "Jared@SuperStartTech.com",
                      JobBudget = 1000.99,
                      JobTitle = "Technology Evangelist",
                      PhoneNumber = "4095556325",
                      SalaryMin = 100000,
                      SalaryMax = 500000,
                      StartDate = DateTime.Now.AddDays(200),
                      EndDate = DateTime.Now.AddDays(500),
                      State = "Texas",
                      StreetAddress = "318 Rockstar Lane",
                      YearsExperience = 2,
                      ZipCode = "63528",
                      UserId = user3.Id,
                      CompanyId = 1,
                      UserCreatedId = user3.Id,
                      UserUpdatedId = user3.Id,

                  },
                  new Job
                  {
                      JobId = 5,
                      City = "Seattle",
                      DateCreated = DateTime.Now,
                      DateUpdated = DateTime.Now,
                      Description = "Crazy Programmers who have a passion for programming from atleast the age of 10",
                      EmailAddress = "Jason@CrazyFastProgrammer.com",
                      JobBudget = 1000.99,
                      JobTitle = "Level 3 Sr. Developer",
                      PhoneNumber = "1234567",
                      SalaryMin = 100000,
                      SalaryMax = 500000,
                      StartDate = DateTime.Now.AddDays(200),
                      EndDate = DateTime.Now.AddDays(500),
                      State = "Washington",
                      StreetAddress = "459 Mystreet Lane",
                      YearsExperience = 2,
                      ZipCode = "49582",
                      UserId = user3.Id,
                      CompanyId = 1,
                      UserCreatedId = user3.Id,
                      UserUpdatedId = user3.Id,

                  },
                  new Job
                  {
                      JobId = 6,
                      City = "City of Nowhere",
                      DateCreated = DateTime.Now,
                      DateUpdated = DateTime.Now,
                      Description = "Bestestest Job",
                      EmailAddress = "Tester@Test.com",
                      JobBudget = 1000.99,
                      JobTitle = "Sr. Developer",
                      PhoneNumber = "1234567",
                      SalaryMin = 100000,
                      SalaryMax = 500000,
                      StartDate = DateTime.Now.AddDays(200),
                      EndDate = DateTime.Now.AddDays(500),
                      State = "Texas",
                      StreetAddress = "123 Uhhuhh Lane",
                      YearsExperience = 2,
                      ZipCode = "77222",
                      UserId = user3.Id,
                      CompanyId = 1,
                      UserCreatedId = user3.Id,
                      UserUpdatedId = user3.Id,

                  },
                  new Job
                  {
                      JobId = 7,
                      City = "Gotham",
                      DateCreated = DateTime.Now,
                      DateUpdated = DateTime.Now,
                      Description = "Crime Fighter",
                      EmailAddress = "Batman@gotham.com",
                      JobBudget = 1000.99,
                      JobTitle = "Batman",
                      PhoneNumber = "1234567",
                      SalaryMin = 100000,
                      SalaryMax = 500000,
                      StartDate = DateTime.Now.AddDays(200),
                      EndDate = DateTime.Now.AddDays(500),
                      State = "New York",
                      StreetAddress = "123 Uhhuhh Lane",
                      YearsExperience = 2,
                      ZipCode = "77222",
                      UserId = user3.Id,
                      CompanyId = 1,
                      UserCreatedId = user3.Id,
                      UserUpdatedId = user3.Id,

                  },
                  new Job
                  {
                      JobId = 8,
                      City = "Metropolis",
                      DateCreated = DateTime.Now,
                      DateUpdated = DateTime.Now,
                      Description = "Bestestest Job",
                      EmailAddress = "Tester@Test.com",
                      JobBudget = 1000.99,
                      JobTitle = "Superman",
                      PhoneNumber = "1234567",
                      SalaryMin = 100000,
                      SalaryMax = 500000,
                      StartDate = DateTime.Now.AddDays(200),
                      EndDate = DateTime.Now.AddDays(500),
                      State = "New York",
                      StreetAddress = "123 Uhhuhh Lane",
                      YearsExperience = 2,
                      ZipCode = "77222",
                      UserId = user3.Id,
                      CompanyId = 1,
                      UserCreatedId = user3.Id,
                      UserUpdatedId = user3.Id,

                  },
                  new Job
                  {
                      JobId = 9,
                      City = "City of Nowhere3",
                      DateCreated = DateTime.Now,
                      DateUpdated = DateTime.Now,
                      Description = "Bestestest Job",
                      EmailAddress = "Tester@Test.com",
                      JobBudget = 1000.99,
                      JobTitle = "Senior Developer",
                      PhoneNumber = "1234567",
                      SalaryMin = 100000,
                      SalaryMax = 500000,
                      StartDate = DateTime.Now.AddDays(200),
                      EndDate = DateTime.Now.AddDays(500),
                      State = "Texas",
                      StreetAddress = "123 Uhhuhh Lane",
                      YearsExperience = 2,
                      ZipCode = "77222",
                      UserId = user3.Id,
                      CompanyId = 1,
                      UserCreatedId = user3.Id,
                      UserUpdatedId = user3.Id,

                  },
                                  
                 new Job
                  {
                      JobId = 10,
                      City = "Smallville",
                      DateCreated = DateTime.Now,
                      DateUpdated = DateTime.Now,
                      Description = "Bestestest Job",
                      EmailAddress = "Tester@Test.com",
                      JobBudget = 1000.99,
                      JobTitle = "Painter",
                      PhoneNumber = "1234567",
                      SalaryMin = 100000,
                      SalaryMax = 500000,
                      StartDate = DateTime.Now.AddDays(200),
                      EndDate = DateTime.Now.AddDays(500),
                      State = "Texas",
                      StreetAddress = "123 Uhhuhh Lane",
                      YearsExperience = 2,
                      ZipCode = "77222",
                      UserId = user3.Id,
                      CompanyId = 1,
                      UserCreatedId = user3.Id,
                      UserUpdatedId = user3.Id,

                  },
                  new Job
                  {
                      JobId = 11,
                      City = "Margaritaville",
                      DateCreated = DateTime.Now,
                      DateUpdated = DateTime.Now,
                      Description = "Bestestest Job",
                      EmailAddress = "Tester@Test.com",
                      JobBudget = 1000.99,
                      JobTitle = "Wrestler",
                      PhoneNumber = "1234567",
                      SalaryMin = 100000,
                      SalaryMax = 500000,
                      StartDate = DateTime.Now.AddDays(200),
                      EndDate = DateTime.Now.AddDays(500),
                      State = "Texas",
                      StreetAddress = "123 Uhhuhh Lane",
                      YearsExperience = 2,
                      ZipCode = "77222",
                      UserId = user3.Id,
                      CompanyId = 1,
                      UserCreatedId = user3.Id,
                      UserUpdatedId = user3.Id,

                  },
                  new Job
                  {
                      JobId = 12,
                      City = "City of Nowhere",
                      DateCreated = DateTime.Now,
                      DateUpdated = DateTime.Now,
                      Description = "Boxer Job",
                      EmailAddress = "Tester@Test.com",
                      JobBudget = 1000.99,
                      JobTitle = "Surfer",
                      PhoneNumber = "1234567",
                      SalaryMin = 100000,
                      SalaryMax = 500000,
                      StartDate = DateTime.Now.AddDays(200),
                      EndDate = DateTime.Now.AddDays(500),
                      State = "Texas",
                      StreetAddress = "123 Uhhuhh Lane",
                      YearsExperience = 2,
                      ZipCode = "77222",
                      UserId = user3.Id,
                      CompanyId = 1,
                      UserCreatedId = user3.Id,
                      UserUpdatedId = user3.Id,

                  },
                  new Job
                  {
                      JobId = 13,
                      City = "City of Nowhere",
                      DateCreated = DateTime.Now,
                      DateUpdated = DateTime.Now,
                      Description = "Bestestest Job",
                      EmailAddress = "Tester@Test.com",
                      JobBudget = 1000.99,
                      JobTitle = "Cat Listener",
                      PhoneNumber = "1234567",
                      SalaryMin = 100000,
                      SalaryMax = 500000,
                      StartDate = DateTime.Now.AddDays(200),
                      EndDate = DateTime.Now.AddDays(500),
                      State = "Texas",
                      StreetAddress = "123 Uhhuhh Lane",
                      YearsExperience = 2,
                      ZipCode = "77222",
                      UserId = user3.Id,
                      CompanyId = 1,
                      UserCreatedId = user3.Id,
                      UserUpdatedId = user3.Id,

                  },
                new Job
                  {
                      JobId = 14,
                      City = "City of Nowhere",
                      DateCreated = DateTime.Now,
                      DateUpdated = DateTime.Now,
                      Description = "Bestestest Job",
                      EmailAddress = "Tester@Test.com",
                      JobBudget = 1000.99,
                      JobTitle = "Water park enthusiast",
                      PhoneNumber = "1234567",
                      SalaryMin = 100000,
                      SalaryMax = 500000,
                      StartDate = DateTime.Now.AddDays(200),
                      EndDate = DateTime.Now.AddDays(500),
                      State = "Texas",
                      StreetAddress = "123 Uhhuhh Lane",
                      YearsExperience = 2,
                      ZipCode = "77222",
                      UserId = user3.Id,
                      CompanyId = 1,
                      UserCreatedId = user3.Id,
                      UserUpdatedId = user3.Id,

                  },                 
                  new Job
                  {
                      JobId = 15,
                      City = "Istanbul",
                      DateCreated = DateTime.Now,
                      DateUpdated = DateTime.Now,
                      Description = "Bestestest Job",
                      EmailAddress = "Tester@Test.com",
                      JobBudget = 1000.99,
                      JobTitle = "Sophomore Developer",
                      PhoneNumber = "1234567",
                      SalaryMin = 100000,
                      SalaryMax = 500000,
                      StartDate = DateTime.Now.AddDays(200),
                      EndDate = DateTime.Now.AddDays(500),
                      State = "Texas",
                      StreetAddress = "123 Uhhuhh Lane",
                      YearsExperience = 2,
                      ZipCode = "77222",
                      UserId = user3.Id,
                      CompanyId = 1,
                      UserCreatedId = user3.Id,
                      UserUpdatedId = user3.Id,

                  });
                context.SaveChanges();

                context.Messages.AddOrUpdate(
                    m => m.MessageId,
                    new Message
                    {
                        MessageId = 1,
                        Subject = "Hello",
                        Content = "Hi There",
                        UserId = user2.Id,
                        CompanyId = 1,
                        DateCreated = DateTime.Now.AddHours(-1),
                        DateUpdated = DateTime.Now.AddHours(-1),
                        UserCreatedId = user2.Id,
                        UserUpdatedId = user2.Id
                    }
                    );
                context.SaveChanges();

                context.Applications.AddOrUpdate(
                    p => p.ApplicationId,
                    new Application
                    {
                        ApplicationId = 1,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        Content = "Looking for someone with 15 years of .Net experience",
                        Title = "Looking for Programmer",
                        JobId = 1,
                        UserId = user4.Id,
                        ResumeId = 1,
                        UserCreatedId = user4.Id,
                        UserUpdatedId = user4.Id
                       

                    },
                    
                    new Application
                    {
                        ApplicationId = 2,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        Content = "Need a Sr. Programmer with great knowledge in PHP",
                        Title = "Looking for PHP Developer",
                        JobId = 2,
                        UserId = user4.Id,
                        ResumeId = 1,
                        UserCreatedId = user4.Id,
                        UserUpdatedId = user4.Id
                       

                    },
                
                new Application
                    {
                        ApplicationId = 3,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        Content = "We are in need of a Jr. Developer who has the passion the enhance their skills in .Net Development",
                        Title = "Looking for Jr. Developer",
                        JobId = 3,
                        UserId = user4.Id,
                        ResumeId = 1,
                        UserCreatedId = user4.Id,
                        UserUpdatedId = user4.Id
                       

                    },
                
                new Application
                    {
                        ApplicationId = 4,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        Content = "Looking for someone with 15 years of .Net experience",
                        Title = "Looking for Programmer",
                        JobId = 4,
                        UserId = user4.Id,
                        ResumeId = 1,
                        UserCreatedId = user4.Id,
                        UserUpdatedId = user4.Id
                       

                    });

                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string errorList = string.Empty;
                ex.EntityValidationErrors.SelectMany(e => e.ValidationErrors).ToList().ForEach(e => errorList += e.PropertyName + ": " + e.ErrorMessage + " | ");

                throw new Exception(errorList);
            }
           

            //new Company { CompanyId = 2, City = "Houston", CompanyName = "Walmart", DateCreated = DateTime.Now, DateUpdated = DateTime.Now, EmailAddress = "walmart@walmart.com", PhoneNumber = "5653456", State = "Texas", StreetAddress = "321 Broadway St", UserCreatedId = "2", UserUpdatedId = "2", ZipCode = "77583" }
            //);


        }


        //  new Job { JobId = 2, City = "Dallas", ClickId = 1, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, Description = "Test2", EmailAddress = "Test2@Test.com", JobBudget = 1000.99, JobTitle = "Programmer", PhoneNumber = "2345678", RequiredEducationSkills = "Not lot", RequiredProgrammingSkills = "A lot", SalaryMin = 132524, SalaryMax = 928542, StartDate = DateTime.Now.AddDays(200), EndDate = DateTime.Now.AddDays(500), State = "Texas", JobStatusId = 1, StreetAddress = "321 Uhh Blvd", UserCreatedId = "2", UserId = "2", UserUpdatedId = "2", YearsExperience = 2, ZipCode = "22222", CompanyName = "Yahoo" }



        //);
        //   context.JobStatuses.AddOrUpdate(
        //       p => p.Name,
        //       new JobStatus { JobStatusId = 1, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, Name = "Programmer", UserCreatedId = "1", UserUpdatedId = "1" },
        //       new JobStatus { JobStatusId = 2, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, Name = "Programmer", UserCreatedId = "2", UserUpdatedId = "2" }
        //       );

        //   context.Messages.AddOrUpdate(
        //       p => p.MessageId,
        //       new Message { MessageId = 1, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, MsgBody = "Ayyy", MsgSubject = "U want a job lol", UserCreatedId = "1", UserId = "1", UserUpdatedId = "1" },
        //       new Message { MessageId = 2, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, MsgBody = "ur not hired", MsgSubject = "sucks 2 suck", UserUpdatedId = "2", UserId = "2", UserCreatedId = "2" }

        //       );
        //   context.Resumes.AddOrUpdate(
        //       p => p.ResumeId,
        //       new Resume { ResumeId = 1, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, File = "somefileurl", UserCreatedId = "1", UserId = "1", UserUpdatedId = "1" },
        //       new Resume { ResumeId = 2, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, File = "somefileurl2", UserCreatedId = "2", UserId = "2", UserUpdatedId = "2" }
        //       );
        //   context.Clicks.AddOrUpdate(
        //       p => p.ClickId,
        //       new Click { ClickId = 1, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, IpAddress = "192.168.0.1", JobId = 1, NumOfClicks = 5, UserCreatedId = "1", UserUpdatedId = "1" },
        //       new Click { ClickId = 2, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, IpAddress = "192.168.0.1", JobId = 2, NumOfClicks = 3, UserCreatedId = "2", UserUpdatedId = "2" }

        //       );



        //}
    }
}