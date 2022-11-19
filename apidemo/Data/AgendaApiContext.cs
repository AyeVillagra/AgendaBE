using apidemo.Entities;
using Microsoft.EntityFrameworkCore;

// todo lo que va en el contexto son instrucciones que le doy al ORM para que cuando corro la
//aplicación, el ORM mapee mis entidades a tablas. 
// lo uso para dar la instrucciones a EntityFramework p q levante la BD. Y para  acceder a los datos; por eso
// hay que inyectarlo al Repository

namespace apidemo.Data
{
    public class AgendaApiContext : DbContext
    {
        // especifico las entidades que van a ser tablas
        public DbSet<User> Users { get; set; } 
        public DbSet<Contact> Contacts { get; set; } 

        // constructor
        public AgendaApiContext(DbContextOptions<AgendaApiContext> options) : base(options)// indica que llama al constructor de la clase padre o base
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User karen = new User()
            {
                Email = "asasju@hsyso.com",
                Name = "Karen",
                Password = "passwordsegura",
                Id = 1
            };
            User luis = new User()
            {
                Email = "juytgsju@hsyso.com",
                Name = "Luis",
                Password = "passwordinsegura",
                Id = 2
            };


            Contact jaimitoC = new Contact()
            {
                Name = "Jaimito",
                CelularNumber = 3452692,
                Id = 1,
                Description = "plomero",
                UserId = karen.Id
            };
            Contact pepeC = new Contact()
            {
                Name = "Pedro",
                TelephoneNumber = 24516790,
                Description = "Hermano",
                Id = 2,
                UserId = luis.Id
            };

            modelBuilder.Entity<Contact>().HasData(jaimitoC, pepeC);
            modelBuilder.Entity<User>().HasData(karen, luis);

            //tabla de la relación. Un usuario tiene muchos contactos en el elemento Contacts
            // con un contacto en User
            modelBuilder.Entity<User>().HasMany<Contact>(u => u.Contacts).WithOne(c => c.User);

            base.OnModelCreating(modelBuilder);
        }
    }
}
