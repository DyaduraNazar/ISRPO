using System.Data;
using System.Data.SqlClient;

namespace SkladApp
{
    internal class DataBase
    {
        private static SqlConnection connection = new SqlConnection(@"Data source=DESKTOP-33V95C9\SQLEXPRESS;Initial Catalog=supermarket;Integrated Security=True");
        private static SqlDataAdapter adapter = new SqlDataAdapter();

        public static void openConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public static void closeConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public static SqlConnection getConnection()
        {
            return connection;
        }

        public static DataTable executeQuery(string query)
        {
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand(query, connection);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        public static void executeNonQuery(string query)
        {
            SqlCommand command = new SqlCommand(query, connection);
            openConnection();
            command.ExecuteNonQuery();
            closeConnection();
        }

    }
}
