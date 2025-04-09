using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ProjectCSharp.Model;
using ProjectCSharp.Utils;

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
    }
}
