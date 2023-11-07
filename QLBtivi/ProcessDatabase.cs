using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLBtivi
{
    class ProcessDatabase
    {
        string _sql = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Ki 1 nam 3\\Lap trinh truc quan\\BTL\\QLBtivi\\QLBtivi\\QLTiVi.mdf\";Integrated Security=True";
        SqlConnection conn;
        public void KetNoi()
        {
            conn = new SqlConnection(_sql);
            if (conn.State != ConnectionState.Open)

                conn.Open();

        }
        public void DongKetNoi()
        {
            if (conn.State != ConnectionState.Closed)
                conn.Close();
            conn.Dispose();
        }
        public DataTable DocBang(string sql)
        {
            DataTable tb = new DataTable();
            KetNoi();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(tb);
            DongKetNoi();
            return tb;
        }
        public void CapNhat(string sql)
        {
            SqlCommand sqlCommand = new SqlCommand();
            KetNoi();
            sqlCommand.CommandText = sql;
            sqlCommand.Connection = conn;
            sqlCommand.ExecuteNonQuery();
            DongKetNoi();
        }
    }
}
