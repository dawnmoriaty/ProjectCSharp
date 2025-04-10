using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ProjectCSharp.Model;
using ProjectCSharp.Utils;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjectCSharp.DAO
{
    class TransactionDAO
    {
        public TransactionDAO() { }

        public bool CreateTransaction(decimal Amount, int CategoryId, int BudgetId, string Description, int UserId)
        {
            MySqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string insertQuery = "INSERT INTO Transactions (Amount, CategoryId, BudgetId, TransactionDate, Description, UserId) " +
                                     "VALUES (@amount, @categoryId, @budgetId, @transactionDate, @description, @userId)";
                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@amount", Amount);
                cmd.Parameters.AddWithValue("@categoryId", CategoryId);
                cmd.Parameters.AddWithValue("@budgetId", BudgetId);
                cmd.Parameters.AddWithValue("@transactionDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@description", Description);
                cmd.Parameters.AddWithValue("@userId", UserId);

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                int rowsAffected = cmd.ExecuteNonQuery(); // Số dòng bị ảnh hưởng
                return rowsAffected > 0; // Trả về true nếu có ít nhất một dòng được thêm
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
            finally
            {
                ConnectDB.CloseConnection(conn);
            }
        }
        public List<Transaction> GetTransactionsByUserId(int userId)
        {
            MySqlConnection conn = ConnectDB.GetConnection();
            List<Transaction> transactions = new List<Transaction>();
            try
            {
                string selectQuery = "SELECT * FROM Transactions WHERE UserId = @userId";
                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Transaction transaction = new Transaction
                    {
                        Id = reader.GetInt32("Id"),
                        Amount = reader.GetDecimal("Amount"),
                        CategoryId = reader.GetInt32("CategoryId"),
                        BudgetId = reader.GetInt32("BudgetId"),
                        TransactionDate = reader.GetDateTime("TransactionDate"),
                        Description = reader.GetString("Description"),
                        UserId = reader.GetInt32("UserId")
                    };
                    transactions.Add(transaction);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                ConnectDB.CloseConnection(conn);
            }
            return transactions;
        }
        public bool UpdateTransaction(int TransactionId, decimal Amount, int CategoryId, int BudgetId, string Description)
        {
            MySqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string updateQuery = "UPDATE Transactions SET Amount = @amount, CategoryId = @categoryId, BudgetId = @budgetId, " +
                                     "Description = @description WHERE Id = @transactionId"; // Giả sử cột là Id

                MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@amount", Amount);
                cmd.Parameters.AddWithValue("@categoryId", CategoryId);
                cmd.Parameters.AddWithValue("@budgetId", BudgetId);
                cmd.Parameters.AddWithValue("@description", Description);
                cmd.Parameters.AddWithValue("@transactionId", TransactionId);

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật giao dịch: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                ConnectDB.CloseConnection(conn);
            }
        }
        public bool DeleteTransaction(int transactionId)
        {
            MySqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string deleteQuery = "DELETE FROM Transactions WHERE Id = @Id"; 
                MySqlCommand cmd = new MySqlCommand(deleteQuery, conn);
                cmd.Parameters.AddWithValue("@transactionId", transactionId);

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0; // Trả về true nếu xóa thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa giao dịch: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                ConnectDB.CloseConnection(conn);
            }
        }
        public async Task<List<Transaction>> GetTransactionsAsync(int userId, DateTime fromDate, DateTime toDate)
        {
            List<Transaction> transactions = new List<Transaction>();
            MySqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string selectQuery = @"
                    SELECT t.*, tc.Name as CategoryName 
                    FROM Transactions t 
                    LEFT JOIN TransactionCategories tc ON t.CategoryId = tc.Id 
                    WHERE t.UserId = @userId 
                    AND t.TransactionDate BETWEEN @fromDate AND @toDate 
                    ORDER BY t.TransactionDate DESC";
                
                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@fromDate", fromDate);
                cmd.Parameters.AddWithValue("@toDate", toDate);

                if (conn.State != ConnectionState.Open)
                {
                    await conn.OpenAsync();
                }

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Transaction transaction = new Transaction
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Amount = Convert.ToDecimal(reader["Amount"]),
                            CategoryId = Convert.ToInt32(reader["CategoryId"]),
                            BudgetId = Convert.ToInt32(reader["BudgetId"]),
                            TransactionDate = Convert.ToDateTime(reader["TransactionDate"]),
                            Description = reader["Description"].ToString(),
                            UserId = Convert.ToInt32(reader["UserId"]),
                            CategoryName = reader["CategoryName"] == DBNull.Value ? 
                                "Không xác định" : reader["CategoryName"].ToString()
                        };
                        transactions.Add(transaction);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy giao dịch: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConnectDB.CloseConnection(conn);
            }
            return transactions;
        }
        public async Task<decimal> GetTotalIncomeAsync(int userId)
        {
            decimal total = 0;
            MySqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string selectQuery = @"
                    SELECT COALESCE(SUM(t.Amount), 0) as TotalIncome
                    FROM Transactions t 
                    INNER JOIN TransactionCategories tc ON t.CategoryId = tc.Id 
                    WHERE t.UserId = @userId 
                    AND tc.Type = 'INCOME'";
                
                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        total = reader.GetDecimal(0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính tổng thu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConnectDB.CloseConnection(conn);
            }
            return total;
        }

        public async Task<decimal> GetTotalExpenseAsync(int userId)
        {
            decimal total = 0;
            MySqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string selectQuery = @"
                    SELECT COALESCE(SUM(t.Amount), 0) as TotalExpense
                    FROM Transactions t 
                    INNER JOIN TransactionCategories tc ON t.CategoryId = tc.Id 
                    WHERE t.UserId = @userId 
                    AND tc.Type = 'EXPENSE'";
                
                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        total = reader.GetDecimal(0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính tổng chi tiêu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConnectDB.CloseConnection(conn);
            }
            return total;
        }
        public async Task<DataTable> GetIncomeByDateAsync(int userId, DateTime fromDate, DateTime toDate)
        {
            string query = @"
            SELECT 
            DATE(TransactionDate) AS Date, 
            SUM(CASE WHEN tc.Type = 'INCOME' THEN Amount ELSE 0 END) AS Income,
            SUM(CASE WHEN tc.Type = 'EXPENSE' THEN Amount ELSE 0 END) AS Expense
            FROM Transactions t
            JOIN TransactionCategories tc ON t.CategoryId = tc.Id
            WHERE t.UserId = @UserId 
            AND t.TransactionDate BETWEEN @FromDate AND @ToDate
            GROUP BY DATE(TransactionDate)
            ORDER BY Date;";

            var parameters = new MySqlParameter[]
            {
            new MySqlParameter("@UserId", userId),
            new MySqlParameter("@FromDate", fromDate),
            new MySqlParameter("@ToDate", toDate)
            };

            return await new ConnectDB().ExecuteQueryAsync(query, parameters);

        }

        // Phương thức lấy thu nhập theo danh mục
        public async Task<DataTable> GetRevenueByCategoryAsync(int userId, DateTime fromDate, DateTime toDate)
        {
            string query = @"
        SELECT 
            tc.Name AS CategoryName, 
            SUM(t.Amount) AS Total
        FROM Transactions t
        JOIN TransactionCategories tc ON t.CategoryId = tc.Id
        WHERE t.UserId = @UserId 
          AND tc.Type = 'INCOME'
          AND t.TransactionDate BETWEEN @FromDate AND @ToDate
        GROUP BY tc.Name";

            var parameters = new MySqlParameter[]
            {
            new MySqlParameter("@UserId", userId),
            new MySqlParameter("@FromDate", fromDate),
            new MySqlParameter("@ToDate", toDate)
            };

            return await new ConnectDB().ExecuteQueryAsync(query, parameters);

        }

        // Phương thức lấy chi tiêu theo danh mục
        public async Task<DataTable> GetExpenseByCategoryAsync(int userId, DateTime fromDate, DateTime toDate)
        {
            string query = @"
        SELECT 
                tc.Name AS CategoryName, 
                SUM(t.Amount) AS Total
            FROM Transactions t
            JOIN TransactionCategories tc ON t.CategoryId = tc.Id
            WHERE t.UserId = @UserId 
              AND tc.Type = 'EXPENSE'
              AND t.TransactionDate BETWEEN @FromDate AND @ToDate
            GROUP BY tc.Name;";

            var parameters = new MySqlParameter[]
            {
            new MySqlParameter("@UserId", userId),
            new MySqlParameter("@FromDate", fromDate),
            new MySqlParameter("@ToDate", toDate)
            };

            return await new ConnectDB().ExecuteQueryAsync(query, parameters);

        }

        public async Task<DataTable> GetTransactionOrderByDateAsync(int userId)
        {
            string query = @"
        SELECT t.amount, t.description, tc.name
        FROM Transactions t
        JOIN TransactionCategories tc ON tc.Id = t.CategoryId
        WHERE t.UserId = @UserId
        ORDER BY TransactionDate DESC
        LIMIT 10;";

            var parameters = new MySqlParameter[]
            {
            new MySqlParameter("@UserId", userId),

            };

            return await new ConnectDB().ExecuteQueryAsync(query, parameters);

        }

    }
}
