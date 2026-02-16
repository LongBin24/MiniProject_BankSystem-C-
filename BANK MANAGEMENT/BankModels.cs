using System;
using System.Collections.Generic;

namespace BANK_MANAGEMENT
{
    public class Staff
    {
        public string StaffID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Password { get; set; }
    }

    public class Customer
    {
        public string CustomerID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }

    public class Account
    {
        public string AccountNumber { get; set; }
        public string CustomerID { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
    }

    public class Transaction
    {
        public string TransactionID { get; set; }
        public string AccountNumber { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal BalanceAfter { get; set; }
    }
}