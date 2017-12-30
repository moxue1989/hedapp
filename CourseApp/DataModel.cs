namespace CourseApp
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataModel : DbContext
    {
        // Your context has been configured to use a 'DataModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CourseApp.DataModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DataModel' 
        // connection string in the application configuration file.
        public DataModel()
            : base("name=DataModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Course> Courses { get; set; }
         public virtual DbSet<User> Users { get; set; }
         public virtual DbSet<Institution> Institutions { get; set; }
         public virtual DbSet<Permission> Permissions { get; set; }
         public virtual DbSet<OfferingType> OfferingTypes { get; set; }
         public virtual DbSet<AvailiabilityType> AvailiabilityTypes { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }

    public class Institution
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Permission
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public virtual Institution Institution { get; set; }
    }

    public class AvailiabilityType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CourseCode { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Credits { get; set; }
    }

    public class OfferingType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}