using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ProjectCSharp.Utils;
using ProjectCSharp.Model;

namespace ProjectCSharp.DAO
{
    class TransactionDAO
    {
        private readonly ConnectDB db;

        public TransactionDAO()
        {
            db = new ConnectDB();
        }

        public async Task<List<Transaction>> GetTransactionsAsync(int userId, DateTime fromDate, DateTime toDate)
        {
            string query = @"
            SELECT 
            Id,
            Amount,
            TransactionDate,
            Description,
            UserId,
            CategoryId,
            Type,
            Status,
            Attachment
            FROM Transactions 
            WHERE UserId = @UserId AND TransactionDate BETWEEN @FromDate AND @ToDate";

            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@UserId", userId),
                new MySqlParameter("@FromDate", fromDate),
                new MySqlParameter("@ToDate", toDate)
            };

            DataTable dataTable = await db.ExecuteQueryAsync(query, parameters);
            List<Transaction> transactions = new List<Transaction>();

            foreach (DataRow row in dataTable.Rows)
            {
                Transaction transaction = new Transaction
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Amount = Convert.ToDecimal(row["Amount"]),
                    TransactionDate = Convert.ToDateTime(row["TransactionDate"]),
                    Description = row["Description"].ToString(),
                    UserId = Convert.ToInt32(row["UserId"]),
                    CategoryId = Convert.ToInt32(row["CategoryId"]), 
                    Type = row["Type"].ToString(),
                    Status = Convert.ToBoolean(row["Status"]), 
                    Attachment = row["Attachment"] != DBNull.Value ? row["Attachment"].ToString() : null
                };
                transactions.Add(transaction);
            }

            return transactions;
        }

        public async Task<DataTable> GetIncomeByDateAsync(int userId, DateTime fromDate, DateTime toDate)
        {
            string query = @"
            SELECT 
            TransactionDate AS Date, 
            SUM(CASE WHEN Type = 'INCOME' THEN Amount ELSE 0 END) AS Income,
            SUM(CASE WHEN Type = 'EXPENSE' THEN Amount ELSE 0 END) AS Expense
            FROM Transactions
            WHERE UserId = @UserId AND TransactionDate BETWEEN @FromDate AND @ToDate
            GROUP BY TransactionDate
            ORDER BY TransactionDate";

            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@UserId", userId),
                new MySqlParameter("@FromDate", fromDate),
                new MySqlParameter("@ToDate", toDate)
            };

            return await db.ExecuteQueryAsync(query, parameters);
        }

        public async Task<DataTable> GetRevenueByCategoryAsync(int userId, DateTime fromDate, DateTime toDate)
        {
            string query = @"
            SELECT tc.Name AS CategoryName, SUM(t.Amount) AS Total
            FROM Transactions t
            JOIN TransactionCategories tc ON t.CategoryId = tc.Id
            WHERE t.UserId = @UserId AND t.Type = 'INCOME' 
            AND t.TransactionDate BETWEEN @FromDate AND @ToDate
            GROUP BY tc.Name";

            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@UserId", userId),
                new MySqlParameter("@FromDate", fromDate),
                new MySqlParameter("@ToDate", toDate)
            };

            return await db.ExecuteQueryAsync(query, parameters);
        }

        public async Task<DataTable> GetExpenseByCategoryAsync(int userId, DateTime fromDate, DateTime toDate)
        {
            string query = @"
            SELECT tc.Name AS CategoryName, SUM(t.Amount) AS Total
            FROM Transactions t
            JOIN TransactionCategories tc ON t.CategoryId = tc.Id
            WHERE t.UserId = @UserId AND t.Type = 'EXPENSE' 
            AND t.TransactionDate BETWEEN @FromDate AND @ToDate
            GROUP BY tc.Name";

            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@UserId", userId),
                new MySqlParameter("@FromDate", fromDate),
                new MySqlParameter("@ToDate", toDate)
            };

            return await db.ExecuteQueryAsync(query, parameters);
        }

        public string CreateTransaction(Transaction transaction)
        {
            MySqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string query = @"INSERT INTO Transactions (Amount, CategoryId, BudgetId, TransactionDate, Description, UserId) 
                                VALUES (@Amount, @CategoryId, @BudgetId, @TransactionDate, @Description, @UserId)";
                
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Amount", transaction.Amount);
                cmd.Parameters.AddWithValue("@CategoryId", transaction.CategoryId);
                cmd.Parameters.AddWithValue("@BudgetId", transaction.BudgetId);
                cmd.Parameters.AddWithValue("@TransactionDate", transaction.TransactionDate);
                cmd.Parameters.AddWithValue("@Description", transaction.Description ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@UserId", transaction.UserId);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return "success";
                }
                return "Không thể tạo giao dịch";
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
            finally
            {
                ConnectDB.CloseConnection(conn);
            }
        }
    }
}
