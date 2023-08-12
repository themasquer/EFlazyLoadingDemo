using System;
using System.Collections.Generic;

namespace EFlazyLoadingDemo.Entities;

public partial class OgrenciDers
{
    public int Id { get; set; }

    public int OgrenciId { get; set; }

    public int DersId { get; set; }

    public virtual Ders Ders { get; set; } = null!;

    public virtual Ogrenci Ogrenci { get; set; } = null!;
}
