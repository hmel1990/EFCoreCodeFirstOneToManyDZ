using System;
using System.Collections.Generic;

namespace EFCoreCodeFirstOneToManyDZ.Models;

public partial class Producer
{
    public int Id { get; set; }

    public int? Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
