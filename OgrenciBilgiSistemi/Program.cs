namespace OgrenciBilgiSistemi
{
    internal class Program
    {
        static string Soru(string soru) //METOD İLE SORU SORMA KISMI
        {
            Console.Write(soru);
            return Console.ReadLine();
        }

        class Ogrenci //ÖĞRENCİ BİLGİ GİRİŞİ 
        {
            public string Isim { get; set; }
            public string SoyIsim { get; set; }
            public DateOnly DTarihi { get; set; }
            public string Cinsiyet { get; set; }
            public int Numara { get; set; }
        }
        static List<Ogrenci> ogrenciler = new List<Ogrenci>(); //ÖĞRENCİ KAYIT TUTMA ALANI
        static List<Ogrenci> OgrenciArama(string isim, int numara)//ÖĞRENCİ ARAMA DÖNDÜRME ALANI
        {
            List<Ogrenci>aramaListesi = new List<Ogrenci>();
            foreach (var listelenen in ogrenciler)
            {
                if(listelenen.Isim == isim || listelenen.Numara == numara)
                {
                    aramaListesi.Add(listelenen);
                }
            }
            return aramaListesi;
        }
        static void Main(string[] args)
        {
        anamenü:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ÖĞRENCİ BİLGİ SİSTEMİ");
            Console.WriteLine("==============================");
            Console.WriteLine("1- ÖĞRENCİ EKLE");
            Console.WriteLine("2- ÖĞRENCİ BUL");
            Console.WriteLine("3- ÖĞRENCİLERİ LİSTELE");
            Console.WriteLine("==============================");
            Console.ResetColor();
            string secim = Console.ReadLine();
            if (secim == "1")
            {
                Console.Clear();
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("ÖĞRENCİ KAYIT SİSTEMİ");
                Console.WriteLine("==============================");
                Ogrenci ogrenci = new Ogrenci();
                ogrenci.Isim = Soru("İsim: ");
                ogrenci.SoyIsim = Soru("Soyİsim: ");
                ogrenci.Numara = int.Parse(Soru("Okul Numarası: "));
                ogrenci.Cinsiyet = Soru("Cinsiyet: ");
                ogrenci.DTarihi = DateOnly.Parse(Soru("Doğum Tarihi(00.00.0000): "));
                Console.WriteLine("==============================");
                Console.ResetColor();
                ogrenciler.Add(ogrenci);
                goto anamenü;
            }
            else if (secim == "2")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("ÖĞRENCİ ARAMA SİSTEMİ");
                Console.WriteLine("==============================");
                Console.WriteLine("1- İSİM İLE ARAMA");
                Console.WriteLine("2- NUMARA İLE ARAMA");
                string secimArama = Soru("Seçiminiz: ");
                if (secimArama == "1")
                {
                    Console.Clear();
                    Console.Write("İSİM GİRİNİZ: ");
                    string isim = Console.ReadLine();
                    List<Ogrenci> isimAramaSonuclari = OgrenciArama(isim, -1);
                    Console.WriteLine("İsim||Soyisim||Cinsiyet||Okul numarası||D.Tarihi|");
                    foreach (Ogrenci ogrenci in isimAramaSonuclari)
                    {
                        Console.WriteLine($"{ogrenci.Isim} {ogrenci.SoyIsim}   -   {ogrenci.Cinsiyet}   -   {ogrenci.Numara}  -  {ogrenci.DTarihi}");
                    }
                }
                else if (secimArama == "2")
                {
                    Console.Clear();
                    Console.Write("NUMARA GİRİNİZ: ");
                    int numara = int.Parse(Console.ReadLine());
                    List<Ogrenci> numaraAramaSonuclari = OgrenciArama("", numara);
                    Console.WriteLine("İsim||Soyisim||Cinsiyet||Okul numarası||D.Tarihi|");
                    foreach (Ogrenci ogrenci in numaraAramaSonuclari)
                    {
                        Console.WriteLine($"{ogrenci.Isim} {ogrenci.SoyIsim}   -   {ogrenci.Cinsiyet}   -   {ogrenci.Numara}  -  {ogrenci.DTarihi}");
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim. Lütfen 1 veya 2 giriniz.");
                }

                Console.WriteLine("DEVAM ETMEK İÇİN BİR TUŞA BASINIZ");
                Console.ReadKey();
                Console.ResetColor();
                goto anamenü;

            }
            else if (secim == "3")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("ÖĞRENCİ LİSTESİ ");
                Console.WriteLine("==============================");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("İsim||Soyisim||Cinsiyet||Okul numarası||D.Tarihi|");
                Console.WriteLine("---------------------------------------------------");
                foreach (Ogrenci ogrenci in ogrenciler)
                {
                    Console.WriteLine($"{ogrenci.Isim} {ogrenci.SoyIsim}   -   {ogrenci.Cinsiyet}   -   {ogrenci.Numara}  -  {ogrenci.DTarihi}");
                }
                Console.WriteLine("==============================");
                Console.WriteLine("1- Öğrenci Düzenleme");
                Console.WriteLine("2- Cinsiyete Göre Listeleme");
                string aramasecim = Console.ReadLine();
                if(aramasecim == "1") { 
                Console.Write("Düzenlemek istediğiniz öğrencinin adını giriniz: ");
                string arananIsim = Console.ReadLine();
                Ogrenci? duzenlenecekOgrenci = ogrenciler.FirstOrDefault(o => o.Isim == arananIsim);
                if (duzenlenecekOgrenci != null)
                {
                    Console.WriteLine("Öğrenci Bilgilerini Düzenleme Bölümü");
                    Console.WriteLine("===============================");
                    Console.Write("Yeni İsim: ");
                    string yeniIsim = Console.ReadLine();
                    duzenlenecekOgrenci.Isim = yeniIsim;

                    Console.Write("Yeni Soyisim: ");
                    string yeniSoyisim = Console.ReadLine();
                    duzenlenecekOgrenci.SoyIsim = yeniSoyisim;

                    Console.Write("Yeni Numara: ");
                    int yeniNumara = int.Parse(Console.ReadLine());
                    duzenlenecekOgrenci.Numara = yeniNumara;

                    Console.Write("Yeni Cinsiyet: ");
                    string yeniCinsiyet = Console.ReadLine();
                    duzenlenecekOgrenci.Cinsiyet = yeniCinsiyet;

                    Console.Write("Yeni Doğum Tarihi: ");
                    DateOnly yeniDtarihi =DateOnly.Parse(Console.ReadLine());
                    duzenlenecekOgrenci.DTarihi = yeniDtarihi;

                    Console.WriteLine("Değişiklikler başarıyla kaydedildi.");
                }
                else
                {
                    Console.WriteLine("Belirtilen isimde bir öğrenci bulunamadı.");
                }
                }
                else if (aramasecim == "2")
                { 
                List<Ogrenci> kadinlar = ogrenciler.Where(o => o.Cinsiyet == "kadın").ToList();
                Console.WriteLine("KADIN ÖĞRENCİLER");
                Console.WriteLine("==============================");
                foreach (Ogrenci kadin in kadinlar)
                {
                    Console.WriteLine($"{kadin.Isim} {kadin.SoyIsim}   -   {kadin.Cinsiyet}   -   {kadin.Numara}  -  {kadin.DTarihi}");
                }
                Console.WriteLine("==============================");
                List<Ogrenci> erkekler = ogrenciler.Where(o => o.Cinsiyet == "erkek").ToList();
                Console.WriteLine("ERKEK ÖĞRENCİLER");
                Console.WriteLine("==============================");
                foreach (Ogrenci erkek in erkekler)
                {
                    Console.WriteLine($"{erkek.Isim} {erkek.SoyIsim}   -   {erkek.Cinsiyet}   -   {erkek.Numara}  -  {erkek.DTarihi}");
                }
                Console.WriteLine("==============================");
                Console.ResetColor();
                    Console.ReadKey();
                }
                goto anamenü;
            }
            else
            {
                Console.WriteLine("ÇIKIŞ");
            }
        }
    }
}
