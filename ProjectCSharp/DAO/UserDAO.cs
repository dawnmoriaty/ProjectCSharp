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
            MySqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string query = "SELECT PasswordHash,Status FROM Users WHERE UserName = @userName AND UserRole = @userRole";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userName", username);
                cmd.Parameters.AddWithValue("@userRole", userRole);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Kiểm tra trạng thái tài khoản
                        bool status = reader.GetBoolean("Status");
                        if (!status) // Nếu trạng thái là 0 (false)
                        {
                            MessageBox.Show("Tài khoản đã bị vô hiệu hóa. Không thể đăng nhập.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        // Xác minh mật khẩu
                        string storedHashedPassword = reader.GetString("PasswordHash");
                        return VerifyPassword(password, storedHashedPassword);
                    }
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
        public User Register(string username, string password, string fullName, string email, string userRole = "USER")
        {
            MySqlConnection conn = ConnectDB.GetConnection();
            try
            {
                // Kiểm tra xem username đã tồn tại chưa
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE UserName = @userName";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@userName", username);
                int userExists = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (userExists > 0)
                {
                    throw new Exception("Tên đăng nhập đã tồn tại");
                }

                // Kiểm tra xem email đã tồn tại chưa
                string checkEmailQuery = "SELECT COUNT(*) FROM Users WHERE Email = @email";
                MySqlCommand checkEmailCmd = new MySqlCommand(checkEmailQuery, conn);
                checkEmailCmd.Parameters.AddWithValue("@email", email);
                int emailExists = Convert.ToInt32(checkEmailCmd.ExecuteScalar());

                if (emailExists > 0)
                {
                    throw new Exception("Email đã được sử dụng");
                }

                // Mã hóa mật khẩu và thêm người dùng mới
                string hashedPassword = HashPassword(password);
                string insertQuery = "INSERT INTO Users (UserName, PasswordHash, FullName, Email, UserRole, Status) " +
                     "VALUES (@userName, @password, @fullName, @email, @userRole, @status)";
                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@userName", username);
                cmd.Parameters.AddWithValue("@password", hashedPassword);
                cmd.Parameters.AddWithValue("@fullName", fullName);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@userRole", userRole);
                cmd.Parameters.AddWithValue("@status", true);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    // Lấy thông tin user vừa đăng ký
                    return GetUserInfo(username);
                }
                else
                {
                    throw new Exception("Không thể chèn dữ liệu vào cơ sở dữ liệu");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi đăng ký: " + ex.Message);
            }
            finally
            {
                ConnectDB.CloseConnection(conn);
            }
        }
        // get infor
        public User GetUserInfo(string username)
        {
            MySqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string query = "SELECT Id, UserName, FullName, Email FROM Users WHERE UserName = @userName";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userName", username);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new User
                    {
                        Id = reader.GetInt32("Id"),
                        UserName = reader.GetString("UserName"),
                        FullName = reader.GetString("FullName"),
                        Email = reader.GetString("Email")
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
            MySqlConnection conn = ConnectDB.GetConnection();
            try
            {
                // Kiểm tra xem user có tồn tại và mật khẩu cũ có đúng không
                string queryCheck = "SELECT PasswordHash FROM Users WHERE UserName = @userName";
                MySqlCommand cmdCheck = new MySqlCommand(queryCheck, conn);
                cmdCheck.Parameters.AddWithValue("@userName", username);

                object result = cmdCheck.ExecuteScalar();
                if (result == null) return "Người dùng không tồn tại!";

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
                MySqlCommand cmdUpdate = new MySqlCommand(queryUpdate, conn);
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
            MySqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string query = "UPDATE Users SET FullName = @fullName, Email = @email WHERE UserName = @userName";
                MySqlCommand cmd = new MySqlCommand(query, conn);
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
            MySqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string query = "DELETE FROM Users WHERE UserName = @userName";
                MySqlCommand cmd = new MySqlCommand(query, conn);
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
            MySqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string query = "SELECT Id, UserName, FullName, Email, UserRole, Status FROM Users";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Id = reader.GetInt32("Id"),
                        UserName = reader.GetString("UserName"),
                        FullName = reader.GetString("FullName"),
                        Email = reader.GetString("Email"),
                        UserRole = reader.GetString("UserRole"),
                        Status = reader.GetBoolean("Status")
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
        //cap nhat trang thai
        public string UpdateUserStatus(int userId, bool status)
        {
            MySqlConnection conn = ConnectDB.GetConnection();
            try
            {
                string query = "UPDATE Users SET Status = @Status WHERE Id = @UserId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@Status", status);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0 ? "Success" : "Failed";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message); // Ghi nhật ký lỗi (nếu cần)
                return "Error";
            }
            finally
            {
                ConnectDB.CloseConnection(conn);
            }
        }

    }
}
