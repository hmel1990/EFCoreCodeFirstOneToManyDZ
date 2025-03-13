using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirstOneToManyDZ.Models;

public partial class Order
{
    public int Id { get; set; }

    [ForeignKey("Product")]
    public int? IdProduct { get; set; }

    public int? Quantity { get; set; }

    public virtual Product? IdProductNavigation { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
