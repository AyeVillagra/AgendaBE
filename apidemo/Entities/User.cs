using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apidemo.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // nos hace un ID único por sí solo - autogenerado
        public int Id { get; set; }
        public string Name { get; set; }
        public string? UserName { get; set; }
        [Required]
        public string Email { get; set; }
        public string? LastName { get; set; }
        public string Password { get; set; }        
        public ICollection<Contact>? Contacts {get; set;}

    }
}
