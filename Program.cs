using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyTracker; // Modelleri ve Servisi görmek için şart

namespace CurrencyTracker
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "CurrencyTracker";

            // Servisimizi (Kuryeyi) çağırıyoruz
            CurrencyService service = new CurrencyService();

            Console.WriteLine("Veriler sunucudan çekiliyor, lütfen bekleyiniz...");
            List<Currency> dovizListesi = await service.GetRatesAsync();

            // Eğer liste boş geldiyse hata vardır
            if (dovizListesi.Count == 0)
            {
                Console.WriteLine("Hata: Veri çekilemedi! İnternet bağlantınızı kontrol edin.");
                return;
            }

            Console.WriteLine("Veriler başarıyla alındı.\n");

            // Sonsuz döngü ile menüyü sürekli göster
            while (true)
            {
                Console.WriteLine("===== CurrencyTracker =====");
                Console.WriteLine("1. Tüm dövizleri listele");
                Console.WriteLine("2. Koda göre döviz ara");
                Console.WriteLine("3. Belirli bir değerden büyük dövizleri listele");
                Console.WriteLine("4. Dövizleri değere göre sırala");
                Console.WriteLine("5. İstatistiksel özet göster");
                Console.WriteLine("0. Çıkış");
                Console.Write("Seçiminiz: ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1": // LİSTELEME
                        var tumListe = dovizListesi.Select(x => x).ToList();
                        foreach (var item in tumListe)
                        {
                            Console.WriteLine($"{item.Code}: {item.Rate}");
                        }
                        break;

                    case "2": // ARAMA
                        Console.Write("Aranacak Kod (Örn: USD): ");
                        string kod = Console.ReadLine().ToUpper();
                        var bulunan = dovizListesi.Where(x => x.Code.Contains(kod)).ToList();

                        if (bulunan.Count > 0)
                        {
                            foreach (var item in bulunan)
                                Console.WriteLine($"{item.Code}: {item.Rate}");
                        }
                        else
                        {
                            Console.WriteLine("Bulunamadı.");
                        }
                        break;

                    case "3": // FİLTRELEME
                        Console.Write("Minimum Değer: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal deger))
                        {
                            var buyukler = dovizListesi.Where(x => x.Rate > deger).ToList();
                            foreach (var item in buyukler)
                            {
                                Console.WriteLine($"{item.Code}: {item.Rate}");
                            }
                        }
                        break;

                    case "4": // SIRALAMA
                        var sirali = dovizListesi.OrderBy(x => x.Rate).ToList();
                        foreach (var item in sirali)
                        {
                            Console.WriteLine($"{item.Code}: {item.Rate}");
                        }
                        break;

                    case "5": // İSTATİSTİK
                        Console.WriteLine($"Toplam Sayı: {dovizListesi.Count()}");
                        Console.WriteLine($"En Yüksek: {dovizListesi.Max(x => x.Rate)}");
                        Console.WriteLine($"En Düşük: {dovizListesi.Min(x => x.Rate)}");
                        Console.WriteLine($"Ortalama: {dovizListesi.Average(x => x.Rate):F2}");
                        break;

                    case "0": // ÇIKIŞ
                        return;

                    default:
                        Console.WriteLine("Geçersiz seçim.");
                        break;
                }

                Console.WriteLine("\nDevam etmek için bir tuşa basın...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}