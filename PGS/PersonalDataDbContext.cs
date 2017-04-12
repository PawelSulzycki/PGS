using System.Data.Entity;

namespace PGS
{
    public class PersonalDataDbContext : DbContext
    {
        public PersonalDataDbContext() : base("PersonalData")
        {
            
        }  
        
        public DbSet<PersonalData> PersonalData { get; set; }
    }
}