using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCSharp.Model
{
    public class Transaction
    {
        public Transaction() { }
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public int BudgetId { get; set; }
        public string Type { get; set; } // "income" or "expense"
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public bool Status { get; set; } // true for active, false for inactive
        public string Attachment { get; set; } // file path or URL to the attachment
    }
}
