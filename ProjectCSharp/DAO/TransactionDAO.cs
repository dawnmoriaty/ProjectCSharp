using System;
using System.Collections.Generic;
using System.Data;
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
                                     "Description = @description WHERE TransactionId = @transactionId";

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
