using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCSharp.Utils
{
    class ConnectDB
    {
        private static readonly string connectionString = "Data Source=DESKTOP-P2D30BR\\SQLEXPRESS;Initial Catalog=PersonalFinanceApp;Integrated Security=True;TrustServerCertificate=True";
        // Mở kết nối
        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                Console.WriteLine("Kết nối thành công!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi kết nối CSDL: " + ex.Message);
            }
            return conn;
        }
        // Đóng kết nối
        public static void CloseConnection(SqlConnection conn)
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    conn.Close();
                    Console.WriteLine("Đóng kết nối thành công!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi đóng kết nối: " + ex.Message);
                }
            }
        }
    }
}
