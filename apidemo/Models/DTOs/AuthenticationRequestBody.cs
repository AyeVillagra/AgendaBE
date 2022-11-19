using System.ComponentModel.DataAnnotations;

namespace apidemo.DTOs
{
    public class AuthenticationRequestBody
    {
        [MaxLength(500)]
        public string UserName { get; set; }
        [MaxLength(500)]
        public string Password { get; set; }
    }
}
