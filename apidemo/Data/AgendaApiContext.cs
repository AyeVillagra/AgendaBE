using apidemo.Entities;
using apidemo.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System;

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
                Id = 1,
                Name = "Karen",
                LastName = "Lasot",
                Password = "Pa$$w0rd",
                Email = "karenbailapiola@gmail.com",
                UserName = "karenpiola",
                Rol = Rol.Admin
            };
            User luis = new User()
            {
                Id = 2,
                Name = "Luis Gonzalez",
                LastName = "Gonzales",
                Password = "lamismadesiempre",
                Email = "elluismidetotoras@gmail.com",
                UserName = "luismitoto",
                Rol = Rol.User
            };

            Contact jaimitoC = new Contact()
            {
                Id = 1,
                Name = "Jaimito",
                CelularNumber = 341457896,
                Description = "Plomero",
                TelephoneNumber = null,
                UserId = karen.Id
                
            };

            Contact pepeC = new Contact()
            {
                Id = 2,
                Name = "Pepe",
                CelularNumber = 34156978,
                Description = "Papa",
                TelephoneNumber = 422568,
                UserId = luis.Id,
            };

            Contact mariaC = new Contact()
            {
                Id = 3,
                Name = "Maria",
                CelularNumber = 011425789,
                Description = "Jefa",
                TelephoneNumber = null,
                UserId = karen.Id,
            };

            modelBuilder.Entity<User>().HasData(
                karen, luis);

            modelBuilder.Entity<Contact>().HasData(
                 jaimitoC, pepeC, mariaC
                 );

            ////tabla de la relación. Un usuario tiene muchos contactos en el elemento Contacts
            //// con un contacto en User

            modelBuilder.Entity<User>()
              .HasMany<Contact>(u => u.Contacts)
              .WithOne(c => c.User);

            base.OnModelCreating(modelBuilder);
        }
    }
}   

            
           
   
