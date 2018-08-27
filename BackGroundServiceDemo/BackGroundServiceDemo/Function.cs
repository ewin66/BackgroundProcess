using System;
using System.Data;


namespace BackGroundServiceDemo
{
    internal class Function
    {
        internal static void CheckAmProduct()
        {
            Oracle oracle = Oracle.GetOracle();
            string sql = "select am_product from T_OEE_DAY_PLAN_RECORD_OLD t where t.id='111'";
            DataTable dt = oracle.QueryData(sql);
            string am_product = dt.Rows[0][0].ToString();
            Log.WriteLog("Am_Product", "Write Successful:" + am_product, "获取值");
        }
    }
}
