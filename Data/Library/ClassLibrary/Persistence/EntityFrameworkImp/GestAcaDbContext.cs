using System;
using System.Data.Entity;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using GestAca.Entities;



namespace GestAca.Persistence
{
    public class GestAcaDbContext : DbContextISW
    {
        public GestAcaDbContext() : base("Name=GestAcaDbConnection") //this is the connection string name
        {
            /*
            See DbContext.Configuration documentation
            */
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        static GestAcaDbContext()
        {
            //Database.SetInitializer<BikeClubDbContext>(new CreateDatabaseIfNotExists<BikeClubDbContext>());
            Database.SetInitializer<GestAcaDbContext>(new DropCreateDatabaseIfModelChanges<GestAcaDbContext>());
            //Database.SetInitializer<BikeClubDbContext>(new DropCreateDatabaseAlways<BikeClubDbContext>());
            //Database.SetInitializer<BikeClubDbContext>(new BikeClubDbContextInitializer());
            //Database.SetInitializer(new NullDatabaseInitializer<BikeClubDbContext>());
        }

        // DbSets for persistent classes in your case study
        public IDbSet<Absence> Absences { get; set; }
        public IDbSet<Enrollment> Enrollments { get; set; }
        public IDbSet<Classroom> Classrooms { get; set; }
        public IDbSet<TaughtCourse> TaughtCourses { get; set; }
        public IDbSet<Course> Courses { get; set; }
        public IDbSet<Person> People { get; set; }
        public IDbSet<Student> Students { get; set; }
        public IDbSet<Teacher> Teachers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Con fluentAPI evita el problema de borrado en cascada por el Required en la propiedad Owner de Content

        }

        // Generic method to clear all the data (except some relations if needed)
         public override void RemoveAllData()
        {
            clearSomeRelationships();

            base.RemoveAllData(); 
        }

        // Sometimes it is needed to clear some relationships explicitly 
        private void clearSomeRelationships()
        {
//            SaveChanges();
        }

    }

}
