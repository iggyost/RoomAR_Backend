using System;
using System.Collections.Generic;

namespace Backend_RoomAr.ApplicationData;

public partial class Photo
{
    public int PhotoId { get; set; }

    public string Photo1 { get; set; } = null!;

    public virtual ICollection<FurnituresPhoto> FurnituresPhotos { get; set; } = new List<FurnituresPhoto>();
}
