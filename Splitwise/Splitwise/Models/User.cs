using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Models
{
    public class User
    {
        private static int id { get; set; } = 1;
        public string userId { get; private set; }
        public string name { get; private set; }
        public string email { get; private set; }
        public long mobile { get; private set; }
        public List<Transaction> transactions { get; set; }
        public Dictionary<string,decimal> lenders { get; set; }
        public Dictionary<string, decimal> borrowers { get; set; }

        public User(string Name, string Email, long Mobile)
        {
            userId = "u"+id++;
            name = Name;
            email = Email;
            mobile = Mobile;
        }
    }

    public class AllTransactions
    {
        public List<Transaction> txnList { get; set; }
    }
    public class Transaction
    {
        private static int id { get; set; } = 1001;
        public int transactionId { get; set; }
        public string expenseName { get; set; } = "";
        public string lenderId { get; set; }
        public string borrowerId { get; set; }
        public decimal amount { get; set; }

        public Transaction(string lender,string borrower, decimal value)
        {
            transactionId = id++;
            lenderId = lender;
            borrowerId = borrower;
            amount = value;
        }
    }

    public enum ExpenseEnum{
        EQUAL = 1,
        EXACT = 2,
        PERCENT = 3,
        SHARE = 4

    }

    public enum OperationsEnum
    {
        SHOW = 1,
        EXPENSE = 2
    }
}
