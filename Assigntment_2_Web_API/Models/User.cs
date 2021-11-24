using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        [Key, MaxLength(21)]
        public string UserName { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string Password { get; set; }
    }
}