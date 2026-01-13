using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata; // BU EKLENDİ (Kilit açıcı kütüphane)
using System.Threading.Tasks;

namespace CurrencyTracker
{
    public class CurrencyService
    {
        private readonly string _apiUrl = "https://api.frankfurter.app/latest?from=TRY";
        private readonly HttpClient _httpClient;

        public CurrencyService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Currency>> GetRatesAsync()
        {
            try
            {
                string jsonResponse = await _httpClient.GetStringAsync(_apiUrl);

                // .NET 9.0 İÇİN DÜZELTME BURADA YAPILDI
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    // Aşağıdaki satır hata veren kilidi açıyor:
                    TypeInfoResolver = new DefaultJsonTypeInfoResolver()
                };

                var apiData = JsonSerializer.Deserialize<CurrencyResponse>(jsonResponse, options);

                List<Currency> currencyList = apiData.Rates.Select(k => new Currency
                {
                    Code = k.Key,
                    Rate = k.Value
                }).ToList();

                return currencyList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Veri çekilirken hata oluştu: " + ex.Message);
                return new List<Currency>();
            }
        }
    }
}