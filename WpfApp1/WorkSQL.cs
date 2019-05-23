using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    static class WorkSQL
    {
        /// <summary>
        /// Взаимодействие с PostgreSQL сервером
        /// </summary>
        private static NpgsqlConnection npgSqlCon = null;
        internal static NpgsqlConnection npgSqlCon_p
        {
            get { return npgSqlCon; }
            set { npgSqlCon = value; }
        }

        private static NpgsqlCommand npgSqlCom = null;
        internal static NpgsqlCommand npgSqlCom_p
        {
            get { return npgSqlCom; }
            set { npgSqlCom = value; }
        }

        /// <summary>
        /// Строка запроса
        /// </summary>
        private static string sql = null;
        internal static string sql_p
        {
            get { return sql; }
            set { sql = value; }
        }

        /// <summary>
        /// Роль того,кто зашёл в систему
        /// </summary>
        private static string role = null;
        internal static string role_p
        {
            get { return role; }
            set { role = value; }
        }

        /// <summary>
        /// Логин того,кто зашёл в систему
        /// </summary>
        private static string login = null;
        internal static string login_p
        {
            get { return login; }
            set { login = value; }
        }

        private static DataRowView drv = null;
        internal static DataRowView drv_p
        {
            get { return drv; }
            set { drv = value; }
        }

        private static string first_date = null;
        internal static string first_date_p
        {
            get { return first_date; }
            set { first_date = value; }
        }

        private static string second_date = null;
        internal static string second_date_p
        {
            get { return second_date; }
            set { second_date = value; }
        }

        internal static DataTable ConvertQueryToTable()
        {
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql_p, npgSqlCon_p);
            //ds.Reset();
            //da.Fill(ds);
            da.Fill(dt);

            //dt = ds.Tables[0];
            return dt;

            //npgSqlCon.Close();
        }

        internal static List<string> ConvertQueryToComboBox()
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql_p, npgSqlCon_p);
            da.Fill(dt);
            List<string> temp = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                temp.Add(dt.Rows[i].ItemArray[0].ToString());
            }
            return temp;
        }

        internal static void ExecuteSQL()
        {
            npgSqlCom_p = new NpgsqlCommand(sql_p, npgSqlCon_p);
            npgSqlCom.ExecuteNonQuery();
        }
    }
}
