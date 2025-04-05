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
            List<Transaction> transactions = new List<Transaction>();
            MySqlConnection conn = null;
            
            try
            {
                conn = ConnectDB.GetConnection();
                
                string query = @"
                SELECT 
                Id,
                Amount,
                TransactionDate,
                Description,
                UserId,
                CategoryId
                FROM Transactions 
                WHERE UserId = @UserId AND TransactionDate BETWEEN @FromDate AND @ToDate";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@FromDate", fromDate);
                    cmd.Parameters.AddWithValue("@ToDate", toDate);
                    
                    // Sử dụng ExecuteReader thay vì ExecuteQueryAsync
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                Transaction transaction = new Transaction
                                {
                                    Id = reader.GetInt32("Id"),
                                    Amount = reader.GetDecimal("Amount"),
                                    TransactionDate = reader.GetDateTime("TransactionDate"),
                                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? "" : reader.GetString("Description"),
                                    UserId = reader.GetInt32("UserId"),
                                    CategoryId = reader.GetInt32("CategoryId")
                                };
                                transactions.Add(transaction);
                            }
                            catch (Exception ex)
                            {
                                // Ghi log lỗi khi chuyển đổi dữ liệu
                                Console.WriteLine($"Lỗi khi chuyển đổi dữ liệu: {ex.Message}");
                                // Tiếp tục với dòng tiếp theo
                                continue;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi khi truy vấn dữ liệu
                Console.WriteLine($"Lỗi khi truy vấn dữ liệu: {ex.Message}");
                // Có thể ném lại exception hoặc trả về danh sách rỗng
                // throw;
            }
            finally
            {
                if (conn != null)
                {
                    ConnectDB.CloseConnection(conn);
                }
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
