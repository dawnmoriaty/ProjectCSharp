using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjectCSharp
{
    class TransactionService
    {
        private readonly DatabaseConnection db;

        public TransactionService()
        {
            db = new DatabaseConnection();
        }

        public async Task<DataTable> GetIncomeByDateAsync(DateTime fromDate, DateTime toDate)
        {
            string query = @"
            SELECT 
            TransactionDate AS Date, 
            SUM(CASE WHEN IncomeCategoryId IS NOT NULL THEN Amount ELSE 0 END) AS Income,
            SUM(CASE WHEN ExpenseCategoryId IS NOT NULL THEN Amount ELSE 0 END) AS Expense
            FROM [Transaction]
            WHERE TransactionDate BETWEEN @FromDate AND @ToDate
            GROUP BY TransactionDate
            ORDER BY TransactionDate;
            ";

            var parameters = new SqlParameter[]
            {
            new SqlParameter("@FromDate", fromDate),
            new SqlParameter("@ToDate", toDate)
            };

            return await db.ExecuteQueryAsync(query, parameters);
        }

        public async Task<DataTable> GetRevenueByCategoryAsync(DateTime fromDate, DateTime toDate)
        {
            string query = @"
            SELECT ic.CategoryName, SUM(t.Amount) AS Total
            FROM [Transaction] t
            JOIN IncomeCategory ic ON t.IncomeCategoryId = ic.IncomeCategoryId
            WHERE t.TransactionDate BETWEEN @FromDate AND @ToDate
            GROUP BY ic.CategoryName";

            var parameters = new SqlParameter[]
            {
            new SqlParameter("@FromDate", fromDate),
            new SqlParameter("@ToDate", toDate)
            };

            return await db.ExecuteQueryAsync(query, parameters);
        }

        public async Task<DataTable> GetExpenseByCategoryAsync(DateTime fromDate, DateTime toDate)
        {
            string query = @"
            SELECT ec.CategoryName, SUM(t.Amount) AS Total
            FROM [Transaction] t
            JOIN ExpenseCategory ec ON t.ExpenseCategoryId = ec.ExpenseCategoryId
            WHERE t.TransactionDate BETWEEN @FromDate AND @ToDate
            GROUP BY ec.CategoryName";

            var parameters = new SqlParameter[]
            {
            new SqlParameter("@FromDate", fromDate),
            new SqlParameter("@ToDate", toDate)
            };

            return await db.ExecuteQueryAsync(query, parameters);
        }
    }
}
