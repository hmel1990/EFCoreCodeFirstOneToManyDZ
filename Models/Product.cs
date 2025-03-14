using System;
using System.Collections.Generic;

namespace EFCoreCodeFirstOneToManyDZ;


public partial class Product
{
    public int Id { get; set; }

    public int? IdCategory { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public int? Quantity { get; set; }

    public byte[]? ProductPicture { get; set; }

    public string? ProductPicturePath { get; set; }

    public int? IdProducer { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual Producer? IdProducerNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
