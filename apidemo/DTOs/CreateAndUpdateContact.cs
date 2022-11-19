using apidemo.Entities;
using System.ComponentModel.DataAnnotations;

namespace apidemo.DTOs
{
    public class CreateAndUpdateContact
    {
        [Required]
        public string Name { get; set; }
        public int? CelularNumber { get; set; }
        public int? TelephoneNumber { get; set; }
        public string Description = String.Empty;
        public User? User;
    }
}