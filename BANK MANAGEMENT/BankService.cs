using BANK_MANAGEMENT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace BANK_MANAGEMENT
{
    public class BankService
    {
        private static BankService instance;
        public static BankService Instance
        {
            get
            {
                if (instance == null)
                    instance = new BankService();
                return instance;
            }
        }

        public List<Staff> Staffs { get; set; } = new List<Staff>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Account> Accounts { get; set; } = new List<Account>();
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        private const string FileName = "bank_data.json";

        public void SaveData()
        {
            var data = new BankData
            {
                Staffs = Staffs,
                Customers = Customers,
                Accounts = Accounts,
                Transactions = Transactions
            };

            File.WriteAllText(FileName,
                JsonConvert.SerializeObject(data, Formatting.Indented));
        }

        public void LoadData()
        {
            if (File.Exists(FileName))
            {
                var json = File.ReadAllText(FileName);
                var data = JsonConvert.DeserializeObject<BankData>(json);

                if (data != null)
                {
                    Staffs = data.Staffs ?? new List<Staff>();
                    Customers = data.Customers ?? new List<Customer>();
                    Accounts = data.Accounts ?? new List<Account>();
                    Transactions = data.Transactions ?? new List<Transaction>();
                }
            }

            if (!Staffs.Any())
                Staffs.Add(new Staff { StaffID = "admin", Name = "Admin", Password = "123" });
        }

        public string GenerateAccountNumber(string type)
        {
            string prefix = (type == "Saving") ? "10" : "20";
            string year = DateTime.Now.ToString("yy");
            var lastAcc = Accounts.Where(a => a.AccountNumber.StartsWith(prefix + year))
                                  .OrderByDescending(a => a.AccountNumber).FirstOrDefault();
            int seq = (lastAcc != null) ? int.Parse(lastAcc.AccountNumber.Substring(4)) + 1 : 1;
            return $"{prefix}{year}{seq:D4}";
        }

        private class BankData
        {
            public List<Staff> Staffs { get; set; }
            public List<Customer> Customers { get; set; }
            public List<Account> Accounts { get; set; }
            public List<Transaction> Transactions { get; set; }
        }
    }
}