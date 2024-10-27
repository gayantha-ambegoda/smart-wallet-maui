using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWalletHybrid.Models
{
    public class Account
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public bool IsCategory { get; set; } = false;
    }

    public class Budget
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public decimal ExpectedIncome { get; set; }
        public decimal ExpectedExpense { get; set; }
    }

    public class Plan
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty ;
        public int BudgetId { get; set; }
        public decimal Amount { get; set; }
        public bool IsIncome { get; set; }
        public bool IsDone { get; set; }
    }

    public class Transaction
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Title {  get; set; } = string.Empty;
        public int FromAccount { get; set; }
        public int ToAccount { get; set; }
        public int Plan { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransDate { get; set; }
    }
}
