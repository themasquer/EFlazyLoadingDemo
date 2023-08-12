using System;
using System.Collections.Generic;

namespace EFlazyLoadingDemo.Entities;

public partial class Ders
{
    public int Id { get; set; }

    public string Adi { get; set; } = null!;

    public string? Icerik { get; set; }

    public virtual ICollection<OgrenciDers> OgrenciDers { get; set; } = new List<OgrenciDers>();
}
