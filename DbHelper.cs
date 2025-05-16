// DbHelper.cs
using System.Data;
using MySql.Data.MySqlClient;

namespace MAD_VENTANAS
{
    public static class DbHelper
    {
        private static readonly string ConnStr =
            "server=localhost;user id=root;password=3d99025;database=hoteles;SslMode=None;default command timeout=30;";

        public static DataTable ExecuteQuery(string sql, params MySqlParameter[] pars)
        {
            using (var conn = new MySqlConnection(ConnStr))
            {
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    if (pars != null)
                        cmd.Parameters.AddRange(pars);

                    using (var da = new MySqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public static int ExecuteNonQuery(string sql, params MySqlParameter[] pars)
        {
            using (var conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    if (pars != null)
                        cmd.Parameters.AddRange(pars);

                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
