using System;
using System.Collections.Generic;

namespace EFCoreCodeFirstOneToManyDZ.Models;

public partial class Review
{
    public int Id { get; set; }

    public string? Text { get; set; }

    public int? IdProduct { get; set; }

    public int? IdUser { get; set; }

    public virtual Product? IdProductNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
