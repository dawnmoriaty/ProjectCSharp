using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectCSharp.Model;
using ProjectCSharp.Utils;

namespace ProjectCSharp.DAO
{
    class BudgetDAO
    {
        public BudgetDAO() { }

        // Tạo ngân sách mới cho user
        public string CreateBudget(int userId, decimal amount, DateTime startDate, DateTime endDate)
        {
            MySqlConnection conn = ConnectDB.GetConnection();
            try
            {
                // Kiểm tra xem user đã có ngân sách chưa
                string checkQuery = "SELECT COUNT(*) FROM Budgets WHERE UserId = @userId";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@userId", userId);
                int budgetExists = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (budgetExists > 0)
                {
                    return "Người dùng đã có ngân sách";
                }

                string insertQuery = "INSERT INTO Budgets (UserId, Amount, StartDate, EndDate, CreatedDate) " +
                                   "VALUES (@userId, @budgetName, @amount, @currency, @startDate, @endDate, @createdDate)";
                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                cmd.Parameters.AddWithValue("@createdDate", DateTime.Now);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return "Tạo ngân sách thành công";
                }
                else
                {
                    return "Không thể tạo ngân sách";
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

        // Lấy thông tin ngân sách của user
        public Budget GetBudgetByUserId(int userId)
        {
            MySqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string query = "SELECT Id, UserId, Amount, StartDate, EndDate, CreatedDate, LastUpdatedDate " +
                             "FROM Budgets WHERE UserId = @userId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Budget
                    {
                        Id = reader.GetInt32("Id"),
                        UserId = reader.GetInt32("UserId"),
                        Amount = reader.GetDecimal("Amount"),
                        StartDate = reader.GetDateTime("StartDate"),
                        EndDate = reader.GetDateTime("EndDate"),
                        CreatedDate = reader.GetDateTime("CreatedDate"),
                        LastUpdatedDate = reader.IsDBNull(reader.GetOrdinal("LastUpdatedDate")) ? null : (DateTime?)reader.GetDateTime("LastUpdatedDate")
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                return null;
            }
            finally
            {
                ConnectDB.CloseConnection(conn);
            }
        }

        // Cập nhật số tiền ngân sách
        public string UpdateAmount(int budgetId, decimal newAmount)
        {
            MySqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string query = "UPDATE Budgets SET Amount = @amount, LastUpdatedDate = @lastUpdatedDate " +
                             "WHERE Id = @budgetId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@budgetId", budgetId);
                cmd.Parameters.AddWithValue("@amount", newAmount);
                cmd.Parameters.AddWithValue("@lastUpdatedDate", DateTime.Now);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return "Cập nhật ngân sách thành công";
                }
                else
                {
                    return "Không thể cập nhật ngân sách";
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

        // Lấy BudgetId của user dựa trên UserId
        public int? GetBudgetIdByUserId(int userId)
        {
            MySqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string query = "SELECT Id FROM Budgets WHERE UserId = @userId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
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
    }
}