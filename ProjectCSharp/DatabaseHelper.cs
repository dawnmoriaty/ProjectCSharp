using System;
using System.Data;
using System.Data.SqlClient;

namespace ProjectCSharp
{
    public static class DatabaseHelper
    {
        private static string connectionString = "Data Source=LAPTOP-S1S1TFI1\\SQLEXPRESS;Initial Catalog=PersonalFinanceApp;Integrated Security=True";

        public static DataTable GetIncomeCategories()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM IncomeCategory";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public static DataTable GetExpenseCategories()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ExpenseCategory";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }
    }
}
