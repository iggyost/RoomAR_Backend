using System;
using System.Collections.Generic;

namespace Backend_RoomAr.ApplicationData;

public partial class Furniture
{
    public int FurnitureId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Cost { get; set; }

    public string? Description { get; set; }

    public string? CoverPhoto { get; set; }

    public double? Width { get; set; }

    public double? Height { get; set; }

    public double? Length { get; set; }

    public double? Weight { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<FurnituresCart> FurnituresCarts { get; set; } = new List<FurnituresCart>();

    public virtual ICollection<FurnituresColor> FurnituresColors { get; set; } = new List<FurnituresColor>();

    public virtual ICollection<FurnituresModel> FurnituresModels { get; set; } = new List<FurnituresModel>();

    public virtual ICollection<FurnituresPhoto> FurnituresPhotos { get; set; } = new List<FurnituresPhoto>();

    public virtual ICollection<FurnituresReview> FurnituresReviews { get; set; } = new List<FurnituresReview>();
}
