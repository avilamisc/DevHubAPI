namespace DevHub.API.Migrations
{
    using Models;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DevHub.API.Models.DevHubContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DevHub.API.Models.DevHubContext";
        }

        protected override void Seed(DevHubContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            CreateDataDefaultForCaterogies(context.Categories);
            CreateDataDefaultForCourses(context.Courses);
            CreateDataDefaultForVideos(context.Videos);
            CreateDataDefaultForComments(context.Comments);

        }

        private void CreateDataDefaultForCaterogies(DbSet<Category> table)
        {
            table.AddOrUpdate(x => x.Id,
                new Category() { Id = 1, Name = "Android", Color = "#F00" },
                new Category() { Id = 2, Name = "Javascript", Color = "#F00" },
                new Category() { Id = 3, Name = "Java", Color = "#F00" },
                new Category() { Id = 4, Name = "C#", Color = "#F00" },
                new Category() { Id = 5, Name = "HTML5 & CSS3", Color = "#F00" }
            );
        }

        private void CreateDataDefaultForCourses(DbSet<Course> table)
        {
            table.AddOrUpdate(x => x.Id,
                new Course() { Id = 1, CategoryId = 1, Title = "Android from scratch", IsValid = true },
                new Course() { Id = 2, CategoryId = 1, Title = "Android with Material Design", IsValid = true },
                new Course() { Id = 3, CategoryId = 1, Title = "Android advanced", IsValid = true },
                new Course() { Id = 4, CategoryId = 1, Title = "Android for dummies", IsValid = false },
                new Course() { Id = 5, CategoryId = 2, Title = "Javascript getting started", IsValid = true },
                new Course() { Id = 6, CategoryId = 2, Title = "Javascript design patterns", IsValid = true },
                new Course() { Id = 7, CategoryId = 2, Title = "Javascript MVC", IsValid = true },
                new Course() { Id = 8, CategoryId = 2, Title = "Javascript oriented object programming", IsValid = true },
                new Course() { Id = 9, CategoryId = 2, Title = "Javascript frameworks", IsValid = false },
                new Course() { Id = 10, CategoryId = 3, Title = "Java for Web", IsValid = true },
                new Course() { Id = 11, CategoryId = 3, Title = "Java for desktop", IsValid = true },
                new Course() { Id = 12, CategoryId = 3, Title = "Java for mobile", IsValid = true },
                new Course() { Id = 13, CategoryId = 4, Title = "C# from scratch", IsValid = true },
                new Course() { Id = 14, CategoryId = 4, Title = "C# .Net framework", IsValid = true },
                new Course() { Id = 15, CategoryId = 4, Title = "C# .Net WEB API 2", IsValid = true },
                new Course() { Id = 16, CategoryId = 4, Title = "C# for mobile", IsValid = false },
                new Course() { Id = 17, CategoryId = 5, Title = "HTML5 & CSS3 getting started", IsValid = true },
                new Course() { Id = 18, CategoryId = 5, Title = "CSS3 pushing the limits", IsValid = true },
                new Course() { Id = 19, CategoryId = 5, Title = "CSS3 Flex box", IsValid = true },
                new Course() { Id = 20, CategoryId = 5, Title = "HTML5 Canvas", IsValid = true },
                new Course() { Id = 21, CategoryId = 5, Title = "HTML5 web games", IsValid = false }
            );
        }

        private void CreateDataDefaultForVideos(DbSet<Video> table)
        {
            table.AddOrUpdate(x => x.Id,
                new Video { Id = 1, CourseId = 1, Title = "Android: setting up the environment", Code = "jSSMfRhi7SI", Duration = 2629, Lesson = 1 },
                new Video { Id = 2, CourseId = 1, Title = "Android: life cycle", Code = "XQNzv_T_14Y", Duration = 2049, Lesson = 2 },
                new Video { Id = 3, CourseId = 1, Title = "Android: Activities", Code = "vp0xVzZjU0I", Duration = 601, Lesson = 3 },

                new Video { Id = 4, CourseId = 2, Title = "Android MD: principes of Material Design", Code = "jSSMfRhi7SI", Duration = 2629, Lesson = 1 },
                new Video { Id = 5, CourseId = 2, Title = "Android MD: design patterns Material Design", Code = "jSSMfRhi7SI", Duration = 2629, Lesson = 2 },
                new Video { Id = 6, CourseId = 2, Title = "Android MD: effects on Material Design", Code = "jSSMfRhi7SI", Duration = 2629, Lesson = 3 },

                new Video { Id = 7, CourseId = 5, Title = "Javascript: how to start", Code = "jSSMfRhi7SI", Duration = 2629, Lesson = 1 },
                new Video { Id = 8, CourseId = 5, Title = "Javascript: context, variables", Code = "jSSMfRhi7SI", Duration = 2629, Lesson = 2 },
                new Video { Id = 9, CourseId = 5, Title = "Javascript: debug console & tools", Code = "jSSMfRhi7SI", Duration = 2629, Lesson = 3 },

                new Video { Id = 10, CourseId = 9, Title = "AngularJS: getting start", Code = "jSSMfRhi7SI", Duration = 2629, Lesson = 1 },
                new Video { Id = 11, CourseId = 9, Title = "AngularJS: $scope", Code = "jSSMfRhi7SI", Duration = 2629, Lesson = 2 },
                new Video { Id = 12, CourseId = 9, Title = "AngularJS: MVVM pattern", Code = "jSSMfRhi7SI", Duration = 2629, Lesson = 3 },

                new Video { Id = 22, CourseId = 11, Title = "Java: SDK", Code = "jSSMfRhi7SI", Duration = 2629, Lesson = 1 },
                new Video { Id = 23, CourseId = 11, Title = "Java: OBDC for Oracle Database", Code = "jSSMfRhi7SI", Duration = 2629, Lesson = 2 },
                new Video { Id = 24, CourseId = 11, Title = "Java: Swing", Code = "jSSMfRhi7SI", Duration = 2629, Lesson = 3 },


                new Video { Id = 13, CourseId = 15, Title = "Web API 2: Entity Framework", Code = "jSSMfRhi7SI", Duration = 2629, Lesson = 1 },
                new Video { Id = 14, CourseId = 15, Title = "Web API 2: code first aproach", Code = "jSSMfRhi7SI", Duration = 2629, Lesson = 2 },
                new Video { Id = 15, CourseId = 15, Title = "Web API 2: Dependency Injection", Code = "jSSMfRhi7SI", Duration = 2629, Lesson = 3 },

                new Video { Id = 16, CourseId = 17, Title = "HTML5 & CSS3: W3C standar", Code = "jSSMfRhi7SI", Duration = 2629, Lesson = 1 },
                new Video { Id = 17, CourseId = 17, Title = "HTML5 & CSS3: HTML5, new syntax", Code = "jSSMfRhi7SI", Duration = 2629, Lesson = 2 },
                new Video { Id = 18, CourseId = 17, Title = "HTML5 & CSS3: CSS3, new syntax", Code = "jSSMfRhi7SI", Duration = 2629, Lesson = 3 },

                new Video { Id = 19, CourseId = 18, Title = "CSS3: transitions and effects", Code = "jSSMfRhi7SI", Duration = 2629, Lesson = 1 },
                new Video { Id = 20, CourseId = 18, Title = "CSS3: pseudoelements", Code = "jSSMfRhi7SI", Duration = 2629, Lesson = 2 },
                new Video { Id = 21, CourseId = 18, Title = "CSS3: preprocessors", Code = "jSSMfRhi7SI", Duration = 2629, Lesson = 3 },


                new Video { Id = 25, CourseId = 19, Title = "FlexBox: grid", Code = "jSSMfRhi7SI", Duration = 2629, Lesson = 1 },
                new Video { Id = 26, CourseId = 19, Title = "FlexBox: compatibilities", Code = "jSSMfRhi7SI", Duration = 2629, Lesson = 2 },
                new Video { Id = 27, CourseId = 19, Title = "FlexBox: prefixes", Code = "jSSMfRhi7SI", Duration = 2629, Lesson = 3 }
            );
        }

        private void CreateDataDefaultForComments(DbSet<Comment> table)
        {
            table.AddOrUpdate(
                new Comment { CourseId = 1, Message = "This course is amazing! keep up bro!" },
                new Comment { CourseId = 2, Message = "I'm learning a lot, thks man! :)" },
                new Comment { CourseId = 5, Message = "From my point of view, this course is ok but it should go faster and deeper about some concepts. Anyway, good job!" },
                new Comment { CourseId = 11, Message = "The quality of the videos could be better" },
                new Comment { CourseId = 15, Message = "One of the best course I saw about EF and DI. Nice one!" },
                new Comment { CourseId = 17, Message = "I though I was developing for HTML5 standar but after this course I just realized that I didn't" },
                new Comment { CourseId = 18, Message = "OMG finally a fucking good explication of how to implement transitions on CSS..." },
                new Comment { CourseId = 19, Message = "I never used flexboz but I gonna start right now" },
                new Comment { CourseId = 19, Message = "How was possible my life without this??" },
                new Comment { CourseId = 19, Message = "+10 man, nice tech ;)" }
            );
        }

    }
}
