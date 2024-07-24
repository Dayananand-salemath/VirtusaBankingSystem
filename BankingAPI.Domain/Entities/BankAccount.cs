using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAPI.Domain.Entities
{
    public class BankAccount
    {
        // Represents a bank account entity with necessary properties
        public int Id { get; set; } // Unique identifier for the bank account
        public string AccountNumber { get; set; } // Account number of the bank account
        public string AccountType { get; set; } // Type of the bank account (savings or current)
        public decimal Balance { get; set; } // Balance of the bank account
        public string CustomerName { get; set; } // Name of the customer who owns the bank account
    }
}
