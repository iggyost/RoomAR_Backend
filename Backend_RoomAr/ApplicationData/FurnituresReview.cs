using System;
using System.Collections.Generic;

namespace Backend_RoomAr.ApplicationData;

public partial class FurnituresReview
{
    public int Id { get; set; }

    public int FurnitureId { get; set; }

    public int ReviewId { get; set; }

    public virtual Furniture Furniture { get; set; } = null!;

    public virtual Review Review { get; set; } = null!;
}
