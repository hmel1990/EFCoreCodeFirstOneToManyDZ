using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirstOneToManyDZ.Models;

public partial class Review
{
    [Key]
    public int Id { get; set; }

    [StringLength(500, ErrorMessage = "длина сообщения не может превышать 500 символов")]
    public string? Text { get; set; }

    public int? IdProduct { get; set; }

    public int? IdUser { get; set; }

    public virtual Product? IdProductNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }

    
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
