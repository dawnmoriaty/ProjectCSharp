using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectCSharp.Model;
using ProjectCSharp.Utils;
using System.Data;

namespace ProjectCSharp.DAO
{
    class TransactionCategoryDAO
    {
        public TransactionCategoryDAO() { }
        //===================================== Dang lam ==========================================
        public string CreateCategory(int userId, string name, string description, string type)
        {
            MySqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string insertQuery = "INSERT INTO TransactionCategories (UserId, Name, Description, Type, CreatedDate) " +
                                     "VALUES (@userId, @name, @description, @type, @createdDate)";
                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@userId", userId); 
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@createdDate", DateTime.Now);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0 ? "Tạo danh mục thành công" : "Không thể tạo danh mục";
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
        public List<TransactionCategory> GetCategoriesByUserId(int userId)
        {
            List<TransactionCategory> categories = new List<TransactionCategory>();
            MySqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string query = "SELECT * FROM TransactionCategories WHERE UserId = @userId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TransactionCategory category = new TransactionCategory
                    {
                        Id = reader.GetInt32("Id"),
                        Name = reader.GetString("Name"),
                        Description = reader.GetString("Description"),
                        Type = reader.GetString("Type"),
                        CreatedDate = reader.GetDateTime("CreatedDate")
                    };
                    categories.Add(category); // Thêm đối tượng vào danh sách
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                ConnectDB.CloseConnection(conn);
            }
            return categories; // Trả về danh sách các đối tượng TransactionCategory
        }
        public List<Tuple<int, string>> GetCategoryNames(int userId)
        {
            List<Tuple<int, string>> categoryNames = new List<Tuple<int, string>>();
            MySqlConnection conn = ConnectDB.GetConnection();
            try
            {
                // Sửa câu truy vấn để không lọc theo Type
                string selectQuery = "SELECT Id, Name FROM TransactionCategories WHERE UserId = @userId";
                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("Id"); // Lấy Id
                        string name = reader.GetString("Name"); // Lấy Name
                        categoryNames.Add(new Tuple<int, string>(id, name));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConnectDB.CloseConnection(conn);
            }
            return categoryNames;
        }

        public string UpdateCategory(int userId, int id, string name, string description, string type)
        {
            MySqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string updateQuery = "UPDATE TransactionCategories SET Name = @name, Description = @description, Type = @type " +
                                     "WHERE Id = @id AND UserId = @userId"; // Thêm điều kiện UserId
                MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@userId", userId); // Thêm tham số userId
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@type", type);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0 ? "Cập nhật danh mục thành công" : "Không thể cập nhật danh mục";
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
        public string DeleteCategory(int userId, int id)
        {
            MySqlConnection conn = ConnectDB.GetConnection();
            try
            {
                // Xóa các khoản thu chi liên quan đến danh mục
                string deleteTransactionsQuery = "DELETE FROM Transactions WHERE CategoryId = @id AND UserId = @userId";
                MySqlCommand deleteTransactionsCmd = new MySqlCommand(deleteTransactionsQuery, conn);
                deleteTransactionsCmd.Parameters.AddWithValue("@id", id);
                deleteTransactionsCmd.Parameters.AddWithValue("@userId", userId);
                deleteTransactionsCmd.ExecuteNonQuery(); // Xóa các khoản thu chi liên quan

                // Xóa danh mục
                string deleteCategoryQuery = "DELETE FROM TransactionCategories WHERE Id = @id AND UserId = @userId";
                MySqlCommand deleteCategoryCmd = new MySqlCommand(deleteCategoryQuery, conn);
                deleteCategoryCmd.Parameters.AddWithValue("@id", id);
                deleteCategoryCmd.Parameters.AddWithValue("@userId", userId);

                int rowsAffected = deleteCategoryCmd.ExecuteNonQuery();
                return rowsAffected > 0 ? "Xóa danh mục thành công" : "Không thể xóa danh mục";
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
        public List<Tuple<int, string>> GetCategoryNames(int userId, string type)
        {
            List<Tuple<int, string>> categoryNames = new List<Tuple<int, string>>();
            MySqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string selectQuery = "SELECT Id, Name FROM TransactionCategories WHERE UserId = @userId AND Type = @type";
                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@type", type);

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]); 
                    string name = reader["Name"].ToString(); 
                    categoryNames.Add(new Tuple<int, string>(id, name));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                ConnectDB.CloseConnection(conn);
            }
            return categoryNames;
        }
        //===================================== Dang lam ==========================================

    }
}