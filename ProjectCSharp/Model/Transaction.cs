using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCSharp.Model
{
    public class Transaction
    {
        public int Id { get; set; }
        public int WalletId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } // INCOME hoặc EXPENSE
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; } = "COMPLETED"; // COMPLETED, PENDING, CANCELLED
        public string Location { get; set; } // Địa điểm giao dịch (tùy chọn)
        public string Attachment { get; set; } // Đường dẫn đến file đính kèm (tùy chọn)
        public int BudgetId { get; set; }
        
        // Navigation properties
        public virtual User User { get; set; }
        public virtual TransactionCategory Category { get; set; }
        public virtual Budget Budget { get; set; }
    }
} 