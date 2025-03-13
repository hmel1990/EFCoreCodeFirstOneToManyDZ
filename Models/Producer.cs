using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCoreCodeFirstOneToManyDZ.Models;

public partial class Producer
{
    [Key]

    public int Id { get; set; }

    [Required(ErrorMessage = "Название обязательно для заполнения")]
    [StringLength(100, ErrorMessage = "Название не может превышать 100 символов")]
    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
