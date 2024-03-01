using System;
using System.Collections.Generic;

namespace Backend_RoomAr.ApplicationData;

public partial class FurnituresColor
{
    public int Id { get; set; }

    public int FurnitureId { get; set; }

    public int ColorId { get; set; }

    public virtual Color Color { get; set; } = null!;

    public virtual Furniture Furniture { get; set; } = null!;
}
