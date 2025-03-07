using System;
using System.Collections.Generic;

namespace EFCoreCodeFirstOneToManyDZ.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Access { get; set; } = null!;

    public byte[]? ProfilePicture { get; set; }

    public string? PicturePath { get; set; }

    public int? IdOrder { get; set; }

    public int? IdReview { get; set; }

    public virtual Order? IdOrderNavigation { get; set; }

    public virtual Review? IdReviewNavigation { get; set; }
}
