using System;
using System.Collections.Generic;

namespace Backend_RoomAr.ApplicationData;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? PhoneNum { get; set; }

    public string Email { get; set; } = null!;

    public string? Password { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
