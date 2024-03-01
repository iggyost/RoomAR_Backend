using System;
using System.Collections.Generic;

namespace Backend_RoomAr.ApplicationData;

public partial class FurnituresCart
{
    public int Id { get; set; }

    public int CartId { get; set; }

    public int FurnitureId { get; set; }

    public int Count { get; set; }

    public decimal? TotalCost { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public virtual Furniture Furniture { get; set; } = null!;
}
