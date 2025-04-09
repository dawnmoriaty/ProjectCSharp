using System;
using System.Collections.Generic;
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

        public bool CreateTransaction(Transaction transaction)
        {
            MySqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string insertQuery = "INSERT INTO Transactions (Amount, CategoryId, BudgetId, Type, TransactionDate, Description, UserId) " +
                                     "VALUES (@amount, @categoryId, @budgetId, @type, @transactionDate, @description, @userId)";
                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@amount", transaction.Amount);
                cmd.Parameters.AddWithValue("@categoryId", transaction.CategoryId);
                cmd.Parameters.AddWithValue("@budgetId", transaction.BudgetId);
                cmd.Parameters.AddWithValue("@transactionDate", transaction.TransactionDate);
                cmd.Parameters.AddWithValue("@description", transaction.Description);
                cmd.Parameters.AddWithValue("@userId", transaction.UserId);

                conn.Open();
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
