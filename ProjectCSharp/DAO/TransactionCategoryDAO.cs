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
    class TransactionCategoryDAO
    {
        public TransactionCategoryDAO() { }

        // Tạo category mới
        public string CreateCategory(string name, string description, string type, string icon, bool isDefault = false)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string insertQuery = "INSERT INTO TransactionCategories (Name, Description, Type, Icon, IsDefault, CreatedDate) " +
                                   "VALUES (@name, @description, @type, @icon, @isDefault, @createdDate)";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@icon", icon);
                cmd.Parameters.AddWithValue("@isDefault", isDefault);
                cmd.Parameters.AddWithValue("@createdDate", DateTime.Now);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return "Tạo danh mục thành công";
                }
                else
                {
                    return "Không thể tạo danh mục";
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

        // Lấy tất cả categories theo loại (INCOME/EXPENSE)
        public List<TransactionCategory> GetCategoriesByType(string type)
        {
            List<TransactionCategory> categories = new List<TransactionCategory>();
            SqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string query = "SELECT Id, Name, Description, Type, Icon, IsDefault, CreatedDate " +
                             "FROM TransactionCategories WHERE Type = @type ORDER BY Name";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@type", type);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    categories.Add(new TransactionCategory
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString(),
                        Type = reader["Type"].ToString(),
                        Icon = reader["Icon"].ToString(),
                        IsDefault = (bool)reader["IsDefault"],
                        CreatedDate = (DateTime)reader["CreatedDate"]
                    });
                }
                return categories;
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

        // Lấy category theo ID
        public TransactionCategory GetCategoryById(int id)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string query = "SELECT Id, Name, Description, Type, Icon, IsDefault, CreatedDate " +
                             "FROM TransactionCategories WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new TransactionCategory
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString(),
                        Type = reader["Type"].ToString(),
                        Icon = reader["Icon"].ToString(),
                        IsDefault = (bool)reader["IsDefault"],
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

        // Cập nhật category
        public string UpdateCategory(int id, string name, string description, string icon)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string query = "UPDATE TransactionCategories SET Name = @name, Description = @description, " +
                             "Icon = @icon WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@icon", icon);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return "Cập nhật danh mục thành công";
                }
                else
                {
                    return "Không thể cập nhật danh mục";
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

        // Xóa category
        public string DeleteCategory(int id)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            try
            {
                // Kiểm tra xem category có phải là mặc định không
                string checkQuery = "SELECT IsDefault FROM TransactionCategories WHERE Id = @id";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@id", id);
                bool isDefault = (bool)checkCmd.ExecuteScalar();

                if (isDefault)
                {
                    return "Không thể xóa danh mục mặc định";
                }

                string query = "DELETE FROM TransactionCategories WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return "Xóa danh mục thành công";
                }
                else
                {
                    return "Không thể xóa danh mục";
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