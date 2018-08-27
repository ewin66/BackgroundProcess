using System;
using System.Data;
using System.Configuration;
using Oracle.DataAccess.Client;

namespace BackGroundServiceDemo
{
    internal class Oracle
    {
        static Oracle oracle;
        OracleConnection Conn;
        OracleTransaction Trans;

        private Oracle()
        {
            Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["PVMES"].ConnectionString);
        }
        public static Oracle GetOracle()
        {
            if (oracle == null)
            {
                oracle = new Oracle();
            }
            return oracle;
        }

        internal DataTable QueryData(string sql)
        {
            if (Conn == null)
            {
                return null;
            }
            try
            {
                Conn.Open();
                DataTable dt = new DataTable();
                OracleDataAdapter ada = new OracleDataAdapter(sql, Conn);
                ada.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "数据库操作异常");
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
    }
}
