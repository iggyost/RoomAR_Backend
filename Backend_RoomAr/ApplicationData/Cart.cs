using System;
using System.Collections.Generic;

namespace Backend_RoomAr.ApplicationData;

public partial class Cart
{
    public int CartId { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<FurnituresCart> FurnituresCarts { get; set; } = new List<FurnituresCart>();

    public virtual User User { get; set; } = null!;
}
