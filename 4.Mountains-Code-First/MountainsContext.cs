using System.Data.Entity;

namespace _4.Mountains_Code_First
{
    public class MountainsContext : DbContext
    {
        // Your context has been configured to use a 'MountainsContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // '_4.Mountains_Code_First.MountainsContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MountainsContext' 
        // connection string in the application configuration file.
        public MountainsContext()
            : base("name=MountainsContext")
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Mountain> Mountains { get; set; }
        public virtual DbSet<Peak> Peaks { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}