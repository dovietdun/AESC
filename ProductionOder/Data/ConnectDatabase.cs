using System.Data;
using Microsoft.Data.SqlClient;

namespace ProductionOrder.Data
{
    public class ConnectDatabase
    {
        public static string strConnect = ConfigurationManager.AppSetting.GetConnectionString("LocalConnectionString");

        public ConnectDatabase()
        {
        }


        public static DataTable? FindData(string sql)
        {
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                using (SqlDataAdapter dap = new SqlDataAdapter(sql, conn))
                {
                    using (DataSet ds = new DataSet())
                    {
                        dap.SelectCommand.CommandTimeout = 30000;
                        dap.Fill(ds);
                        conn.Close();
                        conn.Dispose();
                        return ds.Tables[0];
                    }
                }
            }

        }
        public static int Execute(string sql)
        {
            SqlConnection conn = new SqlConnection(strConnect);
            SqlCommand cmd = new SqlCommand(sql, conn);
            int row = 0;
            conn.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            //row = cmd.ExecuteNonQuery();

            object o = cmd.ExecuteScalar();
            if (o != null)
            {
                row = Convert.ToInt32(o.ToString());
            }

            conn.Close();
            conn.Dispose();
            return row;
        }
        public static int ExecuteStore(string store_name, string[] param_type, params object[] obj)
        {
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                int row = 0;
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(store_name, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p;
                for (int i = 0; i < param_type.Length; i++)
                {
                    p = new SqlParameter(param_type[i], obj[i]);
                    cmd.Parameters.Add(p);
                }
                //return cmd.ExecuteNonQuery();
                object o = cmd.ExecuteScalar();
                if (o != null)
                {
                    row = Convert.ToInt32(o.ToString());
                }

                conn.Close();
                return row;
            }

        }

        public static DataTable FindDataStore(string store_name, params object[] obj)
        {
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(store_name, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cmd);
                for (int i = 1; i <= obj.Length; i++)
                {
                    cmd.Parameters[i].Value = obj[i - 1];
                }
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                //cmd.ExecuteNonQuery();
                dap.Fill(ds);
                conn.Dispose();
                conn.Close();
                return ds.Tables[0];
            }
        }
    }
}

