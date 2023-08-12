using EFlazyLoadingDemo.Contexts;
using EFlazyLoadingDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFlazyLoadingDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KursAdvancedDbContext db;

            db = new KursAdvancedDbContext();
            var ogrenciler1 = db.Ogrenci.ToList();
            Yazdir1(ogrenciler1);
            //Yazdir2(ogrenciler);

            Console.WriteLine();

            db = new KursAdvancedDbContext();
            ogrenciler1 = db.Ogrenci.Include(ogrenci => ogrenci.Bolum).ToList();
            Yazdir1(ogrenciler1);
            Yazdir2(ogrenciler1);

            Console.WriteLine();

            db = new KursAdvancedDbContext();
            ogrenciler1 = db.Ogrenci.Include(ogrenci => ogrenci.Bolum).Include(ogrenci => ogrenci.OgrenciDers).ToList();
            Yazdir1(ogrenciler1);
            Yazdir2(ogrenciler1);

            Console.WriteLine();

            db = new KursAdvancedDbContext();
            ogrenciler1 = db.Ogrenci.Include(ogrenci => ogrenci.Bolum).Include(ogrenci => ogrenci.OgrenciDers).ThenInclude(ogrenciDers => ogrenciDers.Ders).ToList();
            Yazdir1(ogrenciler1);
            Yazdir2(ogrenciler1);

            Console.WriteLine();

            db = new KursAdvancedDbContext();
            var ogrenciler2 = db.Ogrenci.Select(ogrenci => new OgrenciDTO()
            {
                BolumAdi = ogrenci.Bolum.Adi,
                OgrenciDersSayisi = ogrenci.OgrenciDers.Count,
                DersSayisi = ogrenci.OgrenciDers.Select(ogrenciDers => ogrenciDers.Ders).Count()
            }).ToList();
            Yazdir3(ogrenciler2);
        }

        static void Yazdir1(List<Ogrenci> ogrenciler)
        {
            int dersSayisi;
            foreach (var ogrenci in ogrenciler)
            {
                if (ogrenci.Bolum is not null)
                    Console.Write("Bölüm: " + ogrenci.Bolum.Adi + ", ");
                else
                    Console.Write("Bölüm: -, ");
                if (ogrenci.OgrenciDers is not null)
                    Console.Write("ÖğrenciDers Sayısı: " + ogrenci.OgrenciDers.Count + ", ");
                else
                    Console.Write("ÖğrenciDers Sayısı: -, ");
                dersSayisi = 0;
                foreach (var ogrenciDers in ogrenci.OgrenciDers)
                {
                    if (ogrenciDers.Ders is not null)
                        dersSayisi++;
                }
                Console.Write("Ders Sayısı: " + dersSayisi);
                Console.WriteLine();
            }
        }

        static void Yazdir2(List<Ogrenci> ogrenciler)
        {
            foreach(var ogrenci in ogrenciler)
                Console.WriteLine("Bölüm: " + ogrenci.Bolum.Adi + ", ÖgrenciDers Sayısı: " + ogrenci.OgrenciDers.Count +
                    ", Ders Sayısı: " + ogrenci.OgrenciDers.Select(ogrenciDers => ogrenciDers.Ders).Count());
        }

        static void Yazdir3(List<OgrenciDTO> ogrenciler)
        {
            foreach (var ogrenci in ogrenciler)
                Console.WriteLine("Bölüm: " + ogrenci.BolumAdi + ", ÖgrenciDers Sayısı: " + ogrenci.OgrenciDersSayisi +
                    ", Ders Sayısı: " + ogrenci.DersSayisi);
        }
    }

    class OgrenciDTO
    {
        public string BolumAdi { get; set; }

        public int OgrenciDersSayisi { get; set; }

        public int DersSayisi { get; set; }
    }
}