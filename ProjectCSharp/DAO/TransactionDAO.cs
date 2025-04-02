using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectCSharp.Model;
using ProjectCSharp.Utils;

namespace ProjectCSharp.DAO
{
    class TransactionDAO
    {
        public TransactionDAO() { }

        // Tạo giao dịch mới
        public string CreateTransaction(int budgetId, int userId, int categoryId, decimal amount, 
            string type, string description, DateTime transactionDate, string location = null, string attachment = null)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            try
            {
                // Bắt đầu transaction
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    // 1. Tạo giao dịch mới
                    string insertQuery = "INSERT INTO Transactions (BudgetId, UserId, CategoryId, Amount, Type, " +
                                       "Description, TransactionDate, Location, Attachment, Status, CreatedDate) " +
                                       "VALUES (@budgetId, @userId, @categoryId, @amount, @type, " +
                                       "@description, @transactionDate, @location, @attachment, @status, @createdDate)";
                    SqlCommand cmd = new SqlCommand(insertQuery, conn, transaction);
                    cmd.Parameters.AddWithValue("@budgetId", budgetId);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@categoryId", categoryId);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@transactionDate", transactionDate);
                    cmd.Parameters.AddWithValue("@location", (object)location ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@attachment", (object)attachment ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@status", "COMPLETED");
                    cmd.Parameters.AddWithValue("@createdDate", DateTime.Now);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // 2. Cập nhật số dư ví
                        string updateBudgetQuery = "UPDATE Budgets SET Amount = Amount + @amount, " +
                                                 "LastUpdatedDate = @lastUpdatedDate WHERE Id = @budgetId";
                        SqlCommand updateBudgetCmd = new SqlCommand(updateBudgetQuery, conn, transaction);
                        updateBudgetCmd.Parameters.AddWithValue("@amount", type == "INCOME" ? amount : -amount);
                        updateBudgetCmd.Parameters.AddWithValue("@lastUpdatedDate", DateTime.Now);
                        updateBudgetCmd.Parameters.AddWithValue("@budgetId", budgetId);

