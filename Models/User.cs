using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirstOneToManyDZ.Models;

public partial class User
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Имя обязательно для заполнения")]
    [StringLength(100, ErrorMessage = "Имя не может превышать 100 символов")]
    public string Username { get; set; } = null!;
    [Required(ErrorMessage = "Имя обязательно для заполнения")]
    public string Password { get; set; } = null!;

    public string Access { get; set; } = null!;

    public byte[]? ProfilePicture { get; set; }

    public string? PicturePath { get; set; }

    public int? IdOrder { get; set; }

    public int? IdReview { get; set; }

    public virtual Order? IdOrderNavigation { get; set; }

    public virtual Review? IdReviewNavigation { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
