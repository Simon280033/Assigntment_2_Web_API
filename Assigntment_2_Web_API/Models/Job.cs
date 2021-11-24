using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Job
    {
        [Key, MaxLength(256)]
        public string JobTitle { get; set; }
        [Required]
        public int Salary { get; set; }
    }
}