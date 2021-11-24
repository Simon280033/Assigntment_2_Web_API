using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models {
public class Adult : Person {
    [Key]
    public Job Job { get; set; }
}
}