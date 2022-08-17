using System;
using System.Collections.Generic;
using System.Text.Json;

namespace TestTransaction
{
    public class Service
    {
        static Dictionary<int, Transaction> _transactions = new Dictionary<int, Transaction>();

        static readonly JsonSerializerOptions _options;

        static Service()
        {
            _options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            _options.Converters.Add(new DateTimeConverter());
        }

        public bool Add(int idAdd, DateTime date, decimal amount)
        {
            var dt = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond, DateTimeKind.Local);
            var transaction = new Transaction(idAdd, dt, amount);
            if (!_transactions.ContainsKey(idAdd))
            {
                _transactions.Add(idAdd, transaction);
                return true;
            }
            return false;
        }

        public bool Get(int idGet, out string result)
        {
            result = null;
            if (_transactions.ContainsKey(idGet))
            {
                result = JsonSerializer.Serialize(_transactions[idGet], _options);
                return true;
            }
            return false;
        }
    }
}