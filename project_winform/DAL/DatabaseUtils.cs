using System.Data.SqlClient;
using System.Windows.Forms;

namespace project_winform.DAL
{
    class DatabaseUtils
    {
       
        public static string strConnect = "Data Source=.;Initial Catalog=QLSieuThi_;Integrated Security=True";
        public static SqlConnection connectDB = new SqlConnection();
        //$"Server={DatabaseConfig.Host};" +
        //$"Database={DatabaseConfig.Database};" +
        //$"Port={DatabaseConfig.Port};" +
        //$"User Id={DatabaseConfig.Username};" +
        //$"Password={DatabaseConfig.Password}";

        public static bool DatabaseUtilsConnect()
        {
            try
            {
                connectDB.ConnectionString = strConnect;
                connectDB.Open();
                return true;
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.ToString());
            }
            return false;
        }
    }
}
