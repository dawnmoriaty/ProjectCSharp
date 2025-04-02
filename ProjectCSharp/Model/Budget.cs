using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCSharp.Model
{
    public class Budget
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string BudgetName { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "VND";
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        
        // Navigation property
        public virtual User User { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
} 