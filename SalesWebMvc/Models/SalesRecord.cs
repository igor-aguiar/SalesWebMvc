using SalesWebMvc.Models.enums;
using System;

namespace SalesWebMvc.Models
{
    public class SalesRecord
    {
        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amount, SaleStatus saleStatus, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            SaleStatus = saleStatus;
            Seller = seller;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SaleStatus SaleStatus { get; set; }
        public Seller Seller { get; set; }


    }
}