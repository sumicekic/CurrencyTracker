using System.Collections.Generic;

namespace CurrencyTracker
{
    public class CurrencyResponse
    {
        public string Base { get; set; }
        public Dictionary<string, decimal> Rates { get; set; }
    }

    public class Currency
    {
        public string Code { get; set; }
        public decimal Rate { get; set; }
    }
}