using System;
using System.Collections.Generic;

namespace EFCoreCodeFirstOneToManyDZ;

public partial class Order
{
    public int Id { get; set; }

    public int? IdProduct { get; set; }

    public int? Quantity { get; set; }

    public virtual Product? IdProductNavigation { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