                        updateBudgetCmd.ExecuteNonQuery();
                        transaction.Commit();
                        return "Tạo giao dịch thành công";
                    }
                    else
                    {
                        transaction.Rollback();
                        return "Không thể tạo giao dịch";
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
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

        // Lấy danh sách giao dịch của ví theo khoảng thời gian
        public List<Transaction> GetTransactionsByBudget(int budgetId, DateTime startDate, DateTime endDate)
        {
            List<Transaction> transactions = new List<Transaction>();
            SqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string query = "SELECT t.*, c.Name as CategoryName, c.Type as CategoryType " +
                             "FROM Transactions t " +
                             "JOIN TransactionCategories c ON t.CategoryId = c.Id " +
                             "WHERE t.BudgetId = @budgetId " +
                             "AND t.TransactionDate BETWEEN @startDate AND @endDate " +
                             "ORDER BY t.TransactionDate DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@budgetId", budgetId);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    transactions.Add(new Transaction
                    {
                        Id = (int)reader["Id"],
                        BudgetId = (int)reader["BudgetId"],
                        UserId = (int)reader["UserId"],
                        CategoryId = (int)reader["CategoryId"],
                        Amount = (decimal)reader["Amount"],
                        Type = reader["Type"].ToString(),
                        Description = reader["Description"].ToString(),
                        TransactionDate = (DateTime)reader["TransactionDate"],
                        Location = reader["Location"] != DBNull.Value ? reader["Location"].ToString() : null,
                        Attachment = reader["Attachment"] != DBNull.Value ? reader["Attachment"].ToString() : null,
                        Status = reader["Status"].ToString(),
                        CreatedDate = (DateTime)reader["CreatedDate"]
                    });
                }
                return transactions;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                ConnectDB.CloseConnection(conn);
            }
        }

        // Lấy thông tin chi tiết giao dịch
        public Transaction GetTransactionById(int transactionId)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string query = "SELECT t.*, c.Name as CategoryName, c.Type as CategoryType " +
                             "FROM Transactions t " +
                             "JOIN TransactionCategories c ON t.CategoryId = c.Id " +
                             "WHERE t.Id = @transactionId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@transactionId", transactionId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Transaction
                    {
                        Id = (int)reader["Id"],
                        BudgetId = (int)reader["BudgetId"],
                        UserId = (int)reader["UserId"],
                        CategoryId = (int)reader["CategoryId"],
                        Amount = (decimal)reader["Amount"],
                        Type = reader["Type"].ToString(),
                        Description = reader["Description"].ToString(),
                        TransactionDate = (DateTime)reader["TransactionDate"],
                        Location = reader["Location"] != DBNull.Value ? reader["Location"].ToString() : null,
                        Attachment = reader["Attachment"] != DBNull.Value ? reader["Attachment"].ToString() : null,
                        Status = reader["Status"].ToString(),
                        CreatedDate = (DateTime)reader["CreatedDate"]
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                ConnectDB.CloseConnection(conn);
            }
        }

        // Cập nhật giao dịch
        public string UpdateTransaction(int transactionId, decimal amount, string description, 
            DateTime transactionDate, string location = null, string attachment = null)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            try
            {
                // Bắt đầu transaction
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    // 1. Lấy thông tin giao dịch cũ
                    string getOldQuery = "SELECT Amount, Type FROM Transactions WHERE Id = @transactionId";
                    SqlCommand getOldCmd = new SqlCommand(getOldQuery, conn, transaction);
                    getOldCmd.Parameters.AddWithValue("@transactionId", transactionId);
                    SqlDataReader reader = getOldCmd.ExecuteReader();
                    reader.Read();
                    decimal oldAmount = (decimal)reader["Amount"];
                    string type = reader["Type"].ToString();
                    reader.Close();

                    // 2. Cập nhật giao dịch
                    string updateQuery = "UPDATE Transactions SET Amount = @amount, Description = @description, " +
                                       "TransactionDate = @transactionDate, Location = @location, " +
                                       "Attachment = @attachment WHERE Id = @transactionId";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn, transaction);
                    updateCmd.Parameters.AddWithValue("@transactionId", transactionId);
                    updateCmd.Parameters.AddWithValue("@amount", amount);
                    updateCmd.Parameters.AddWithValue("@description", description);
                    updateCmd.Parameters.AddWithValue("@transactionDate", transactionDate);
                    updateCmd.Parameters.AddWithValue("@location", (object)location ?? DBNull.Value);
                    updateCmd.Parameters.AddWithValue("@attachment", (object)attachment ?? DBNull.Value);

                    int rowsAffected = updateCmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // 3. Cập nhật số dư ví
                        string updateBudgetQuery = "UPDATE Budgets SET Amount = Amount - @oldAmount + @newAmount, " +
                                                 "LastUpdatedDate = @lastUpdatedDate WHERE Id = (SELECT BudgetId FROM Transactions WHERE Id = @transactionId)";
                        SqlCommand updateBudgetCmd = new SqlCommand(updateBudgetQuery, conn, transaction);
                        updateBudgetCmd.Parameters.AddWithValue("@oldAmount", type == "INCOME" ? oldAmount : -oldAmount);
                        updateBudgetCmd.Parameters.AddWithValue("@newAmount", type == "INCOME" ? amount : -amount);
                        updateBudgetCmd.Parameters.AddWithValue("@lastUpdatedDate", DateTime.Now);
                        updateBudgetCmd.Parameters.AddWithValue("@transactionId", transactionId);

                        updateBudgetCmd.ExecuteNonQuery();
                        transaction.Commit();
                        return "Cập nhật giao dịch thành công";
                    }
                    else
                    {
                        transaction.Rollback();
                        return "Không thể cập nhật giao dịch";
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
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

        // Xóa giao dịch
        public string DeleteTransaction(int transactionId)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            try
            {
                // Bắt đầu transaction
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    // 1. Lấy thông tin giao dịch
                    string getQuery = "SELECT Amount, Type, BudgetId FROM Transactions WHERE Id = @transactionId";
                    SqlCommand getCmd = new SqlCommand(getQuery, conn, transaction);
                    getCmd.Parameters.AddWithValue("@transactionId", transactionId);
                    SqlDataReader reader = getCmd.ExecuteReader();
                    reader.Read();
                    decimal amount = (decimal)reader["Amount"];
                    string type = reader["Type"].ToString();
                    int budgetId = (int)reader["BudgetId"];
                    reader.Close();

                    // 2. Xóa giao dịch
                    string deleteQuery = "DELETE FROM Transactions WHERE Id = @transactionId";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn, transaction);
                    deleteCmd.Parameters.AddWithValue("@transactionId", transactionId);

                    int rowsAffected = deleteCmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // 3. Cập nhật số dư ví
                        string updateBudgetQuery = "UPDATE Budgets SET Amount = Amount - @amount, " +
                                                 "LastUpdatedDate = @lastUpdatedDate WHERE Id = @budgetId";
                        SqlCommand updateBudgetCmd = new SqlCommand(updateBudgetQuery, conn, transaction);
                        updateBudgetCmd.Parameters.AddWithValue("@amount", type == "INCOME" ? -amount : amount);
                        updateBudgetCmd.Parameters.AddWithValue("@lastUpdatedDate", DateTime.Now);
                        updateBudgetCmd.Parameters.AddWithValue("@budgetId", budgetId);

                        updateBudgetCmd.ExecuteNonQuery();
                        transaction.Commit();
                        return "Xóa giao dịch thành công";
                    }
                    else
                    {
                        transaction.Rollback();
                        return "Không thể xóa giao dịch";
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
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