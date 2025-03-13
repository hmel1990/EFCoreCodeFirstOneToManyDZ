using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCoreCodeFirstOneToManyDZ.Models;

public partial class Product
{
    [Key]
    public int Id { get; set; }

    public int? IdCategory { get; set; }

    [Required(ErrorMessage = "Название обязательно для заполнения")]
    [StringLength(100, ErrorMessage = "Имя не может превышать 100 символов")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "цена обязательна для заполнения")]
    public double? Price { get; set; }

    [Range(0, 100, ErrorMessage = "количество должно быть в пределах от 0 до 1000")]
    public int? Quantity { get; set; }

    public byte[]? ProductPicture { get; set; }

    public string? ProductPicturePath { get; set; }

    public int? IdProducer { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual Producer? IdProducerNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
