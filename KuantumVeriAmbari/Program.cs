using System;
using System.Collections.Generic;

namespace KuantumVeriAmbari
{
    // SOYUT SINIF (ABSTRACT CLASS)
    public abstract class KuantumNesnesi
    {
        public string ID { get; set; }
        public int TehlikeSeviyesi { get; set; }

        // Kapsülleme (Encapsulation) için gizli değişken
        private double _stabilite;

        public double Stabilite
        {
            get { return _stabilite; }
            set
            {
                // 100'den büyükse 100'e sabitle
                if (value > 100)
                {
                    _stabilite = 100;
                }
                // 0 veya küçükse HATA FIRLAT
                else if (value <= 0)
                {
                    _stabilite = 0;
                    // HATA YÖNETİMİ
                    throw new KuantumCokusuException(ID);
                }
                else
                {
                    _stabilite = value;
                }
            }
        }

        // Abstract metot 
        public abstract void AnalizEt();

        // Normal metot
        public string DurumBilgisi()
        {
            return $"ID: {ID} | Stabilite: %{Math.Round(Stabilite, 1)} | Tehlike: {TehlikeSeviyesi}";
        }
    }

    // ANA PROGRAM
    class Program
    {
        static void Main(string[] args)
        {
            List<KuantumNesnesi> envanter = new List<KuantumNesnesi>();
            Random rnd = new Random();
            int sayac = 1;

            Console.WriteLine("--- OMEGA SEKTÖRÜ KUANTUM VERİ AMBARI BAŞLATILDI ---");

            while (true)
            {
                // TRY-CATCH
                try
                {
                    Console.WriteLine("\n=== KONTROL PANELİ ===");
                    Console.WriteLine("1. Yeni Nesne Ekle (Rastgele)");
                    Console.WriteLine("2. Tüm Envanteri Listele");
                    Console.WriteLine("3. Nesneyi Analiz Et");
                    Console.WriteLine("4. Acil Durum Soğutması Yap (Sadece Kritikler!)");
                    Console.WriteLine("5. Çıkış");
                    Console.Write("Seçiminiz: ");
                    string secim = Console.ReadLine();

                    switch (secim)
                    {
                        case "1":
                            // RASTGELE NESNE ÜRETME
                            int tur = rnd.Next(1, 4); // 1, 2 veya 3
                            KuantumNesnesi yeniNesne = null;

                            if (tur == 1)
                            {
                                yeniNesne = new VeriPaketi();
                                yeniNesne.TehlikeSeviyesi = 1;
                            }
                            else if (tur == 2)
                            {
                                yeniNesne = new KaranlikMadde();
                                yeniNesne.TehlikeSeviyesi = 5;
                            }
                            else
                            {
                                yeniNesne = new AntiMadde();
                                yeniNesne.TehlikeSeviyesi = 9;
                            }

                            // Nesnenin özelliklerini ayarla
                            yeniNesne.ID = "NESNE-" + sayac;
                            // 0 gelirse hata verir.
                            yeniNesne.Stabilite = rnd.Next(50, 91); 

                            envanter.Add(yeniNesne);
                            Console.WriteLine($"[SİSTEM] Depoya {yeniNesne.ID} eklendi. Türü: {yeniNesne.GetType().Name}");
                            sayac++;
                            break;

                        case "2":
                            Console.WriteLine("\n--- GÜNCEL ENVANTER ---");
                            if (envanter.Count == 0) Console.WriteLine("Depo boş.");
                            
                            foreach (var nesne in envanter)
                            {
                                Console.WriteLine(nesne.DurumBilgisi());
                            }
                            break;

                        case "3":
                            Console.Write("Analiz edilecek ID (örn: NESNE-1): ");
                            string analizID = Console.ReadLine();
                            
                            var bulunan = envanter.Find(n => n.ID == analizID);

                            if (bulunan != null)
                            {
                                // 0 olursa Exception fırlatır
                                bulunan.AnalizEt();
                            }
                            else
                            {
                                Console.WriteLine("HATA: Nesne bulunamadı!");
                            }
                            break;

                        case "4":
                            Console.Write("Soğutulacak ID: ");
                            string sogutmaID = Console.ReadLine();
                            var sogutulacak = envanter.Find(n => n.ID == sogutmaID);

                            if (sogutulacak != null)
                            {
                                // (Tür Kontrolü)
                                if (sogutulacak is IKritik)
                                {
                                    
                                    ((IKritik)sogutulacak).AcilDurumSogutmasi();
                                }
                                else
                                {
                                    Console.WriteLine("HATA: Bu nesne güvenlidir, soğutma gerektirmez!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nesne bulunamadı.");
                            }
                            break;

                        case "5":
                            Console.WriteLine("Çıkış yapılıyor...");
                            return;

                        default:
                            Console.WriteLine("Geçersiz işlem!");
                            break;
                    }
                }
                catch (KuantumCokusuException ex)
                {
                    Console.WriteLine("\n************************************************");
                    Console.WriteLine("SİSTEM ÇÖKTÜ! TAHLİYE BAŞLATILIYOR...");
                    Console.WriteLine($"SEBEP: {ex.Message}");
                    Console.WriteLine("************************************************");
                    break; // Döngüyü kırar ve program biter
                }
                catch (Exception genelHata)
                {
                    Console.WriteLine($"Beklenmedik Hata: {genelHata.Message}");
                }
            }
        }
    }
}