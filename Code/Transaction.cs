using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TestTransaction
{
    public class Transaction
    {
        [Range(1, int.MaxValue, ErrorMessage = "Введите целое число большее или равное 1")]
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }

        public Transaction(int id, DateTime date, decimal amount)
        {
            Id = id;
            TransactionDate = date;
            Amount = amount;
        }
    }
}