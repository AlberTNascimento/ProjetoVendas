﻿using System;
using VendasWebMvc.Models.Enums;

namespace VendasWebMvc.Models
{
    public class SalesRecord
    {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SalesStatus Sales { get; set; }
        public Seller Seller { get; set; }

        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amount, SalesStatus sales, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Sales = sales;
            Seller = seller;
        }



    }
}
