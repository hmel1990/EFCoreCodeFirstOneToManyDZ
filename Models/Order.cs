using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirstOneToManyDZ.Models;

public partial class Order
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Product")]
    public int? IdProduct { get; set; }

    [Range(0, 100, ErrorMessage = "количество должно быть в пределах от 0 до 1000")]
    public int? Quantity { get; set; }

    public virtual Product? IdProductNavigation { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
