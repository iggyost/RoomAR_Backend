using System;
using System.Collections.Generic;

namespace Backend_RoomAr.ApplicationData;

public partial class FurnituresModel
{
    public int FurnitureModelId { get; set; }

    public int FurnitureId { get; set; }

    public string Model { get; set; } = null!;

    public virtual Furniture Furniture { get; set; } = null!;
}
