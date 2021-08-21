using System;
using System.Data.Entity;
using System.Linq;
using DTO;
namespace DAL
{
    public class QlsvContext : DbContext
    {
        // Your context has been configured to use a 'QlsvContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DAL.QlsvContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'QlsvContext' 
        // connection string in the application configuration file.
        public QlsvContext()
            : base("name=QlsvContext")
        {
            Database.SetInitializer<QlsvContext>(new CreateDB());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Add(new DataTypePropertyAttributeConvention());
        }
        public DbSet<SV> SVs { get; set; }
        public DbSet<LSH> LSHs { get; set; }
    }   
        
   
}