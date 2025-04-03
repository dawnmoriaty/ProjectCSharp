using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCSharp.Model
{
    public class TransactionCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; } // INCOME hoặc EXPENSE
        public bool IsDefault { get; set; } = false;
        public DateTime CreatedDate { get; set; }

        // Navigation property
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}