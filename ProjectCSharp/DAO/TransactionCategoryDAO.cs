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
        //===================================== Dang lam ==========================================
        //public string CreateCategory(string name, string description, string type, bool isDefault = false)
        //{
        //    MySqlConnection conn = ConnectDB.GetConnection();
        //    try
        //    {
        //        string insertQuery = "INSERT INTO TransactionCategories (Name, Description, Type, IsDefault, CreatedDate) " +
        //                           "VALUES (@name, @description, @type, @isDefault, @createdDate)";
        //        MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
        //        cmd.Parameters.AddWithValue("@name", name);
        //        cmd.Parameters.AddWithValue("@description", description);
        //        cmd.Parameters.AddWithValue("@type", type);
        //        cmd.Parameters.AddWithValue("@createdDate", DateTime.Now);

        //        int rowsAffected = cmd.ExecuteNonQuery();
        //        if (rowsAffected > 0)
        //        {
        //            return "Tạo danh mục thành công";
        //        }
        //        else
        //        {
        //            return "Không thể tạo danh mục";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return "Lỗi: " + ex.Message;
        //    }
        //    finally
        //    {
        //        ConnectDB.CloseConnection(conn);
        //    }
        //}

        //// Lấy tất cả categories theo loại (INCOME/EXPENSE)
        //public List<TransactionCategory> GetCategoriesByType(string type)
        //{
        //    List<TransactionCategory> categories = new List<TransactionCategory>();
        //    MySqlConnection conn = ConnectDB.GetConnection();
        //    try
        //    {
        //        string query = "SELECT Id, Name, Description, Type, IsDefault, CreatedDate " +
        //                     "FROM TransactionCategories WHERE Type = @type ORDER BY Name";
        //        MySqlCommand cmd = new MySqlCommand(query, conn);
        //        cmd.Parameters.AddWithValue("@type", type);
        //        MySqlDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            categories.Add(new TransactionCategory
        //            {
        //                Id = reader.GetInt32("Id"),
        //                Name = reader.GetString("Name"),
        //                Description = reader.GetString("Description"),
        //                Type = reader.GetString("Type"),
        //                CreatedDate = reader.GetDateTime("CreatedDate")
        //            });
        //        }
        //        return categories;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null;
        //    }
        //    finally
        //    {
        //        ConnectDB.CloseConnection(conn);
        //    }
        //}

        //// Lấy category theo ID
        //public TransactionCategory GetCategoryById(int id)
        //{
        //    MySqlConnection conn = ConnectDB.GetConnection();
        //    try
        //    {
        //        string query = "SELECT Id, Name, Description, Type, IsDefault, CreatedDate " +
        //                     "FROM TransactionCategories WHERE Id = @id";
        //        MySqlCommand cmd = new MySqlCommand(query, conn);
        //        cmd.Parameters.AddWithValue("@id", id);
        //        MySqlDataReader reader = cmd.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            return new TransactionCategory
        //            {
        //                Id = reader.GetInt32("Id"),
        //                Name = reader.GetString("Name"),
        //                Description = reader.GetString("Description"),
        //                Type = reader.GetString("Type"),
        //                IsDefault = reader.GetBoolean("IsDefault"),
        //                CreatedDate = reader.GetDateTime("CreatedDate")
        //            };
        //        }
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null;
        //    }
        //    finally
        //    {
        //        ConnectDB.CloseConnection(conn);
        //    }
        //}

        //// Cập nhật category
        //public string UpdateCategory(int id, string name, string description)
        //{
        //    MySqlConnection conn = ConnectDB.GetConnection();
        //    try
        //    {
        //        string query = "UPDATE TransactionCategories SET Name = @name, Description = @description " +
        //                     "WHERE Id = @id";
        //        MySqlCommand cmd = new MySqlCommand(query, conn);
        //        cmd.Parameters.AddWithValue("@id", id);
        //        cmd.Parameters.AddWithValue("@name", name);
        //        cmd.Parameters.AddWithValue("@description", description);

        //        int rowsAffected = cmd.ExecuteNonQuery();
        //        if (rowsAffected > 0)
        //        {
        //            return "Cập nhật danh mục thành công";
        //        }
        //        else
        //        {
        //            return "Không thể cập nhật danh mục";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return "Lỗi: " + ex.Message;
        //    }
        //    finally
        //    {
        //        ConnectDB.CloseConnection(conn);
        //    }
        //}

        //// Xóa category
        //public string DeleteCategory(int id)
        //{
        //    MySqlConnection conn = ConnectDB.GetConnection();
        //    try
        //    {
        //        // Kiểm tra xem category có phải là mặc định không
        //        string checkQuery = "SELECT IsDefault FROM TransactionCategories WHERE Id = @id";
        //        MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
        //        checkCmd.Parameters.AddWithValue("@id", id);
        //        bool isDefault = Convert.ToBoolean(checkCmd.ExecuteScalar());

        //        if (isDefault)
        //        {
        //            return "Không thể xóa danh mục mặc định";
        //        }

        //        string query = "DELETE FROM TransactionCategories WHERE Id = @id";
        //        MySqlCommand cmd = new MySqlCommand(query, conn);
        //        cmd.Parameters.AddWithValue("@id", id);

        //        int rowsAffected = cmd.ExecuteNonQuery();
        //        if (rowsAffected > 0)
        //        {
        //            return "Xóa danh mục thành công";
        //        }
        //        else
        //        {
        //            return "Không thể xóa danh mục";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return "Lỗi: " + ex.Message;
        //    }
        //    finally
        //    {
        //        ConnectDB.CloseConnection(conn);
        //    }
        //}

        //// Lấy tất cả categories
        //public List<TransactionCategory> GetAllCategories()
        //{
        //    List<TransactionCategory> categories = new List<TransactionCategory>();
        //    MySqlConnection conn = ConnectDB.GetConnection();
        //    try
        //    {
        //        string query = "SELECT Id, Name, Description, Type, IsDefault, CreatedDate " +
        //                      "FROM TransactionCategories ORDER BY Name";
        //        MySqlCommand cmd = new MySqlCommand(query, conn);
        //        MySqlDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            categories.Add(new TransactionCategory
        //            {
        //                Id = reader.GetInt32("Id"),
        //                Name = reader.GetString("Name"),
        //                Description = reader.GetString("Description"),
        //                Type = reader.GetString("Type"),
        //                IsDefault = reader.GetBoolean("IsDefault"),
        //                CreatedDate = reader.GetDateTime("CreatedDate")
        //            });
        //        }
        //        return categories;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null;
        //    }
        //    finally
        //    {
        //        ConnectDB.CloseConnection(conn);
        //    }
        //}
    }
}