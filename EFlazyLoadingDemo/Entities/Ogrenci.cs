using System;
using System.Collections.Generic;

namespace EFlazyLoadingDemo.Entities;

public partial class Ogrenci
{
    public int Id { get; set; }

    public string Adi { get; set; } = null!;

    public string Soyadi { get; set; } = null!;

    public int? OgrenciNo { get; set; }

    public int BolumId { get; set; }

    public bool MezunMu { get; set; }

    public int Cinsiyeti { get; set; }

    public virtual Bolum Bolum { get; set; } = null!;

    public virtual ICollection<OgrenciDers> OgrenciDers { get; set; } = new List<OgrenciDers>();
}
