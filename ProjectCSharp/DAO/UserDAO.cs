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
    class UserDAO
    {
        public UserDAO() { }
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        private bool VerifyPassword(string enteredPassword, string storedPasswordHash)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedPasswordHash);
        }
        // login
        public bool CheckLogin(string username, string password, string userRole)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string query = "SELECT PasswordHash FROM Users WHERE UserName = @userName AND UserRole = @userRole";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userName", username);
                cmd.Parameters.AddWithValue("@userRole", userRole);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    string storedHashedPassword = result.ToString();
                    return VerifyPassword(password, storedHashedPassword);
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                ConnectDB.CloseConnection(conn);
            }
        }
        //register
        public string Register(string username, string password, string fullName, string email, string userRole = "USER")
        {
            SqlConnection conn = ConnectDB.GetConnection();
            try
            {
                // Kiểm tra xem username đã tồn tại chưa
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE UserName = @userName";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@userName", username);
                int userExists = (int)checkCmd.ExecuteScalar();

                if (userExists > 0)
                {
                    return "Tên đăng nhập đã tồn tại";
                }

                // Kiểm tra xem email đã tồn tại chưa (tùy chọn, nếu cần)
                string checkEmailQuery = "SELECT COUNT(*) FROM Users WHERE Email = @email";
                SqlCommand checkEmailCmd = new SqlCommand(checkEmailQuery, conn);
                checkEmailCmd.Parameters.AddWithValue("@email", email);
                int emailExists = (int)checkEmailCmd.ExecuteScalar();

                if (emailExists > 0)
                {
                    return "Email đã được sử dụng";
                }

                // Mã hóa mật khẩu và thêm người dùng mới
                string hashedPassword = HashPassword(password);
                string insertQuery = "INSERT INTO Users (UserName, PasswordHash, FullName, Email, UserRole) " +
                                   "VALUES (@userName, @password, @fullName, @email, @userRole)";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@userName", username);
                cmd.Parameters.AddWithValue("@password", hashedPassword);
                cmd.Parameters.AddWithValue("@fullName", fullName);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@userRole", userRole);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return "Đăng ký thành công";
                }
                else
                {
                    return "Không thể chèn dữ liệu vào cơ sở dữ liệu";
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
        // get infor
        public User GetUserInfo(string username)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string query = "SELECT UserId,UserName ,FullName, Email FROM Users WHERE UserName = @userName";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userName", username);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new User
                    {
                        Id = (int)reader["UserId"],
                        UserName = reader["UserName"].ToString(),
                        FullName = reader["FullName"].ToString(),
                        Email = reader["Email"].ToString()
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
        // change password
        public string ChangePassword(string username, string oldPassword, string newPassword)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            try
            {
                // Kiểm tra xem user có tồn tại và mật khẩu cũ có đúng không
                string queryCheck = "SELECT PasswordHash FROM Users WHERE UserName = @userName";
                SqlCommand cmdCheck = new SqlCommand(queryCheck, conn);
                cmdCheck.Parameters.AddWithValue("@userName", username);

                object result = cmdCheck.ExecuteScalar();

                string storedHashedPassword = result.ToString();

                // Kiểm tra mật khẩu cũ
                if (!BCrypt.Net.BCrypt.Verify(oldPassword, storedHashedPassword))
                {
                    return "Mật khẩu cũ không chính xác!";
                }

                // Mã hóa mật khẩu mới
                string hashedNewPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);

                // Cập nhật mật khẩu mới
                string queryUpdate = "UPDATE Users SET PasswordHash = @newPassword WHERE UserName = @userName";
                SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conn);
                cmdUpdate.Parameters.AddWithValue("@newPassword", hashedNewPassword);
                cmdUpdate.Parameters.AddWithValue("@userName", username);

                int rowsAffected = cmdUpdate.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return "Đổi mật khẩu thành công!";
                }
                else
                {
                    return "Không thể cập nhật mật khẩu!";
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
        // update infor
        public string UpdateUserInfo(string username, string fullName, string email)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string query = "UPDATE Users SET FullName = @fullName, Email = @email WHERE UserName = @userName";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@fullName", fullName);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@userName", username);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return "Cập nhật thông tin thành công!";
                }
                else
                {
                    return "Không thể cập nhật thông tin!";
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
        //delete users
        public string DeleteUser(string username)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string query = "DELETE FROM Users WHERE UserName = @userName";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userName", username);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return "Xóa người dùng thành công!";
                }
                else
                {
                    return "Không thể xóa người dùng!";
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
        // get all by admin
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            SqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string query = "SELECT Id, UserName, FullName, Email, UserRole FROM Users";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Id = (int)reader["Id"],
                        UserName = reader["UserName"].ToString(),
                        FullName = reader["FullName"].ToString(),
                        Email = reader["Email"].ToString(),
                        UserRole = reader["UserRole"].ToString()
                    });
                }
                return users;
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
        // disable user


    }
}
