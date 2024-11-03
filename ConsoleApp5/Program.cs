using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace ÖğrenciYönetimSistemi
{
    class Öğrenci /*her bir öğrenci için numara, ad soyad ve bir sonraki öğrenciyi gösteren bir düğüm oluşturmak için*/
    {
        public int Numara { get; set; }
        public string AdSoyad { get; set; }
        public Öğrenci Sonraki { get; set; }
    }

    class Program
    {
        static Öğrenci headnode;

        static void Main(string[] args)
        {
            Console.WriteLine("Öğrenci Yönetim Sistemine Hoş Geldiniz!");

            while (true) /*seçim yaptırması için çıkışa basana kadar çıkmaya devam edecek*/
            {
                Console.WriteLine("\nLütfen yapmak istediğiniz işlemi seçin:");
                Console.WriteLine("1. Yeni Öğrenci Ekle");
                Console.WriteLine("2. Öğrenci Sil");
                Console.WriteLine("3. Öğrenci Listesini Sıralı Olarak Yazdır");
                Console.WriteLine("4. Tüm Öğrenci Bilgilerini Yazdır");
                Console.WriteLine("5. Çıkış");

                int secim = Convert.ToInt32(Console.ReadLine());

                switch (secim)
                {
                    case 1:
                        YeniÖğrenciEkle();
                        break;
                    case 2:
                        ÖğrenciSil();
                        break;
                    case 3:
                        ÖğrenciListesiniSıralıYazdır();
                        break;
                    case 4:
                        TümÖğrenciBilgileriniYazdır();
                        break;
                    case 5:
                        Console.WriteLine("Çıkış yapılıyor...");
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim!");
                        break;
                }
            }
        }

        static void YeniÖğrenciEkle() /*kullanıcıdan veri alır liste boşsa başa ekler listede birileri varsa sona*/
        {
            Console.WriteLine("Yeni öğrencinin numarasını girin:");
            int numara = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Yeni öğrencinin adını ve soyadını girin:");
            string adSoyad = Console.ReadLine();

            Öğrenci yeniÖğrenci = new Öğrenci { Numara = numara, AdSoyad = adSoyad };

            if (headnode == null)
            {
                headnode = yeniÖğrenci;
            }
            else
            {
                Öğrenci mevcutÖğrenci = headnode;
                while (mevcutÖğrenci.Sonraki != null)
                {
                    mevcutÖğrenci = mevcutÖğrenci.Sonraki;
                }
                mevcutÖğrenci.Sonraki = yeniÖğrenci;
            }

            Console.WriteLine("Öğrenci başarıyla eklendi.");
        }

        static void ÖğrenciSil() /*numarasını yazdığımız öğrencinin silinmesi*/
        {
            Console.WriteLine("Silmek istediğiniz öğrencinin numarasını girin:");
            int silinecekNumara = Convert.ToInt32(Console.ReadLine());

            if (headnode == null)
            {
                Console.WriteLine("Liste boş.");
                return;
            }

            if (headnode.Numara == silinecekNumara)
            {
                headnode = headnode.Sonraki;
                Console.WriteLine("Öğrenci başarıyla silindi.");
                return;
            }

            Öğrenci öncekiÖğrenci = headnode;
            Öğrenci mevcutÖğrenci = headnode.Sonraki;

            while (mevcutÖğrenci != null)
            {
                if (mevcutÖğrenci.Numara == silinecekNumara)
                {
                    öncekiÖğrenci.Sonraki = mevcutÖğrenci.Sonraki;
                    Console.WriteLine("Öğrenci başarıyla silindi.");
                    return;
                }
                öncekiÖğrenci = mevcutÖğrenci;
                mevcutÖğrenci = mevcutÖğrenci.Sonraki;
            }

            Console.WriteLine("Belirtilen numaraya sahip öğrenci bulunamadı.");
        }

        static void ÖğrenciListesiniSıralıYazdır() /*kullanıcıdan aldığı öğrenci numarasını küçükten büyüğe sıralaması*/
        {
            if (headnode == null)
            {
                Console.WriteLine("Liste boş.");
                return;
            }

            List<Öğrenci> öğrenciListesi = new List<Öğrenci>();
            Öğrenci mevcutÖğrenci = headnode;
            while (mevcutÖğrenci != null)
            {
                öğrenciListesi.Add(mevcutÖğrenci);
                mevcutÖğrenci = mevcutÖğrenci.Sonraki;
            }

            öğrenciListesi.Sort((x, y) => x.Numara.CompareTo(y.Numara));

            Console.WriteLine("Sıralı Öğrenci Listesi:");
            foreach (Öğrenci öğrenci in öğrenciListesi)
            {
                Console.WriteLine($"Numara: {öğrenci.Numara}, Ad Soyad: {öğrenci.AdSoyad}");
            }
        }

        static void TümÖğrenciBilgileriniYazdır() /*kullanıcıdan aldığı verileri direk aldığı sıraya göre yazdırması*/
        {
            if (headnode == null)
            {
                Console.WriteLine("Liste boş.");
                return;
            }

            Console.WriteLine("Tüm Öğrenci Bilgileri:");
            Öğrenci mevcutÖğrenci = headnode;
            while (mevcutÖğrenci != null)
            {
                Console.WriteLine($"Numara: {mevcutÖğrenci.Numara}, Ad Soyad: {mevcutÖğrenci.AdSoyad}");
                mevcutÖğrenci = mevcutÖğrenci.Sonraki;
            }
        }
    }
}

