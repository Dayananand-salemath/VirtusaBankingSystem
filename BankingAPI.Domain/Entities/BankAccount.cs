using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAPI.Domain.Entities
{
    public class BankAccount
    {
        public int Id { get; set; }
        public required string AccountNumber { get; set; }
        public required string AccountType { get; set; } // "savings" or "current"
        public decimal Balance { get; set; }
        public required  string CustomerName { get; set; }
    }
}
